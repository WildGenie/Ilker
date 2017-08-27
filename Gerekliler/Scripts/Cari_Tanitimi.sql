/*
   28 Ağustos 2017 Pazartesi00:36:29
   User: 
   Server: (localdb)\MSSQLLocalDB
   Database: PRCSOFT
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Kurum_Kodu
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Cari_No
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Silindi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Cari_Kodu
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Unvani
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Adi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Soyadi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Kart_Kodu
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Sinifi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Subesi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Ogrenci_No
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Cinsiyeti
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Durum
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Boy
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Kilo
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Dogum_Tarihi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Harcama_Limiti
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Veli_Adi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Veli_Soyadi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Veli_Cinsiyeti
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Telefon_11
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Veli_Telefon_11
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_E_Mail_11
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Veli_E_Mail1
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Resim
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Grup_Kodu
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Ozel_Kodu
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Indirim
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Para_Birimi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Vergi_Dairesi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Vergi_No
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Musteri
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Satici
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Satici1
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Ogrenci
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Ogretmen
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Mahalle_Koy
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Cadde_Sokak
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Dis_Kapi_No
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Site_Adi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Apartman_Adi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Kat
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Daire
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Ilce
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Il
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Ulke
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Telefon_1
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Telefon_2
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Telefon_3
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Fax_1
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Fax_2
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_E_Mail_1
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_E_Mail_2
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Ise_Giris_Tarihi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Isten_Cikis_Tarihi
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Gorev_Kodu
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Maas
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Insert_User
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Inser_Date
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Update_User
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Update_Date
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Delete_User
GO
ALTER TABLE dbo.Cari_Tanitimi
	DROP CONSTRAINT DF_Cari_Tanitimi_Delete_Date
GO
CREATE TABLE dbo.Tmp_Cari_Tanitimi
	(
	Kurum_Kodu varchar(20) NOT NULL,
	Cari_No int NOT NULL,
	Silindi tinyint NULL,
	Cari_Kodu varchar(25) NULL,
	Unvani varchar(255) NULL,
	Adi varchar(50) NULL,
	Soyadi varchar(50) NULL,
	Kart_Kodu varchar(20) NULL,
	Sinifi varchar(20) NULL,
	Subesi varchar(20) NULL,
	Ogrenci_No int NULL,
	Cinsiyeti tinyint NULL,
	Durum tinyint NULL,
	Boy float(53) NULL,
	Kilo float(53) NULL,
	Dogum_Tarihi datetime NULL,
	Harcama_Limiti float(53) NULL,
	Veli_Adi varchar(50) NULL,
	Veli_Soyadi varchar(50) NULL,
	Veli_Cinsiyeti tinyint NULL,
	Veli_Telefon_1 varchar(50) NULL,
	Veli_Telefon_2 varchar(50) NULL,
	Veli_E_Mail varchar(150) NULL,
	Veli_E_Mail_Gonder tinyint NULL,
	Resim varbinary(MAX) NULL,
	Grup_Kodu varchar(25) NULL,
	Ozel_Kodu varchar(25) NULL,
	Indirim float(53) NULL,
	Para_Birimi varchar(10) NULL,
	Vergi_Dairesi varchar(255) NULL,
	Vergi_TC_No varchar(15) NULL,
	Musteri tinyint NULL,
	Satici tinyint NULL,
	Personel tinyint NULL,
	Ogrenci tinyint NULL,
	Ogretmen tinyint NULL,
	Mahalle_Koy varchar(50) NULL,
	Cadde_Sokak varchar(50) NULL,
	Dis_Kapi_No varchar(10) NULL,
	Site_Adi varchar(50) NULL,
	Apartman_Blok varchar(50) NULL,
	Kat varchar(10) NULL,
	Daire varchar(10) NULL,
	Ilce varchar(50) NULL,
	Il varchar(50) NULL,
	Ulke varchar(50) NULL,
	Telefon_1 varchar(50) NULL,
	Telefon_2 varchar(50) NULL,
	Telefon_3 varchar(50) NULL,
	Fax_1 varchar(50) NULL,
	Fax_2 varchar(50) NULL,
	E_Mail_1 varchar(150) NULL,
	E_Mail_2 varchar(150) NULL,
	Ise_Giris_Tarihi datetime NULL,
	Isten_Cikis_Tarihi datetime NULL,
	Gorev_Kodu varchar(25) NULL,
	Maas float(53) NULL,
	Aile_No varchar(10) NULL,
	Ana_Adi varchar(50) NULL,
	Baba_Adi varchar(50) NULL,
	Banka_Adi varchar(150) NULL,
	Banka_Subesi varchar(150) NULL,
	Calisma_Yeri varchar(100) NULL,
	Cikis_Nedeni varchar(255) NULL,
	Cilt_No varchar(10) NULL,
	Dogum_Yeri varchar(50) NULL,
	Hesap_No varchar(255) NULL,
	Kimlik_Il varchar(50) NULL,
	Kimlik_Ilce varchar(50) NULL,
	Kimlik_Mahalle_Koy varchar(50) NULL,
	Kimlik_Seri_No_1 varchar(5) NULL,
	Kimlik_Seri_No_2 varchar(20) NULL,
	Sira_No varchar(10) NULL,
	Askerlik tinyint NULL,
	Egitim_Durumu tinyint NULL,
	Ehliyet tinyint NULL,
	Isyeri_Kodu int NOT NULL,
	Kan_Grubu tinyint NULL,
	Medeni_Hali tinyint NULL,
	AGI_Tutari float(53) NULL,
	Cocuk_Sayisi int NULL,
	Yatirilan_Maas float(53) NULL,
	Insert_User varchar(50) NULL,
	Insert_Date datetime NULL,
	Update_User varchar(50) NULL,
	Update_Date datetime NULL,
	Delete_User varchar(50) NULL,
	Delete_Date datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi SET (LOCK_ESCALATION = TABLE)
GO
DECLARE @v sql_variant 
SET @v = N'0 = Erkek, 1 = Kız'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Cari_Tanitimi', N'COLUMN', N'Cinsiyeti'
GO
DECLARE @v sql_variant 
SET @v = N'0 = Aktif, 1 = Pasif'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Cari_Tanitimi', N'COLUMN', N'Durum'
GO
DECLARE @v sql_variant 
SET @v = N'Günlük Harcama Limiti'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Cari_Tanitimi', N'COLUMN', N'Harcama_Limiti'
GO
DECLARE @v sql_variant 
SET @v = N'0 = Erkek, 1 = Kız'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Cari_Tanitimi', N'COLUMN', N'Veli_Cinsiyeti'
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Kurum_Kodu DEFAULT ('') FOR Kurum_Kodu
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Cari_No DEFAULT ((0)) FOR Cari_No
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Silindi DEFAULT ((0)) FOR Silindi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Cari_Kodu DEFAULT ('') FOR Cari_Kodu
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Unvani DEFAULT ('') FOR Unvani
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Adi DEFAULT ('') FOR Adi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Soyadi DEFAULT ('') FOR Soyadi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Kart_Kodu DEFAULT ('') FOR Kart_Kodu
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Sinifi DEFAULT ('') FOR Sinifi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Subesi DEFAULT ('') FOR Subesi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Ogrenci_No DEFAULT ((0)) FOR Ogrenci_No
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Cinsiyeti DEFAULT ((0)) FOR Cinsiyeti
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Durum DEFAULT ((0)) FOR Durum
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Boy DEFAULT ((0)) FOR Boy
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Kilo DEFAULT ((0)) FOR Kilo
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Dogum_Tarihi DEFAULT ('') FOR Dogum_Tarihi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Harcama_Limiti DEFAULT ((0)) FOR Harcama_Limiti
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Veli_Adi DEFAULT ('') FOR Veli_Adi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Veli_Soyadi DEFAULT ('') FOR Veli_Soyadi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Veli_Cinsiyeti DEFAULT ((0)) FOR Veli_Cinsiyeti
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Telefon_11 DEFAULT ('') FOR Veli_Telefon_1
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Veli_Telefon_11 DEFAULT ('') FOR Veli_Telefon_2
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_E_Mail_11 DEFAULT ('') FOR Veli_E_Mail
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Veli_E_Mail1 DEFAULT ((0)) FOR Veli_E_Mail_Gonder
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Resim DEFAULT (NULL) FOR Resim
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Grup_Kodu DEFAULT ('') FOR Grup_Kodu
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Ozel_Kodu DEFAULT ('') FOR Ozel_Kodu
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Indirim DEFAULT ((0)) FOR Indirim
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Para_Birimi DEFAULT ('') FOR Para_Birimi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Vergi_Dairesi DEFAULT ('') FOR Vergi_Dairesi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Vergi_No DEFAULT ('') FOR Vergi_TC_No
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Musteri DEFAULT ((0)) FOR Musteri
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Satici DEFAULT ((0)) FOR Satici
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Satici1 DEFAULT ((0)) FOR Personel
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Ogrenci DEFAULT ((0)) FOR Ogrenci
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Ogretmen DEFAULT ((0)) FOR Ogretmen
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Mahalle_Koy DEFAULT ('') FOR Mahalle_Koy
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Cadde_Sokak DEFAULT ('') FOR Cadde_Sokak
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Dis_Kapi_No DEFAULT ('') FOR Dis_Kapi_No
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Site_Adi DEFAULT ('') FOR Site_Adi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Apartman_Adi DEFAULT ('') FOR Apartman_Blok
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Kat DEFAULT ('') FOR Kat
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Daire DEFAULT ('') FOR Daire
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Ilce DEFAULT ('') FOR Ilce
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Il DEFAULT ('') FOR Il
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Ulke DEFAULT ('') FOR Ulke
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Telefon_1 DEFAULT ('') FOR Telefon_1
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Telefon_2 DEFAULT ('') FOR Telefon_2
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Telefon_3 DEFAULT ('') FOR Telefon_3
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Fax_1 DEFAULT ('') FOR Fax_1
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Fax_2 DEFAULT ('') FOR Fax_2
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_E_Mail_1 DEFAULT ('') FOR E_Mail_1
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_E_Mail_2 DEFAULT ('') FOR E_Mail_2
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Ise_Giris_Tarihi DEFAULT ('') FOR Ise_Giris_Tarihi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Isten_Cikis_Tarihi DEFAULT ('') FOR Isten_Cikis_Tarihi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Gorev_Kodu DEFAULT ('') FOR Gorev_Kodu
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Maas DEFAULT ((0)) FOR Maas
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Aile_No DEFAULT '' FOR Aile_No
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Ana_Adi DEFAULT '' FOR Ana_Adi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Ana_Adi1 DEFAULT '' FOR Baba_Adi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Baba_Adi1 DEFAULT '' FOR Banka_Adi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Banka_Adi1 DEFAULT '' FOR Banka_Subesi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Banka_Subesi1 DEFAULT '' FOR Calisma_Yeri
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Calisma_Yeri1 DEFAULT '' FOR Cikis_Nedeni
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Aile_No1 DEFAULT '' FOR Cilt_No
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Cikis_Nedeni1 DEFAULT '' FOR Dogum_Yeri
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Il1 DEFAULT ('') FOR Kimlik_Il
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Ilce1 DEFAULT ('') FOR Kimlik_Ilce
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Mahalle_Koy1 DEFAULT ('') FOR Kimlik_Mahalle_Koy
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Kimlik_Seri_No_1 DEFAULT '' FOR Kimlik_Seri_No_1
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Kimlik_Seri_No_11 DEFAULT '' FOR Kimlik_Seri_No_2
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Cilt_No1 DEFAULT '' FOR Sira_No
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Askerlik DEFAULT 0 FOR Askerlik
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Askerlik1 DEFAULT 0 FOR Egitim_Durumu
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Egitim_Durumu1 DEFAULT 0 FOR Ehliyet
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Isyeri_Kodu DEFAULT ((0)) FOR Isyeri_Kodu
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Ehliyet1 DEFAULT 0 FOR Kan_Grubu
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Kan_Grubu1 DEFAULT 0 FOR Medeni_Hali
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_AGI_Tutari DEFAULT 0 FOR AGI_Tutari
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Cocuk_Sayisi DEFAULT 0 FOR Cocuk_Sayisi
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Maas1 DEFAULT ((0)) FOR Yatirilan_Maas
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Insert_User DEFAULT ('') FOR Insert_User
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Inser_Date DEFAULT ('') FOR Insert_Date
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Update_User DEFAULT ('') FOR Update_User
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Update_Date DEFAULT ('') FOR Update_Date
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Delete_User DEFAULT ('') FOR Delete_User
GO
ALTER TABLE dbo.Tmp_Cari_Tanitimi ADD CONSTRAINT
	DF_Cari_Tanitimi_Delete_Date DEFAULT ('') FOR Delete_Date
GO
IF EXISTS(SELECT * FROM dbo.Cari_Tanitimi)
	 EXEC('INSERT INTO dbo.Tmp_Cari_Tanitimi (Kurum_Kodu, Cari_No, Silindi, Cari_Kodu, Unvani, Adi, Soyadi, Kart_Kodu, Sinifi, Subesi, Ogrenci_No, Cinsiyeti, Durum, Boy, Kilo, Dogum_Tarihi, Harcama_Limiti, Veli_Adi, Veli_Soyadi, Veli_Cinsiyeti, Veli_Telefon_1, Veli_Telefon_2, Veli_E_Mail, Veli_E_Mail_Gonder, Resim, Grup_Kodu, Ozel_Kodu, Indirim, Para_Birimi, Vergi_Dairesi, Vergi_TC_No, Musteri, Satici, Personel, Ogrenci, Ogretmen, Mahalle_Koy, Cadde_Sokak, Dis_Kapi_No, Site_Adi, Apartman_Blok, Kat, Daire, Ilce, Il, Ulke, Telefon_1, Telefon_2, Telefon_3, Fax_1, Fax_2, E_Mail_1, E_Mail_2, Ise_Giris_Tarihi, Isten_Cikis_Tarihi, Gorev_Kodu, Maas, Insert_User, Insert_Date, Update_User, Update_Date, Delete_User, Delete_Date)
		SELECT Kurum_Kodu, Cari_No, Silindi, Cari_Kodu, Unvani, Adi, Soyadi, Kart_Kodu, Sinifi, Subesi, Ogrenci_No, Cinsiyeti, Durum, Boy, Kilo, Dogum_Tarihi, Harcama_Limiti, Veli_Adi, Veli_Soyadi, Veli_Cinsiyeti, Veli_Telefon_1, Veli_Telefon_2, Veli_E_Mail, Veli_E_Mail_Gonder, Resim, Grup_Kodu, Ozel_Kodu, Indirim, Para_Birimi, Vergi_Dairesi, Vergi_TC_No, Musteri, Satici, Personel, Ogrenci, Ogretmen, Mahalle_Koy, Cadde_Sokak, Dis_Kapi_No, Site_Adi, Apartman_Blok, Kat, Daire, Ilce, Il, Ulke, Telefon_1, Telefon_2, Telefon_3, Fax_1, Fax_2, E_Mail_1, E_Mail_2, Ise_Giris_Tarihi, Isten_Cikis_Tarihi, Gorev_Kodu, Maas, Insert_User, Insert_Date, Update_User, Update_Date, Delete_User, Delete_Date FROM dbo.Cari_Tanitimi WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.Cari_Tanitimi
GO
EXECUTE sp_rename N'dbo.Tmp_Cari_Tanitimi', N'Cari_Tanitimi', 'OBJECT' 
GO
ALTER TABLE dbo.Cari_Tanitimi ADD CONSTRAINT
	PK_Cari_Tanitimi PRIMARY KEY CLUSTERED 
	(
	Kurum_Kodu,
	Cari_No
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cari_Tanitimi', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cari_Tanitimi', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cari_Tanitimi', 'Object', 'CONTROL') as Contr_Per 