USE Northwind
GO

CREATE PROC usp_FindTotalIncome(@supplierName nvarchar, @startDate date, @endDate date)
AS
	SELECT SUM(od.UnitPrice * od.Quantity) 
	FROM [Order Details] od
		JOIN Orders o ON od.OrderID = o.OrderID
		JOIN Products p ON od.ProductID = p.ProductID
		JOIN Suppliers s ON p.SupplierID = s.SupplierID
	WHERE (o.ShippedDate BETWEEN YEAR(@startDate) AND YEAR(@endDate)) AND s.CompanyName = @supplierName
GO
