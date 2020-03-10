USE [Filmes]
GO

/****** Object:  Table [dbo].[CatalogoFilmes]    Script Date: 09/03/2020 22:59:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CatalogoFilmes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NULL,
	[Duracao] [varchar](50) NULL,
	[Ano] [varchar](50) NULL,
	[TipoMidia] [varchar](50) NULL,
	[Elenco] [varchar](100) NULL,
	[Direcao] [varchar](50) NULL,
 CONSTRAINT [PK_Titulo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


