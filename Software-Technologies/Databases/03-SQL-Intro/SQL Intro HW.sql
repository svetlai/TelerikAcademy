--1. What is SQL? What is DML? What is DDL? Recite the most important SQL commands.

--SQL stands for Structured Query Language. It's a declarative language for query and 
--manipulation of relational data.

--DML stands for Data Manipulation Language - used for selecting, inserting, deleting and 
--updating data in a database. SELECT, INSERT, UPDATE, DELETE

--DDL stands for Data Definition Language - for defining data structures, especially database schemas.
--CREATE, DROP, ALTER, GRANT, REVOKE

--Some of the most important SQL commands are: 
--SELECT, INSERT, UPDATE, DELETE, CREATE, DROP, ALTER, GRANT, REVOKE, JOIN, ORDER BY and many more

--2. What is Transact-SQL (T-SQL)?
--T-SQL is an extension to the standard SQL language for querying, altering and defining 
--relational databases, using declarative statements. It Supports if statements, loops, 
--exceptions - constructions used in the high-level procedural programming languages (like C#)
--T-SQL is used for writing stored procedures, functions, triggers, etc.

--3. Start SQL Management Studio and connect to the database TelerikAcademy. 
--Examine the major tables in the "TelerikAcademy" database.

--4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

SELECT *
FROM [TelerikAcademy].[dbo].[Departments]

--5. Write a SQL query to find all department names.

SELECT Name AS DepartmentName
FROM [TelerikAcademy].[dbo].[Departments]

--6. Write a SQL query to find the salary of each employee.

SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM [TelerikAcademy].[dbo].[Employees]

--7. Write a SQL to find the full name of each employee.

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS FullName
FROM [TelerikAcademy].[dbo].[Employees]

--8. Write a SQL query to find the email addresses of each employee (by his first and last name). 
--Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". 
--The produced column should be named "Full Email Addresses".

SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
FROM [TelerikAcademy].[dbo].[Employees]

-- 9. Write a SQL query to find all different employee salaries.

SELECT DISTINCT Salary
FROM [TelerikAcademy].[dbo].[Employees]

--10. Write a SQL query to find all information about the employees whose job title is 
--“Sales Representative“.

SELECT *
FROM [TelerikAcademy].[dbo].[Employees]
WHERE JobTitle = 'Sales Representative'

-- 11. Write a SQL query to find the names of all employees whose first name starts with "SA".

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS FullName
FROM [TelerikAcademy].[dbo].[Employees]
WHERE FirstName LIKE 'SA%'

--12. Write a SQL query to find the names of all employees whose last name contains "ei".

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS FullName
FROM [TelerikAcademy].[dbo].[Employees]
WHERE LastName LIKE '%ei%'

--13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM [TelerikAcademy].[dbo].[Employees]
WHERE Salary >= 20000 AND Salary <= 30000

--14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM [TelerikAcademy].[dbo].[Employees]
WHERE Salary IN (25000, 14000, 12500, 23600)

--15. Write a SQL query to find all employees that do not have manager.

SELECT FirstName + ' ' + LastName AS FullName, ManagerID
FROM [TelerikAcademy].[dbo].Employees
WHERE ManagerID IS NULL

--16. Write a SQL query to find all employees that have salary more than 50000. 
--Order them in decreasing order by salary.

SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM [TelerikAcademy].[dbo].[Employees]
WHERE Salary > 50000
ORDER BY Salary DESC

--17. Write a SQL query to find the top 5 best paid employees.

SELECT TOP 5 Salary, FirstName + ' ' + LastName AS FullName
FROM [TelerikAcademy].[dbo].[Employees]

--18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.

SELECT e.FirstName + ' ' + e.LastName AS FullName, a.AddressText
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
		ON e.AddressID = a.AddressID

--19. Write a SQL query to find all employees and their address. 
--Use equijoins (conditions in the WHERE clause).

SELECT e.FirstName + ' ' + e.LastName AS FullName, a.AddressText
FROM [TelerikAcademy].[dbo].[Employees] e, [TelerikAcademy].[dbo].[Addresses] a
WHERE e.AddressID = a.AddressID

--20. Write a SQL query to find all employees along with their manager.

SELECT e.FirstName + ' ' + e.LastName AS Employee, m.FirstName + ' ' + m.LastName as Manager
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Employees] m
		ON m.EmployeeID = e.ManagerID

--21. Write a SQL query to find all employees, along with their manager and their address. 
--Join the 3 tables: Employees e, Employees m and Addresses a.

SELECT e.FirstName + ' ' + e.LastName AS Employee, 
		m.FirstName + ' ' + m.LastName as Manager, 
		AddressText
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Employees] m
		ON m.EmployeeID = e.ManagerID
	INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
		ON e.AddressID = a.AddressID

--22. Write a SQL query to find all departments and all town names as a single list. Use UNION.

SELECT Name AS DepartmentsTownsList
FROM [TelerikAcademy].[dbo].[Departments]
UNION
SELECT Name AS DepartmentsTownsList
FROM [TelerikAcademy].[dbo].[Towns]

--23. Write a SQL query to find all the employees and the manager for each of them along with the 
--employees that do not have manager. Use right outer join. Rewrite the query to use left outer 
--join.

--RIGHT OUTER JOIN
SELECT m.FirstName + ' ' + m.LastName AS Employee, e.FirstName + ' ' + e.LastName as Manager
FROM [TelerikAcademy].[dbo].[Employees] e
	RIGHT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m
		ON e.EmployeeID = m.ManagerID

--LEFT OUTER JOIN
SELECT e.FirstName + ' ' + e.LastName AS Employee, m.FirstName + ' ' + m.LastName as Manager
FROM [TelerikAcademy].[dbo].[Employees] e
	LEFT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m
		ON m.EmployeeID = e.ManagerID

--24. Write a SQL query to find the names of all employees from the departments "Sales" and 
--"Finance" whose hire year is between 1995 and 2005.

SELECT e.FirstName + ' ' + e.LastName AS Employee, d.Name AS Department, e.HireDate
FROM [TelerikAcademy].[dbo].[Employees] e, [TelerikAcademy].[dbo].[Departments] d
WHERE (d.Name = 'Sales' OR d.Name = 'Finance')
		AND (e.HireDate >= '1995' AND e.HireDate <= '2005')