--17. Write a SQL query to find the top 5 best paid employees.

SELECT TOP 5 Salary, FirstName + ' ' + LastName AS FullName
FROM [TelerikAcademy].[dbo].[Employees]
