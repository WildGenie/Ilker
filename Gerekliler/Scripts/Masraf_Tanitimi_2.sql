/*
   26 Ağustos 2017 Cumartesi21:38:13
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
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Kurum_Kodu
GO
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Masraf_No
GO
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Masraf_Kodu
GO
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Silindi
GO
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Masraf_Adi
GO
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Islem
GO
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Masraf_Tipi
GO
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Insert_User
GO
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Insert_Date
GO
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Update_User
GO
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Update_Date
GO
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Delete_User
GO
ALTER TABLE dbo.Masraf_Tanitimi
	DROP CONSTRAINT DF_Masraf_Tanitimi_Delete_Date
GO
CREATE TABLE dbo.Tmp_Masraf_Tanitimi
	(
	Kurum_Kodu varchar(20) NOT NULL,
	Masraf_No int NOT NULL,
	Masraf_Kodu varchar(25) NULL,
	Silindi tinyint NULL,
	Masraf_Adi varchar(255) NULL,
	Islem tinyint NULL,
	Masraf_Tipi tinyint NULL,
	Kdv_Orani float(53) NULL,
	Insert_User varchar(50) NULL,
	Insert_Date datetime NULL,
	Update_User varchar(50) NULL,
	Update_Date datetime NULL,
	Delete_User varchar(50) NULL,
	Delete_Date datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Kurum_Kodu DEFAULT ('') FOR Kurum_Kodu
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Masraf_No DEFAULT ((0)) FOR Masraf_No
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Masraf_Kodu DEFAULT ('') FOR Masraf_Kodu
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Silindi DEFAULT ((0)) FOR Silindi
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Masraf_Adi DEFAULT ('') FOR Masraf_Adi
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Islem DEFAULT ((0)) FOR Islem
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Masraf_Tipi DEFAULT ((0)) FOR Masraf_Tipi
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Kdv_Toptan DEFAULT ((0)) FOR Kdv_Orani
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Insert_User DEFAULT ('') FOR Insert_User
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Insert_Date DEFAULT ('') FOR Insert_Date
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Update_User DEFAULT ('') FOR Update_User
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Update_Date DEFAULT ('') FOR Update_Date
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Delete_User DEFAULT ('') FOR Delete_User
GO
ALTER TABLE dbo.Tmp_Masraf_Tanitimi ADD CONSTRAINT
	DF_Masraf_Tanitimi_Delete_Date DEFAULT ('') FOR Delete_Date
GO
IF EXISTS(SELECT * FROM dbo.Masraf_Tanitimi)
	 EXEC('INSERT INTO dbo.Tmp_Masraf_Tanitimi (Kurum_Kodu, Masraf_No, Masraf_Kodu, Silindi, Masraf_Adi, Islem, Masraf_Tipi, Insert_User, Insert_Date, Update_User, Update_Date, Delete_User, Delete_Date)
		SELECT Kurum_Kodu, Masraf_No, Masraf_Kodu, Silindi, Masraf_Adi, Islem, Masraf_Tipi, Insert_User, Insert_Date, Update_User, Update_Date, Delete_User, Delete_Date FROM dbo.Masraf_Tanitimi WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.Masraf_Tanitimi
GO
EXECUTE sp_rename N'dbo.Tmp_Masraf_Tanitimi', N'Masraf_Tanitimi', 'OBJECT' 
GO
ALTER TABLE dbo.Masraf_Tanitimi ADD CONSTRAINT
	PK_Masraf_Tanitimi_1 PRIMARY KEY CLUSTERED 
	(
	Kurum_Kodu,
	Masraf_No
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Masraf_Tanitimi', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Masraf_Tanitimi', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Masraf_Tanitimi', 'Object', 'CONTROL') as Contr_Per 