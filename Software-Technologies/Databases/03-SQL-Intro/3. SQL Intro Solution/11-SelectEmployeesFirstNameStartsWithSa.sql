-- 11. Write a SQL query to find the names of all employees whose first name starts with "SA".

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS FullName
FROM [TelerikAcademy].[dbo].[Employees]
WHERE FirstName LIKE 'SA%'