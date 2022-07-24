--- Create tables ---
CREATE TABLE Products (
	ProductID INT PRIMARY KEY,
	ProductName TEXT
);

CREATE TABLE Categories (
	CategoryID INT PRIMARY KEY,
	CategoryName TEXT
);

CREATE TABLE ProductsCategories (
	ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
	CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID),
);


INSERT INTO Products
VALUES
	(1, 'Rx570'),
	(2, 'Cat food'),
	(3, 'Banana'),
	(4, 'Calculator'),
	(5, 'Window');



INSERT INTO Categories
VALUES
	(1, 'Game'),
	(2, 'Tecnical'),
	(3, 'Videocard'),
	(4, 'Food'),
	(5, 'For animal');


INSERT INTO ProductsCategories
VALUES
	(1, 2),
	(1, 3),
	(2, 4),
	(2, 5),
	(3, 4),
	(4, 2);