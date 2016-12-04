--24. Write a SQL query to find the names of all employees from the departments "Sales" and 
--"Finance" whose hire year is between 1995 and 2005.

SELECT e.FirstName + ' ' + e.LastName AS Employee, d.Name AS Department, e.HireDate
FROM [TelerikAcademy].[dbo].[Employees] e, [TelerikAcademy].[dbo].[Departments] d
WHERE (d.Name = 'Sales' OR d.Name = 'Finance')
		AND (e.HireDate >= '1995' AND e.HireDate <= '2005')