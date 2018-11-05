USE [8Aug_MIPL]
GO

/****** Object:  Table [Ecomm].[ShoppingCart]    Script Date: 11/2/2018 3:05:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Ecomm].[ShoppingCart](
	[Cart_Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Product_Id] [varchar](15) NOT NULL,
	[Date_Created] [date] NOT NULL,
 CONSTRAINT [PK_ShoppingCart] PRIMARY KEY CLUSTERED 
(
	[Cart_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [Ecomm].[ShoppingCart]  WITH CHECK ADD FOREIGN KEY([Product_Id])
REFERENCES [Ecomm].[Products] ([Product_Id])
GO


