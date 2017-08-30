/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2008 R2
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [master]
GO
/****** Object:  Database [PRCSOFT]    Script Date: 31.08.2017 01:07:06 ******/
CREATE DATABASE [PRCSOFT] ON  PRIMARY 
( NAME = N'PRCSOFT', FILENAME = N'F:\SEFA\SQLDATA\PRCSOFT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PRCSOFT_log', FILENAME = N'F:\SEFA\SQLDATA\PRCSOFT_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PRCSOFT] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRCSOFT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRCSOFT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRCSOFT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRCSOFT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRCSOFT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRCSOFT] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRCSOFT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRCSOFT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRCSOFT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRCSOFT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRCSOFT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRCSOFT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRCSOFT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRCSOFT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRCSOFT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRCSOFT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRCSOFT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRCSOFT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRCSOFT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRCSOFT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRCSOFT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRCSOFT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRCSOFT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRCSOFT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRCSOFT] SET  MULTI_USER 
GO
ALTER DATABASE [PRCSOFT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRCSOFT] SET DB_CHAINING OFF 
GO
USE [PRCSOFT]
GO
/****** Object:  Table [dbo].[Belge_Tipi_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Belge_Tipi_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Belge_Tipi] [varchar](25) NOT NULL,
 CONSTRAINT [PK_Belge_Tipi_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Belge_Tipi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cari_Gorev_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cari_Gorev_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Gorev_Kodu] [varchar](25) NOT NULL,
	[Gorev_Adi] [varchar](255) NULL,
 CONSTRAINT [PK_Cari_Gorev_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Gorev_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cari_Grup_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cari_Grup_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Grup_Kodu] [varchar](25) NOT NULL,
	[Grup_Adi] [varchar](50) NULL,
 CONSTRAINT [PK_Cari_Grup_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Grup_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cari_Ozel_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cari_Ozel_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Ozel_Kodu] [varchar](25) NOT NULL,
	[Ozel_Adi] [varchar](255) NULL,
 CONSTRAINT [PK_Cari_Ozel_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Ozel_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cari_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cari_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Cari_No] [int] NOT NULL,
	[Silindi] [tinyint] NULL,
	[Cari_Kodu] [varchar](25) NULL,
	[Unvani] [varchar](255) NULL,
	[Adi] [varchar](50) NULL,
	[Soyadi] [varchar](50) NULL,
	[Kart_Kodu] [varchar](20) NULL,
	[Sinifi] [varchar](20) NULL,
	[Subesi] [varchar](20) NULL,
	[Ogrenci_No] [int] NULL,
	[Cinsiyeti] [tinyint] NULL,
	[Durum] [tinyint] NULL,
	[Boy] [float] NULL,
	[Kilo] [float] NULL,
	[Dogum_Tarihi] [datetime] NULL,
	[Harcama_Limiti] [float] NULL,
	[Veli_Adi] [varchar](50) NULL,
	[Veli_Soyadi] [varchar](50) NULL,
	[Veli_Cinsiyeti] [tinyint] NULL,
	[Veli_Telefon_1] [varchar](50) NULL,
	[Veli_Telefon_2] [varchar](50) NULL,
	[Veli_E_Mail] [varchar](150) NULL,
	[Veli_E_Mail_Gonder] [tinyint] NULL,
	[Resim] [varbinary](max) NULL,
	[Grup_Kodu] [varchar](25) NULL,
	[Ozel_Kodu] [varchar](25) NULL,
	[Indirim] [float] NULL,
	[Para_Birimi] [varchar](10) NULL,
	[Vergi_Dairesi] [varchar](255) NULL,
	[Vergi_TC_No] [varchar](15) NULL,
	[Musteri] [tinyint] NULL,
	[Satici] [tinyint] NULL,
	[Personel] [tinyint] NULL,
	[Ogrenci] [tinyint] NULL,
	[Ogretmen] [tinyint] NULL,
	[Mahalle_Koy] [varchar](50) NULL,
	[Cadde_Sokak] [varchar](50) NULL,
	[Dis_Kapi_No] [varchar](10) NULL,
	[Site_Adi] [varchar](50) NULL,
	[Apartman_Blok] [varchar](50) NULL,
	[Kat] [varchar](10) NULL,
	[Daire] [varchar](10) NULL,
	[Ilce] [varchar](50) NULL,
	[Il] [varchar](50) NULL,
	[Ulke] [varchar](50) NULL,
	[Telefon_1] [varchar](50) NULL,
	[Telefon_2] [varchar](50) NULL,
	[Telefon_3] [varchar](50) NULL,
	[Fax_1] [varchar](50) NULL,
	[Fax_2] [varchar](50) NULL,
	[E_Mail_1] [varchar](150) NULL,
	[E_Mail_2] [varchar](150) NULL,
	[Ise_Giris_Tarihi] [datetime] NULL,
	[Isten_Cikis_Tarihi] [datetime] NULL,
	[Gorev_Kodu] [varchar](25) NULL,
	[Maas] [float] NULL,
	[Aile_No] [varchar](10) NULL,
	[Ana_Adi] [varchar](50) NULL,
	[Baba_Adi] [varchar](50) NULL,
	[Banka_Adi] [varchar](150) NULL,
	[Banka_Subesi] [varchar](150) NULL,
	[Calisma_Yeri] [varchar](100) NULL,
	[Cikis_Nedeni] [varchar](255) NULL,
	[Cilt_No] [varchar](10) NULL,
	[Dogum_Yeri] [varchar](50) NULL,
	[Hesap_No] [varchar](255) NULL,
	[Kimlik_Il] [varchar](50) NULL,
	[Kimlik_Ilce] [varchar](50) NULL,
	[Kimlik_Mahalle_Koy] [varchar](50) NULL,
	[Kimlik_Seri_No_1] [varchar](5) NULL,
	[Kimlik_Seri_No_2] [varchar](20) NULL,
	[Sira_No] [varchar](10) NULL,
	[Askerlik] [tinyint] NULL,
	[Egitim_Durumu] [tinyint] NULL,
	[Ehliyet] [tinyint] NULL,
	[Isyeri_Kodu] [int] NOT NULL,
	[Kan_Grubu] [tinyint] NULL,
	[Medeni_Hali] [tinyint] NULL,
	[AGI_Tutari] [float] NULL,
	[Cocuk_Sayisi] [int] NULL,
	[Yatirilan_Maas] [float] NULL,
	[Insert_User] [varchar](50) NULL,
	[Insert_Date] [datetime] NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime] NULL,
	[Delete_User] [varchar](50) NULL,
	[Delete_Date] [datetime] NULL,
 CONSTRAINT [PK_Cari_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Cari_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cari_Yasakli_Urunler]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cari_Yasakli_Urunler](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Cari_No] [int] NOT NULL,
	[Sira_No] [int] NOT NULL,
	[Tip] [tinyint] NULL,
	[Kodu] [varchar](25) NULL,
 CONSTRAINT [PK_Cari_Yasakli_Urunler_1] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Cari_No] ASC,
	[Sira_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cari_Yetkili_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cari_Yetkili_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Cari_No] [int] NOT NULL,
	[Sira_No] [int] NOT NULL,
	[Adi] [varchar](50) NULL,
	[Soyadi] [varchar](50) NULL,
	[Telefon_1] [varchar](50) NULL,
	[E_Mail_1] [varchar](150) NULL,
 CONSTRAINT [PK_Cari_Yetkili_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Cari_No] ASC,
	[Sira_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Depo_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depo_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Depo_Kodu] [int] NOT NULL,
	[Depo_Adi] [varchar](255) NULL,
	[Isyeri_Kodu] [int] NULL,
 CONSTRAINT [PK_Depo_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Depo_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Islem_Baslik]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Islem_Baslik](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Fis_Tipi] [int] NOT NULL,
	[Isyeri_Kodu] [int] NOT NULL,
	[Fis_No] [int] NOT NULL,
	[Silindi] [tinyint] NULL,
	[Depo_Kodu_1] [int] NULL,
	[Depo_Kodu_2] [int] NULL,
	[Fis_Tarihi] [datetime] NULL,
	[Fis_Saati] [datetime] NULL,
	[Cari_No] [int] NULL,
	[Kasa_Kodu] [varchar](25) NULL,
	[Belge_Tipi] [varchar](25) NULL,
	[Belge_No] [varchar](25) NULL,
	[Belge_Tarihi] [datetime] NULL,
	[Para_Birimi] [varchar](10) NULL,
	[Fiyat_Tipi] [int] NULL,
	[Kdv_Tipi_1] [int] NULL,
	[Kdv_Tipi_2] [int] NULL,
	[Aciklama] [varchar](255) NULL,
	[Insert_User] [varchar](50) NULL,
	[Inser_Date] [datetime] NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime] NULL,
	[Delete_User] [varchar](50) NULL,
	[Delete_Date] [datetime] NULL,
 CONSTRAINT [PK_Islem_Baslik] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Fis_Tipi] ASC,
	[Isyeri_Kodu] ASC,
	[Fis_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Islem_Detay_Cari]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Islem_Detay_Cari](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Fis_Tipi] [int] NOT NULL,
	[Isyeri_Kodu] [int] NOT NULL,
	[Fis_No] [int] NOT NULL,
	[Fis_Sira] [int] NOT NULL,
	[Islem_Yonu] [int] NOT NULL,
	[Silindi] [tinyint] NULL,
	[Fis_Tarihi] [datetime] NULL,
	[Fis_Saati] [datetime] NULL,
	[Cari_No] [int] NULL,
	[Masraf_No] [int] NULL,
	[Borc_Tutari] [float] NULL,
	[Borc_Tutari_Baslik] [float] NULL,
	[Borc_Tutari_Kart] [float] NULL,
	[Borc_Tutari_Sistem] [float] NULL,
	[Alacak_Tutari] [float] NULL,
	[Alacak_Tutari_Baslik] [float] NULL,
	[Alacak_Tutari_Kart] [float] NULL,
	[Alacak_Tutari_Sistem] [float] NULL,
	[Aciklama] [varchar](255) NULL,
	[Odeme_No] [int] NULL,
 CONSTRAINT [PK_Islem_Detay_Cari] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Fis_Tipi] ASC,
	[Isyeri_Kodu] ASC,
	[Fis_No] ASC,
	[Fis_Sira] ASC,
	[Islem_Yonu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Islem_Detay_Kasa]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Islem_Detay_Kasa](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Fis_Tipi] [int] NOT NULL,
	[Isyeri_Kodu] [int] NOT NULL,
	[Fis_No] [int] NOT NULL,
	[Fis_Sira] [int] NOT NULL,
	[Islem_Yonu] [int] NOT NULL,
	[Silindi] [tinyint] NULL,
	[Fis_Tarihi] [datetime] NULL,
	[Fis_Saati] [datetime] NULL,
	[Kasa_Kodu] [varchar](25) NULL,
	[Cari_No] [int] NULL,
	[Masraf_No] [int] NULL,
	[Borc_Tutari] [float] NULL,
	[Borc_Tutari_Baslik] [float] NULL,
	[Borc_Tutari_Kart] [float] NULL,
	[Borc_Tutari_Sistem] [float] NULL,
	[Alacak_Tutari] [float] NULL,
	[Alacak_Tutari_Baslik] [float] NULL,
	[Alacak_Tutari_Kart] [float] NULL,
	[Alacak_Tutari_Sistem] [float] NULL,
	[Aciklama] [varchar](255) NULL,
	[Odeme_No] [int] NULL,
 CONSTRAINT [PK_Islem_Detay_Kasa] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Fis_Tipi] ASC,
	[Isyeri_Kodu] ASC,
	[Fis_No] ASC,
	[Fis_Sira] ASC,
	[Islem_Yonu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Islem_Detay_Masraf]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Islem_Detay_Masraf](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Fis_Tipi] [int] NOT NULL,
	[Isyeri_Kodu] [int] NOT NULL,
	[Fis_No] [int] NOT NULL,
	[Fis_Sira] [int] NOT NULL,
	[Islem_Yonu] [int] NOT NULL,
	[Silindi] [tinyint] NULL,
	[Masraf_No] [int] NULL,
	[Fis_Tarihi] [datetime] NULL,
	[Fis_Saati] [datetime] NULL,
	[Borc_Tutari] [float] NULL,
	[Borc_Tutari_Baslik] [float] NULL,
	[Borc_Tutari_Kart] [float] NULL,
	[Borc_Tutari_Sistem] [float] NULL,
	[Alacak_Tutari] [float] NULL,
	[Alacak_Tutari_Baslik] [float] NULL,
	[Alacak_Tutari_Kart] [float] NULL,
	[Alacak_Tutari_Sistem] [float] NULL,
	[Kdv_Orani] [float] NULL,
	[Kdv_Tutari] [float] NULL,
	[Kdv_Tutari_Baslik] [float] NULL,
	[Kdv_Tutari_Kart] [float] NULL,
	[Kdv_Tutari_Sistem] [float] NULL,
	[Aciklama] [varchar](255) NULL,
 CONSTRAINT [PK_Islem_Detay_Masraf] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Fis_Tipi] ASC,
	[Isyeri_Kodu] ASC,
	[Fis_No] ASC,
	[Fis_Sira] ASC,
	[Islem_Yonu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Islem_Detay_Stok]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Islem_Detay_Stok](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Fis_Tipi] [int] NOT NULL,
	[Isyeri_Kodu] [int] NOT NULL,
	[Fis_No] [int] NOT NULL,
	[Fis_Sira] [int] NOT NULL,
	[Islem_Yonu] [int] NOT NULL,
	[Silindi] [tinyint] NULL,
	[Fis_Tarihi] [datetime] NULL,
	[Fis_Saati] [datetime] NULL,
	[Depo_Kodu] [int] NULL,
	[Stok_No] [int] NULL,
	[Birim_Kodu] [varchar](10) NULL,
	[Giris_Miktari] [float] NULL,
	[Cikis_Miktari] [float] NULL,
	[Birim_Fiyati] [float] NULL,
	[Isk_Orani_1] [float] NULL,
	[Isk_Orani_2] [float] NULL,
	[Isk_Orani_3] [float] NULL,
	[Kdv_Orani] [float] NULL,
	[Isk_Tutari_1] [float] NULL,
	[Isk_Tutari_1_Baslik] [float] NULL,
	[Isk_Tutari_1_Kart] [float] NULL,
	[Isk_Tutari_1_Sistem] [float] NULL,
	[Isk_Tutari_2] [float] NULL,
	[Isk_Tutari_2_Baslik] [float] NULL,
	[Isk_Tutari_2_Kart] [float] NULL,
	[Isk_Tutari_2_Sistem] [float] NULL,
	[Isk_Tutari_3] [float] NULL,
	[Isk_Tutari_3_Baslik] [float] NULL,
	[Isk_Tutari_3_Kart] [float] NULL,
	[Isk_Tutari_3_Sistem] [float] NULL,
	[Kdv_Tutari] [float] NULL,
	[Kdv_Tutari_Baslik] [float] NULL,
	[Kdv_Tutari_Kart] [float] NULL,
	[Kdv_Tutari_Sistem] [float] NULL,
	[Giris_Tutari] [float] NULL,
	[Giris_Tutari_Baslik] [float] NULL,
	[Giris_Tutari_Kart] [float] NULL,
	[Giris_Tutari_Sistem] [float] NULL,
	[Cikis_Tutari] [float] NULL,
	[Cikis_Tutari_Baslik] [float] NULL,
	[Cikis_Tutari_Kart] [float] NULL,
	[Cikis_Tutari_Sistem] [float] NULL,
	[Giris_Tutari_Net] [float] NULL,
	[Giris_Tutari_Net_Baslik] [float] NULL,
	[Giris_Tutari_Net_Kart] [float] NULL,
	[Giris_Tutari_Net_Sistem] [float] NULL,
	[Cikis_Tutari_Net] [float] NULL,
	[Cikis_Tutari_Net_Baslik] [float] NULL,
	[Cikis_Tutari_Net_Kart] [float] NULL,
	[Cikis_Tutari_Net_Sistem] [float] NULL,
	[Aciklama] [varchar](255) NULL,
 CONSTRAINT [PK_Islem_Detay_Stok] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Fis_Tipi] ASC,
	[Isyeri_Kodu] ASC,
	[Fis_No] ASC,
	[Fis_Sira] ASC,
	[Islem_Yonu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Isyeri_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Isyeri_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Isyeri_Kodu] [int] NOT NULL,
	[Isyeri_Adi] [varchar](255) NULL,
 CONSTRAINT [PK_Isyeri_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Isyeri_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kasa_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kasa_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Kasa_Kodu] [varchar](25) NOT NULL,
	[Silindi] [tinyint] NULL,
	[Kasa_Adi] [varchar](255) NULL,
	[Yetkilisi] [varchar](255) NULL,
	[Para_Birimi] [varchar](10) NULL,
	[Isyeri_Kodu] [int] NULL,
	[Insert_User] [varchar](50) NULL,
	[Insert_Date] [datetime] NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime] NULL,
	[Delete_User] [varchar](50) NULL,
	[Delete_Date] [datetime] NULL,
 CONSTRAINT [PK_Kasa_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Kasa_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kdv_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kdv_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Kdv_Orani] [float] NOT NULL,
	[Kdv_Adi] [varchar](255) NULL,
 CONSTRAINT [PK_Kdv_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Kdv_Orani] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Masa_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Masa_Tanitimi](
	[Isyeri_Kodu] [int] NOT NULL,
	[Salon_Kodu] [varchar](25) NOT NULL,
	[Masa_Kodu] [varchar](50) NOT NULL,
	[Lokasyon_X] [int] NULL,
	[Lokasyon_Y] [int] NULL,
 CONSTRAINT [PK_Masa_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Isyeri_Kodu] ASC,
	[Salon_Kodu] ASC,
	[Masa_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Masraf_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Masraf_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Masraf_No] [int] NOT NULL,
	[Masraf_Kodu] [varchar](25) NULL,
	[Silindi] [tinyint] NULL,
	[Masraf_Adi] [varchar](255) NULL,
	[Islem] [tinyint] NULL,
	[Masraf_Tipi] [tinyint] NULL,
	[Kdv_Orani] [float] NULL,
	[Kdv_Tutari] [float] NULL,
	[Insert_User] [varchar](50) NULL,
	[Insert_Date] [datetime] NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime] NULL,
	[Delete_User] [varchar](50) NULL,
	[Delete_Date] [datetime] NULL,
 CONSTRAINT [PK_Masraf_Tanitimi_1] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Masraf_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Odeme_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odeme_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Odeme_No] [int] NOT NULL,
	[Odeme_Kodu] [varchar](15) NOT NULL,
	[Silindi] [tinyint] NULL,
	[Odeme_Adi] [varchar](255) NULL,
	[Odeme_Tipi] [tinyint] NULL,
	[Kayit_Tipi] [tinyint] NULL,
	[Kayit_Kodu] [varchar](25) NULL,
	[Insert_User] [varchar](50) NULL,
	[Insert_Date] [datetime] NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime] NULL,
	[Delete_User] [varchar](50) NULL,
	[Delete_Date] [datetime] NULL,
 CONSTRAINT [PK_Odeme_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Odeme_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Para_Birimi_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Para_Birimi_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Para_Birimi] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Para_Birimi_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Para_Birimi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametreler]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametreler](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Kodu] [varchar](25) NOT NULL,
	[Degeri] [varchar](255) NULL,
 CONSTRAINT [PK_Parametreler] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salon_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salon_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Isyeri_Kodu] [int] NOT NULL,
	[Salon_Kodu] [varchar](25) NOT NULL,
	[Salon_Adi] [varchar](50) NULL,
 CONSTRAINT [PK_Salon_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Isyeri_Kodu] ASC,
	[Salon_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stok_Bagli_Irsaliyeler]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stok_Bagli_Irsaliyeler](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Irsaliye_Fis_Tipi] [int] NOT NULL,
	[Irsaliye_Isyeri_Kodu] [int] NOT NULL,
	[Irsaliye_Fis_No] [int] NOT NULL,
	[Fatura_Fis_Tipi] [int] NOT NULL,
	[Fatura_Isyeri_Kodu] [int] NOT NULL,
	[Fatura_Fis_No] [int] NOT NULL,
 CONSTRAINT [PK_Stok_Bagli_Irsaliyeler_1] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Irsaliye_Fis_Tipi] ASC,
	[Irsaliye_Isyeri_Kodu] ASC,
	[Irsaliye_Fis_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stok_Bagli_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stok_Bagli_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Stok_No] [int] NOT NULL,
	[Sira_No] [nchar](10) NOT NULL,
	[Bagli_Stok_No] [int] NOT NULL,
 CONSTRAINT [PK_Stok_Bagli_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Stok_No] ASC,
	[Sira_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stok_Birim_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stok_Birim_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Birim_Kodu] [varchar](10) NOT NULL,
	[Birim_Adi] [varchar](255) NULL,
	[Agirlik_Birimi] [tinyint] NULL,
 CONSTRAINT [PK_Stok_Birim_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Birim_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stok_Departman_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stok_Departman_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Departman_Kodu] [varchar](25) NOT NULL,
	[Departman_Adi] [varchar](150) NULL,
 CONSTRAINT [PK_Stok_Departman_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Departman_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stok_Grup_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stok_Grup_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Grup_Kodu] [varchar](25) NOT NULL,
	[Grup_Adi] [varchar](50) NULL,
 CONSTRAINT [PK_Stok_Grup_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Grup_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stok_Ozel_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stok_Ozel_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Ozel_Kodu] [varchar](25) NOT NULL,
	[Ozel_Adi] [varchar](255) NULL,
 CONSTRAINT [PK_Stok_Ozel_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Ozel_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stok_Reyon_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stok_Reyon_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Reyon_Kodu] [varchar](25) NOT NULL,
	[Reyon_Adi] [varchar](150) NULL,
 CONSTRAINT [PK_Stok_Reyon_Tanitimi] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Reyon_Kodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stok_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stok_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Stok_No] [int] NOT NULL,
	[Silindi] [tinyint] NULL,
	[Stok_Kodu] [varchar](25) NULL,
	[Stok_Adi] [varchar](255) NULL,
	[Kisa_Adi] [varchar](255) NULL,
	[Durum] [tinyint] NULL,
	[Resim] [varbinary](max) NULL,
	[Grup_Kodu] [varchar](25) NULL,
	[Ozel_Kodu] [varchar](25) NULL,
	[Kdv_Toptan] [float] NULL,
	[Kdv_Perakende] [float] NULL,
	[Stok_Tipi] [tinyint] NULL,
	[Departman_Kodu] [varchar](20) NULL,
	[Min_Miktar] [float] NULL,
	[Max_Miktar] [float] NULL,
	[Raf_Omru] [int] NULL,
	[Reyon_Kodu] [varchar](25) NULL,
	[Urun_Notu] [varchar](255) NULL,
	[Urun_Icerigi] [varchar](255) NULL,
	[Ruhsat_Sahibi] [varchar](150) NULL,
	[Ruhsat_Tarihi] [datetime] NULL,
	[Gida_Uretim_Izni] [varchar](50) NULL,
	[Alerjen_Uyarisi] [varchar](255) NULL,
	[Birim_Kodu_1] [varchar](10) NULL,
	[BT1_Orani] [float] NULL,
	[BT1_Barkod] [varchar](50) NULL,
	[BT1_Hizli_Satis] [tinyint] NULL,
	[BT1_Alis_Fiyati] [float] NULL,
	[BT1_Alis_Kdvli_Fiyati] [float] NULL,
	[BT1_Satis_Fiyati_1] [float] NULL,
	[BT1_Satis_Fiyati_2] [float] NULL,
	[BT1_Satis_Fiyati_3] [float] NULL,
	[Birim_Kodu_2] [varchar](10) NULL,
	[BT2_Orani] [float] NULL,
	[BT2_Barkod] [varchar](50) NULL,
	[BT2_Hizli_Satis] [tinyint] NULL,
	[BT2_Alis_Fiyati] [float] NULL,
	[BT2_Alis_Kdvli_Fiyati] [float] NULL,
	[BT2_Satis_Fiyati_1] [float] NULL,
	[BT2_Satis_Fiyati_2] [float] NULL,
	[BT2_Satis_Fiyati_3] [float] NULL,
	[Karbonhidrat] [float] NULL,
	[Protein] [float] NULL,
	[Yag] [float] NULL,
	[Doymus_Yag] [float] NULL,
	[Lif] [float] NULL,
	[Kolesterol] [float] NULL,
	[Sodyum] [float] NULL,
	[Potasyum] [float] NULL,
	[Kalsiyum] [float] NULL,
	[Vitamin_A] [float] NULL,
	[Vitamin_C] [float] NULL,
	[Demir] [float] NULL,
	[Enerji] [float] NULL,
	[Seker] [float] NULL,
	[Ozel_Kodu_1] [varchar](150) NULL,
	[Ozel_Kodu_2] [varchar](150) NULL,
	[Ozel_Kodu_3] [varchar](150) NULL,
	[Ozel_Kodu_4] [varchar](150) NULL,
	[Ozel_Kodu_5] [varchar](150) NULL,
	[Ozel_Kodu_6] [varchar](150) NULL,
	[Ozel_Kodu_7] [varchar](150) NULL,
	[Ozel_Kodu_8] [varchar](150) NULL,
	[Ozel_Kodu_9] [varchar](150) NULL,
	[Ozel_Kodu_10] [varchar](150) NULL,
	[Ozel_Kodu_11] [varchar](150) NULL,
	[Ozel_Kodu_12] [varchar](150) NULL,
	[Ozel_Kodu_13] [varchar](150) NULL,
	[Ozel_Kodu_14] [varchar](150) NULL,
	[Ozel_Kodu_15] [varchar](150) NULL,
	[Insert_User] [varchar](50) NULL,
	[Insert_Date] [datetime] NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime] NULL,
	[Delete_User] [varchar](50) NULL,
	[Delete_Date] [datetime] NULL,
 CONSTRAINT [PK_Stok_Tanitimi_1] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Stok_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stok_Tedarikci_Tanitimi]    Script Date: 31.08.2017 01:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stok_Tedarikci_Tanitimi](
	[Kurum_Kodu] [varchar](20) NOT NULL,
	[Stok_No] [int] NOT NULL,
	[Tedarikci_No] [int] NOT NULL,
 CONSTRAINT [PK_Stok_Tedarikci_Tanitimi_1] PRIMARY KEY CLUSTERED 
(
	[Kurum_Kodu] ASC,
	[Stok_No] ASC,
	[Tedarikci_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Belge_Tipi_Tanitimi] ADD  CONSTRAINT [DF_Belge_Tipi_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Belge_Tipi_Tanitimi] ADD  CONSTRAINT [DF_Belge_Tipi_Tanitimi_Belge_Tipi]  DEFAULT ('') FOR [Belge_Tipi]
GO
ALTER TABLE [dbo].[Cari_Gorev_Tanitimi] ADD  CONSTRAINT [DF_Cari_Gorev_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Cari_Gorev_Tanitimi] ADD  CONSTRAINT [DF_Cari_Gorev_Tanitimi_Gorev_Kodu]  DEFAULT ('') FOR [Gorev_Kodu]
GO
ALTER TABLE [dbo].[Cari_Gorev_Tanitimi] ADD  CONSTRAINT [DF_Cari_Gorev_Tanitimi_Gorev_Adi]  DEFAULT ('') FOR [Gorev_Adi]
GO
ALTER TABLE [dbo].[Cari_Grup_Tanitimi] ADD  CONSTRAINT [DF_Cari_Grup_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Cari_Grup_Tanitimi] ADD  CONSTRAINT [DF_Cari_Grup_Tanitimi_Grup_Kodu]  DEFAULT ('') FOR [Grup_Kodu]
GO
ALTER TABLE [dbo].[Cari_Grup_Tanitimi] ADD  CONSTRAINT [DF_Cari_Grup_Tanitimi_Grup_Adi]  DEFAULT ('') FOR [Grup_Adi]
GO
ALTER TABLE [dbo].[Cari_Ozel_Tanitimi] ADD  CONSTRAINT [DF_Cari_Ozel_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Cari_Ozel_Tanitimi] ADD  CONSTRAINT [DF_Cari_Ozel_Tanitimi_Ozel_Kodu]  DEFAULT ('') FOR [Ozel_Kodu]
GO
ALTER TABLE [dbo].[Cari_Ozel_Tanitimi] ADD  CONSTRAINT [DF_Cari_Ozel_Tanitimi_Ozel_Adi]  DEFAULT ('') FOR [Ozel_Adi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Cari_No]  DEFAULT ((0)) FOR [Cari_No]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Silindi]  DEFAULT ((0)) FOR [Silindi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Cari_Kodu]  DEFAULT ('') FOR [Cari_Kodu]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Unvani]  DEFAULT ('') FOR [Unvani]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Adi]  DEFAULT ('') FOR [Adi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Soyadi]  DEFAULT ('') FOR [Soyadi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Kart_Kodu]  DEFAULT ('') FOR [Kart_Kodu]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Sinifi]  DEFAULT ('') FOR [Sinifi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Subesi]  DEFAULT ('') FOR [Subesi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Ogrenci_No]  DEFAULT ((0)) FOR [Ogrenci_No]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Cinsiyeti]  DEFAULT ((0)) FOR [Cinsiyeti]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Durum]  DEFAULT ((0)) FOR [Durum]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Boy]  DEFAULT ((0)) FOR [Boy]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Kilo]  DEFAULT ((0)) FOR [Kilo]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Dogum_Tarihi]  DEFAULT ('') FOR [Dogum_Tarihi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Harcama_Limiti]  DEFAULT ((0)) FOR [Harcama_Limiti]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Veli_Adi]  DEFAULT ('') FOR [Veli_Adi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Veli_Soyadi]  DEFAULT ('') FOR [Veli_Soyadi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Veli_Cinsiyeti]  DEFAULT ((0)) FOR [Veli_Cinsiyeti]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Telefon_11]  DEFAULT ('') FOR [Veli_Telefon_1]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Veli_Telefon_11]  DEFAULT ('') FOR [Veli_Telefon_2]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_E_Mail_11]  DEFAULT ('') FOR [Veli_E_Mail]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Veli_E_Mail1]  DEFAULT ((0)) FOR [Veli_E_Mail_Gonder]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Resim]  DEFAULT (NULL) FOR [Resim]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Grup_Kodu]  DEFAULT ('') FOR [Grup_Kodu]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Ozel_Kodu]  DEFAULT ('') FOR [Ozel_Kodu]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Indirim]  DEFAULT ((0)) FOR [Indirim]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Para_Birimi]  DEFAULT ('') FOR [Para_Birimi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Vergi_Dairesi]  DEFAULT ('') FOR [Vergi_Dairesi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Vergi_No]  DEFAULT ('') FOR [Vergi_TC_No]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Musteri]  DEFAULT ((0)) FOR [Musteri]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Satici]  DEFAULT ((0)) FOR [Satici]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Satici1]  DEFAULT ((0)) FOR [Personel]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Ogrenci]  DEFAULT ((0)) FOR [Ogrenci]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Ogretmen]  DEFAULT ((0)) FOR [Ogretmen]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Mahalle_Koy]  DEFAULT ('') FOR [Mahalle_Koy]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Cadde_Sokak]  DEFAULT ('') FOR [Cadde_Sokak]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Dis_Kapi_No]  DEFAULT ('') FOR [Dis_Kapi_No]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Site_Adi]  DEFAULT ('') FOR [Site_Adi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Apartman_Adi]  DEFAULT ('') FOR [Apartman_Blok]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Kat]  DEFAULT ('') FOR [Kat]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Daire]  DEFAULT ('') FOR [Daire]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Ilce]  DEFAULT ('') FOR [Ilce]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Il]  DEFAULT ('') FOR [Il]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Ulke]  DEFAULT ('') FOR [Ulke]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Telefon_1]  DEFAULT ('') FOR [Telefon_1]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Telefon_2]  DEFAULT ('') FOR [Telefon_2]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Telefon_3]  DEFAULT ('') FOR [Telefon_3]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Fax_1]  DEFAULT ('') FOR [Fax_1]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Fax_2]  DEFAULT ('') FOR [Fax_2]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_E_Mail_1]  DEFAULT ('') FOR [E_Mail_1]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_E_Mail_2]  DEFAULT ('') FOR [E_Mail_2]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Ise_Giris_Tarihi]  DEFAULT ('') FOR [Ise_Giris_Tarihi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Isten_Cikis_Tarihi]  DEFAULT ('') FOR [Isten_Cikis_Tarihi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Gorev_Kodu]  DEFAULT ('') FOR [Gorev_Kodu]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Maas]  DEFAULT ((0)) FOR [Maas]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Aile_No]  DEFAULT ('') FOR [Aile_No]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Ana_Adi]  DEFAULT ('') FOR [Ana_Adi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Ana_Adi1]  DEFAULT ('') FOR [Baba_Adi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Baba_Adi1]  DEFAULT ('') FOR [Banka_Adi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Banka_Adi1]  DEFAULT ('') FOR [Banka_Subesi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Banka_Subesi1]  DEFAULT ('') FOR [Calisma_Yeri]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Calisma_Yeri1]  DEFAULT ('') FOR [Cikis_Nedeni]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Aile_No1]  DEFAULT ('') FOR [Cilt_No]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Cikis_Nedeni1]  DEFAULT ('') FOR [Dogum_Yeri]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Il1]  DEFAULT ('') FOR [Kimlik_Il]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Ilce1]  DEFAULT ('') FOR [Kimlik_Ilce]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Mahalle_Koy1]  DEFAULT ('') FOR [Kimlik_Mahalle_Koy]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Kimlik_Seri_No_1]  DEFAULT ('') FOR [Kimlik_Seri_No_1]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Kimlik_Seri_No_11]  DEFAULT ('') FOR [Kimlik_Seri_No_2]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Cilt_No1]  DEFAULT ('') FOR [Sira_No]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Askerlik]  DEFAULT ((0)) FOR [Askerlik]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Askerlik1]  DEFAULT ((0)) FOR [Egitim_Durumu]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Egitim_Durumu1]  DEFAULT ((0)) FOR [Ehliyet]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Isyeri_Kodu]  DEFAULT ((0)) FOR [Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Ehliyet1]  DEFAULT ((0)) FOR [Kan_Grubu]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Kan_Grubu1]  DEFAULT ((0)) FOR [Medeni_Hali]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_AGI_Tutari]  DEFAULT ((0)) FOR [AGI_Tutari]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Cocuk_Sayisi]  DEFAULT ((0)) FOR [Cocuk_Sayisi]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Maas1]  DEFAULT ((0)) FOR [Yatirilan_Maas]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Insert_User]  DEFAULT ('') FOR [Insert_User]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Inser_Date]  DEFAULT ('') FOR [Insert_Date]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Update_User]  DEFAULT ('') FOR [Update_User]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Update_Date]  DEFAULT ('') FOR [Update_Date]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Delete_User]  DEFAULT ('') FOR [Delete_User]
GO
ALTER TABLE [dbo].[Cari_Tanitimi] ADD  CONSTRAINT [DF_Cari_Tanitimi_Delete_Date]  DEFAULT ('') FOR [Delete_Date]
GO
ALTER TABLE [dbo].[Cari_Yasakli_Urunler] ADD  CONSTRAINT [DF_Cari_Yasakli_Urunler_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Cari_Yasakli_Urunler] ADD  CONSTRAINT [DF_Cari_Yasakli_Urunler_Cari_No]  DEFAULT ((0)) FOR [Cari_No]
GO
ALTER TABLE [dbo].[Cari_Yasakli_Urunler] ADD  CONSTRAINT [DF_Cari_Yasakli_Urunler_Sira_No]  DEFAULT ((0)) FOR [Sira_No]
GO
ALTER TABLE [dbo].[Cari_Yasakli_Urunler] ADD  CONSTRAINT [DF_Cari_Yasakli_Urunler_Tip]  DEFAULT ((0)) FOR [Tip]
GO
ALTER TABLE [dbo].[Cari_Yasakli_Urunler] ADD  CONSTRAINT [DF_Cari_Yasakli_Urunler_Kodu]  DEFAULT ('') FOR [Kodu]
GO
ALTER TABLE [dbo].[Cari_Yetkili_Tanitimi] ADD  CONSTRAINT [DF_Cari_Yetkili_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Cari_Yetkili_Tanitimi] ADD  CONSTRAINT [DF_Cari_Yetkili_Tanitimi_Cari_No]  DEFAULT ((0)) FOR [Cari_No]
GO
ALTER TABLE [dbo].[Cari_Yetkili_Tanitimi] ADD  CONSTRAINT [DF_Cari_Yetkili_Tanitimi_Sira_No]  DEFAULT ((0)) FOR [Sira_No]
GO
ALTER TABLE [dbo].[Cari_Yetkili_Tanitimi] ADD  CONSTRAINT [DF_Cari_Yetkili_Tanitimi_Adi]  DEFAULT ('') FOR [Adi]
GO
ALTER TABLE [dbo].[Cari_Yetkili_Tanitimi] ADD  CONSTRAINT [DF_Cari_Yetkili_Tanitimi_Soyadi]  DEFAULT ('') FOR [Soyadi]
GO
ALTER TABLE [dbo].[Cari_Yetkili_Tanitimi] ADD  CONSTRAINT [DF_Cari_Yetkili_Tanitimi_Telefon_1]  DEFAULT ('') FOR [Telefon_1]
GO
ALTER TABLE [dbo].[Cari_Yetkili_Tanitimi] ADD  CONSTRAINT [DF_Cari_Yetkili_Tanitimi_E_Mail_1]  DEFAULT ('') FOR [E_Mail_1]
GO
ALTER TABLE [dbo].[Depo_Tanitimi] ADD  CONSTRAINT [DF_Depo_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Depo_Tanitimi] ADD  CONSTRAINT [DF_Depo_Tanitimi_Depo_Kodu]  DEFAULT ((0)) FOR [Depo_Kodu]
GO
ALTER TABLE [dbo].[Depo_Tanitimi] ADD  CONSTRAINT [DF_Depo_Tanitimi_Depo_Adi]  DEFAULT ('') FOR [Depo_Adi]
GO
ALTER TABLE [dbo].[Depo_Tanitimi] ADD  CONSTRAINT [DF_Depo_Tanitimi_Isyeri_Kodu]  DEFAULT ((0)) FOR [Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Fis_Tipi]  DEFAULT ((0)) FOR [Fis_Tipi]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Isyeri_Kodu]  DEFAULT ((0)) FOR [Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Fis_No]  DEFAULT ((0)) FOR [Fis_No]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Silindi]  DEFAULT ((0)) FOR [Silindi]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Depo_Kodu]  DEFAULT ((0)) FOR [Depo_Kodu_1]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Depo_Kodu_11]  DEFAULT ((0)) FOR [Depo_Kodu_2]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Fis_Tarihi]  DEFAULT ('') FOR [Fis_Tarihi]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Fis_Saati]  DEFAULT ('') FOR [Fis_Saati]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Cari_No]  DEFAULT ((0)) FOR [Cari_No]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Kasa_Kodu]  DEFAULT ('') FOR [Kasa_Kodu]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Belge_Tipi]  DEFAULT ('') FOR [Belge_Tipi]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Belge_No]  DEFAULT ('') FOR [Belge_No]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Belge_Tarihi]  DEFAULT ('') FOR [Belge_Tarihi]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Para_Birimi]  DEFAULT ('') FOR [Para_Birimi]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Fiyat_Tipi]  DEFAULT ((0)) FOR [Fiyat_Tipi]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Kdv_Tipi_1]  DEFAULT ((0)) FOR [Kdv_Tipi_1]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Kdv_Tipi_2]  DEFAULT ((0)) FOR [Kdv_Tipi_2]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Aciklama]  DEFAULT ('') FOR [Aciklama]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Insert_User]  DEFAULT ('') FOR [Insert_User]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Inser_Date]  DEFAULT ('') FOR [Inser_Date]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Update_User]  DEFAULT ('') FOR [Update_User]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Update_Date]  DEFAULT ('') FOR [Update_Date]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Delete_User]  DEFAULT ('') FOR [Delete_User]
GO
ALTER TABLE [dbo].[Islem_Baslik] ADD  CONSTRAINT [DF_Islem_Baslik_Delete_Date]  DEFAULT ('') FOR [Delete_Date]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Islem_Detay_Cari_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Islem_Detay_Cari_Fis_Tipi]  DEFAULT ((0)) FOR [Fis_Tipi]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Islem_Detay_Cari_Isyeri_Kodu]  DEFAULT ((0)) FOR [Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Islem_Detay_Cari_Fis_No]  DEFAULT ((0)) FOR [Fis_No]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Islem_Detay_Cari_Fis_Sira]  DEFAULT ((0)) FOR [Fis_Sira]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Islem_Detay_Cari_Islem_Yonu]  DEFAULT ((0)) FOR [Islem_Yonu]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Islem_Detay_Cari_Silindi]  DEFAULT ((0)) FOR [Silindi]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Islem_Detay_Cari_Fis_Tarihi]  DEFAULT ('') FOR [Fis_Tarihi]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Islem_Detay_Cari_Fis_Saati]  DEFAULT ('') FOR [Fis_Saati]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Islem_Detay_Cari_Cari_No]  DEFAULT ((0)) FOR [Cari_No]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Islem_Detay_Cari_Masraf_No]  DEFAULT ((0)) FOR [Masraf_No]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Table_1_Borc_Tutari_Cari]  DEFAULT ((0)) FOR [Borc_Tutari]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Table_1_Borc_Tutari_Cari_Baslik]  DEFAULT ((0)) FOR [Borc_Tutari_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Table_1_Borc_Tutari_Cari_Kart]  DEFAULT ((0)) FOR [Borc_Tutari_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Table_1_Borc_Tutari_Cari_Sistem]  DEFAULT ((0)) FOR [Borc_Tutari_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Table_1_Alacak_Tutari_Cari]  DEFAULT ((0)) FOR [Alacak_Tutari]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Table_1_Alacak_Tutari_Cari_Baslik]  DEFAULT ((0)) FOR [Alacak_Tutari_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Table_1_Alacak_Tutari_Cari_Kart]  DEFAULT ((0)) FOR [Alacak_Tutari_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Table_1_Alacak_Tutari_Cari_Sistem]  DEFAULT ((0)) FOR [Alacak_Tutari_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Cari] ADD  CONSTRAINT [DF_Islem_Detay_Cari_Aciklama]  DEFAULT ('') FOR [Aciklama]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Fis_Tipi]  DEFAULT ((0)) FOR [Fis_Tipi]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Isyeri_Kodu]  DEFAULT ((0)) FOR [Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Fis_No]  DEFAULT ((0)) FOR [Fis_No]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Fis_Sira]  DEFAULT ((0)) FOR [Fis_Sira]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Islem_Yonu]  DEFAULT ((0)) FOR [Islem_Yonu]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Silindi]  DEFAULT ((0)) FOR [Silindi]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Fis_Tarihi]  DEFAULT ('') FOR [Fis_Tarihi]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Fis_Saati]  DEFAULT ('') FOR [Fis_Saati]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Kasa_Kodu]  DEFAULT ('') FOR [Kasa_Kodu]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Cari_No]  DEFAULT ((0)) FOR [Cari_No]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Masraf_No]  DEFAULT ((0)) FOR [Masraf_No]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Table_1_Borc_Tutari_Kasa]  DEFAULT ((0)) FOR [Borc_Tutari]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Table_1_Borc_Tutari_Kasa_Baslik]  DEFAULT ((0)) FOR [Borc_Tutari_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Table_1_Borc_Tutari_Kasa_Kart]  DEFAULT ((0)) FOR [Borc_Tutari_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Table_1_Borc_Tutari_Kasa_Sistem]  DEFAULT ((0)) FOR [Borc_Tutari_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Table_1_Alacak_Tutari_Kasa]  DEFAULT ((0)) FOR [Alacak_Tutari]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Table_1_Alacak_Tutari_Kasa_Baslik]  DEFAULT ((0)) FOR [Alacak_Tutari_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Table_1_Alacak_Tutari_Kasa_Kart]  DEFAULT ((0)) FOR [Alacak_Tutari_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Table_1_Alacak_Tutari_Kasa_Sistem]  DEFAULT ((0)) FOR [Alacak_Tutari_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Aciklama]  DEFAULT ('') FOR [Aciklama]
GO
ALTER TABLE [dbo].[Islem_Detay_Kasa] ADD  CONSTRAINT [DF_Islem_Detay_Kasa_Odeme_No]  DEFAULT ((0)) FOR [Odeme_No]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Fis_Tipi]  DEFAULT ((0)) FOR [Fis_Tipi]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Isyeri_Kodu]  DEFAULT ((0)) FOR [Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Fis_No]  DEFAULT ((0)) FOR [Fis_No]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Fis_Sira]  DEFAULT ((0)) FOR [Fis_Sira]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Islem_Yonu]  DEFAULT ((0)) FOR [Islem_Yonu]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Silindi]  DEFAULT ((0)) FOR [Silindi]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Masraf_No]  DEFAULT ((0)) FOR [Masraf_No]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Fis_Tarihi]  DEFAULT ('') FOR [Fis_Tarihi]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Fis_Saati]  DEFAULT ('') FOR [Fis_Saati]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Borc_Tutari]  DEFAULT ((0)) FOR [Borc_Tutari]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Borc_Tutari_Baslik]  DEFAULT ((0)) FOR [Borc_Tutari_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Borc_Tutari_Kart]  DEFAULT ((0)) FOR [Borc_Tutari_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Borc_Tutari_Sistem]  DEFAULT ((0)) FOR [Borc_Tutari_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Alacak_Tutari]  DEFAULT ((0)) FOR [Alacak_Tutari]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Alacak_Tutari_Baslik]  DEFAULT ((0)) FOR [Alacak_Tutari_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Alacak_Tutari_Kart]  DEFAULT ((0)) FOR [Alacak_Tutari_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Alacak_Tutari_Sistem]  DEFAULT ((0)) FOR [Alacak_Tutari_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Kdv_Orani]  DEFAULT ((0)) FOR [Kdv_Orani]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Kdv_Tutari]  DEFAULT ((0)) FOR [Kdv_Tutari]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Kdv_Tutari_Baslik]  DEFAULT ((0)) FOR [Kdv_Tutari_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Kdv_Tutari_Kart]  DEFAULT ((0)) FOR [Kdv_Tutari_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Kdv_Tutari_Sistem]  DEFAULT ((0)) FOR [Kdv_Tutari_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Masraf] ADD  CONSTRAINT [DF_Islem_Detay_Masraf_Aciklama]  DEFAULT ('') FOR [Aciklama]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Fis_Tipi]  DEFAULT ((0)) FOR [Fis_Tipi]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isyeri_Kodu]  DEFAULT ((0)) FOR [Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Fis_No]  DEFAULT ((0)) FOR [Fis_No]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Fis_Sira]  DEFAULT ((0)) FOR [Fis_Sira]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Islem_Yonu]  DEFAULT ((0)) FOR [Islem_Yonu]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Silindi]  DEFAULT ((0)) FOR [Silindi]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Fis_Tarihi]  DEFAULT ('') FOR [Fis_Tarihi]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Fis_Saati]  DEFAULT ('') FOR [Fis_Saati]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Depo_Kodu]  DEFAULT ((0)) FOR [Depo_Kodu]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Stok_No]  DEFAULT ((0)) FOR [Stok_No]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Birim_Kodu]  DEFAULT ('') FOR [Birim_Kodu]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Giris_Miktari]  DEFAULT ((0)) FOR [Giris_Miktari]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Cikis_Miktari]  DEFAULT ((0)) FOR [Cikis_Miktari]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Birim_Fiyati]  DEFAULT ((0)) FOR [Birim_Fiyati]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Orani_1]  DEFAULT ((0)) FOR [Isk_Orani_1]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Orani_2]  DEFAULT ((0)) FOR [Isk_Orani_2]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Orani_3]  DEFAULT ((0)) FOR [Isk_Orani_3]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Kdv_Orani]  DEFAULT ((0)) FOR [Kdv_Orani]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Tutari_1]  DEFAULT ((0)) FOR [Isk_Tutari_1]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Tutari_1_Baslik]  DEFAULT ((0)) FOR [Isk_Tutari_1_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Tutari_1_Kart]  DEFAULT ((0)) FOR [Isk_Tutari_1_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Tutari_1_Sistem]  DEFAULT ((0)) FOR [Isk_Tutari_1_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Tutari_2]  DEFAULT ((0)) FOR [Isk_Tutari_2]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Tutari_2_Baslik]  DEFAULT ((0)) FOR [Isk_Tutari_2_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Tutari_2_Kart]  DEFAULT ((0)) FOR [Isk_Tutari_2_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Tutari_2_Sistem]  DEFAULT ((0)) FOR [Isk_Tutari_2_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Tutari_3]  DEFAULT ((0)) FOR [Isk_Tutari_3]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Tutari_3_Baslik]  DEFAULT ((0)) FOR [Isk_Tutari_3_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Tutari_3_Kart]  DEFAULT ((0)) FOR [Isk_Tutari_3_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Isk_Tutari_3_Sistem]  DEFAULT ((0)) FOR [Isk_Tutari_3_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Kdv_Tutari]  DEFAULT ((0)) FOR [Kdv_Tutari]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Kdv_Tutari_Baslik]  DEFAULT ((0)) FOR [Kdv_Tutari_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Kdv_Tutari_Kart]  DEFAULT ((0)) FOR [Kdv_Tutari_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Kdv_Tutari_Sistem]  DEFAULT ((0)) FOR [Kdv_Tutari_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Giris_Tutari]  DEFAULT ((0)) FOR [Giris_Tutari]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Giris_Tutari_Baslik]  DEFAULT ((0)) FOR [Giris_Tutari_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Giris_Tutari_Kart]  DEFAULT ((0)) FOR [Giris_Tutari_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Giris_Tutari_Sistem]  DEFAULT ((0)) FOR [Giris_Tutari_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Cikis_Tutari]  DEFAULT ((0)) FOR [Cikis_Tutari]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Cikis_Tutari_Baslik]  DEFAULT ((0)) FOR [Cikis_Tutari_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Cikis_Tutari_Kart]  DEFAULT ((0)) FOR [Cikis_Tutari_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Cikis_Tutari_Sistem]  DEFAULT ((0)) FOR [Cikis_Tutari_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Giris_Tutari_Net]  DEFAULT ((0)) FOR [Giris_Tutari_Net]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Giris_Tutari_Net_Baslik]  DEFAULT ((0)) FOR [Giris_Tutari_Net_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Giris_Tutari_Net_Kart]  DEFAULT ((0)) FOR [Giris_Tutari_Net_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Giris_Tutari_Net_Sistem]  DEFAULT ((0)) FOR [Giris_Tutari_Net_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Cikis_Tutari_Net]  DEFAULT ((0)) FOR [Cikis_Tutari_Net]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Cikis_Tutari_Net_Baslik]  DEFAULT ((0)) FOR [Cikis_Tutari_Net_Baslik]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Cikis_Tutari_Net_Kart]  DEFAULT ((0)) FOR [Cikis_Tutari_Net_Kart]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Cikis_Tutari_Net_Sistem]  DEFAULT ((0)) FOR [Cikis_Tutari_Net_Sistem]
GO
ALTER TABLE [dbo].[Islem_Detay_Stok] ADD  CONSTRAINT [DF_Islem_Detay_Stok_Aciklama]  DEFAULT ('') FOR [Aciklama]
GO
ALTER TABLE [dbo].[Isyeri_Tanitimi] ADD  CONSTRAINT [DF_Isyeri_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Isyeri_Tanitimi] ADD  CONSTRAINT [DF_Isyeri_Tanitimi_Isyeri_Kodu]  DEFAULT ((0)) FOR [Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Isyeri_Tanitimi] ADD  CONSTRAINT [DF_Isyeri_Tanitimi_Isyeri_Adi]  DEFAULT ('') FOR [Isyeri_Adi]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Kasa_Kodu]  DEFAULT ('') FOR [Kasa_Kodu]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Silindi]  DEFAULT ((0)) FOR [Silindi]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Kasa_Adi]  DEFAULT ('') FOR [Kasa_Adi]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Yetkilisi]  DEFAULT ('') FOR [Yetkilisi]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Para_Birimi]  DEFAULT ('') FOR [Para_Birimi]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Isyeri_Kodu]  DEFAULT ((0)) FOR [Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Insert_User]  DEFAULT ('') FOR [Insert_User]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Inser_Date]  DEFAULT ('') FOR [Insert_Date]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Update_User]  DEFAULT ('') FOR [Update_User]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Update_Date]  DEFAULT ('') FOR [Update_Date]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Delete_User]  DEFAULT ('') FOR [Delete_User]
GO
ALTER TABLE [dbo].[Kasa_Tanitimi] ADD  CONSTRAINT [DF_Kasa_Tanitimi_Delete_Date]  DEFAULT ('') FOR [Delete_Date]
GO
ALTER TABLE [dbo].[Kdv_Tanitimi] ADD  CONSTRAINT [DF_Kdv_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Masa_Tanitimi] ADD  CONSTRAINT [DF_Masa_Tanitimi_Isyeri_Kodu]  DEFAULT ((0)) FOR [Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Masa_Tanitimi] ADD  CONSTRAINT [DF_Masa_Tanitimi_Salon_Kodu]  DEFAULT ('') FOR [Salon_Kodu]
GO
ALTER TABLE [dbo].[Masa_Tanitimi] ADD  CONSTRAINT [DF_Masa_Tanitimi_Masa_Kodu]  DEFAULT ('') FOR [Masa_Kodu]
GO
ALTER TABLE [dbo].[Masa_Tanitimi] ADD  CONSTRAINT [DF_Masa_Tanitimi_Lokasyon_X]  DEFAULT ((0)) FOR [Lokasyon_X]
GO
ALTER TABLE [dbo].[Masa_Tanitimi] ADD  CONSTRAINT [DF_Masa_Tanitimi_Lokasyon_Y]  DEFAULT ((0)) FOR [Lokasyon_Y]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Masraf_No]  DEFAULT ((0)) FOR [Masraf_No]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Masraf_Kodu]  DEFAULT ('') FOR [Masraf_Kodu]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Silindi]  DEFAULT ((0)) FOR [Silindi]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Masraf_Adi]  DEFAULT ('') FOR [Masraf_Adi]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Islem]  DEFAULT ((0)) FOR [Islem]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Masraf_Tipi]  DEFAULT ((0)) FOR [Masraf_Tipi]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Kdv_Orani]  DEFAULT ((0)) FOR [Kdv_Orani]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Kdv_Tutari]  DEFAULT ((0)) FOR [Kdv_Tutari]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Insert_User]  DEFAULT ('') FOR [Insert_User]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Insert_Date]  DEFAULT ('') FOR [Insert_Date]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Update_User]  DEFAULT ('') FOR [Update_User]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Update_Date]  DEFAULT ('') FOR [Update_Date]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Delete_User]  DEFAULT ('') FOR [Delete_User]
GO
ALTER TABLE [dbo].[Masraf_Tanitimi] ADD  CONSTRAINT [DF_Masraf_Tanitimi_Delete_Date]  DEFAULT ('') FOR [Delete_Date]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Odeme_No]  DEFAULT ((0)) FOR [Odeme_No]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Odeme_Kodu]  DEFAULT ('') FOR [Odeme_Kodu]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Silindi]  DEFAULT ((0)) FOR [Silindi]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Odeme_Adi]  DEFAULT ('') FOR [Odeme_Adi]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Odeme_Tipi]  DEFAULT ('') FOR [Odeme_Tipi]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Kayit_Tipi]  DEFAULT ((0)) FOR [Kayit_Tipi]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Kayit_Kodu]  DEFAULT ('') FOR [Kayit_Kodu]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Insert_User]  DEFAULT ('') FOR [Insert_User]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Insert_Date]  DEFAULT ('') FOR [Insert_Date]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Update_User]  DEFAULT ('') FOR [Update_User]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Update_Date]  DEFAULT ('') FOR [Update_Date]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Delete_User]  DEFAULT ('') FOR [Delete_User]
GO
ALTER TABLE [dbo].[Odeme_Tanitimi] ADD  CONSTRAINT [DF_Odeme_Tanitimi_Delete_Date]  DEFAULT ('') FOR [Delete_Date]
GO
ALTER TABLE [dbo].[Para_Birimi_Tanitimi] ADD  CONSTRAINT [DF_Para_Birimi_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Para_Birimi_Tanitimi] ADD  CONSTRAINT [DF_Para_Birimi_Tanitimi_Para_Birimi]  DEFAULT ('') FOR [Para_Birimi]
GO
ALTER TABLE [dbo].[Parametreler] ADD  CONSTRAINT [DF_Parametreler_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Parametreler] ADD  CONSTRAINT [DF_Parametreler_Kodu]  DEFAULT ('') FOR [Kodu]
GO
ALTER TABLE [dbo].[Parametreler] ADD  CONSTRAINT [DF_Parametreler_Degeri]  DEFAULT ('') FOR [Degeri]
GO
ALTER TABLE [dbo].[Salon_Tanitimi] ADD  CONSTRAINT [DF_Salon_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Salon_Tanitimi] ADD  CONSTRAINT [DF_Salon_Tanitimi_Isyeri_Kodu]  DEFAULT ((0)) FOR [Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Salon_Tanitimi] ADD  CONSTRAINT [DF_Salon_Tanitimi_Salon_Kodu]  DEFAULT ('') FOR [Salon_Kodu]
GO
ALTER TABLE [dbo].[Salon_Tanitimi] ADD  CONSTRAINT [DF_Salon_Tanitimi_Salon_Adi]  DEFAULT ('') FOR [Salon_Adi]
GO
ALTER TABLE [dbo].[Stok_Bagli_Irsaliyeler] ADD  CONSTRAINT [DF_Stok_Bagli_Irsaliyeler_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Stok_Bagli_Irsaliyeler] ADD  CONSTRAINT [DF_Stok_Bagli_Irsaliyeler_Irsaliye_Fis_Tipi]  DEFAULT ((0)) FOR [Irsaliye_Fis_Tipi]
GO
ALTER TABLE [dbo].[Stok_Bagli_Irsaliyeler] ADD  CONSTRAINT [DF_Stok_Bagli_Irsaliyeler_Irsaliye_Isyeri_Kodu]  DEFAULT ((0)) FOR [Irsaliye_Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Stok_Bagli_Irsaliyeler] ADD  CONSTRAINT [DF_Stok_Bagli_Irsaliyeler_Irsaliye_Fis_No]  DEFAULT ((0)) FOR [Irsaliye_Fis_No]
GO
ALTER TABLE [dbo].[Stok_Bagli_Irsaliyeler] ADD  CONSTRAINT [DF_Stok_Bagli_Irsaliyeler_Fatura_Fis_Tipi]  DEFAULT ((0)) FOR [Fatura_Fis_Tipi]
GO
ALTER TABLE [dbo].[Stok_Bagli_Irsaliyeler] ADD  CONSTRAINT [DF_Stok_Bagli_Irsaliyeler_Fatura_Isyeri_Kodu]  DEFAULT ((0)) FOR [Fatura_Isyeri_Kodu]
GO
ALTER TABLE [dbo].[Stok_Bagli_Irsaliyeler] ADD  CONSTRAINT [DF_Stok_Bagli_Irsaliyeler_Fatura_Fis_No]  DEFAULT ((0)) FOR [Fatura_Fis_No]
GO
ALTER TABLE [dbo].[Stok_Bagli_Tanitimi] ADD  CONSTRAINT [DF_Stok_Bagli_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Stok_Birim_Tanitimi] ADD  CONSTRAINT [DF_Stok_Birim_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Stok_Birim_Tanitimi] ADD  CONSTRAINT [DF_Stok_Birim_Tanitimi_Birim_Kodu]  DEFAULT ('') FOR [Birim_Kodu]
GO
ALTER TABLE [dbo].[Stok_Birim_Tanitimi] ADD  CONSTRAINT [DF_Stok_Birim_Tanitimi_Birim_Adi]  DEFAULT ('') FOR [Birim_Adi]
GO
ALTER TABLE [dbo].[Stok_Birim_Tanitimi] ADD  CONSTRAINT [DF_Stok_Birim_Tanitimi_Agirlik_Birimi]  DEFAULT ((0)) FOR [Agirlik_Birimi]
GO
ALTER TABLE [dbo].[Stok_Departman_Tanitimi] ADD  CONSTRAINT [DF_Stok_Departman_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Stok_Departman_Tanitimi] ADD  CONSTRAINT [DF_Stok_Departman_Tanitimi_Departman_Kodu]  DEFAULT ('') FOR [Departman_Kodu]
GO
ALTER TABLE [dbo].[Stok_Departman_Tanitimi] ADD  CONSTRAINT [DF_Stok_Departman_Tanitimi_Departman_Adi]  DEFAULT ('') FOR [Departman_Adi]
GO
ALTER TABLE [dbo].[Stok_Grup_Tanitimi] ADD  CONSTRAINT [DF_Stok_Grup_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Stok_Grup_Tanitimi] ADD  CONSTRAINT [DF_Stok_Grup_Tanitimi_Grup_Kodu]  DEFAULT ('') FOR [Grup_Kodu]
GO
ALTER TABLE [dbo].[Stok_Grup_Tanitimi] ADD  CONSTRAINT [DF_Stok_Grup_Tanitimi_Grup_Adi]  DEFAULT ('') FOR [Grup_Adi]
GO
ALTER TABLE [dbo].[Stok_Ozel_Tanitimi] ADD  CONSTRAINT [DF_Stok_Ozel_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Stok_Ozel_Tanitimi] ADD  CONSTRAINT [DF_Stok_Ozel_Tanitimi_Ozel_Kodu]  DEFAULT ('') FOR [Ozel_Kodu]
GO
ALTER TABLE [dbo].[Stok_Ozel_Tanitimi] ADD  CONSTRAINT [DF_Stok_Ozel_Tanitimi_Ozel_Adi]  DEFAULT ('') FOR [Ozel_Adi]
GO
ALTER TABLE [dbo].[Stok_Reyon_Tanitimi] ADD  CONSTRAINT [DF_Stok_Reyon_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Stok_Reyon_Tanitimi] ADD  CONSTRAINT [DF_Table_1_Departman_Kodu]  DEFAULT ('') FOR [Reyon_Kodu]
GO
ALTER TABLE [dbo].[Stok_Reyon_Tanitimi] ADD  CONSTRAINT [DF_Table_1_Departman_Adi]  DEFAULT ('') FOR [Reyon_Adi]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Stok_No]  DEFAULT ((0)) FOR [Stok_No]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Silindi]  DEFAULT ((0)) FOR [Silindi]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Stok_Kodu]  DEFAULT ('') FOR [Stok_Kodu]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Stok_Adi]  DEFAULT ('') FOR [Stok_Adi]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Kisa_Adi]  DEFAULT ('') FOR [Kisa_Adi]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Durum]  DEFAULT ((0)) FOR [Durum]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Resim]  DEFAULT (NULL) FOR [Resim]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Grup_Kodu]  DEFAULT ('') FOR [Grup_Kodu]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu]  DEFAULT ('') FOR [Ozel_Kodu]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Kdv_Toptan]  DEFAULT ((0)) FOR [Kdv_Toptan]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Kdv_Perakende]  DEFAULT ((0)) FOR [Kdv_Perakende]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Stok_Tipi]  DEFAULT ((0)) FOR [Stok_Tipi]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Departman_Kodu]  DEFAULT ('') FOR [Departman_Kodu]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Min_Miktar]  DEFAULT ((0)) FOR [Min_Miktar]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Max_Miktar]  DEFAULT ((0)) FOR [Max_Miktar]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Raf_Omru]  DEFAULT ((0)) FOR [Raf_Omru]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Reyon_No]  DEFAULT ('') FOR [Reyon_Kodu]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Urun_Notu]  DEFAULT ('') FOR [Urun_Notu]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Urun_Icerigi]  DEFAULT ('') FOR [Urun_Icerigi]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ruhsat_Sahibi]  DEFAULT ('') FOR [Ruhsat_Sahibi]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ruhsat_Tarihi]  DEFAULT ('') FOR [Ruhsat_Tarihi]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Gida_Uretim_Izni]  DEFAULT ('') FOR [Gida_Uretim_Izni]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Alerjen_Uyarisi]  DEFAULT ('') FOR [Alerjen_Uyarisi]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Birim_Tipi_1]  DEFAULT ('') FOR [Birim_Kodu_1]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT1_Orani]  DEFAULT ((0)) FOR [BT1_Orani]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT1_Barkod]  DEFAULT ('') FOR [BT1_Barkod]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT1_Hizli_Satis]  DEFAULT ((0)) FOR [BT1_Hizli_Satis]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT1_Alis_Fiyati]  DEFAULT ((0)) FOR [BT1_Alis_Fiyati]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT1_Alis_Kdvli_Fiyati]  DEFAULT ((0)) FOR [BT1_Alis_Kdvli_Fiyati]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT1_Satis_Fiyati]  DEFAULT ((0)) FOR [BT1_Satis_Fiyati_1]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT1_Satis_Fiyati_11]  DEFAULT ((0)) FOR [BT1_Satis_Fiyati_2]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT1_Satis_Fiyati_12]  DEFAULT ((0)) FOR [BT1_Satis_Fiyati_3]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Birim_Kodu_11]  DEFAULT ('') FOR [Birim_Kodu_2]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT2_Orani]  DEFAULT ((0)) FOR [BT2_Orani]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT2_Barkod]  DEFAULT ('') FOR [BT2_Barkod]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT2_Hizli_Satis]  DEFAULT ((0)) FOR [BT2_Hizli_Satis]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT2_Alis_Fiyati]  DEFAULT ((0)) FOR [BT2_Alis_Fiyati]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT2_Alis_Kdvli_Fiyati]  DEFAULT ((0)) FOR [BT2_Alis_Kdvli_Fiyati]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT2_Satis_Fiyati]  DEFAULT ((0)) FOR [BT2_Satis_Fiyati_1]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT2_Satis_Fiyati_11]  DEFAULT ((0)) FOR [BT2_Satis_Fiyati_2]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_BT2_Satis_Fiyati_12]  DEFAULT ((0)) FOR [BT2_Satis_Fiyati_3]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Karbonhidrat]  DEFAULT ((0)) FOR [Karbonhidrat]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Protein]  DEFAULT ((0)) FOR [Protein]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Yag]  DEFAULT ((0)) FOR [Yag]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_DoymusYag]  DEFAULT ((0)) FOR [Doymus_Yag]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Lif]  DEFAULT ((0)) FOR [Lif]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Kolesterol]  DEFAULT ((0)) FOR [Kolesterol]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Sodyum]  DEFAULT ((0)) FOR [Sodyum]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Potasyum]  DEFAULT ((0)) FOR [Potasyum]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Kalsiyum]  DEFAULT ((0)) FOR [Kalsiyum]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_VitaminA]  DEFAULT ((0)) FOR [Vitamin_A]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_VitaminC]  DEFAULT ((0)) FOR [Vitamin_C]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Demir]  DEFAULT ((0)) FOR [Demir]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Enerji]  DEFAULT ((0)) FOR [Enerji]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Seker]  DEFAULT ((0)) FOR [Seker]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_1]  DEFAULT ('') FOR [Ozel_Kodu_1]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_11]  DEFAULT ('') FOR [Ozel_Kodu_2]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_11_1]  DEFAULT ('') FOR [Ozel_Kodu_3]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_11_2]  DEFAULT ('') FOR [Ozel_Kodu_4]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_11_3]  DEFAULT ('') FOR [Ozel_Kodu_5]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_11_4]  DEFAULT ('') FOR [Ozel_Kodu_6]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_11_5]  DEFAULT ('') FOR [Ozel_Kodu_7]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_71]  DEFAULT ('') FOR [Ozel_Kodu_8]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_71_1]  DEFAULT ('') FOR [Ozel_Kodu_9]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_71_2]  DEFAULT ('') FOR [Ozel_Kodu_10]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_71_3]  DEFAULT ('') FOR [Ozel_Kodu_11]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_71_4]  DEFAULT ('') FOR [Ozel_Kodu_12]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_71_5]  DEFAULT ('') FOR [Ozel_Kodu_13]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_71_6]  DEFAULT ('') FOR [Ozel_Kodu_14]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Ozel_Kodu_71_7]  DEFAULT ('') FOR [Ozel_Kodu_15]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Insert_User]  DEFAULT ('') FOR [Insert_User]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Inser_Date]  DEFAULT ('') FOR [Insert_Date]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Update_User]  DEFAULT ('') FOR [Update_User]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Update_Date]  DEFAULT ('') FOR [Update_Date]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Delete_User]  DEFAULT ('') FOR [Delete_User]
GO
ALTER TABLE [dbo].[Stok_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tanitimi_Delete_Date]  DEFAULT ('') FOR [Delete_Date]
GO
ALTER TABLE [dbo].[Stok_Tedarikci_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tedarikci_Tanitimi_Kurum_Kodu]  DEFAULT ('') FOR [Kurum_Kodu]
GO
ALTER TABLE [dbo].[Stok_Tedarikci_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tedarikci_Tanitimi_Stok_No]  DEFAULT ((0)) FOR [Stok_No]
GO
ALTER TABLE [dbo].[Stok_Tedarikci_Tanitimi] ADD  CONSTRAINT [DF_Stok_Tedarikci_Tanitimi_Tedarikci_No]  DEFAULT ((0)) FOR [Tedarikci_No]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = Erkek, 1 = Kýz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cari_Tanitimi', @level2type=N'COLUMN',@level2name=N'Cinsiyeti'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = Aktif, 1 = Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cari_Tanitimi', @level2type=N'COLUMN',@level2name=N'Durum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Günlük Harcama Limiti' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cari_Tanitimi', @level2type=N'COLUMN',@level2name=N'Harcama_Limiti'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = Erkek, 1 = Kýz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cari_Tanitimi', @level2type=N'COLUMN',@level2name=N'Veli_Cinsiyeti'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = Ürün Grubu, 1 = Tek Ürün' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cari_Yasakli_Urunler', @level2type=N'COLUMN',@level2name=N'Tip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = Veresiye, 
1 = Cari, 
2 = Kasa, 
3 = Banka' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Odeme_Tanitimi', @level2type=N'COLUMN',@level2name=N'Kayit_Tipi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = Aktif, 1 = Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Stok_Tanitimi', @level2type=N'COLUMN',@level2name=N'Durum'
GO
USE [master]
GO
ALTER DATABASE [PRCSOFT] SET  READ_WRITE 
GO
