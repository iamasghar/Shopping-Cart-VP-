# Shopping-Cart-VP-
DataBase is not included in this project...

Use this query to create Product Table :

CREATE TABLE [dbo].[Product](
	[Id] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL,
	[Image] [nvarchar](50) NULL,
	[Description] [nvarchar](350) NULL
);

Also change the connection string in DAL/DBCon.cs class.
