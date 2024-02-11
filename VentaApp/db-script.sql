USE [db_venta]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 04/01/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 04/01/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 04/01/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[StockMinimo] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 04/01/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaDetalle]    Script Date: 04/01/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaDetalle](
	[IdVentaDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_VentaDetalle] PRIMARY KEY CLUSTERED 
(
	[IdVentaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 
GO
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre]) VALUES (1, N'Computadora')
GO
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellidos]) VALUES (1, N'Pedro', N'Diaz')
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 
GO
INSERT [dbo].[Producto] ([IdProducto], [IdCategoria], [Nombre], [Stock], [StockMinimo], [PrecioUnitario]) VALUES (1, 1, N'Toshiba', 126, 1, CAST(3000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Producto] ([IdProducto], [IdCategoria], [Nombre], [Stock], [StockMinimo], [PrecioUnitario]) VALUES (2, 1, N'Dell', 148, 2, CAST(3500.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Venta] ON 
GO
INSERT [dbo].[Venta] ([IdVenta], [IdCliente], [Fecha], [Monto]) VALUES (10, 1, CAST(N'2023-09-23T18:25:20.217' AS DateTime), CAST(200.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Venta] ([IdVenta], [IdCliente], [Fecha], [Monto]) VALUES (11, 1, CAST(N'2023-09-23T18:31:14.380' AS DateTime), CAST(250.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Venta] ([IdVenta], [IdCliente], [Fecha], [Monto]) VALUES (12, 1, CAST(N'2023-09-23T20:11:58.667' AS DateTime), CAST(270.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Venta] ([IdVenta], [IdCliente], [Fecha], [Monto]) VALUES (1002, 1, CAST(N'2024-01-04T22:19:24.107' AS DateTime), CAST(20.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Venta] ([IdVenta], [IdCliente], [Fecha], [Monto]) VALUES (1003, 1, CAST(N'2024-01-04T22:21:46.370' AS DateTime), CAST(54.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Venta] OFF
GO
SET IDENTITY_INSERT [dbo].[VentaDetalle] ON 
GO
INSERT [dbo].[VentaDetalle] ([IdVentaDetalle], [IdVenta], [IdProducto], [Cantidad], [Precio], [SubTotal]) VALUES (10, 0, 1, 2, CAST(100.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[VentaDetalle] ([IdVentaDetalle], [IdVenta], [IdProducto], [Cantidad], [Precio], [SubTotal]) VALUES (11, 11, 1, 2, CAST(100.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[VentaDetalle] ([IdVentaDetalle], [IdVenta], [IdProducto], [Cantidad], [Precio], [SubTotal]) VALUES (12, 11, 2, 1, CAST(50.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[VentaDetalle] ([IdVentaDetalle], [IdVenta], [IdProducto], [Cantidad], [Precio], [SubTotal]) VALUES (13, 12, 1, 2, CAST(100.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[VentaDetalle] ([IdVentaDetalle], [IdVenta], [IdProducto], [Cantidad], [Precio], [SubTotal]) VALUES (14, 12, 2, 1, CAST(70.00 AS Decimal(18, 2)), CAST(70.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[VentaDetalle] ([IdVentaDetalle], [IdVenta], [IdProducto], [Cantidad], [Precio], [SubTotal]) VALUES (1011, 1002, 1, 2, CAST(10.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[VentaDetalle] ([IdVentaDetalle], [IdVenta], [IdProducto], [Cantidad], [Precio], [SubTotal]) VALUES (1012, 1003, 1, 3, CAST(10.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[VentaDetalle] ([IdVentaDetalle], [IdVenta], [IdProducto], [Cantidad], [Precio], [SubTotal]) VALUES (1013, 1003, 2, 2, CAST(12.00 AS Decimal(18, 2)), CAST(24.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[VentaDetalle] OFF
GO
