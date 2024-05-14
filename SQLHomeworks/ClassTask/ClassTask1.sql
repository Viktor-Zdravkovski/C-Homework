USE [master]
GO

CREATE DATABASE [SEDC]
GO

USE [SEDC]
GO

CREATE TABLE [BusinessEntity](
	Id INT IDENTITY(1,1),
	[Name] NVARCHAR(100),
	Region NVARCHAR(1000),
	Zipcode NVARCHAR(10),
	Size NVARCHAR(10)
	CONSTRAINT PK_BusinessEntity PRIMARY KEY CLUSTERED (Id)
)


CREATE TABLE [Employee](
	Id INT IDENTITY(1,1),
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	DateOfBirth DATE,
	Gender NCHAR(1),
	HireDate DATE,
	NationalldNumber NVARCHAR(20)
	CONSTRAINT PK_Employee PRIMARY KEY CLUSTERED (Id)
)


CREATE TABLE [Product](
	Id INT IDENTITY(1,1),
	Code NVARCHAR(50),
	[Name] NVARCHAR(100),
	[Description] NVARCHAR(MAX),
	[Weight] DECIMAL(18,2),
	Price DECIMAL(18,2),
	Cost DECIMAL(18,2)
	CONSTRAINT PK_Product PRIMARY KEY CLUSTERED (Id)
)

CREATE TABLE [Customer](
	Id INT IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL,
	AccountNumber NVARCHAR(50),
	City NVARCHAR(100),
	RegionName NVARCHAR(100),
	CustomerSize NVARCHAR(10),
	PhoneNumber NVARCHAR(20),
	IsActive BIT NOT NULL
	CONSTRAINT PK_Customer PRIMARY KEY CLUSTERED (Id)
)


CREATE TABLE [Order](
	Id BIGINT IDENTITY(1,1),
	OrderDate DATETIME,
	[Status] SMALLINT,
	BusinessEntityId INT,
	CustomerId INT,
	EmployeeId INT,
	TotalPrice DECIMAL(18,2),
	Comment NVARCHAR(MAX)
	CONSTRAINT PK_Order PRIMARY KEY CLUSTERED (Id)
)


CREATE TABLE [OrderDetails](
	Id BIGINT IDENTITY(1,1),
	OrderId BIGINT,
	ProductID INT,
	Quantity INT,
	Price DECIMAL(18,2)
	CONSTRAINT PK_OrderDetails PRIMARY KEY CLUSTERED (Id)
)

DROP TABLE dbo.BusinessEntity
DROP TABLE dbo.Customer
DROP TABLE dbo.Employee
DROP TABLE dbo.[Order]
DROP TABLE dbo.OrderDetails
DROP TABLE dbo.Product


SELECT * FROM dbo.BusinessEntity
SELECT * FROM dbo.Employee
SELECT * FROM dbo.Product
SELECT * FROM dbo.Customer
SELECT * FROM dbo.[Order]
SELECT * FROM dbo.OrderDetails

INSERT INTO [dbo].[BusinessEntity] ([Name], [Region], [Zipcode], [Size])
VALUES ('Grillex', 'Amsterdam', 'NL', 'Big' ),
('Fervex', 'Roterdam', 'NL', 'Big' ),
('Skrillex', 'Frankfurt', 'DE', 'Small' )
GO

INSERT INTO [dbo].[Employee] ([FirstName], [LastName], [DateOfBirth], [Gender], [HireDate], [NationalldNumber])
VALUES ('Dimitar', 'Gogrievski', '2001.04.12', 1, '2022.04.12', '351'),
('Viktor', 'Zdravkovski', '2002.03.25', 1, '2025.04.12', '332'),
('Andrej', 'Jankovikj', '2004.09.11', 1, '2025.04.12', '531')
GO

INSERT INTO [dbo].[Product] ([Code],[Name],[Description],[Weight],[Price],[Cost])
VALUES ('351', 'Bazen', 'Krug pun so voda',100.20 ,1800.25 ,1000.25),
('355', 'Trkalo', 'Trkalo za kola', 15.20, 150.20 , 1650.25),
('31', 'Bure', 'Drveno bure', 5.12 , 180.20 , 1000.25)
GO

INSERT INTO [dbo].[Customer] ([Name], [AccountNumber], [City], [RegionName], [CustomerSize], [PhoneNumber], [IsActive])
VALUES ('Milorad', '625', 'Birmingham', 'West MidLands', 'Medium', '123456789', 1),
('Miroljub', '352', 'Manchester', 'West MidLands', 'Big', '987654321', 2),
('Dragoslav', '752', 'Canada', 'North America', 'Small', '767323512', 1)
GO

INSERT INTO [dbo].[Order] ([OrderDate],[Status],[BusinessEntityId],[CustomerId],[EmployeeId],[TotalPrice],[Comment])
VALUES ('2023.04.12', 3, 12, 31, 42, 15000.13 , 'Krshlivo'),
('2022.06.13', 5, 21, 23, 45, 17230.15 , 'So prioritet'),
('2025.03.11', 2, 51, 361, 422, 2000.13 , 'Hazardous')
GO

INSERT INTO dbo.OrderDetails ([OrderId], [ProductId], [Quantity], [Price])
VALUES (42, 55, 2, 1450.25),
(62, 45, 44, 6250.22),
(2, 5, 23, 146350.23)
GO