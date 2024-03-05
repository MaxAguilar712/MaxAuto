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
  (42069, 999999, 2023, 'TOMAHAWK X SRT', 'MT', 'Dodge', 150, 'https://assets.newatlas.com/dims4/default/098f9bb/2147483647/strip/true/crop/1620x1080+150+0/resize/1200x800!/quality/90/?url=http%3A%2F%2Fnewatlas-brightspot.s3.amazonaws.com%2Farchive%2FCN015_042SRco1r7mk5pp8rn14gfprhdhbdlp.jpg', 999999, 1),


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
  

SET IDENTITY_INSERT [User] ON
INSERT INTO [User]
  ([Id], [Name], [Email], [UserTypeId], [Money])
VALUES 
  (1, 'Admin', 'Admin@email.com', 1, 999999);


SET IDENTITY_INSERT [Part] OFF
INSERT INTO [Part]
  ([Id], [Name], [Category], [Price])
VALUES
  (1, 'Ceramic Brakes', 'Brakes', 80),
  (2, 'Organic Brakes', 'Brakes', 40),
  (3, 'Semi-Metallic Brakes', 'Brakes', 60),
  (4, 'Serpentine Belt', 'Belts', 25),
  (5, 'Fan Belt', 'Belts', 15),
  (6, 'Timing Belt', 'Belts', 25);



```
