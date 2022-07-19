--DROP DATABASE eStore
GO
CREATE DATABASE eStore
GO
use eStore
GO
CREATE tABLE Member(
	MemberId int identity(1,1) PRIMARY KEY,
	Email varchar(100) UNIQUE NOT NULL,
	CompanyName varchar(40) NOT NULL,
	City varchar(15) NOT NULL,
	Country varchar(15) NOT NULL,
	Password varchar(30) NOT NULL
)
GO
INSERT INTO Member(Email, CompanyName, City, Country, Password) VALUES
('longdhse161171@fpt.edu.vn','Cong ty Hoang Long', 'HCM','Vietnam','123'),
('taindse161887@fpt.edu.vn','Cong ty Duc Tai', 'HCM','Vietnam','123'),
('viethqse150049@fpt.edu.vn','Cong ty Quoc Viet', 'HCM','Vietnam','123'),
('vinhbhse161171@fpt.edu.vn','Cong ty Quoc Vinh', 'HCM','Vietnam','123'),
('tanmtse161171@fpt.edu.vn','Cong ty Manh Tan', 'HCM','Vietnam','123');
GO
CREATE TABLE [Order](
	OrderId int identity(1,1) PRIMARY KEY,
	MemberId int NOT NULL FOREIGN KEY REFERENCES Member(MemberId),
	OrderDate datetime NOT NULL,
	RequiredDate datetime,
	ShippedDate datetime,
	Freight money
)
GO
INSERT INTO [Order](MemberId, OrderDate, RequiredDate, ShippedDate, Freight) VALUES
(1, '2022-07-18','2022-07-18','2022-08-19',15000),
(1, '2022-07-18','2022-07-28','2022-08-19',10000)
GO
CREATE TABLE Product(
	ProductId int identity(1,1) PRIMARY KEY,
	CategoryId int NOT NULL,
	ProductName varchar(40) NOT NULL,
	Weight varchar(20) NOT NULL,
	UnitPrice money NOT NULL,
	UnitsInStock int NOT NULL
)
GO
INSERT INTO Product(CategoryId, ProductName, Weight, UnitPrice, UnitsInStock) VALUES
(1, 'Laptop ASUS', '2kg', 20000000, 100),
(2, 'Headphone', '100gr', 300000, 140),
(1, 'Laptop DELL', '1,7kg', 14000000, 98),
(3, 'Ban phim co', '300gr', 400000, 100),
(4, 'Ghe gaming', '6kg', 5000000, 214)
GO
CREATE TABLE OrderDetail(
	OrderId int NOT NULL FOREIGN KEY REFERENCES [Order](OrderId),
	ProductId int NOT NULL FOREIGN KEY REFERENCES Product(ProductId),
	UnitPrice money NOT NULL,
	Quantity int NOT NULL,
	Discount float NOT NULL
)
GO
CREATE TRIGGER trg_UpdateProduct on OrderDetail after update AS
BEGIN
   UPDATE Product SET UnitsInStock = UnitsInStock -
	   (SELECT Quantity FROM inserted WHERE ProductId = Product.ProductId) +
	   (SELECT Quantity FROM deleted WHERE ProductId = Product.ProductId)
   FROM Product 
   JOIN deleted ON Product.ProductId = deleted.ProductId
end
GO
CREATE TRIGGER trg_InsertProduct ON OrderDetail AFTER INSERT AS 
BEGIN
	UPDATE Product
	SET UnitsInStock = UnitsInStock - (
		SELECT Quantity
		FROM inserted
		WHERE ProductId = Product.ProductId
	)
	FROM Product
	JOIN inserted ON Product.ProductId = inserted.ProductId
END
GO
create TRIGGER trg_HuyDatHang ON OrderDetail FOR DELETE AS 
BEGIN
	UPDATE Product
	SET UnitsInStock = UnitsInStock + (SELECT Quantity FROM deleted WHERE ProductId = Product.ProductId)
	FROM Product 
	JOIN deleted ON Product.ProductId = deleted.ProductId
END
GO
