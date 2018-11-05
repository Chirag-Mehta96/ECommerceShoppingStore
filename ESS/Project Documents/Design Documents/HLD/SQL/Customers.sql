USE [8Aug_MIPL]
GO

/****** Object:  Table [Ecomm].[Customers]    Script Date: 11/2/2018 3:04:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Ecomm].[Customers](
	[Customer_Id] [int] IDENTITY(1,1) NOT NULL,
	[Full_Name] [varchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Password] [varchar](15) NOT NULL,
	[Mobile_No] [varchar](13) NOT NULL,
	[Delivery_Address] [varchar](80) NOT NULL,
 CONSTRAINT [PK_Ecomm.Customers] PRIMARY KEY CLUSTERED 
(
	[Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


