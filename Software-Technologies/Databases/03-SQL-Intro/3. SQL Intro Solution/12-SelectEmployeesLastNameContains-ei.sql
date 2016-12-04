--12. Write a SQL query to find the names of all employees whose last name contains "ei".

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS FullName
FROM [TelerikAcademy].[dbo].[Employees]
WHERE LastName LIKE '%ei%'