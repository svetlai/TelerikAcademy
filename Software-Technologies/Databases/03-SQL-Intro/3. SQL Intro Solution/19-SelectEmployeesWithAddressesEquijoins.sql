--19. Write a SQL query to find all employees and their address. 
--Use equijoins (conditions in the WHERE clause).

SELECT e.FirstName + ' ' + e.LastName AS FullName, a.AddressText
FROM [TelerikAcademy].[dbo].[Employees] e, [TelerikAcademy].[dbo].[Addresses] a
WHERE e.AddressID = a.AddressID