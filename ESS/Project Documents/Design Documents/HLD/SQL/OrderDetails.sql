USE [8Aug_MIPL]
GO

/****** Object:  Table [Ecomm].[OrderDetails]    Script Date: 11/2/2018 3:04:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Ecomm].[OrderDetails](
	[Order_Id] [int] NOT NULL,
	[Product_Id] [varchar](15) NOT NULL,
	[Order_Quantity] [tinyint] NOT NULL,
	[Order_Unit_Cost] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [Ecomm].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([Order_Id])
REFERENCES [Ecomm].[Orders] ([Order_Id])
GO

ALTER TABLE [Ecomm].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([Product_Id])
REFERENCES [Ecomm].[Products] ([Product_Id])
GO


