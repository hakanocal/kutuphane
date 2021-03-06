USE [master]
GO
/****** Object:  Database [kutuphane]    Script Date: 19.5.2020 16:49:14 ******/
CREATE DATABASE [kutuphane]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kutuphane', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\kutuphane.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'kutuphane_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\kutuphane_log.ldf' , SIZE = 6272KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [kutuphane] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kutuphane].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kutuphane] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kutuphane] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kutuphane] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kutuphane] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kutuphane] SET ARITHABORT OFF 
GO
ALTER DATABASE [kutuphane] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [kutuphane] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [kutuphane] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kutuphane] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kutuphane] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kutuphane] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kutuphane] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kutuphane] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kutuphane] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kutuphane] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kutuphane] SET  DISABLE_BROKER 
GO
ALTER DATABASE [kutuphane] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kutuphane] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kutuphane] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kutuphane] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kutuphane] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kutuphane] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [kutuphane] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kutuphane] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [kutuphane] SET  MULTI_USER 
GO
ALTER DATABASE [kutuphane] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kutuphane] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kutuphane] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kutuphane] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [kutuphane]
GO
/****** Object:  Table [dbo].[kitaplar]    Script Date: 19.5.2020 16:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kitaplar](
	[ISBN] [nchar](17) NOT NULL,
	[kitap_adi] [varchar](100) NULL,
	[yazar_id] [int] NULL,
	[yayinevi_id] [int] NULL,
	[yayin_tarihi] [varchar](50) NULL,
	[sayfa_sayisi] [int] NULL,
	[tur_id] [int] NULL,
	[stok] [int] NULL,
	[resim] [varchar](256) NULL,
 CONSTRAINT [PK_kitaplar] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[odunc]    Script Date: 19.5.2020 16:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[odunc](
	[odunc_id] [int] IDENTITY(1,1) NOT NULL,
	[tc] [char](11) NULL,
	[alis_tarihi] [datetime] NULL,
	[teslim_tarihi] [datetime] NULL,
	[durum] [varchar](50) NULL,
	[istek_tarihi] [datetime] NULL,
	[istedigi_tarih] [datetime] NULL,
 CONSTRAINT [PK_odunc] PRIMARY KEY CLUSTERED 
(
	[odunc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[odunc_detay]    Script Date: 19.5.2020 16:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[odunc_detay](
	[detay_id] [int] IDENTITY(1,1) NOT NULL,
	[odunc_id] [int] NULL,
	[ISBN] [nchar](17) NULL,
 CONSTRAINT [PK_odunc_detay] PRIMARY KEY CLUSTERED 
(
	[detay_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[turler]    Script Date: 19.5.2020 16:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[turler](
	[tur_id] [int] IDENTITY(1,1) NOT NULL,
	[tur_adi] [varchar](50) NULL,
 CONSTRAINT [PK_turler] PRIMARY KEY CLUSTERED 
(
	[tur_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[uyeler]    Script Date: 19.5.2020 16:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[uyeler](
	[tc] [char](11) NOT NULL,
	[ad] [varchar](50) NULL,
	[soyad] [varchar](50) NULL,
	[tel] [char](11) NULL,
	[mail] [varchar](50) NULL,
	[sifre] [varchar](50) NULL,
	[yetki] [varchar](50) NULL,
 CONSTRAINT [PK_uyeler] PRIMARY KEY CLUSTERED 
(
	[tc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[yayinevi]    Script Date: 19.5.2020 16:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[yayinevi](
	[yayinevi_id] [int] IDENTITY(1,1) NOT NULL,
	[yayin_evi_ad] [varchar](50) NULL,
	[adres] [varchar](250) NULL,
	[tel] [char](11) NULL,
	[mail] [varchar](50) NULL,
 CONSTRAINT [PK_yayinevi] PRIMARY KEY CLUSTERED 
(
	[yayinevi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[yazarlar]    Script Date: 19.5.2020 16:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[yazarlar](
	[yazar_id] [int] IDENTITY(1,1) NOT NULL,
	[ad] [varchar](50) NULL,
	[soyad] [varchar](50) NULL,
	[mail] [varchar](50) NULL,
 CONSTRAINT [PK_yazarlar] PRIMARY KEY CLUSTERED 
(
	[yazar_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[kitaplar]  WITH CHECK ADD  CONSTRAINT [FK__kitaplar__tur_id__4222D4EF] FOREIGN KEY([tur_id])
REFERENCES [dbo].[turler] ([tur_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[kitaplar] CHECK CONSTRAINT [FK__kitaplar__tur_id__4222D4EF]
GO
ALTER TABLE [dbo].[kitaplar]  WITH CHECK ADD  CONSTRAINT [FK__kitaplar__yayine__412EB0B6] FOREIGN KEY([yayinevi_id])
REFERENCES [dbo].[yayinevi] ([yayinevi_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[kitaplar] CHECK CONSTRAINT [FK__kitaplar__yayine__412EB0B6]
GO
ALTER TABLE [dbo].[kitaplar]  WITH CHECK ADD  CONSTRAINT [FK__kitaplar__yazar___403A8C7D] FOREIGN KEY([yazar_id])
REFERENCES [dbo].[yazarlar] ([yazar_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[kitaplar] CHECK CONSTRAINT [FK__kitaplar__yazar___403A8C7D]
GO
ALTER TABLE [dbo].[odunc]  WITH CHECK ADD  CONSTRAINT [FK__odunc__tc__4316F928] FOREIGN KEY([tc])
REFERENCES [dbo].[uyeler] ([tc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[odunc] CHECK CONSTRAINT [FK__odunc__tc__4316F928]
GO
ALTER TABLE [dbo].[odunc_detay]  WITH CHECK ADD  CONSTRAINT [FK__odunc_det__odunc__440B1D61] FOREIGN KEY([odunc_id])
REFERENCES [dbo].[odunc] ([odunc_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[odunc_detay] CHECK CONSTRAINT [FK__odunc_det__odunc__440B1D61]
GO
ALTER TABLE [dbo].[odunc_detay]  WITH CHECK ADD  CONSTRAINT [FK__odunc_deta__ISBN__44FF419A] FOREIGN KEY([ISBN])
REFERENCES [dbo].[kitaplar] ([ISBN])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[odunc_detay] CHECK CONSTRAINT [FK__odunc_deta__ISBN__44FF419A]
GO
USE [master]
GO
ALTER DATABASE [kutuphane] SET  READ_WRITE 
GO
