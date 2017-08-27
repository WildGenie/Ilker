/*
   20 Ağustos 2017 Pazar13:57:46
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
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Kurum_Kodu
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Stok_No
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Silindi
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Stok_Kodu
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Stok_Adi
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Kisa_Adi
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Durum
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Resim
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Grup_Kodu
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Ozel_Kodu
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Kdv_Toptan
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Kdv_Perakende
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Stok_Tipi
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Birim_Tipi_1
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_BT1_Orani
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_BT1_Barkod
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_BT1_Hizli_Satis
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_BT1_Alis_Fiyati
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_BT1_Alis_Kdvli_Fiyati
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_BT1_Satis_Fiyati
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Birim_Kodu_11
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_BT2_Orani
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_BT2_Barkod
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_BT2_Hizli_Satis
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_BT2_Alis_Fiyati
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_BT2_Alis_Kdvli_Fiyati
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_BT2_Satis_Fiyati
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Karbonhidrat
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Protein
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Yag
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_DoymusYag
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Lif
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Kolesterol
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Sodyum
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Potasyum
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Kalsiyum
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_VitaminA
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_VitaminC
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Demir
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Enerji
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Seker
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Insert_User
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Inser_Date
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Update_User
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Update_Date
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Delete_User
GO
ALTER TABLE dbo.Stok_Tanitimi
	DROP CONSTRAINT DF_Stok_Tanitimi_Delete_Date
GO
CREATE TABLE dbo.Tmp_Stok_Tanitimi
	(
	Kurum_Kodu varchar(20) NOT NULL,
	Stok_No int NOT NULL,
	Silindi tinyint NULL,
	Stok_Kodu varchar(25) NULL,
	Stok_Adi varchar(255) NULL,
	Kisa_Adi varchar(255) NULL,
	Durum tinyint NULL,
	Resim varbinary(MAX) NULL,
	Grup_Kodu varchar(25) NULL,
	Ozel_Kodu varchar(25) NULL,
	Kdv_Toptan float(53) NULL,
	Kdv_Perakende float(53) NULL,
	Stok_Tipi tinyint NULL,
	Birim_Kodu_1 varchar(10) NULL,
	BT1_Orani float(53) NULL,
	BT1_Barkod varchar(50) NULL,
	BT1_Hizli_Satis tinyint NULL,
	BT1_Alis_Fiyati float(53) NULL,
	BT1_Alis_Kdvli_Fiyati float(53) NULL,
	BT1_Satis_Fiyati_1 float(53) NULL,
	BT1_Satis_Fiyati_2 float(53) NULL,
	BT1_Satis_Fiyati_3 float(53) NULL,
	Birim_Kodu_2 varchar(10) NULL,
	BT2_Orani float(53) NULL,
	BT2_Barkod varchar(50) NULL,
	BT2_Hizli_Satis tinyint NULL,
	BT2_Alis_Fiyati float(53) NULL,
	BT2_Alis_Kdvli_Fiyati float(53) NULL,
	BT2_Satis_Fiyati_1 float(53) NULL,
	BT2_Satis_Fiyati_2 float(53) NULL,
	BT2_Satis_Fiyati_3 float(53) NULL,
	Karbonhidrat float(53) NULL,
	Protein float(53) NULL,
	Yag float(53) NULL,
	Doymus_Yag float(53) NULL,
	Lif float(53) NULL,
	Kolesterol float(53) NULL,
	Sodyum float(53) NULL,
	Potasyum float(53) NULL,
	Kalsiyum float(53) NULL,
	Vitamin_A float(53) NULL,
	Vitamin_C float(53) NULL,
	Demir float(53) NULL,
	Enerji float(53) NULL,
	Seker float(53) NULL,
	Insert_User varchar(50) NULL,
	Insert_Date datetime NULL,
	Update_User varchar(50) NULL,
	Update_Date datetime NULL,
	Delete_User varchar(50) NULL,
	Delete_Date datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi SET (LOCK_ESCALATION = TABLE)
GO
DECLARE @v sql_variant 
SET @v = N'0 = Aktif, 1 = Pasif'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Stok_Tanitimi', N'COLUMN', N'Durum'
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Kurum_Kodu DEFAULT ('') FOR Kurum_Kodu
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Stok_No DEFAULT ((0)) FOR Stok_No
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Silindi DEFAULT ((0)) FOR Silindi
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Stok_Kodu DEFAULT ('') FOR Stok_Kodu
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Stok_Adi DEFAULT ('') FOR Stok_Adi
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Kisa_Adi DEFAULT ('') FOR Kisa_Adi
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Durum DEFAULT ((0)) FOR Durum
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Resim DEFAULT (NULL) FOR Resim
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Grup_Kodu DEFAULT ('') FOR Grup_Kodu
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Ozel_Kodu DEFAULT ('') FOR Ozel_Kodu
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Kdv_Toptan DEFAULT ((0)) FOR Kdv_Toptan
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Kdv_Perakende DEFAULT ((0)) FOR Kdv_Perakende
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Stok_Tipi DEFAULT ((0)) FOR Stok_Tipi
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Birim_Tipi_1 DEFAULT ('') FOR Birim_Kodu_1
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT1_Orani DEFAULT ((0)) FOR BT1_Orani
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT1_Barkod DEFAULT ('') FOR BT1_Barkod
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT1_Hizli_Satis DEFAULT ((0)) FOR BT1_Hizli_Satis
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT1_Alis_Fiyati DEFAULT ((0)) FOR BT1_Alis_Fiyati
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT1_Alis_Kdvli_Fiyati DEFAULT ((0)) FOR BT1_Alis_Kdvli_Fiyati
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT1_Satis_Fiyati DEFAULT ((0)) FOR BT1_Satis_Fiyati_1
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT1_Satis_Fiyati_11 DEFAULT ((0)) FOR BT1_Satis_Fiyati_2
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT1_Satis_Fiyati_12 DEFAULT ((0)) FOR BT1_Satis_Fiyati_3
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Birim_Kodu_11 DEFAULT ('') FOR Birim_Kodu_2
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT2_Orani DEFAULT ((0)) FOR BT2_Orani
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT2_Barkod DEFAULT ('') FOR BT2_Barkod
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT2_Hizli_Satis DEFAULT ((0)) FOR BT2_Hizli_Satis
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT2_Alis_Fiyati DEFAULT ((0)) FOR BT2_Alis_Fiyati
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT2_Alis_Kdvli_Fiyati DEFAULT ((0)) FOR BT2_Alis_Kdvli_Fiyati
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT2_Satis_Fiyati DEFAULT ((0)) FOR BT2_Satis_Fiyati_1
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT2_Satis_Fiyati_11 DEFAULT ((0)) FOR BT2_Satis_Fiyati_2
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_BT2_Satis_Fiyati_12 DEFAULT ((0)) FOR BT2_Satis_Fiyati_3
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Karbonhidrat DEFAULT ((0)) FOR Karbonhidrat
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Protein DEFAULT ((0)) FOR Protein
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Yag DEFAULT ((0)) FOR Yag
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_DoymusYag DEFAULT ((0)) FOR Doymus_Yag
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Lif DEFAULT ((0)) FOR Lif
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Kolesterol DEFAULT ((0)) FOR Kolesterol
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Sodyum DEFAULT ((0)) FOR Sodyum
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Potasyum DEFAULT ((0)) FOR Potasyum
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Kalsiyum DEFAULT ((0)) FOR Kalsiyum
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_VitaminA DEFAULT ((0)) FOR Vitamin_A
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_VitaminC DEFAULT ((0)) FOR Vitamin_C
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Demir DEFAULT ((0)) FOR Demir
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Enerji DEFAULT ((0)) FOR Enerji
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Seker DEFAULT ((0)) FOR Seker
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Insert_User DEFAULT ('') FOR Insert_User
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Inser_Date DEFAULT ('') FOR Insert_Date
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Update_User DEFAULT ('') FOR Update_User
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Update_Date DEFAULT ('') FOR Update_Date
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Delete_User DEFAULT ('') FOR Delete_User
GO
ALTER TABLE dbo.Tmp_Stok_Tanitimi ADD CONSTRAINT
	DF_Stok_Tanitimi_Delete_Date DEFAULT ('') FOR Delete_Date
GO
IF EXISTS(SELECT * FROM dbo.Stok_Tanitimi)
	 EXEC('INSERT INTO dbo.Tmp_Stok_Tanitimi (Kurum_Kodu, Stok_No, Silindi, Stok_Kodu, Stok_Adi, Kisa_Adi, Durum, Resim, Grup_Kodu, Ozel_Kodu, Kdv_Toptan, Kdv_Perakende, Stok_Tipi, Birim_Kodu_1, BT1_Orani, BT1_Barkod, BT1_Hizli_Satis, BT1_Alis_Fiyati, BT1_Alis_Kdvli_Fiyati, BT1_Satis_Fiyati_1, Birim_Kodu_2, BT2_Orani, BT2_Barkod, BT2_Hizli_Satis, BT2_Alis_Fiyati, BT2_Alis_Kdvli_Fiyati, BT2_Satis_Fiyati_1, Karbonhidrat, Protein, Yag, Doymus_Yag, Lif, Kolesterol, Sodyum, Potasyum, Kalsiyum, Vitamin_A, Vitamin_C, Demir, Enerji, Seker, Insert_User, Insert_Date, Update_User, Update_Date, Delete_User, Delete_Date)
		SELECT Kurum_Kodu, Stok_No, Silindi, Stok_Kodu, Stok_Adi, Kisa_Adi, Durum, Resim, Grup_Kodu, Ozel_Kodu, Kdv_Toptan, Kdv_Perakende, Stok_Tipi, Birim_Kodu_1, BT1_Orani, BT1_Barkod, BT1_Hizli_Satis, BT1_Alis_Fiyati, BT1_Alis_Kdvli_Fiyati, BT1_Satis_Fiyati, Birim_Kodu_2, BT2_Orani, BT2_Barkod, BT2_Hizli_Satis, BT2_Alis_Fiyati, BT2_Alis_Kdvli_Fiyati, BT2_Satis_Fiyati, Karbonhidrat, Protein, Yag, Doymus_Yag, Lif, Kolesterol, Sodyum, Potasyum, Kalsiyum, Vitamin_A, Vitamin_C, Demir, Enerji, Seker, Insert_User, Insert_Date, Update_User, Update_Date, Delete_User, Delete_Date FROM dbo.Stok_Tanitimi WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.Stok_Tanitimi
GO
EXECUTE sp_rename N'dbo.Tmp_Stok_Tanitimi', N'Stok_Tanitimi', 'OBJECT' 
GO
ALTER TABLE dbo.Stok_Tanitimi ADD CONSTRAINT
	PK_Stok_Tanitimi_1 PRIMARY KEY CLUSTERED 
	(
	Kurum_Kodu,
	Stok_No
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Stok_Tanitimi', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Stok_Tanitimi', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Stok_Tanitimi', 'Object', 'CONTROL') as Contr_Per 