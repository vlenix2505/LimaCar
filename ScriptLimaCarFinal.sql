USE [master]
GO
/****** Object:  Database [LimaCar]    Script Date: 20/11/2023 04:33:31 ******/
CREATE DATABASE [LimaCar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LimaCar', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LimaCar.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LimaCar_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LimaCar_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LimaCar] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LimaCar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LimaCar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LimaCar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LimaCar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LimaCar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LimaCar] SET ARITHABORT OFF 
GO
ALTER DATABASE [LimaCar] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LimaCar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LimaCar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LimaCar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LimaCar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LimaCar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LimaCar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LimaCar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LimaCar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LimaCar] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LimaCar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LimaCar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LimaCar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LimaCar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LimaCar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LimaCar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LimaCar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LimaCar] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LimaCar] SET  MULTI_USER 
GO
ALTER DATABASE [LimaCar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LimaCar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LimaCar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LimaCar] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LimaCar] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LimaCar] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LimaCar] SET QUERY_STORE = ON
GO
ALTER DATABASE [LimaCar] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LimaCar]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 20/11/2023 04:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[CodigoCliente] [int] IDENTITY(1,1) NOT NULL,
	[Dni] [nvarchar](8) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](9) NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Pais] [nvarchar](100) NOT NULL,
	[Sexo] [nvarchar](9) NOT NULL,
	[Nombre_usuario] [nvarchar](100) NOT NULL,
	[Clave] [nvarchar](100) NOT NULL,
	[i_fechaCreacion] [datetime] NOT NULL,
	[i_fechaModificado] [datetime] NOT NULL,
	[i_creadoPor] [nvarchar](100) NOT NULL,
	[i_modificadoPor] [nvarchar](100) NOT NULL,
 CONSTRAINT [clientes_pk] PRIMARY KEY CLUSTERED 
(
	[CodigoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disponibilidad]    Script Date: 20/11/2023 04:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disponibilidad](
	[CodigoDisponibilidad] [int] IDENTITY(1,1) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[CodigoVehiculo] [int] NOT NULL,
 CONSTRAINT [Disponibilidad_pk] PRIMARY KEY CLUSTERED 
(
	[CodigoDisponibilidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoReserva]    Script Date: 20/11/2023 04:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoReserva](
	[CodigoEstadoReserva] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](250) NOT NULL,
 CONSTRAINT [solicitud_reserva_pk] PRIMARY KEY CLUSTERED 
(
	[CodigoEstadoReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 20/11/2023 04:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[CodigoMarca] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [marca_pk] PRIMARY KEY CLUSTERED 
(
	[CodigoMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 20/11/2023 04:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelo](
	[CodigoModelo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[CodigoMarca] [int] NOT NULL,
 CONSTRAINT [modelos_pk] PRIMARY KEY CLUSTERED 
(
	[CodigoModelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 20/11/2023 04:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[CodigoPago] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [money] NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[CodigoTipoPago] [int] NOT NULL,
 CONSTRAINT [Pago_pk] PRIMARY KEY CLUSTERED 
(
	[CodigoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 20/11/2023 04:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[CodigoReserva] [int] IDENTITY(1,1) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[Galones] [int] NOT NULL,
	[CodigoPago] [int] NULL,
	[CodigoEstadoReserva] [int] NOT NULL,
	[i_fechaCreacion] [datetime] NOT NULL,
	[i_creadoPor] [nvarchar](100) NOT NULL,
	[CodigoCliente] [int] NOT NULL,
	[CodigoVehiculo] [int] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[CodigoReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 20/11/2023 04:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPago](
	[CodigoTipoPago] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipo] [nvarchar](250) NOT NULL,
 CONSTRAINT [TipoPago_pk] PRIMARY KEY CLUSTERED 
(
	[CodigoTipoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipovehiculo]    Script Date: 20/11/2023 04:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipovehiculo](
	[CodigoTipoVehiculo] [int] IDENTITY(1,1) NOT NULL,
	[TipoVehiculo] [nvarchar](100) NOT NULL,
 CONSTRAINT [tipo_auto_pk] PRIMARY KEY CLUSTERED 
(
	[CodigoTipoVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 20/11/2023 04:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[CodigoVehiculo] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](100) NOT NULL,
	[Anio] [int] NOT NULL,
	[TipoCombustible] [nvarchar](100) NOT NULL,
	[Precio] [money] NOT NULL,
	[Capacidad] [int] NOT NULL,
	[Placa] [nvarchar](6) NOT NULL,
	[CodigoTipoVehiculo] [int] NOT NULL,
	[CodigoModelo] [int] NOT NULL,
	[ImagenVehiculo] [nvarchar](250) NOT NULL,
	[i_creadoPor] [nvarchar](100) NOT NULL,
	[i_modificadoPor] [nvarchar](100) NOT NULL,
	[i_fechaCreacion] [datetime] NOT NULL,
	[i_fechaModificado] [datetime] NOT NULL,
 CONSTRAINT [vehiculos_pk] PRIMARY KEY CLUSTERED 
(
	[CodigoVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([CodigoCliente], [Dni], [Nombre], [Apellidos], [Telefono], [Correo], [FechaNacimiento], [Pais], [Sexo], [Nombre_usuario], [Clave], [i_fechaCreacion], [i_fechaModificado], [i_creadoPor], [i_modificadoPor]) VALUES (1, N'73204565', N'Vlen', N'Messi', N'730525620', N'belen@upc.edu.pe', CAST(N'2005-05-25' AS Date), N'Argentina', N'Femenino', N'vlen', N'sara', CAST(N'2023-11-08T15:48:56.190' AS DateTime), CAST(N'2023-11-17T18:03:00.577' AS DateTime), N'Lenovo', N'Camila')
INSERT [dbo].[Cliente] ([CodigoCliente], [Dni], [Nombre], [Apellidos], [Telefono], [Correo], [FechaNacimiento], [Pais], [Sexo], [Nombre_usuario], [Clave], [i_fechaCreacion], [i_fechaModificado], [i_creadoPor], [i_modificadoPor]) VALUES (2, N'72951894', N'Cami', N'Torres', N'995115222', N'u202217059@upc.edu.pe', CAST(N'2003-06-22' AS Date), N'Perú', N'Femenino', N'cami', N'cami', CAST(N'2023-11-14T12:41:38.673' AS DateTime), CAST(N'2023-11-17T18:01:49.910' AS DateTime), N'Camila', N'Camila')
INSERT [dbo].[Cliente] ([CodigoCliente], [Dni], [Nombre], [Apellidos], [Telefono], [Correo], [FechaNacimiento], [Pais], [Sexo], [Nombre_usuario], [Clave], [i_fechaCreacion], [i_fechaModificado], [i_creadoPor], [i_modificadoPor]) VALUES (3, N'98758626', N'Gasparin', N'Lunares', N'998855663', N'gasparin.lunares@gmail.com', CAST(N'2005-10-17' AS Date), N'Colombia', N'Femenino', N'gasparin', N'gasparin', CAST(N'2023-11-17T17:58:17.800' AS DateTime), CAST(N'2023-11-17T17:58:55.747' AS DateTime), N'Camila', N'Camila')
INSERT [dbo].[Cliente] ([CodigoCliente], [Dni], [Nombre], [Apellidos], [Telefono], [Correo], [FechaNacimiento], [Pais], [Sexo], [Nombre_usuario], [Clave], [i_fechaCreacion], [i_fechaModificado], [i_creadoPor], [i_modificadoPor]) VALUES (4, N'87659325', N'Luciano', N'Lopez', N'968532654', N'luciano.lopez@hotmail.com', CAST(N'1999-09-15' AS Date), N'Perú', N'Masculino', N'luciano', N'luciano', CAST(N'2023-11-18T01:14:30.243' AS DateTime), CAST(N'2023-11-18T01:14:30.243' AS DateTime), N'Camila', N'Camila')
INSERT [dbo].[Cliente] ([CodigoCliente], [Dni], [Nombre], [Apellidos], [Telefono], [Correo], [FechaNacimiento], [Pais], [Sexo], [Nombre_usuario], [Clave], [i_fechaCreacion], [i_fechaModificado], [i_creadoPor], [i_modificadoPor]) VALUES (5, N'ND', N'Administrador', N'ND', N'ND', N'ND', CAST(N'2023-10-20' AS Date), N'ND', N'ND', N'admin', N'admin', CAST(N'2023-10-20T15:22:52.790' AS DateTime), CAST(N'2023-10-20T15:22:52.790' AS DateTime), N'ND', N'ND')
INSERT [dbo].[Cliente] ([CodigoCliente], [Dni], [Nombre], [Apellidos], [Telefono], [Correo], [FechaNacimiento], [Pais], [Sexo], [Nombre_usuario], [Clave], [i_fechaCreacion], [i_fechaModificado], [i_creadoPor], [i_modificadoPor]) VALUES (6, N'68574239', N'Rodrigo', N'Quispe', N'951536887', N'rodrigo.quispe@gmail.com', CAST(N'1990-11-23' AS Date), N'Perú', N'Masculino', N'rodro523', N'lima1', CAST(N'2023-11-20T01:58:22.420' AS DateTime), CAST(N'2023-11-20T01:58:22.420' AS DateTime), N'Camila', N'Camila')
INSERT [dbo].[Cliente] ([CodigoCliente], [Dni], [Nombre], [Apellidos], [Telefono], [Correo], [FechaNacimiento], [Pais], [Sexo], [Nombre_usuario], [Clave], [i_fechaCreacion], [i_fechaModificado], [i_creadoPor], [i_modificadoPor]) VALUES (7, N'45465231', N'Javier', N'Fernandini', N'963852456', N'javier.fernandini@gmail.com', CAST(N'1981-05-26' AS Date), N'Perú', N'Masculino', N'javier', N'patito11', CAST(N'2023-11-20T01:59:50.023' AS DateTime), CAST(N'2023-11-20T02:00:56.663' AS DateTime), N'Camila', N'Camila')
INSERT [dbo].[Cliente] ([CodigoCliente], [Dni], [Nombre], [Apellidos], [Telefono], [Correo], [FechaNacimiento], [Pais], [Sexo], [Nombre_usuario], [Clave], [i_fechaCreacion], [i_fechaModificado], [i_creadoPor], [i_modificadoPor]) VALUES (8, N'74185296', N'Lionel', N'Perez', N'741852963', N'lionel.perez@gmail.com', CAST(N'1992-02-11' AS Date), N'Argentina', N'Masculino', N'lionel30', N'miamigod', CAST(N'2023-11-20T02:02:58.703' AS DateTime), CAST(N'2023-11-20T02:02:58.703' AS DateTime), N'Camila', N'Camila')
INSERT [dbo].[Cliente] ([CodigoCliente], [Dni], [Nombre], [Apellidos], [Telefono], [Correo], [FechaNacimiento], [Pais], [Sexo], [Nombre_usuario], [Clave], [i_fechaCreacion], [i_fechaModificado], [i_creadoPor], [i_modificadoPor]) VALUES (9, N'85296387', N'Ronald', N'Marchan', N'985632417', N'ronald.marchan@gmail.com', CAST(N'1979-09-18' AS Date), N'Perú', N'Masculino', N'ronald', N'ayudin856', CAST(N'2023-11-20T02:04:38.390' AS DateTime), CAST(N'2023-11-20T02:04:38.390' AS DateTime), N'Camila', N'Camila')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Disponibilidad] ON 

INSERT [dbo].[Disponibilidad] ([CodigoDisponibilidad], [FechaInicio], [FechaFin], [CodigoVehiculo]) VALUES (50, CAST(N'2023-11-21T00:00:00.000' AS DateTime), CAST(N'2023-11-23T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Disponibilidad] ([CodigoDisponibilidad], [FechaInicio], [FechaFin], [CodigoVehiculo]) VALUES (51, CAST(N'2023-11-22T00:00:00.000' AS DateTime), CAST(N'2023-11-25T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Disponibilidad] ([CodigoDisponibilidad], [FechaInicio], [FechaFin], [CodigoVehiculo]) VALUES (52, CAST(N'2023-11-24T00:00:00.000' AS DateTime), CAST(N'2023-11-27T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Disponibilidad] ([CodigoDisponibilidad], [FechaInicio], [FechaFin], [CodigoVehiculo]) VALUES (53, CAST(N'2023-12-01T00:00:00.000' AS DateTime), CAST(N'2023-12-05T00:00:00.000' AS DateTime), 13)
SET IDENTITY_INSERT [dbo].[Disponibilidad] OFF
GO
SET IDENTITY_INSERT [dbo].[EstadoReserva] ON 

INSERT [dbo].[EstadoReserva] ([CodigoEstadoReserva], [Descripcion]) VALUES (1, N'Aprobado')
INSERT [dbo].[EstadoReserva] ([CodigoEstadoReserva], [Descripcion]) VALUES (2, N'En proceso')
INSERT [dbo].[EstadoReserva] ([CodigoEstadoReserva], [Descripcion]) VALUES (3, N'Cancelado')
SET IDENTITY_INSERT [dbo].[EstadoReserva] OFF
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 

INSERT [dbo].[Marca] ([CodigoMarca], [Nombre]) VALUES (1, N'Toyota')
INSERT [dbo].[Marca] ([CodigoMarca], [Nombre]) VALUES (2, N'Kia')
INSERT [dbo].[Marca] ([CodigoMarca], [Nombre]) VALUES (3, N'Audi')
INSERT [dbo].[Marca] ([CodigoMarca], [Nombre]) VALUES (4, N'Mitsubishi')
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Modelo] ON 

INSERT [dbo].[Modelo] ([CodigoModelo], [Nombre], [CodigoMarca]) VALUES (1, N'Hilux', 1)
INSERT [dbo].[Modelo] ([CodigoModelo], [Nombre], [CodigoMarca]) VALUES (2, N'Rav4', 1)
INSERT [dbo].[Modelo] ([CodigoModelo], [Nombre], [CodigoMarca]) VALUES (3, N'Corolla', 1)
INSERT [dbo].[Modelo] ([CodigoModelo], [Nombre], [CodigoMarca]) VALUES (4, N'Sorento', 2)
INSERT [dbo].[Modelo] ([CodigoModelo], [Nombre], [CodigoMarca]) VALUES (5, N'Cerato', 2)
INSERT [dbo].[Modelo] ([CodigoModelo], [Nombre], [CodigoMarca]) VALUES (6, N'Rio', 2)
INSERT [dbo].[Modelo] ([CodigoModelo], [Nombre], [CodigoMarca]) VALUES (7, N'Q2', 3)
INSERT [dbo].[Modelo] ([CodigoModelo], [Nombre], [CodigoMarca]) VALUES (8, N'A1', 3)
INSERT [dbo].[Modelo] ([CodigoModelo], [Nombre], [CodigoMarca]) VALUES (9, N'A5', 3)
INSERT [dbo].[Modelo] ([CodigoModelo], [Nombre], [CodigoMarca]) VALUES (10, N'L200', 4)
INSERT [dbo].[Modelo] ([CodigoModelo], [Nombre], [CodigoMarca]) VALUES (11, N'Lancer', 4)
SET IDENTITY_INSERT [dbo].[Modelo] OFF
GO
SET IDENTITY_INSERT [dbo].[Pago] ON 

INSERT [dbo].[Pago] ([CodigoPago], [Monto], [FechaPago], [CodigoTipoPago]) VALUES (31, 600.0000, CAST(N'2023-11-20T02:59:54.763' AS DateTime), 2)
INSERT [dbo].[Pago] ([CodigoPago], [Monto], [FechaPago], [CodigoTipoPago]) VALUES (32, 800.0000, CAST(N'2023-11-20T03:02:32.777' AS DateTime), 3)
INSERT [dbo].[Pago] ([CodigoPago], [Monto], [FechaPago], [CodigoTipoPago]) VALUES (33, 425.0000, CAST(N'2023-11-20T04:26:24.930' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[Pago] OFF
GO
SET IDENTITY_INSERT [dbo].[Reserva] ON 

INSERT [dbo].[Reserva] ([CodigoReserva], [FechaInicio], [FechaFin], [Galones], [CodigoPago], [CodigoEstadoReserva], [i_fechaCreacion], [i_creadoPor], [CodigoCliente], [CodigoVehiculo]) VALUES (44, CAST(N'2023-11-21T00:00:00.000' AS DateTime), CAST(N'2023-11-23T00:00:00.000' AS DateTime), 15, 31, 1, CAST(N'2023-11-20T02:59:10.387' AS DateTime), N'Camila', 2, 10)
INSERT [dbo].[Reserva] ([CodigoReserva], [FechaInicio], [FechaFin], [Galones], [CodigoPago], [CodigoEstadoReserva], [i_fechaCreacion], [i_creadoPor], [CodigoCliente], [CodigoVehiculo]) VALUES (45, CAST(N'2023-11-22T00:00:00.000' AS DateTime), CAST(N'2023-11-25T00:00:00.000' AS DateTime), 13, NULL, 3, CAST(N'2023-11-20T02:59:42.327' AS DateTime), N'Camila', 2, 1)
INSERT [dbo].[Reserva] ([CodigoReserva], [FechaInicio], [FechaFin], [Galones], [CodigoPago], [CodigoEstadoReserva], [i_fechaCreacion], [i_creadoPor], [CodigoCliente], [CodigoVehiculo]) VALUES (46, CAST(N'2023-11-24T00:00:00.000' AS DateTime), CAST(N'2023-11-27T00:00:00.000' AS DateTime), 12, 32, 1, CAST(N'2023-11-20T03:02:22.593' AS DateTime), N'Camila', 6, 10)
INSERT [dbo].[Reserva] ([CodigoReserva], [FechaInicio], [FechaFin], [Galones], [CodigoPago], [CodigoEstadoReserva], [i_fechaCreacion], [i_creadoPor], [CodigoCliente], [CodigoVehiculo]) VALUES (47, CAST(N'2023-12-01T00:00:00.000' AS DateTime), CAST(N'2023-12-05T00:00:00.000' AS DateTime), 13, 33, 1, CAST(N'2023-11-20T04:26:12.370' AS DateTime), N'Camila', 1, 13)
SET IDENTITY_INSERT [dbo].[Reserva] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoPago] ON 

INSERT [dbo].[TipoPago] ([CodigoTipoPago], [NombreTipo]) VALUES (1, N'MasterCard')
INSERT [dbo].[TipoPago] ([CodigoTipoPago], [NombreTipo]) VALUES (2, N'Visa')
INSERT [dbo].[TipoPago] ([CodigoTipoPago], [NombreTipo]) VALUES (3, N'American Express')
SET IDENTITY_INSERT [dbo].[TipoPago] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipovehiculo] ON 

INSERT [dbo].[Tipovehiculo] ([CodigoTipoVehiculo], [TipoVehiculo]) VALUES (1, N'Auto')
INSERT [dbo].[Tipovehiculo] ([CodigoTipoVehiculo], [TipoVehiculo]) VALUES (2, N'Camioneta')
SET IDENTITY_INSERT [dbo].[Tipovehiculo] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] ON 

INSERT [dbo].[Vehiculo] ([CodigoVehiculo], [Color], [Anio], [TipoCombustible], [Precio], [Capacidad], [Placa], [CodigoTipoVehiculo], [CodigoModelo], [ImagenVehiculo], [i_creadoPor], [i_modificadoPor], [i_fechaCreacion], [i_fechaModificado]) VALUES (1, N'Plateado', 2022, N'Gasolina', 80.0000, 5, N'BDM573', 1, 3, N'https://www.toyotacorolla.com.pe/assets/images/corolla-plata.png', N'Camila', N'Camila', CAST(N'2023-11-14T03:44:56.173' AS DateTime), CAST(N'2023-11-14T03:44:56.173' AS DateTime))
INSERT [dbo].[Vehiculo] ([CodigoVehiculo], [Color], [Anio], [TipoCombustible], [Precio], [Capacidad], [Placa], [CodigoTipoVehiculo], [CodigoModelo], [ImagenVehiculo], [i_creadoPor], [i_modificadoPor], [i_fechaCreacion], [i_fechaModificado]) VALUES (2, N'Azul', 2021, N'Gasolina', 85.0000, 5, N'F1J899', 1, 5, N'https://www.santaclara.com.pe/uploads/kia-cerato-2022-pequeno.png', N'Camila', N'Camila', CAST(N'2023-11-14T09:35:25.713' AS DateTime), CAST(N'2023-11-14T17:12:26.600' AS DateTime))
INSERT [dbo].[Vehiculo] ([CodigoVehiculo], [Color], [Anio], [TipoCombustible], [Precio], [Capacidad], [Placa], [CodigoTipoVehiculo], [CodigoModelo], [ImagenVehiculo], [i_creadoPor], [i_modificadoPor], [i_fechaCreacion], [i_fechaModificado]) VALUES (3, N'Negro', 2023, N'Petroleo', 190.0000, 5, N'EFT965', 2, 1, N'https://toyotacoatzacoalcos.com/Assets/ModelosNuevos/Img/Modelos/hilux/23/Colores/negro.png', N'Camila', N'Camila', CAST(N'2023-11-14T09:21:50.967' AS DateTime), CAST(N'2023-11-15T09:15:04.727' AS DateTime))
INSERT [dbo].[Vehiculo] ([CodigoVehiculo], [Color], [Anio], [TipoCombustible], [Precio], [Capacidad], [Placa], [CodigoTipoVehiculo], [CodigoModelo], [ImagenVehiculo], [i_creadoPor], [i_modificadoPor], [i_fechaCreacion], [i_fechaModificado]) VALUES (4, N'Blanco', 2023, N'Gasolina', 170.0000, 5, N'PKI965', 2, 2, N'https://vehicle-images.dealerinspire.com/stock-images/chrome/619768ca88ad744161b0ace2d2e33d8c.png', N'Camila', N'Camila', CAST(N'2023-11-14T09:25:25.957' AS DateTime), CAST(N'2023-11-14T09:25:25.957' AS DateTime))
INSERT [dbo].[Vehiculo] ([CodigoVehiculo], [Color], [Anio], [TipoCombustible], [Precio], [Capacidad], [Placa], [CodigoTipoVehiculo], [CodigoModelo], [ImagenVehiculo], [i_creadoPor], [i_modificadoPor], [i_fechaCreacion], [i_fechaModificado]) VALUES (5, N'Blanco', 2022, N'Gasolina', 165.0000, 7, N'BCD876', 2, 4, N'https://images.dealer.com/ddc/vehicles/2022/Kia/Sorento%20Plug-In%20Hybrid/SUV/perspective/front-left/2022_24.png', N'Camila', N'Camila', CAST(N'2023-11-14T09:32:52.093' AS DateTime), CAST(N'2023-11-14T09:32:52.093' AS DateTime))
INSERT [dbo].[Vehiculo] ([CodigoVehiculo], [Color], [Anio], [TipoCombustible], [Precio], [Capacidad], [Placa], [CodigoTipoVehiculo], [CodigoModelo], [ImagenVehiculo], [i_creadoPor], [i_modificadoPor], [i_fechaCreacion], [i_fechaModificado]) VALUES (6, N'Rojo', 2020, N'Gasolina', 70.0000, 6, N'WER859', 1, 6, N'https://d1extt4q0kbmr.cloudfront.net/wp-content/uploads/2019/10/PORTADA.png', N'Camila', N'Camila', CAST(N'2023-11-14T17:04:15.450' AS DateTime), CAST(N'2023-11-14T17:04:15.450' AS DateTime))
INSERT [dbo].[Vehiculo] ([CodigoVehiculo], [Color], [Anio], [TipoCombustible], [Precio], [Capacidad], [Placa], [CodigoTipoVehiculo], [CodigoModelo], [ImagenVehiculo], [i_creadoPor], [i_modificadoPor], [i_fechaCreacion], [i_fechaModificado]) VALUES (9, N'Blanco', 2021, N'Gasolina', 300.0000, 5, N'A3T658', 2, 7, N'https://www.autosvalls.com/wp-content/uploads/2021/04/Audi-Q2.png', N'Camila', N'Camila', CAST(N'2023-11-14T23:06:47.293' AS DateTime), CAST(N'2023-11-14T23:06:47.293' AS DateTime))
INSERT [dbo].[Vehiculo] ([CodigoVehiculo], [Color], [Anio], [TipoCombustible], [Precio], [Capacidad], [Placa], [CodigoTipoVehiculo], [CodigoModelo], [ImagenVehiculo], [i_creadoPor], [i_modificadoPor], [i_fechaCreacion], [i_fechaModificado]) VALUES (10, N'Gris', 2022, N'Gasolina', 200.0000, 4, N'L3N758', 1, 8, N'https://www.pngplay.com/wp-content/uploads/13/Audi-A1-PNG-HD-Quality.png', N'Camila', N'Camila', CAST(N'2023-11-14T23:09:16.073' AS DateTime), CAST(N'2023-11-14T23:10:33.777' AS DateTime))
INSERT [dbo].[Vehiculo] ([CodigoVehiculo], [Color], [Anio], [TipoCombustible], [Precio], [Capacidad], [Placa], [CodigoTipoVehiculo], [CodigoModelo], [ImagenVehiculo], [i_creadoPor], [i_modificadoPor], [i_fechaCreacion], [i_fechaModificado]) VALUES (11, N'Azul', 2022, N'Gasolina', 220.0000, 4, N'RYN987', 1, 9, N'https://mediaservice.audi.com/media/cdb/data/28d896be-5e3a-4ac1-bfb2-2b3938aba0a5.jpg', N'Camila', N'Camila', CAST(N'2023-11-14T23:10:25.943' AS DateTime), CAST(N'2023-11-14T23:10:25.943' AS DateTime))
INSERT [dbo].[Vehiculo] ([CodigoVehiculo], [Color], [Anio], [TipoCombustible], [Precio], [Capacidad], [Placa], [CodigoTipoVehiculo], [CodigoModelo], [ImagenVehiculo], [i_creadoPor], [i_modificadoPor], [i_fechaCreacion], [i_fechaModificado]) VALUES (12, N'Gris', 2022, N'Petroleo', 200.0000, 5, N'REP965', 2, 10, N'https://mitsubishi.cr/wp-content/uploads/2020/03/Foto-header-621x386px-1.png', N'Camila', N'Camila', CAST(N'2023-11-14T23:13:26.747' AS DateTime), CAST(N'2023-11-14T23:13:26.747' AS DateTime))
INSERT [dbo].[Vehiculo] ([CodigoVehiculo], [Color], [Anio], [TipoCombustible], [Precio], [Capacidad], [Placa], [CodigoTipoVehiculo], [CodigoModelo], [ImagenVehiculo], [i_creadoPor], [i_modificadoPor], [i_fechaCreacion], [i_fechaModificado]) VALUES (13, N'Azul', 2022, N'Gasolina', 85.0000, 5, N'AMU254', 1, 11, N'https://i.pinimg.com/originals/2f/11/b6/2f11b63190ff3ecf66ca78d8b6c7b7e7.png', N'Camila', N'Camila', CAST(N'2023-11-14T23:15:28.003' AS DateTime), CAST(N'2023-11-14T23:15:28.003' AS DateTime))
SET IDENTITY_INSERT [dbo].[Vehiculo] OFF
GO
ALTER TABLE [dbo].[Disponibilidad]  WITH CHECK ADD  CONSTRAINT [disponibilidad_vehiculos] FOREIGN KEY([CodigoVehiculo])
REFERENCES [dbo].[Vehiculo] ([CodigoVehiculo])
GO
ALTER TABLE [dbo].[Disponibilidad] CHECK CONSTRAINT [disponibilidad_vehiculos]
GO
ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD  CONSTRAINT [modelos_marcas] FOREIGN KEY([CodigoMarca])
REFERENCES [dbo].[Marca] ([CodigoMarca])
GO
ALTER TABLE [dbo].[Modelo] CHECK CONSTRAINT [modelos_marcas]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [pagos_tipos_de_pago] FOREIGN KEY([CodigoTipoPago])
REFERENCES [dbo].[TipoPago] ([CodigoTipoPago])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [pagos_tipos_de_pago]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [reservas_clientes] FOREIGN KEY([CodigoCliente])
REFERENCES [dbo].[Cliente] ([CodigoCliente])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [reservas_clientes]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [reservas_estado_reserva] FOREIGN KEY([CodigoEstadoReserva])
REFERENCES [dbo].[EstadoReserva] ([CodigoEstadoReserva])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [reservas_estado_reserva]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [reservas_pagos] FOREIGN KEY([CodigoPago])
REFERENCES [dbo].[Pago] ([CodigoPago])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [reservas_pagos]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [reservas_vehiculos] FOREIGN KEY([CodigoVehiculo])
REFERENCES [dbo].[Vehiculo] ([CodigoVehiculo])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [reservas_vehiculos]
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD  CONSTRAINT [vehiculos_modelos] FOREIGN KEY([CodigoModelo])
REFERENCES [dbo].[Modelo] ([CodigoModelo])
GO
ALTER TABLE [dbo].[Vehiculo] CHECK CONSTRAINT [vehiculos_modelos]
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD  CONSTRAINT [vehiculos_tipos_vehiculo] FOREIGN KEY([CodigoTipoVehiculo])
REFERENCES [dbo].[Tipovehiculo] ([CodigoTipoVehiculo])
GO
ALTER TABLE [dbo].[Vehiculo] CHECK CONSTRAINT [vehiculos_tipos_vehiculo]
GO
/****** Object:  StoredProcedure [dbo].[usp_ListarVehiculosCliente]    Script Date: 20/11/2023 04:33:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ListarVehiculosCliente]
AS
BEGIN
    SELECT CodigoVehiculo,Placa,Anio,Color, M2.Nombre AS Marca,
       M.Nombre As Modelo, T.TipoVehiculo, Capacidad,
       Precio FROM Vehiculo V
       JOIN Tipovehiculo T on V.CodigoTipoVehiculo = T.CodigoTipoVehiculo
       JOIN Modelo M on M.CodigoModelo = V.CodigoModelo
       JOIN Marca M2 on M2.CodigoMarca = M.CodigoMarca
end
GO
USE [master]
GO
ALTER DATABASE [LimaCar] SET  READ_WRITE 
GO
