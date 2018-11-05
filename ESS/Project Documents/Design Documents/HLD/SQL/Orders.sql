USE [8Aug_MIPL]
GO

/****** Object:  Table [Ecomm].[Orders]    Script Date: 11/2/2018 3:04:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Ecomm].[Orders](
	[Order_Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_Date] [date] NOT NULL,
	[Cart_Id] [int] NOT NULL,
	[Customer_Id] [int] NOT NULL,
	[Ship_Date] [date] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Order_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Ecomm].[Orders]  WITH CHECK ADD FOREIGN KEY([Cart_Id])
REFERENCES [Ecomm].[ShoppingCart] ([Cart_Id])
GO

ALTER TABLE [Ecomm].[Orders]  WITH CHECK ADD FOREIGN KEY([Customer_Id])
REFERENCES [Ecomm].[Customers] ([Customer_Id])
GO


