USE [Doublep]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 22/12/2022 3:08:15 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Identifier] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[FkIdTypeIdenti] [int] NULL,
	[NumberIdentification] [char](10) NULL,
	[Email] [varchar](50) NULL,
	[DateCreation] [date] NULL,
	[NmaeLastNameConcat]  AS (([name]+' ')+[lastname]),
PRIMARY KEY CLUSTERED 
(
	[Identifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeIdenti]    Script Date: 22/12/2022 3:08:15 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeIdenti](
	[IdTypeIdenti] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](70) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTypeIdenti] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22/12/2022 3:08:15 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Identifier] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](70) NULL,
	[Password] [varchar](250) NULL,
	[DateCreation] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Identifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD FOREIGN KEY([FkIdTypeIdenti])
REFERENCES [dbo].[TypeIdenti] ([IdTypeIdenti])
GO
/****** Object:  StoredProcedure [dbo].[getPerons]    Script Date: 22/12/2022 3:08:15 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[getPerons] 
AS
Begin try 
BEGIN TRAN
	Select *
	From Persons	
END TRY
BEGIN CATCH
	PRINT Error_message()
END CATCH
GO
