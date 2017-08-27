/*
   26 Ağustos 2017 Cumartesi16:36:12
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
CREATE TABLE dbo.Salon_Tanitimi
	(
	Isyeri_Kodu int NOT NULL,
	Salon_Kodu varchar(25) NOT NULL,
	Salon_Adi varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Salon_Tanitimi ADD CONSTRAINT
	DF_Salon_Tanitimi_Isyeri_Kodu DEFAULT 0 FOR Isyeri_Kodu
GO
ALTER TABLE dbo.Salon_Tanitimi ADD CONSTRAINT
	DF_Salon_Tanitimi_Salon_Kodu DEFAULT '' FOR Salon_Kodu
GO
ALTER TABLE dbo.Salon_Tanitimi ADD CONSTRAINT
	DF_Salon_Tanitimi_Salon_Adi DEFAULT '' FOR Salon_Adi
GO
ALTER TABLE dbo.Salon_Tanitimi ADD CONSTRAINT
	PK_Salon_Tanitimi PRIMARY KEY CLUSTERED 
	(
	Isyeri_Kodu,
	Salon_Kodu
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Salon_Tanitimi SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Salon_Tanitimi', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Salon_Tanitimi', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Salon_Tanitimi', 'Object', 'CONTROL') as Contr_Per 