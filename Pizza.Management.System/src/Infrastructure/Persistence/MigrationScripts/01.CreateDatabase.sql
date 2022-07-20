CREATE DATABASE [PizzaManagement]

GO

USE [PizzaManagement]

GO

CREATE TABLE [Pizza] (
						[Id] [int] NOT NULL IDENTITY(1,1),
						[Name] nvarchar(500) NOT NULL,
						[Price] float NOT NULL,
						Version timestamp NOT NULL,
						PRIMARY KEY CLUSTERED 
							(
								Id ASC
							)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
							) ON [PRIMARY];

CREATE TABLE [Customer] (
						[Id] [int] NOT NULL IDENTITY(1,1),
						[Name] nvarchar(500) NOT NULL,
						Version timestamp NOT NULL,
						PRIMARY KEY CLUSTERED 
							(
								Id ASC
							)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
							) ON [PRIMARY];

CREATE TABLE [Order] (
						[Id] [int] NOT NULL IDENTITY(1,1),
						[CustomerId] int NOT NULL,
						[Code] nvarchar(500) NOT NULL,
						[IsDelivered] bit NOT NULL,
						Version timestamp NOT NULL,
						PRIMARY KEY CLUSTERED 
							(
								Id ASC
							)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
							) ON [PRIMARY];

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY(CustomerId)
REFERENCES [dbo].Customer ([ID])
GO


CREATE TABLE [PizzaOrder] (
						[Id] [int] NOT NULL IDENTITY(1,1),
						[OrderId] int NOT NULL,
						[PizzaId] int NOT NULL,
						[Number] int NOT NULL,
						PRIMARY KEY CLUSTERED 
							(
								Id ASC
							)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
							) ON [PRIMARY];

ALTER TABLE [dbo].[PizzaOrder]  WITH CHECK ADD  CONSTRAINT [FK_PizzaOrder_Order] FOREIGN KEY(OrderId)
REFERENCES [dbo].[Order] ([ID])
GO

ALTER TABLE [dbo].[PizzaOrder]  WITH CHECK ADD  CONSTRAINT [FK_PizzaOrder_Pizza] FOREIGN KEY(PizzaId)
REFERENCES [dbo].[Pizza] ([ID])
GO

