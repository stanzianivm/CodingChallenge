USE [DBContactos]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 04/11/2020 17:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[CiudadId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[CodigoPostal] [int] NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[CiudadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacto]    Script Date: 04/11/2020 17:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacto](
	[ContactoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Empresa] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[FechaNacimiento] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[DireccionId] [int] NOT NULL,
	[ImagenPerfil] [nvarchar](50) NULL,
 CONSTRAINT [PK_Contacto] PRIMARY KEY CLUSTERED 
(
	[ContactoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 04/11/2020 17:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direccion](
	[DireccionId] [int] IDENTITY(1,1) NOT NULL,
	[CiudadId] [int] NOT NULL,
	[Calle] [nvarchar](50) NOT NULL,
	[Dpto] [nchar](10) NULL,
	[Piso] [int] NULL,
	[NumeroCasa] [int] NOT NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[DireccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 04/11/2020 17:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[ProvinciaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[ProvinciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ciudad] ON 

INSERT [dbo].[Ciudad] ([CiudadId], [Nombre], [ProvinciaId], [CodigoPostal]) VALUES (1, N'La Plata', 1, 1900)
INSERT [dbo].[Ciudad] ([CiudadId], [Nombre], [ProvinciaId], [CodigoPostal]) VALUES (2, N'Avellaneda', 1, 1870)
INSERT [dbo].[Ciudad] ([CiudadId], [Nombre], [ProvinciaId], [CodigoPostal]) VALUES (3, N'Cosquin', 2, 123)
INSERT [dbo].[Ciudad] ([CiudadId], [Nombre], [ProvinciaId], [CodigoPostal]) VALUES (4, N'Villa Carlos Paz', 2, 321)
SET IDENTITY_INSERT [dbo].[Ciudad] OFF
SET IDENTITY_INSERT [dbo].[Contacto] ON 

INSERT [dbo].[Contacto] ([ContactoId], [Nombre], [Empresa], [Email], [FechaNacimiento], [Telefono], [DireccionId], [ImagenPerfil]) VALUES (9, N'thomas', N'thomasempresa', N'thomas@algo.com', N'01/02/1990', N'123456', 17, NULL)
INSERT [dbo].[Contacto] ([ContactoId], [Nombre], [Empresa], [Email], [FechaNacimiento], [Telefono], [DireccionId], [ImagenPerfil]) VALUES (10, N'Victor Manuel', N'empresa', N'victor@algo.com', N'01/02/1990', N'123456', 18, NULL)
INSERT [dbo].[Contacto] ([ContactoId], [Nombre], [Empresa], [Email], [FechaNacimiento], [Telefono], [DireccionId], [ImagenPerfil]) VALUES (11, N'Juan Ignacio', N'soft', N'juan@algo.com', N'01/02/1990', N'123456', 19, NULL)
INSERT [dbo].[Contacto] ([ContactoId], [Nombre], [Empresa], [Email], [FechaNacimiento], [Telefono], [DireccionId], [ImagenPerfil]) VALUES (14, N'Martin', N'soft', N'martin@algo.com', N'19/09/1995', N'12345678', 22, NULL)
SET IDENTITY_INSERT [dbo].[Contacto] OFF
SET IDENTITY_INSERT [dbo].[Direccion] ON 

INSERT [dbo].[Direccion] ([DireccionId], [CiudadId], [Calle], [Dpto], [Piso], [NumeroCasa]) VALUES (17, 3, N'27', NULL, NULL, 123)
INSERT [dbo].[Direccion] ([DireccionId], [CiudadId], [Calle], [Dpto], [Piso], [NumeroCasa]) VALUES (18, 2, N'123', NULL, NULL, 123)
INSERT [dbo].[Direccion] ([DireccionId], [CiudadId], [Calle], [Dpto], [Piso], [NumeroCasa]) VALUES (19, 3, N'1', NULL, NULL, 123)
INSERT [dbo].[Direccion] ([DireccionId], [CiudadId], [Calle], [Dpto], [Piso], [NumeroCasa]) VALUES (22, 2, N'27', NULL, NULL, 774)
SET IDENTITY_INSERT [dbo].[Direccion] OFF
SET IDENTITY_INSERT [dbo].[Provincia] ON 

INSERT [dbo].[Provincia] ([ProvinciaId], [Nombre]) VALUES (1, N'Buenos Aires')
INSERT [dbo].[Provincia] ([ProvinciaId], [Nombre]) VALUES (2, N'Cordoba')
SET IDENTITY_INSERT [dbo].[Provincia] OFF
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Provincia] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincia] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Provincia]
GO
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_Direccion] FOREIGN KEY([DireccionId])
REFERENCES [dbo].[Direccion] ([DireccionId])
GO
ALTER TABLE [dbo].[Contacto] CHECK CONSTRAINT [FK_Contacto_Direccion]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Ciudad] FOREIGN KEY([CiudadId])
REFERENCES [dbo].[Ciudad] ([CiudadId])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Ciudad]
GO
