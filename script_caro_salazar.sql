USE [BD_EXAMEN]
GO
/****** Object:  StoredProcedure [dbo].[usp_Actualizar_Banco]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Actualizar_Banco]
@Id_Banco int,
@Nombre_Banco varchar(50),
@Direccion_Banco varchar(150)
as
update T_Banco
set
	Nombre_Banco = @Nombre_Banco,
	Direccion_Banco = @Direccion_Banco
where
	Id_Banco = @Id_Banco

GO
/****** Object:  StoredProcedure [dbo].[usp_Actualizar_Orden]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Actualizar_Orden]
@Id_Orden_Pago int,
@Monto decimal(18,2),
@Moneda varchar(50)
as
update T_Orden_Pago
set
	Monto = @Monto,
	Moneda = @Moneda
where
	Id_Orden_Pago = @Id_Orden_Pago

GO
/****** Object:  StoredProcedure [dbo].[usp_Actualizar_Sucursal]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Actualizar_Sucursal]
@Id_Sucursal int,
@Nombre_Sucursal varchar(50),
@Direccion_Sucursal varchar(150),
@Id_Banco int
as

update T_Sucursal
set
	Nombre_Sucursal = @Nombre_Sucursal,
	Direccion_Sucursal = @Direccion_Sucursal
where
	Id_Sucursal = @Id_Sucursal


update T_Banco_Sucursal
set
	Id_Banco = @Id_Banco
where
	Id_Banco = @Id_Banco
	and Id_Sucursal = @Id_Sucursal
GO
/****** Object:  StoredProcedure [dbo].[usp_Eliminar_Banco]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Eliminar_Banco]
@Id_Banco int
as
update T_Banco
set Estado = 0
where Id_Banco = @Id_Banco
GO
/****** Object:  StoredProcedure [dbo].[usp_Eliminar_Orden]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Eliminar_Orden]
@Id_Orden_Pago int,
@Estado varchar(50)
as
update T_Orden_pago
set Estado = @Estado
where Id_Orden_Pago = @Id_Orden_Pago
GO
/****** Object:  StoredProcedure [dbo].[usp_Eliminar_Sucursal]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Eliminar_Sucursal]
@Id_Sucursal int
as
update T_Sucursal
set Estado = 0
where Id_Sucursal = @Id_Sucursal
GO
/****** Object:  StoredProcedure [dbo].[usp_Insertar_Banco]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Insertar_Banco]
@Nombre_Banco varchar(50),
@Direccion_Banco varchar(150)
as
insert into T_Banco
(
	[Nombre_Banco],
	[Direccion_Banco],
	[Fecha_Registro],
	Estado
)
values
(
	@Nombre_Banco,
	@Direccion_Banco,
	getdate(),
	1
)
GO
/****** Object:  StoredProcedure [dbo].[usp_Insertar_Orden]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Insertar_Orden]
@Monto decimal(18,2),
@Moneda varchar(150),
@Estado varchar(50),
@Id_Sucursal int
as
insert into T_Orden_Pago
(
	Monto,
	Moneda,
	Estado,
	[Fecha_Pago]
)
values
(
	@Monto,
	@Moneda,
	@Estado,
	getdate()
)

declare @Id_Orden_Pago int
set @Id_Orden_Pago = SCOPE_IDENTITY()

insert into T_OrdenPago_Sucursal
(
	[Id_Orden_Pago],
	[Id_Sucursal]
)
values
(
	@Id_Orden_Pago,
	@Id_Sucursal
)
GO
/****** Object:  StoredProcedure [dbo].[usp_Insertar_Sucursal]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Insertar_Sucursal]
@Nombre_Sucursal varchar(50),
@Direccion_Sucursal varchar(150),
@Id_Banco int
as
insert into T_Sucursal
(
	[Nombre_Sucursal],
	[Direccion_Sucursal],
	[Fecha_Registro],
	Estado
)
values
(
	@Nombre_Sucursal,
	@Direccion_Sucursal,
	getdate(),
	1
)

declare @Id_Sucursal int
set @Id_Sucursal = SCOPE_IDENTITY()

insert into T_Banco_Sucursal
(
	Id_Banco,
	Id_Sucursal
)
values
(
	@Id_Banco,
	@Id_Sucursal
)
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Banco]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Listar_Banco]
@Id_Banco int
as
select
	[Id_Banco],
	[Nombre_Banco],
	[Direccion_Banco],
	[Fecha_Registro],
	[Estado]
from T_Banco
where Estado = 1 and Id_Banco = @Id_Banco
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Bancos]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Listar_Bancos]
as
select
	[Id_Banco],
	[Nombre_Banco],
	[Direccion_Banco],
	[Fecha_Registro],
	[Estado]
from T_Banco
where Estado = 1
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Orden]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Listar_Orden]
as
select
	[Id_Orden_Pago],
	[Monto],
	[Moneda],
	[Estado],
	[Fecha_Pago]
from T_Orden_Pago
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Ordenes_Sucursal]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Listar_Ordenes_Sucursal]
@Id_Sucursal int,
@Moneda varchar(50)
as
select
	op.Id_Orden_Pago,
	op.Monto,
	op.Moneda,
	op.Estado,
	op.Fecha_Pago,
	s.Nombre_Sucursal,
	s.Direccion_Sucursal
from T_Orden_Pago op
inner join T_OrdenPago_Sucursal ops on op.Id_Orden_Pago = ops.Id_Orden_Pago
inner join T_Sucursal s on ops.Id_Sucursal = s.Id_Sucursal
where
	ops.Id_Sucursal = @Id_Sucursal
	and op.Moneda = @Moneda
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Sucursal]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Listar_Sucursal]
@Id_Sucursal int
as
select
	t.Id_Sucursal,
	[Nombre_Sucursal],
	[Direccion_Sucursal],
	t.Fecha_Registro,
	t.Estado,
	bs.Id_Banco,
	b.Nombre_Banco
from T_Sucursal t
inner join T_Banco_Sucursal bs on t.Id_Sucursal = bs.Id_Sucursal
inner join T_Banco b on bs.Id_Banco = b.Id_Banco
where t.Estado = 1 and t.Id_Sucursal = @Id_Sucursal
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Sucursales]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Listar_Sucursales]
as
select
	t.Id_Sucursal,
	[Nombre_Sucursal],
	[Direccion_Sucursal],
	t.Fecha_Registro,
	t.Estado,
	bs.Id_Banco,
	b.Nombre_Banco
from T_Sucursal t
inner join T_Banco_Sucursal bs on t.Id_Sucursal = bs.Id_Sucursal
inner join T_Banco b on bs.Id_Banco = b.Id_Banco
where t.Estado = 1
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Sucursales_Banco]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Listar_Sucursales_Banco]
@Id_Banco int
as
Select
	s.Id_Sucursal,
	s.Nombre_Sucursal,
	s.Direccion_Sucursal,
	s.Fecha_Registro,
	s.Estado,
	b.Nombre_Banco
from T_Sucursal s
inner join T_Banco_Sucursal bs on s.Id_Sucursal = bs.Id_Sucursal
inner join T_Banco b on bs.Id_Banco = b.Id_Banco
where
	bs.Id_Banco = @Id_Banco
GO
/****** Object:  Table [dbo].[T_Banco]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Banco](
	[Id_Banco] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Banco] [varchar](50) NULL,
	[Direccion_Banco] [varchar](150) NULL,
	[Fecha_Registro] [datetime] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_T_Banco] PRIMARY KEY CLUSTERED 
(
	[Id_Banco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Banco_Sucursal]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Banco_Sucursal](
	[Id_Banco] [int] NOT NULL,
	[Id_Sucursal] [int] NOT NULL,
 CONSTRAINT [PK_T_Banco_Sucursal] PRIMARY KEY CLUSTERED 
(
	[Id_Banco] ASC,
	[Id_Sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Orden_Pago]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Orden_Pago](
	[Id_Orden_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [decimal](18, 2) NULL,
	[Moneda] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[Fecha_Pago] [datetime] NULL,
 CONSTRAINT [PK_T_Orden_Pago] PRIMARY KEY CLUSTERED 
(
	[Id_Orden_Pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_OrdenPago_Sucursal]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_OrdenPago_Sucursal](
	[Id_Orden_Pago] [int] NOT NULL,
	[Id_Sucursal] [int] NOT NULL,
 CONSTRAINT [PK_T_OrdenPago_Sucursal] PRIMARY KEY CLUSTERED 
(
	[Id_Orden_Pago] ASC,
	[Id_Sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Sucursal]    Script Date: 15/05/2017 2:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Sucursal](
	[Id_Sucursal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Sucursal] [varchar](50) NULL,
	[Direccion_Sucursal] [varchar](150) NULL,
	[Fecha_Registro] [datetime] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_T_Sucursal] PRIMARY KEY CLUSTERED 
(
	[Id_Sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[T_Banco] ON 

INSERT [dbo].[T_Banco] ([Id_Banco], [Nombre_Banco], [Direccion_Banco], [Fecha_Registro], [Estado]) VALUES (1, N'Banco 001', N'testttttt', CAST(0x0000A6EE00000000 AS DateTime), 1)
INSERT [dbo].[T_Banco] ([Id_Banco], [Nombre_Banco], [Direccion_Banco], [Fecha_Registro], [Estado]) VALUES (2, N'Banco 002', N'testttt', CAST(0x0000A77000C42F4E AS DateTime), 1)
INSERT [dbo].[T_Banco] ([Id_Banco], [Nombre_Banco], [Direccion_Banco], [Fecha_Registro], [Estado]) VALUES (3, N'ddd', N'ddddd', CAST(0x0000A77100932A64 AS DateTime), 0)
INSERT [dbo].[T_Banco] ([Id_Banco], [Nombre_Banco], [Direccion_Banco], [Fecha_Registro], [Estado]) VALUES (4, N'Banco 4', N'test', CAST(0x0000A77100A3576C AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[T_Banco] OFF
INSERT [dbo].[T_Banco_Sucursal] ([Id_Banco], [Id_Sucursal]) VALUES (1, 1)
INSERT [dbo].[T_Banco_Sucursal] ([Id_Banco], [Id_Sucursal]) VALUES (1, 2)
INSERT [dbo].[T_Banco_Sucursal] ([Id_Banco], [Id_Sucursal]) VALUES (2, 3)
INSERT [dbo].[T_Banco_Sucursal] ([Id_Banco], [Id_Sucursal]) VALUES (2, 4)
INSERT [dbo].[T_Banco_Sucursal] ([Id_Banco], [Id_Sucursal]) VALUES (2, 5)
INSERT [dbo].[T_Banco_Sucursal] ([Id_Banco], [Id_Sucursal]) VALUES (2, 1002)
SET IDENTITY_INSERT [dbo].[T_Orden_Pago] ON 

INSERT [dbo].[T_Orden_Pago] ([Id_Orden_Pago], [Monto], [Moneda], [Estado], [Fecha_Pago]) VALUES (1, CAST(1000.00 AS Decimal(18, 2)), N'Soles', N'Pagada', CAST(0x0000A6F700000000 AS DateTime))
INSERT [dbo].[T_Orden_Pago] ([Id_Orden_Pago], [Monto], [Moneda], [Estado], [Fecha_Pago]) VALUES (2, CAST(2000.00 AS Decimal(18, 2)), N'Soles', N'Declinada', CAST(0x0000A6F700000000 AS DateTime))
INSERT [dbo].[T_Orden_Pago] ([Id_Orden_Pago], [Monto], [Moneda], [Estado], [Fecha_Pago]) VALUES (3, CAST(3000.00 AS Decimal(18, 2)), N'Soles', N'Fallida', CAST(0x0000A6F700000000 AS DateTime))
INSERT [dbo].[T_Orden_Pago] ([Id_Orden_Pago], [Monto], [Moneda], [Estado], [Fecha_Pago]) VALUES (4, CAST(4000.00 AS Decimal(18, 2)), N'Dolares', N'Anulada', CAST(0x0000A6F700000000 AS DateTime))
INSERT [dbo].[T_Orden_Pago] ([Id_Orden_Pago], [Monto], [Moneda], [Estado], [Fecha_Pago]) VALUES (5, CAST(5000.00 AS Decimal(18, 2)), N'Dolares', N'Pagada', CAST(0x0000A6F700000000 AS DateTime))
INSERT [dbo].[T_Orden_Pago] ([Id_Orden_Pago], [Monto], [Moneda], [Estado], [Fecha_Pago]) VALUES (6, CAST(6000.00 AS Decimal(18, 2)), N'Dolares', N'Fallida', CAST(0x0000A6F700000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[T_Orden_Pago] OFF
INSERT [dbo].[T_OrdenPago_Sucursal] ([Id_Orden_Pago], [Id_Sucursal]) VALUES (1, 1)
INSERT [dbo].[T_OrdenPago_Sucursal] ([Id_Orden_Pago], [Id_Sucursal]) VALUES (2, 1)
INSERT [dbo].[T_OrdenPago_Sucursal] ([Id_Orden_Pago], [Id_Sucursal]) VALUES (3, 2)
INSERT [dbo].[T_OrdenPago_Sucursal] ([Id_Orden_Pago], [Id_Sucursal]) VALUES (4, 3)
INSERT [dbo].[T_OrdenPago_Sucursal] ([Id_Orden_Pago], [Id_Sucursal]) VALUES (5, 4)
INSERT [dbo].[T_OrdenPago_Sucursal] ([Id_Orden_Pago], [Id_Sucursal]) VALUES (6, 5)
SET IDENTITY_INSERT [dbo].[T_Sucursal] ON 

INSERT [dbo].[T_Sucursal] ([Id_Sucursal], [Nombre_Sucursal], [Direccion_Sucursal], [Fecha_Registro], [Estado]) VALUES (1, N'Sucursal AAA', N'test', CAST(0x0000A6EE00000000 AS DateTime), 1)
INSERT [dbo].[T_Sucursal] ([Id_Sucursal], [Nombre_Sucursal], [Direccion_Sucursal], [Fecha_Registro], [Estado]) VALUES (2, N'Sucursal BBB', N'test', CAST(0x0000A6EE00000000 AS DateTime), 1)
INSERT [dbo].[T_Sucursal] ([Id_Sucursal], [Nombre_Sucursal], [Direccion_Sucursal], [Fecha_Registro], [Estado]) VALUES (3, N'Sucursal CCC', N'test', CAST(0x0000A6EE00000000 AS DateTime), 1)
INSERT [dbo].[T_Sucursal] ([Id_Sucursal], [Nombre_Sucursal], [Direccion_Sucursal], [Fecha_Registro], [Estado]) VALUES (4, N'Sucursal DDD', N'testttt', CAST(0x0000A6EE00000000 AS DateTime), 1)
INSERT [dbo].[T_Sucursal] ([Id_Sucursal], [Nombre_Sucursal], [Direccion_Sucursal], [Fecha_Registro], [Estado]) VALUES (5, N'Sucursal EEE', N'test', CAST(0x0000A6EE00000000 AS DateTime), 1)
INSERT [dbo].[T_Sucursal] ([Id_Sucursal], [Nombre_Sucursal], [Direccion_Sucursal], [Fecha_Registro], [Estado]) VALUES (1002, N'Sucursal 10', N'test', CAST(0x0000A77400138843 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[T_Sucursal] OFF
ALTER TABLE [dbo].[T_Banco_Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_T_Banco_Sucursal_T_Banco] FOREIGN KEY([Id_Banco])
REFERENCES [dbo].[T_Banco] ([Id_Banco])
GO
ALTER TABLE [dbo].[T_Banco_Sucursal] CHECK CONSTRAINT [FK_T_Banco_Sucursal_T_Banco]
GO
ALTER TABLE [dbo].[T_Banco_Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_T_Banco_Sucursal_T_Sucursal] FOREIGN KEY([Id_Sucursal])
REFERENCES [dbo].[T_Sucursal] ([Id_Sucursal])
GO
ALTER TABLE [dbo].[T_Banco_Sucursal] CHECK CONSTRAINT [FK_T_Banco_Sucursal_T_Sucursal]
GO
ALTER TABLE [dbo].[T_OrdenPago_Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_T_OrdenPago_Sucursal_T_Orden_Pago] FOREIGN KEY([Id_Orden_Pago])
REFERENCES [dbo].[T_Orden_Pago] ([Id_Orden_Pago])
GO
ALTER TABLE [dbo].[T_OrdenPago_Sucursal] CHECK CONSTRAINT [FK_T_OrdenPago_Sucursal_T_Orden_Pago]
GO
ALTER TABLE [dbo].[T_OrdenPago_Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_T_OrdenPago_Sucursal_T_Sucursal] FOREIGN KEY([Id_Sucursal])
REFERENCES [dbo].[T_Sucursal] ([Id_Sucursal])
GO
ALTER TABLE [dbo].[T_OrdenPago_Sucursal] CHECK CONSTRAINT [FK_T_OrdenPago_Sucursal_T_Sucursal]
GO
