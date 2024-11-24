USE [BSDB]
GO
/****** Object:  Table [dbo].[tblAdmin]    Script Date: 11/25/2024 2:36:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAdmin](
	[Id] [nvarchar](250) NULL,
	[Salutation] [nvarchar](250) NOT NULL,
	[AdminName] [nvarchar](250) NOT NULL,
	[AdminUserName] [nvarchar](250) NOT NULL,
	[AdminEmail] [nvarchar](250) NOT NULL,
	[AdminMobile] [nvarchar](250) NOT NULL,
	[AdminPassword] [nvarchar](250) NOT NULL,
	[AdminRole] [nvarchar](250) NOT NULL,
	[EncryptPassword] [nvarchar](250) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBooking]    Script Date: 11/25/2024 2:36:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBooking](
	[Id] [nvarchar](250) NULL,
	[CustomerId] [nvarchar](250) NULL,
	[HotelId] [nvarchar](250) NULL,
	[NoOfRoom] [int] NOT NULL,
	[CheckInDate] [datetime] NOT NULL,
	[CheckOutDate] [datetime] NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[BookingStatus] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBookingRoom]    Script Date: 11/25/2024 2:36:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBookingRoom](
	[Id] [nvarchar](250) NULL,
	[RoomId] [nvarchar](250) NOT NULL,
	[BookingId] [nvarchar](250) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 11/25/2024 2:36:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[Id] [nvarchar](250) NULL,
	[Salutation] [nvarchar](50) NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[FullName] [nvarchar](511) NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHotel]    Script Date: 11/25/2024 2:36:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHotel](
	[Id] [nvarchar](250) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](500) NULL,
	[Email] [nvarchar](255) NULL,
	[Phone] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblInvoice]    Script Date: 11/25/2024 2:36:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInvoice](
	[Id] [nvarchar](250) NULL,
	[InvoiceNo] [nvarchar](150) NOT NULL,
	[BookingId] [nvarchar](250) NOT NULL,
	[InvoiceAmount] [decimal](18, 2) NOT NULL,
	[PaymentStatus] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPayment]    Script Date: 11/25/2024 2:36:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPayment](
	[Id] [nvarchar](250) NULL,
	[InvoiceId] [nvarchar](250) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[PaymentMethod] [nvarchar](350) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[PaymentDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRoom]    Script Date: 11/25/2024 2:36:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRoom](
	[Id] [nvarchar](250) NOT NULL,
	[HotelId] [nvarchar](250) NULL,
	[RoomNumber] [nvarchar](50) NOT NULL,
	[RoomType] [nvarchar](100) NOT NULL,
	[Capacity] [int] NOT NULL,
	[PricePerNight] [decimal](18, 2) NOT NULL,
	[RoomStatus] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblAdmin] ([Id], [Salutation], [AdminName], [AdminUserName], [AdminEmail], [AdminMobile], [AdminPassword], [AdminRole], [EncryptPassword], [Status], [CreatedDate], [ModifiedDate], [CreatedBy]) VALUES (N'324324324', N'Ms', N'zinmar', N'zinmar', N'zinmar@gmail.com', N'345435', N'123', N'Admin', N'123', N'Active', CAST(N'2024-12-03T00:00:00.000' AS DateTime), NULL, N'dfdgfdg')
GO
INSERT [dbo].[tblHotel] ([Id], [Name], [Address], [Email], [Phone], [Description], [Status], [CreatedDate], [ModifiedDate], [CreatedBy]) VALUES (N'HTL--166d4e87-8ade-4152-9686-fd2ea0271be0', N'HotelA', N'yangon', N'yango@gmail.com', N'09487586786', NULL, N'Active', CAST(N'2024-11-24T21:10:49.303' AS DateTime), CAST(N'2024-11-24T21:12:01.120' AS DateTime), N'')
GO
INSERT [dbo].[tblHotel] ([Id], [Name], [Address], [Email], [Phone], [Description], [Status], [CreatedDate], [ModifiedDate], [CreatedBy]) VALUES (N'HTL--e59b7a8a-69db-4e40-9b00-4b5908c3739b', N'dfdsf', N'sdfdsf', N'dsfdsf', N'dsfdsfds', NULL, N'InActive', CAST(N'2024-11-24T21:02:55.227' AS DateTime), CAST(N'2024-11-24T21:12:38.380' AS DateTime), N'')

GO
ALTER TABLE [dbo].[tblBooking] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblBookingRoom] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblCustomer] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblHotel] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblInvoice] ADD  DEFAULT (getdate()) FOR [InvoiceDate]
GO
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT (getdate()) FOR [PaymentDate]
GO
ALTER TABLE [dbo].[tblRoom] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
