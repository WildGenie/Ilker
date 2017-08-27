/*
   27 Ağustos 2017 Pazar14:03:02
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
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Kurum_Kodu
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Fis_Tipi
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Isyeri_Kodu
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Fis_No
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Fis_Sira
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Islem_Yonu
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Silindi
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Masraf_No
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Fis_Tarihi
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Fis_Saati
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Borc_Tutari
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Borc_Tutari_Baslik
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Borc_Tutari_Kart
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Borc_Tutari_Sistem
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Alacak_Tutari
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Alacak_Tutari_Baslik
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Alacak_Tutari_Kart
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Alacak_Tutari_Sistem
GO
ALTER TABLE dbo.Islem_Detay_Masraf
	DROP CONSTRAINT DF_Islem_Detay_Masraf_Aciklama
GO
CREATE TABLE dbo.Tmp_Islem_Detay_Masraf
	(
	Kurum_Kodu varchar(20) NOT NULL,
	Fis_Tipi int NOT NULL,
	Isyeri_Kodu int NOT NULL,
	Fis_No int NOT NULL,
	Fis_Sira int NOT NULL,
	Islem_Yonu int NOT NULL,
	Silindi tinyint NULL,
	Masraf_No int NULL,
	Fis_Tarihi datetime NULL,
	Fis_Saati datetime NULL,
	Borc_Tutari float(53) NULL,
	Borc_Tutari_Baslik float(53) NULL,
	Borc_Tutari_Kart float(53) NULL,
	Borc_Tutari_Sistem float(53) NULL,
	Alacak_Tutari float(53) NULL,
	Alacak_Tutari_Baslik float(53) NULL,
	Alacak_Tutari_Kart float(53) NULL,
	Alacak_Tutari_Sistem float(53) NULL,
	Kdv_Orani float(53) NULL,
	Kdv_Tutari float(53) NULL,
	Kdv_Tutari_Baslik float(53) NULL,
	Kdv_Tutari_Kart float(53) NULL,
	Kdv_Tutari_Sistem float(53) NULL,
	Aciklama varchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Kurum_Kodu DEFAULT ('') FOR Kurum_Kodu
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Fis_Tipi DEFAULT ((0)) FOR Fis_Tipi
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Isyeri_Kodu DEFAULT ((0)) FOR Isyeri_Kodu
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Fis_No DEFAULT ((0)) FOR Fis_No
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Fis_Sira DEFAULT ((0)) FOR Fis_Sira
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Islem_Yonu DEFAULT ((0)) FOR Islem_Yonu
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Silindi DEFAULT ((0)) FOR Silindi
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Masraf_No DEFAULT ((0)) FOR Masraf_No
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Fis_Tarihi DEFAULT ('') FOR Fis_Tarihi
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Fis_Saati DEFAULT ('') FOR Fis_Saati
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Borc_Tutari DEFAULT ((0)) FOR Borc_Tutari
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Borc_Tutari_Baslik DEFAULT ((0)) FOR Borc_Tutari_Baslik
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Borc_Tutari_Kart DEFAULT ((0)) FOR Borc_Tutari_Kart
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Borc_Tutari_Sistem DEFAULT ((0)) FOR Borc_Tutari_Sistem
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Alacak_Tutari DEFAULT ((0)) FOR Alacak_Tutari
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Alacak_Tutari_Baslik DEFAULT ((0)) FOR Alacak_Tutari_Baslik
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Alacak_Tutari_Kart DEFAULT ((0)) FOR Alacak_Tutari_Kart
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Alacak_Tutari_Sistem DEFAULT ((0)) FOR Alacak_Tutari_Sistem
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Kdv_Orani DEFAULT 0 FOR Kdv_Orani
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Kdv_Tutari DEFAULT 0 FOR Kdv_Tutari
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Kdv_Tutari_Baslik DEFAULT ((0)) FOR Kdv_Tutari_Baslik
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Kdv_Tutari_Kart DEFAULT ((0)) FOR Kdv_Tutari_Kart
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Kdv_Tutari_Sistem DEFAULT ((0)) FOR Kdv_Tutari_Sistem
GO
ALTER TABLE dbo.Tmp_Islem_Detay_Masraf ADD CONSTRAINT
	DF_Islem_Detay_Masraf_Aciklama DEFAULT ('') FOR Aciklama
GO
IF EXISTS(SELECT * FROM dbo.Islem_Detay_Masraf)
	 EXEC('INSERT INTO dbo.Tmp_Islem_Detay_Masraf (Kurum_Kodu, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu, Silindi, Masraf_No, Fis_Tarihi, Fis_Saati, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Aciklama)
		SELECT Kurum_Kodu, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu, Silindi, Masraf_No, Fis_Tarihi, Fis_Saati, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Aciklama FROM dbo.Islem_Detay_Masraf WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.Islem_Detay_Masraf
GO
EXECUTE sp_rename N'dbo.Tmp_Islem_Detay_Masraf', N'Islem_Detay_Masraf', 'OBJECT' 
GO
ALTER TABLE dbo.Islem_Detay_Masraf ADD CONSTRAINT
	PK_Islem_Detay_Masraf PRIMARY KEY CLUSTERED 
	(
	Kurum_Kodu,
	Fis_Tipi,
	Isyeri_Kodu,
	Fis_No,
	Fis_Sira,
	Islem_Yonu
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Islem_Detay_Masraf', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Islem_Detay_Masraf', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Islem_Detay_Masraf', 'Object', 'CONTROL') as Contr_Per 