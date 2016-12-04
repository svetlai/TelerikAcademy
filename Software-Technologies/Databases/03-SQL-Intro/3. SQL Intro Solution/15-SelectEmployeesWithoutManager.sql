--15. Write a SQL query to find all employees that do not have manager.

SELECT FirstName + ' ' + LastName AS FullName, ManagerID
FROM [TelerikAcademy].[dbo].Employees
WHERE ManagerID IS NULL