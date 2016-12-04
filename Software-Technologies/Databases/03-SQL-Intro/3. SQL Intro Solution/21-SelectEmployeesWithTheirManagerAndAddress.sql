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