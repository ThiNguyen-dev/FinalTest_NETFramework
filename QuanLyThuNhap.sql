USE [QLKhoanThuNhap]
GO
ALTER TABLE [dbo].[KhoanThuNhap] DROP CONSTRAINT [FK_KhoanThuNhap_LoaiHinhThuNhap]
GO
/****** Object:  Table [dbo].[LoaiHinhThuNhap]    Script Date: 1/2/2022 10:12:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoaiHinhThuNhap]') AND type in (N'U'))
DROP TABLE [dbo].[LoaiHinhThuNhap]
GO
/****** Object:  Table [dbo].[KhoanThuNhap]    Script Date: 1/2/2022 10:12:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KhoanThuNhap]') AND type in (N'U'))
DROP TABLE [dbo].[KhoanThuNhap]
GO
/****** Object:  Table [dbo].[KhoanThuNhap]    Script Date: 1/2/2022 10:12:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoanThuNhap](
	[MaKhoan] [varchar](50) NOT NULL,
	[SoTien] [bigint] NULL,
	[ThoiGian] [datetime] NULL,
	[GhiChu] [nvarchar](50) NULL,
	[MaLoaiHinhThuNhap] [varchar](50) NOT NULL,
 CONSTRAINT [PK_KhoanThuNhap] PRIMARY KEY CLUSTERED 
(
	[MaKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHinhThuNhap]    Script Date: 1/2/2022 10:12:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHinhThuNhap](
	[MaLoaiHinhThuNhap] [varchar](50) NOT NULL,
	[TenLoaiHinhThuNhap] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiHinhThuNhap] PRIMARY KEY CLUSTERED 
(
	[MaLoaiHinhThuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[KhoanThuNhap] ([MaKhoan], [SoTien], [ThoiGian], [GhiChu], [MaLoaiHinhThuNhap]) VALUES (N'TN01', 9000000, CAST(N'2021-12-29T00:00:00.000' AS DateTime), N'Lương tháng 12', N'luong')
INSERT [dbo].[KhoanThuNhap] ([MaKhoan], [SoTien], [ThoiGian], [GhiChu], [MaLoaiHinhThuNhap]) VALUES (N'TN02', 250000, CAST(N'2021-11-10T00:00:00.000' AS DateTime), N'Bán hàng khách sỉ', N'banhang')
INSERT [dbo].[KhoanThuNhap] ([MaKhoan], [SoTien], [ThoiGian], [GhiChu], [MaLoaiHinhThuNhap]) VALUES (N'TN03', 300000, CAST(N'2021-12-31T00:00:00.000' AS DateTime), N'Cho thuê nhà', N'chothue')
INSERT [dbo].[KhoanThuNhap] ([MaKhoan], [SoTien], [ThoiGian], [GhiChu], [MaLoaiHinhThuNhap]) VALUES (N'TN05', 250000, CAST(N'2021-09-01T00:00:00.000' AS DateTime), N'Bán hàng khách lẻ', N'cophieu')
GO
INSERT [dbo].[LoaiHinhThuNhap] ([MaLoaiHinhThuNhap], [TenLoaiHinhThuNhap]) VALUES (N'banhang', N'Bán hàng')
INSERT [dbo].[LoaiHinhThuNhap] ([MaLoaiHinhThuNhap], [TenLoaiHinhThuNhap]) VALUES (N'chothue', N'Cho thuê')
INSERT [dbo].[LoaiHinhThuNhap] ([MaLoaiHinhThuNhap], [TenLoaiHinhThuNhap]) VALUES (N'cophieu', N'Cổ phiếu')
INSERT [dbo].[LoaiHinhThuNhap] ([MaLoaiHinhThuNhap], [TenLoaiHinhThuNhap]) VALUES (N'luong', N'Lương')
INSERT [dbo].[LoaiHinhThuNhap] ([MaLoaiHinhThuNhap], [TenLoaiHinhThuNhap]) VALUES (N'thuong', N'Thưởng')
GO
ALTER TABLE [dbo].[KhoanThuNhap]  WITH CHECK ADD  CONSTRAINT [FK_KhoanThuNhap_LoaiHinhThuNhap] FOREIGN KEY([MaLoaiHinhThuNhap])
REFERENCES [dbo].[LoaiHinhThuNhap] ([MaLoaiHinhThuNhap])
GO
ALTER TABLE [dbo].[KhoanThuNhap] CHECK CONSTRAINT [FK_KhoanThuNhap_LoaiHinhThuNhap]
GO
