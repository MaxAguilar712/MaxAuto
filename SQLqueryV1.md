SEPERATE THESE plz

```sql
USE [master]
GO
IF db_id('MaxAuto') IS NULL
  CREATE DATABASE [MaxAuto]
GO
USE [MaxAuto]
GO

DROP TABLE IF EXISTS [Car];
DROP TABLE IF EXISTS [User];
DROP TABLE IF EXISTS [Part];
DROP TABLE IF EXISTS [CarPart;
DROP TABLE IF EXISTS [CarGarage]

CREATE TABLE [UserType] (
  [Id] integer PRIMARY KEY IDENTITY,

  [Name] nvarchar(20) NOT NULL
)

CREATE TABLE [User] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [UserTypeId] integer NOT NULL,
  [Money] integer,

 CONSTRAINT [FK_User_UserType] FOREIGN KEY ([UserTypeId]) REFERENCES [UserType] ([Id]),
)

GO

CREATE TABLE [Car] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [Price] integer NOT NULL,
  [Year] integer NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Transmission] nvarchar(255),
  [Manufacturer] nvarchar(255),
  [Mileage] integer,
  [ImageUrl] nvarchar(255),
  [Worth] integer NOT NULL,
)
GO

CREATE TABLE [CarPart] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [GarageCarPartId] integer NOT NULL,
  [GarageCarId] integer  NOT NULL,
)

CREATE TABLE [Part] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Category] nvarchar(255) NOT NULL,
  [Price] integer NOT NULL,
)
GO

CREATE TABLE [CarGarage] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [Price] integer NOT NULL,
  [Year] integer NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Transmission] nvarchar(255),
  [Manufacturer] nvarchar(255),
  [Mileage] integer,
  [ImageUrl] nvarchar(255),
  [Worth] integer NOT NULL,
  [UserId] integer NOT NULL,
)
GO

SET IDENTITY_INSERT [CarGarage] ON
INSERT INTO [CarGarage]
  ([Id], [Price], [Year], [Name], [Transmission], [Manufacturer], [Mileage], [ImageUrl], [Worth], [UserId])
VALUES 
  (101, 999999, 2023, 'TOMAHAWK X SRT', 'MT', 'Dodge', 150, 'https://assets.newatlas.com/dims4/default/098f9bb/2147483647/strip/true/crop/1620x1080+150+0/resize/1200x800!/quality/90/?url=http%3A%2F%2Fnewatlas-brightspot.s3.amazonaws.com%2Farchive%2FCN015_042SRco1r7mk5pp8rn14gfprhdhbdlp.jpg', 999999, 1),


SET IDENTITY_INSERT [Car] ON
INSERT INTO [Car]
  ([Id], [Price], [Year], [Name], [Transmission], [Manufacturer], [Mileage], [ImageUrl], [Worth])
VALUES 
  (1, 1500, 1990, 'Civic SI Sedan', 'MT', 'Honda', 255000, 'https://i.imgur.com/nGWK571.jpg', 2200),
  (2, 3500, 1992, 'Acty', 'MT', 'Honda', 125000, 'https://i.imgur.com/1V8WNwU.jpg', 4000),
  (3, 8000, 1986, 'Mustang GT', 'MT', 'Ford', 198000, 'https://i.imgur.com/2SWEqpa.jpeg', 9500),
  (4, 1800, 1998, 'Escort LX', 'AT','Ford', 260000, 'https://i.imgur.com/FljplyL.jpeg', 1200),
  (5, 12000, 1986, 'CRX SI', 'MT', 'Honda', 90000, 'https://i.imgur.com/I3UeV0u.jpeg', 17500),
  (6, 3500, 1988, 'Mark II', 'MT', 'Toyota', 130000, 'https://i.imgur.com/8pWmZTs.jpeg', 3200),
  (7, 24500, 1996, 'Chaser Tourer V', 'MT', 'Toyota', 50000, 'https://i.imgur.com/xyKVSyG.jpeg', 34500),
  (8, 19500, 1989, 'Soarer GT Twin Turbo', 'MT', 'Toyota', 110000, 'https://i.imgur.com/dNbpoW9.jpeg', 22000),
  (9, 9500, 1991, 'Silvia S13', 'MT', 'Nissan', 190000, 'https://i.imgur.com/W9OxbF9.jpeg', 11500),
  (10, 7000, 1987, '200SX S12', 'MT', 'Nissan', 140000, 'https://i.imgur.com/9X9qeYt.jpeg', 8800);
  (11, 19500, 1987, 'RX-7 Turbo II', 'MT', 'Mazda', 120000, 'https://i.imgur.com/Aaa7TFs.jpeg', 23000);
  (12, 1200, 2000, 'Focus SE', 'AT', 'Ford', 222000, 'https://i.imgur.com/i1s4pXZ.jpeg', 2000);
  (13, 1100, 2000, 'Taurus SE', 'AT', 'Ford', 251000, 'https://i.imgur.com/Aaa7TFs.jpeg', 2000);
  (14, 70000, 1991, 'NSX', 'MT', 'Acura', 65000, 'https://i.imgur.com/LwMTxpN.jpg', 90000),
  (15, 7500, 1990, 'Miata NA', 'MT', 'Mazda', 77000, 'https://i.imgur.com/oPGGLpS.jpg', 10000),
  (16, 15500, 2006, 'G35 Coupe', 'AT', 'Infiniti', 102000, 'https://i.imgur.com/2OG2gUX.jpg', 11000),
  (17, 6500, 2008, 'Altima S', 'CVT', 'Nissan', 79000, 'https://i.imgur.com/cD7C2L6.jpg', 8500),
  (18, 250000, 2005, 'SLR', 'AT', 'Mercedes-Benz', 8000, 'https://i.imgur.com/J0kEVAF.jpg', 400000),
  (19, 10000, 1999, 'Mustang SVT Cobra', 'MT', 'Ford', 90000, 'https://i.imgur.com/jLX4O4M.jpg', 16000),
  (20, 6000, 2007, 'Camry SE', 'MT', 'Toyota', 151000, 'https://i.imgur.com/XUfswrn.jpg', 7500),
  (21, 27000, 2022, 'GR86 Premium', 'AT', 'Toyota', 25000, 'https://i.imgur.com/mgOUzyX.jpeg', 31000),
  (22, 20000, 1986, 'Sprinter Trueno', 'MT', 'Toyota', 100600, 'https://i.imgur.com/qC9UFfF.jpg', 30000),
  (23, 7000, 2008, 'Liberty', 'AT', 'Jeep', 174000, 'https://i.imgur.com/SIcr7r3.jpeg', 4500),
  (24, 9000, 2011, 'Eclipse Spyder', 'MT', 'Mitsubishi', 92000, 'https://i.imgur.com/x2nilZ1.jpeg', 12000),
  (25, 85000, 2022, 'Air Grand Touring', 'AT', 'Lucid', 6000, 'https://i.imgur.com/cgxRO3x.jpeg', 91000), 
  (26, 29500, 2023, 'Model Y', 'N/A', 'Tesla', 7000, 'https://i.imgur.com/c48QWbi.jpeg', 12000),
  (27, 14500, 1999, 'M3', 'MT', 'BMW', 95000, 'https://i.imgur.com/JXvOao0.jpeg', 19500),
  (28, 6500, 2001, 'TT Roadster', 'MT', 'Audi', 93000, 'https://i.imgur.com/GRZvXrg.jpeg', 7500),


SET IDENTITY_INSERT [User] ON
INSERT INTO [User]
  ([Id], [Name], [Email], [UserTypeId], [Money])
VALUES 
  (1, 'Admin', 'Admin@email.com', 1, 999999);


SET IDENTITY_INSERT [Part] ON
INSERT INTO [Part]
  ([Id], [Name], [Category], [Price])
VALUES
  (33, 'Sports Computer', 'ECU', 600),
  (34, 'Fully Tuned Computer', 'ECU', 1100), 
  (35, 'Turbo', 'Engine', 1000),
  (36, 'Twin Turbo', 'Engine', 1700),
  (37, 'Supercharger', 'Engine', 2000),
  (38, 'High Performance Air Filter', 'Engine', 300), 
  (39, 'Upgraded Cooling', 'Engine', 700), 
  (40, 'High Performance Exhaust Manifold', 'Exhaust', 800), 
  (41, 'Straight Pipe', 'Exhaust', 500),
  (42, 'High Performance Exhaust', 'Exhaust', 800),
  (43, 'Catalytic Converter Delete', 'Exhaust', 300), 
  (44, 'High Performance Suspension', 'Suspension', 1100),
  (45, 'Adjustable High Performance Coilovers', 'Suspension', 1500),
  (46, 'High Performance Tires', 'Suspension', 700),
  (47, 'Limited-Slip Differential', 'Differential', 900),
  (48, 'High Performance Camshaft', 'Engine', 600),
  (49, 'High Performance Crankshaft', 'Engine', 800),
  (50, 'High Performance Clutch', 'Transmission', 700),
  (51, 'High Performance Flywheel', 'Transmission', 600),



```
