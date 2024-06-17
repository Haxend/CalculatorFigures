SELECT p.name as ProductName, c.name as CategoryName
FROM Products p
	LEFT JOIN ProductCategories pc ON p.ProductID = pc.ProductID
	LEFT JOIN Categories c ON pc.CategoryID = c.CategoryID
ORDER BY p.ProductName, c.CategoryName;