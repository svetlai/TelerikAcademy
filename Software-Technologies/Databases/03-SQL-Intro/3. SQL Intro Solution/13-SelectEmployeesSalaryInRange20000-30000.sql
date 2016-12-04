--13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM [TelerikAcademy].[dbo].[Employees]
WHERE Salary >= 20000 AND Salary <= 30000
