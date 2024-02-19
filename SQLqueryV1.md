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

CREATE TABLE [User] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,

  [Money] integer,
)
GO

CREATE TABLE [Part] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Category] nvarchar(255) NOT NULL,
  [Price] integer NOT NULL,
)
GO


SET IDENTITY_INSERT [Car] ON
INSERT INTO [Car]
  ([Id], [Price], [Year], [Name], [Transmission], [Manufacturer], [Mileage], [ImageUrl], [Worth])
VALUES 
  (1, 1500, 1990, 'Civic SI Sedan', 'MT', 'Honda', 255000, 'https://i.imgur.com/nGWK571.jpg', 2200);
SET IDENTITY_INSERT [UserProfile] OFF
INSERT INTO [User]
  ([Id], [Name], [Email], [Money])
VALUES 
  (1, 'Admin', 'Admin@email.com', 999999);
SET IDENTITY_INSERT [Part] ON
INSERT INTO [Part]
  ([Id], [Name], [Category], [Price])
VALUES
  (1, 'Ceramic Brakes', 'Brakes', 80),
  (2, 'Organic Brakes', 'Brakes', 40),
  (3, 'Semi-Metallic Brakes', 'Brakes', 60),
  (4, 'Serpentine Belt', 'Belts', 25),
  (5, 'Fan Belt', 'Belts', 15),
  (6, 'Timing Belt', 'Belts', 25);
SET IDENTITY_INSERT [Post] OFF

```
