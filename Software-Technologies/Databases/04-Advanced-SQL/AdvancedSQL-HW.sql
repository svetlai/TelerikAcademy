USE [TelerikAcademy]
GO

--1. Write a SQL query to find the names and salaries of the employees that take the minimal 
--salary in the company. Use a nested SELECT statement.

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees)

--2. Write a SQL query to find the names and salaries of the employees that have a salary 
--that is up to 10% higher than the minimal salary for the company.

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary <= 
	(SELECT MIN(Salary) + MIN(Salary)*0.1 FROM Employees)

--3. Write a SQL query to find the full name, salary and department of the employees that 
--take the minimal salary in their department. Use a nested SELECT statement.

SELECT e.FirstName + ' ' + e.LastName AS [FullName], e.Salary, d.Name
FROM Employees e 
  INNER JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = 
  (SELECT MIN(Salary) FROM Employees
   WHERE DepartmentID = e.DepartmentID)

--4. Write a SQL query to find the average salary in the department #1.

SELECT AVG(Salary) AS [AvarageSalaryInDepartment1]
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
		WHERE d.DepartmentID = 1

--5. Write a SQL query to find the average salary in the "Sales" department.

SELECT AVG(Salary) AS [AvarageSalaryInSales]
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
		WHERE d.Name = 'Sales'

--6. Write a SQL query to find the number of employees in the "Sales" department.

SELECT COUNT(*) AS [EmployeesCountInSales]
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
		WHERE d.Name = 'Sales'

--7. Write a SQL query to find the number of all employees that have manager.

SELECT COUNT(*) AS [EmployeesCountWithManager]
FROM Employees e
	INNER JOIN Employees m
	ON m.EmployeeID = e.ManagerID

--8. Write a SQL query to find the number of all employees that have no manager.

SELECT COUNT(*) AS [EmployeesCountWithoutManager]
FROM Employees	
WHERE ManagerID IS NULL

--9. Write a SQL query to find all departments and the average salary for each of them.

SELECT d.Name, AVG(e.Salary) [AverageSalary]
FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

-- 10. Write a SQL query to find the count of all employees in each department and for each town.

SELECT d.Name, t.Name, COUNT(*) AS [EmployeesCount]
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	INNER JOIN Addresses a
		ON e.AddressID = a.AddressID
	INNER JOIN Towns t
		ON t.TownID = a.TownID
GROUP BY d.Name, t.Name

--11. Write a SQL query to find all managers that have exactly 5 employees. Display 
--their first name and last name.

SELECT m.FirstName, m.LastName, COUNT(m.EmployeeID) AS [ManagerCount]
FROM Employees m
	INNER JOIN Employees e
		ON m.EmployeeID = e.ManagerID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5

--12. Write a SQL query to find all employees along with their managers. 
--For employees that do not have manager display the value "(no manager)".

SELECT e.FirstName + ' ' + e.LastName AS [Employee], 
	ISNULL(m.FirstName + ' ' + m.LastName, 'no manager') AS [Manager]
FROM Employees e
	LEFT OUTER JOIN Employees m
		ON m.EmployeeID = e.ManagerID

--13. Write a SQL query to find the names of all employees whose last name is exactly 
--5 characters long. Use the built-in LEN(str) function.

SELECT LastName
FROM Employees
WHERE LEN(LastName) = 5

--14. Write a SQL query to display the current date and time in the following format 
--"day.month.year hour:minutes:seconds:milliseconds". Search in Google to find how to 
--format dates in SQL Server.

SELECT CONVERT(VARCHAR(30), GETDATE(), 121) AS CurrentDateTime

--SELECT GETDATE() AS CurrentDateTime

--15. Write a SQL statement to create a table Users. Users should have username, 
--password, full name and last login time. Choose appropriate data types for the table 
--fields. Define a primary key column with a primary key constraint. Define the primary 
--key column as identity to facilitate inserting records. Define unique constraint to avoid 
--repeating usernames. Define a check constraint to ensure the password is at least 5 
--characters long.

CREATE TABLE [Users]
(
[UserId] int NOT NULL IDENTITY,
[Username] varchar(50) UNIQUE NOT NULL,
[Password] varchar(50),
[FullName] varchar(200),
[LastLogIn] datetime,
CONSTRAINT PK_User PRIMARY KEY([UserId]),
CONSTRAINT PasswordCheck CHECK (LEN([Password]) >= 5)
)

GO

--16. Write a SQL statement to create a view that displays the users from the Users 
--table that have been in the system today. Test if the view works correctly.

CREATE VIEW [V_UserLoggedInToday] AS
SELECT *
FROM [Users]
WHERE DAY([LastLogIn]) = DAY(GETDATE())

GO

--17. Write a SQL statement to create a table Groups. Groups should have unique name 
--(use unique constraint). Define primary key and identity column.

CREATE TABLE [Groups]
(
[GroupID] int NOT NULL IDENTITY,
[GroupName] varchar(100) UNIQUE NOT NULL,
CONSTRAINT PK_Groups PRIMARY KEY([GroupID]),
)
GO

--18. Write a SQL statement to add a column GroupID to the table Users. Fill some data in 
--this new column and as well in the Groups table. Write a SQL statement to add a foreign 
--key constraint between tables Users and Groups tables.

ALTER TABLE [Users] 
ADD [GroupID] int
GO

ALTER TABLE [Users]
ADD CONSTRAINT FK_Groups_Users FOREIGN KEY([GroupID])
	REFERENCES Groups([GroupID])
GO
	
--19. Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO [Groups] ([GroupName])
VALUES ('First Group')
INSERT INTO [Groups] ([GroupName])
VALUES ('Second Group')
GO

INSERT INTO [Users] ([Username], [Password], [FullName], [LastLogIn], [GroupID])
VALUES ('pesho', 'passs', 'Pesho Peshov', GETDATE(), 3)
INSERT INTO [Users] ([Username], [Password], [FullName], [LastLogIn], [GroupID])
VALUES ('gosho', '12345', 'Gosho Goshov', GETDATE(), 3)
GO

--20. Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE [Groups]
SET GroupName='New Group'
WHERE GroupName='Second Group'
GO

UPDATE [Users]
SET FullName='Georgi Georgiev'
WHERE FullName='Gosho Goshov'
GO

--21. Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE FROM [Users]
WHERE [Username] = 'pesho'
GO

DELETE FROM [Groups]
WHERE GroupName = 'New Group'
GO

--22. Write SQL statements to insert in the Users table the names of all employees from the 
--Employees table. Combine the first and last names as a full name. For username use the 
--first letter of the first name + the last name (in lowercase). Use the same for the 
--password, and NULL for last login time.

--NOTE: I've used the first 3 letters of the FirstName + LastName for Username because there are
--repetitive names.

INSERT INTO [Users] ([Username], [Password], [FullName], [LastLogIn], [GroupID])
SELECT LOWER(LEFT(FirstName, 3) + LastName), LOWER(LEFT(FirstName, 3) + LastName), FirstName + ' ' + LastName, NULL, 3
FROM Employees
GO

--23. Write a SQL statement that changes the password to NULL for all users that have not 
--been in the system since 10.03.2010.

UPDATE [Users]
SET Password = NULL
WHERE [LastLogIn] < '2010-03-10'
GO

--24. Write a SQL statement that deletes all users without passwords (NULL password).

DELETE FROM [Users]
WHERE [Password] IS NULL
GO

--25. Write a SQL query to display the average employee salary by department and job title.

SELECT d.Name AS Department, e.JobTitle, AVG(e.Salary) AS AverageSalary
FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY d.Name

--AverageSalary by department only:

--SELECT d.Name AS Department, AVG(e.Salary) AS AverageSalary
--FROM Employees e
--	INNER JOIN Departments d
--	ON e.DepartmentID = d.DepartmentID
--GROUP BY d.Name
--ORDER BY d.Name

--26. Write a SQL query to display the minimal employee salary by department and job title 
--along with the name of some of the employees that take it.

SELECT d.Name, e.JobTitle, e.FirstName + ' ' + e.LastName AS [FullName], e.Salary
FROM Employees e 
  INNER JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = 
  (SELECT MIN(Salary) FROM Employees
   WHERE DepartmentID = e.DepartmentID)
ORDER BY d.Name

--27. Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 t.Name, COUNT(*)
FROM Employees e
	INNER JOIN Addresses a
		ON e.AddressID = a.AddressID
	INNER JOIN Towns t
		ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC

--28. Write a SQL query to display the number of managers from each town.

SELECT t.Name, COUNT(*) AS NumberOfManagers
FROM Employees e
	INNER JOIN Addresses a
		ON e.AddressID = a.AddressID
	INNER JOIN Towns t
		ON t.TownID = a.TownID
	WHERE e.EmployeeID IN
		(SELECT DISTINCT ManagerID FROM Employees)
GROUP BY t.Name

--29. Write a SQL to create table WorkHours to store work reports for each employee 
--(employee id, date, task, hours, comments). Don't forget to define  identity, primary 
--key and appropriate foreign key. 
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
--For each change keep the old record data, the new record data and the command 
--(insert / update / delete).

CREATE TABLE [WorkHours]
(
[WorkHoursID] int NOT NULL IDENTITY,
[Date] datetime,
[Task] nvarchar(300),
[Hours] int,
[Comment] nvarchar(300),
[EmployeeID] int
CONSTRAINT PK_WorkHours PRIMARY KEY([WorkHoursID]),
CONSTRAINT FK_WorkHours_Employees FOREIGN KEY([EmployeeID])
	REFERENCES Employees([EmployeeID])
)
GO

CREATE TABLE [WorkHoursLogs]
(
[WorkHoursLogsID] int NOT NULL IDENTITY,
[DateOld] datetime,
[TaskOld] nvarchar(300),
[HoursOld] int,
[CommentOld] nvarchar(300),
[EmployeeIDOld] int,
[DateNew] datetime,
[TaskNew] nvarchar(300),
[HoursNew] int,
[CommentNew] nvarchar(300),
[EmployeeIDNew] int,
[IssuedCommand] nvarchar(50),
[WorkHoursID] int
CONSTRAINT PK_WorkHoursLogs PRIMARY KEY([WorkHoursLogsID]),
)
GO

CREATE TRIGGER Tr_WorkHoursInsert ON WorkHours
FOR INSERT 
AS
INSERT INTO WorkHoursLogs ([DateOld], [TaskOld], [HoursOld], [CommentOld], [EmployeeIDOld],
	[DateNew], [TaskNew], [HoursNew], [CommentNew], [EmployeeIDNew], [IssuedCommand], [WorkHoursID])
	SELECT NULL, NULL, NULL, NULL, NULL,
		i.[Date], i.[Task], i.[Hours], i.[Comment], i.[EmployeeID], 'INSERT', i.[WorkHoursID]
	FROM WorkHours w 
		INNER JOIN inserted i 
			ON w.[WorkHoursID] = i.[WorkHoursID]
GO

CREATE TRIGGER Tr_WorkHoursUpdate ON WorkHours
FOR UPDATE 
AS
INSERT INTO WorkHoursLogs ([DateOld], [TaskOld], [HoursOld], [CommentOld], [EmployeeIDOld],
	[DateNew], [TaskNew], [HoursNew], [CommentNew], [EmployeeIDNew], [IssuedCommand], [WorkHoursID])
	SELECT w.[Date], w.[Task], w.[Hours], w.[Comment], w.[EmployeeID],
		i.[Date], i.[Task], i.[Hours], i.[Comment], i.[EmployeeID], 'UPDATE', i.[WorkHoursID]
	FROM WorkHours w 
		INNER JOIN inserted i 
			ON w.[WorkHoursID] = i.[WorkHoursID]
GO

CREATE TRIGGER Tr_WorkHoursDelete ON WorkHours
FOR UPDATE 
AS
INSERT INTO WorkHoursLogs ([DateOld], [TaskOld], [HoursOld], [CommentOld], [EmployeeIDOld],
	[DateNew], [TaskNew], [HoursNew], [CommentNew], [EmployeeIDNew], [IssuedCommand], [WorkHoursID])
	SELECT w.[Date], w.[Task], w.[Hours], w.[Comment], w.[EmployeeID],
		NULL, NULL, NULL, NULL, NULL, 'DELETE', i.[WorkHoursID]
	FROM WorkHours w 
		INNER JOIN inserted i 
			ON w.[WorkHoursID] = i.[WorkHoursID]
GO

INSERT INTO WorkHours ([Date], [Task], [Hours], [Comment], [EmployeeID])
VALUES (CONVERT(date, '20140824', 112), 'Have Coffee', 2, 'no comment', 1),
(CONVERT(date, '20140824', 112), 'Do Research', 4, NULL, 3),
(CONVERT(date, '20140823', 112), 'Conference Call', 1, 'conference call with Japan', 5),
(CONVERT(date, '20140823', 112), 'Update the DB', 12, 'new table added', 2),
(CONVERT(date, '20140823', 112), 'Meeting', 3, NULL , 4)
GO

UPDATE [WorkHours]
SET [Comment] = 'nice coffee'
WHERE [Comment] = 'no comment'
GO

UPDATE [WorkHours]
SET [Hours] = 2
WHERE [Task] = 'Conference Call'
GO

DELETE FROM [WorkHours]
WHERE [Task] = 'Meeting'
GO

--30. Start a database transaction, delete all employees from the 'Sales' department along 
--with all dependent records from the pother tables. At the end rollback the transaction.

BEGIN TRAN
ALTER Table Departments
DROP CONSTRAINT FK_Departments_Employees
DELETE FROM Employees
WHERE DepartmentID = 
	(SELECT DepartmentID FROM Departments WHERE Name = 'Sales')
DELETE FROM Departments
WHERE Name = 'Sales'
ROLLBACK TRAN
GO

--31. Start a database transaction and drop the table EmployeesProjects. Now how you could 
--restore back the lost table data?

BEGIN TRAN
DROP Table EmployeesProjects
ROLLBACK TRAN
GO

--32. Find how to use temporary tables in SQL Server. Using temporary tables backup all 
--records from EmployeesProjects and restore them back after dropping and re-creating the 
--table.

BEGIN TRAN
SELECT *
INTO #EmployeesProjects
FROM EmployeesProjects 

DROP Table EmployeesProjects

CREATE Table EmployeesProjects
(
[EmployeeID] int NOT NULL,
[ProjectID] int NOT NULL
CONSTRAINT PK_EmployeesProjects PRIMARY KEY CLUSTERED
	(
		[EmployeeID],
		[ProjectID]
	)
CONSTRAINT [FK_EmployeesProjects_Employees] FOREIGN KEY([EmployeeID])
	REFERENCES [dbo].[Employees] ([EmployeeID])
)

INSERT INTO EmployeesProjects
SELECT *
FROM #EmployeesProjects 

DROP Table #EmployeesProjects

COMMIT
GO