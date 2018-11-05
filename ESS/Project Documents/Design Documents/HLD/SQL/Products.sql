USE [8Aug_MIPL]
GO

/****** Object:  Table [Ecomm].[Products]    Script Date: 11/2/2018 3:05:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Ecomm].[Products](
	[Product_Id] [varchar](15) NOT NULL,
	[Category_Id] [varchar](15) NOT NULL,
	[Model_Number] [varchar](20) NOT NULL,
	[Model_Name] [varchar](max) NOT NULL,
	[Unit_Cost] [int] NOT NULL,
	[P_Description] [varchar](max) NOT NULL,
	[P_Image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Products_1] PRIMARY KEY CLUSTERED 
(
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [Ecomm].[Products]  WITH CHECK ADD FOREIGN KEY([Category_Id])
REFERENCES [Ecomm].[Categories] ([Category_Id])
GO


