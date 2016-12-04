--1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and 
--Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. Write a stored 
--procedure that selects the full names of all persons.

CREATE DATABASE Bank
GO

USE Bank
GO

CREATE Table Persons
(
[PersonsID] int NOT NULL IDENTITY,
[FirstName] nvarchar(50), 
[LastName] nvarchar(50), 
[SSN] nvarchar(50),
CONSTRAINT PK_Persons PRIMARY KEY ([PersonsID])
)
GO

CREATE Table Accounts
(
[AccountsID] int NOT NULL IDENTITY,
[PersonsID] int NOT NULL, 
[Balance] money,
CONSTRAINT PK_Accounts PRIMARY KEY ([AccountsID]),
CONSTRAINT FK_Persons_Accounts FOREIGN KEY([PersonsID])
	REFERENCES Persons([PersonsID])
)
GO

INSERT INTO Persons ([FirstName], [LastName], [SSN])
VALUES ('Peter', 'Johnson', 345909)
INSERT INTO Persons ([FirstName], [LastName], [SSN])
VALUES ('Molly', 'Nickson', 456728)
INSERT INTO Persons ([FirstName], [LastName], [SSN])
VALUES ('James', 'Arthur', 986213)
GO

INSERT INTO Accounts ([PersonsID], [Balance])
VALUES (1, 1000)
INSERT INTO Accounts ([PersonsID], [Balance])
VALUES (2, 500)
INSERT INTO Accounts ([PersonsID], [Balance])
VALUES (3, 2000)
GO

CREATE PROC usp_SelectFullName
AS
	SELECT FirstName + ' ' + LastName AS FullName
	FROM Persons
GO

EXEC usp_SelectFullName
GO

--2. Create a stored procedure that accepts a number as a parameter and returns all persons 
--who have more money in their accounts than the supplied number.
USE Bank
GO

CREATE PROC usp_SelectPeopleWithMoreMoney(@minMoney money)
AS
	SELECT p.PersonsID, p.FirstName, p.LastName, a.Balance
	FROM Persons p
		INNER JOIN Accounts a
		ON p.PersonsID = a.AccountsID
	WHERE a.Balance > @minMoney
GO

EXEC usp_SelectPeopleWithMoreMoney 999
GO

--3. Create a function that accepts as parameters – sum, yearly interest rate and number 
--of months. It should calculate and return the new sum. Write a SELECT to test whether 
--the function works as expected.

USE Bank
GO

CREATE FUNCTION ufn_CalculateInterest(@sum money, @interestRate money, @numberOfMonths real)
  RETURNS money
AS
	BEGIN
	DECLARE @interest money
	DECLARE @newSum money

	SET @interest = ((@numberOfMonths / 12) * @interestRate) / 100
	SET @newSum = @sum + @sum * @interest

	RETURN @newSum
	END
GO

SELECT dbo.ufn_CalculateInterest(100, 6.65, 36) AS NewSum
GO

--4. Create a stored procedure that uses the function from the previous example to give an 
--interest to a person's account for one month. It should take the AccountId and the 
--interest rate as parameters.

USE Bank
GO

CREATE PROC usp_OneMonthInterest(@accountID int, @interestRate real)
AS
	UPDATE Bank.dbo.Accounts
	SET Balance = dbo.ufn_CalculateInterest(Balance, @interestRate, 1)
	WHERE AccountsID = @accountID
GO

EXEC dbo.usp_OneMonthInterest 1, 5.45
GO

--5. Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney 
--(AccountId, money) that operate in transactions.
USE Bank
GO

CREATE PROC usp_WithdrawMoney(@accountID int, @money money)
AS
	BEGIN TRAN
	DECLARE @CurrentBalance money
	
	SELECT @CurrentBalance = Balance
	FROM Bank.dbo.Accounts
	WHERE AccountsID = @accountID

	IF @CurrentBalance >= @money
		BEGIN
			DECLARE @NewBalance money
			SET @NewBalance = @CurrentBalance - @money

			UPDATE Bank.dbo.Accounts
			SET Balance = @NewBalance
			WHERE AccountsID = @accountID
			COMMIT
		END
	ELSE
		BEGIN
			ROLLBACK TRAN
			RAISERROR('Not enough money in account', 16, 1)
		END
GO

EXEC dbo.usp_WithdrawMoney 1, 200
GO

--Test when not enough money in account
EXEC dbo.usp_WithdrawMoney 1, 20000
GO

CREATE PROC usp_DepositMoney(@accountID int, @money money)
AS
	BEGIN TRAN

	IF EXISTS (SELECT AccountsID FROM Bank.dbo.Accounts 
				WHERE AccountsID = @accountID)
		BEGIN
			DECLARE @CurrentBalance money
			DECLARE @NewBalance money

			SELECT @CurrentBalance = Balance
			FROM Bank.dbo.Accounts
			WHERE AccountsID = @accountID
			
			SET @NewBalance = @CurrentBalance + @money

			UPDATE Bank.dbo.Accounts
			SET Balance = @NewBalance
			WHERE AccountsID = @accountID
			COMMIT
		END
	ELSE
		BEGIN
			ROLLBACK TRAN
			RAISERROR('No such account', 16, 1)
		END
GO

EXEC dbo.usp_DepositMoney 1, 300
GO

--Test with non existing AccountID
EXEC dbo.usp_DepositMoney 1000, 300
GO

--6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). Add a trigger to the 
--Accounts table that enters a new entry into the Logs table every time the sum on an account 
--changes.

USE Bank
GO

CREATE Table Logs
(
[LogID] int NOT NULL IDENTITY,
[AccountsID] int, 
[OldSum] money, 
[NewSum] money,
CONSTRAINT PK_Logs PRIMARY KEY ([LogID])
)
GO

CREATE TRIGGER tr_BalanceUpdate ON Accounts
FOR UPDATE 
AS
INSERT INTO Logs ([AccountsID], [OldSum], [NewSum])
	SELECT a.AccountsID, a.Balance, i.Balance
	FROM Accounts a 
		INNER JOIN inserted i 
			ON a.AccountsID = i.AccountsID
GO

--7. Define a function in the database TelerikAcademy that returns all Employee's names 
--(first or middle or last name) and all town's names that are comprised of given set of 
--letters. Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.

USE TelerikAcademy
GO

CREATE FUNCTION ufn_CheckIfHasLetters (@wordToCheck nvarchar(20), @lettersSet nvarchar(20))
RETURNS BIT
AS
BEGIN
	DECLARE @lettersSetLen int = LEN(@lettersSet)
	DECLARE @currentIndex int = 1
	DECLARE @matches int = 0
	DECLARE @currentChar nvarchar(1)

	SET @wordToCheck = LOWER(@wordToCheck)
	SET @lettersSet = LOWER(@lettersSet)

	WHILE(@currentIndex <= @lettersSetLen)
	BEGIN
		SET @currentChar = SUBSTRING(@wordToCheck, @currentindex, 1)
		IF(CHARINDEX(@currentChar, @lettersSet, 0) > 0)
			BEGIN
				SET @matches += 1
				SET @currentindex = @currentindex + 1
			END
		ELSE
			BREAK
	END

	IF(@matches = LEN(@wordToCheck) OR @matches = LEN(@lettersSet))
		BEGIN
			RETURN 1
		END

	RETURN 0
END

GO

CREATE FUNCTION ufn_GetNamesAndTowns(@lettersSet nvarchar(20))
  RETURNS @reulstTable TABLE 
  (
  [Name] nvarchar(50)
  )
AS
BEGIN

INSERT INTO @reulstTable
SELECT FirstName 
FROM Employees
WHERE dbo.ufn_CheckIfHasLetters(FirstName, @lettersSet) = 1

--INSERT INTO @reulstTable
--SELECT MiddleName 
--FROM Employees
--WHERE dbo.ufn_CheckIfHasLetters(MiddleName, @lettersSet) = 1

INSERT INTO @reulstTable
SELECT LastName 
FROM Employees
WHERE dbo.ufn_CheckIfHasLetters(LastName, @lettersSet) = 1

INSERT INTO @reulstTable
SELECT t.Name 
FROM Towns t
WHERE dbo.ufn_CheckIfHasLetters(t.Name, @lettersSet) = 1

RETURN
END

GO

SELECT * FROM dbo.ufn_GetNamesAndTowns('oistmiahf')
GO

--8. Using database cursor write a T-SQL script that scans all employees and their 
--addresses and prints all pairs of employees that live in the same town.

USE TelerikAcademy
GO

DECLARE empCursor CURSOR READ_ONLY FOR
SELECT EmployeeID, FirstName + ' ' + LastName AS EmployeeName, t.Name AS Town
FROM Employees e 
	INNER JOIN Addresses a 
		ON e.AddressID = a.AddressID
	INNER JOIN Towns t 
		ON a.TownID = t.TownID 

OPEN empCursor

DECLARE @employeeID int, 
		@employeeName varchar(150), 
		@townID int,  
		@townName varchar(50)

FETCH NEXT FROM empCursor 
INTO @employeeID, @employeeName, @townID, @townName

CREATE TABLE #TempEmployeeFromSameTownPairs (FirstEmployeeName varchar(150), SecondEmployeeName varchar(150), TownName varchar(50))
WHILE (@@FETCH_STATUS = 0)
  BEGIN	
	INSERT INTO #TempEmployeeFromSameTownPairs (FirstEmployeeName, SecondEmployeeName, TownName)
	SELECT @employeeName, FirstName + ' ' + LastName AS EmployeeName, @townName AS Town
	FROM Employees e 
		INNER JOIN Addresses a 
			ON e.AddressID = a.AddressID
		INNER JOIN Towns t 
			ON a.TownID = t.TownID 
	WHERE a.TownID = @townID AND e.EmployeeID <> @employeeID

    FETCH NEXT FROM empCursor 
	INTO @employeeID, @employeeName, @townID, @townName           
  END
CLOSE empCursor
DEALLOCATE empCursor

--Test it below:
SELECT TownName, FirstEmployeeName, SecondEmployeeName FROM #TempEmployeeFromSameTownPairs
ORDER BY TownName, FirstEmployeeName, SecondEmployeeName
DROP TABLE #TempEmployeeFromSameTownPairs

GO

--9. Write a T-SQL script that shows for each town a list of all employees that live in it. 
USE TelerikAcademy
GO

SELECT Name, t2.Count,
    (SELECT FirstName + ' ' + LastName + ', ' AS [text()]
        FROM Employees AS e
			INNER JOIN Addresses a 
		ON e.AddressID = a.AddressID
			INNER JOIN Towns t 
		ON a.TownID = t.TownID 
        WHERE t.Name = t2.Name
        ORDER BY e.FirstName
        FOR XML PATH('')) AS Names
FROM 
(SELECT t.Name, COUNT(*) AS Count 
	FROM 
	Employees AS e
		INNER JOIN Addresses a 
			ON e.AddressID = a.AddressID
		INNER JOIN Towns t 
			ON a.TownID = t.TownID  
	GROUP BY t.Name) AS t2 

--NOTE: http://stackoverflow.com/questions/6579440/how-to-concatenate-all-strings-from-a-certain-column-for-each-group

--10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings 
--and return a single string that consists of the input strings separated by ','. 
--For example the following SQL statement should return a single string:

--Source: http://www.mssqltips.com/sqlservertip/2022/concat-aggregates-sql-server-clr-function/

-- Remove the aggregate and assembly if they're there
IF OBJECT_ID('dbo.StrConcat') IS NOT NULL DROP Aggregate StrConcat 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
       DROP assembly concat_assembly; 
GO      

-- Be sure to specify the path to the folder where you extracted this homework
DECLARE @path nvarchar(256)
SET @path = 'C:\Path'

-- be sure to specify the path
CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM @path + '\ConcatAggregateSQLFunction\ConcatAggregateSQLFunction\bin\Debug\ConcatAggregateSQLFunction.dll' 
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.StrConcat ( 

    @Value NVARCHAR(MAX) 
  , @Delimiter NVARCHAR(4000) 

) RETURNS NVARCHAR(MAX) 
EXTERNAL Name concat_assembly.concat; 
GO  

---- Enable execution of CLR code 
--sp_configure 'clr enabled',1
--GO
--RECONFIGURE
--GO
----sp_configure 'clr enabled'  -- make sure it took
----GO

SELECT dbo.StrConcat(FirstName + ' ' + LastName, ', ') as Names
FROM Employees

-- Solution to Task 9 using StrConcat
USE [TelerikAcademy]
GO

SELECT t.Name AS Town, [dbo].StrConcat(FirstName + ' ' + LastName, ', ') AS Employees
FROM Employees e 
	INNER JOIN Addresses a 
		ON e.AddressID = a.AddressID
	INNER JOIN Towns t 
		ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY t.Name