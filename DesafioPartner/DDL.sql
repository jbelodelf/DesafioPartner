USE MASTER
GO

CREATE DATABASE DESAFIO_PARTINER
GO

USE DESAFIO_PARTINER
GO

CREATE TABLE [dbo].[TbPatrimonio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[MarcaId] [bigint] NOT NULL,
	[Descricao] [nvarchar](100) NOT NULL,
	[NumTombo] [bigint] NOT NULL,
 CONSTRAINT [PK_IdPatrimonio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TbPatrimonio]  WITH CHECK ADD  CONSTRAINT [FK_TbPatrimonio_TbMarca] FOREIGN KEY([MarcaId])
REFERENCES [dbo].[TbMarca] ([MarcaId])
GO

ALTER TABLE [dbo].[TbPatrimonio] CHECK CONSTRAINT [FK_TbPatrimonio_TbMarca]
GO

CREATE TABLE [dbo].[TbMarca](
	[MarcaId] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](30) NOT NULL,
CONSTRAINT [PK_MarcaId] PRIMARY KEY CLUSTERED
(
   [MarcaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO




















