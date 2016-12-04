--23. Write a SQL query to find all the employees and the manager for each of them along with the 
--employees that do not have manager. Use right outer join. Rewrite the query to use left outer 
--join.

--RIGHT OUTER JOIN
SELECT m.FirstName + ' ' + m.LastName AS Employee, e.FirstName + ' ' + e.LastName as Manager
FROM [TelerikAcademy].[dbo].[Employees] e
	RIGHT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m
		ON e.EmployeeID = m.ManagerID

--LEFT OUTER JOIN
--SELECT e.FirstName + ' ' + e.LastName AS Employee, m.FirstName + ' ' + m.LastName as Manager
--FROM [TelerikAcademy].[dbo].[Employees] e
--	LEFT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m
--		ON m.EmployeeID = e.ManagerID