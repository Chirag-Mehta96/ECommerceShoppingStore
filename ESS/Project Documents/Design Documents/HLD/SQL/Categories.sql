USE [8Aug_MIPL]
GO

/****** Object:  Table [Ecomm].[Categories]    Script Date: 11/2/2018 3:04:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Ecomm].[Categories](
	[Category_Id] [varchar](15) NOT NULL,
	[Category_Name] [varchar](20) NOT NULL,
	[C_Description] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


