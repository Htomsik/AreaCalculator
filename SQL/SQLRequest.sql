--- Request ---
SELECT P.ProductName, C.CategoryName
FROM Products P
LEFT JOIN ProductsCategories PC
	ON P.ProductID = PC.ProductID
LEFT JOIN Categories C
	On C.CategoryID = PC.CategoryID

