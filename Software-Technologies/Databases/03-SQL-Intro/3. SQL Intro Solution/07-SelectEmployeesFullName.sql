--7. Write a SQL to find the full name of each employee.

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS FullName
FROM [TelerikAcademy].[dbo].[Employees]