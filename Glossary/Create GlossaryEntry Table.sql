USE [Glossary]
GO

/****** Object:  Table [dbo].[GlossaryEntry]    Script Date: 09/27/2010 21:47:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GlossaryEntry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Term] [nvarchar](250) NOT NULL,
	[Definition] [nvarchar](4000) NULL,
 CONSTRAINT [PK_GlossaryEntry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


