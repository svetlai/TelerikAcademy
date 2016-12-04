--22. Write a SQL query to find all departments and all town names as a single list. Use UNION.

SELECT Name AS DepartmentsTownsList
FROM [TelerikAcademy].[dbo].[Departments]
UNION
SELECT Name AS DepartmentsTownsList
FROM [TelerikAcademy].[dbo].[Towns]