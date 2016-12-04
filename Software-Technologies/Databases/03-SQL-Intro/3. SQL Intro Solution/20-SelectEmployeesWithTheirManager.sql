--20. Write a SQL query to find all employees along with their manager.

SELECT e.FirstName + ' ' + e.LastName AS Employee, m.FirstName + ' ' + m.LastName as Manager
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Employees] m
		ON m.EmployeeID = e.ManagerID