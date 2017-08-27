/*
   20 Ağustos 2017 Pazar15:56:14
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
CREATE TABLE dbo.Stok_Departman_Tanitimi
	(
	Kurum_Kodu varchar(20) NOT NULL,
	Departman_Kodu varchar(25) NOT NULL,
	Departman_Adi varchar(150) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Stok_Departman_Tanitimi ADD CONSTRAINT
	DF_Stok_Departman_Tanitimi_Kurum_Kodu DEFAULT ('') FOR Kurum_Kodu
GO
ALTER TABLE dbo.Stok_Departman_Tanitimi ADD CONSTRAINT
	DF_Stok_Departman_Tanitimi_Departman_Kodu DEFAULT '' FOR Departman_Kodu
GO
ALTER TABLE dbo.Stok_Departman_Tanitimi ADD CONSTRAINT
	DF_Stok_Departman_Tanitimi_Departman_Adi DEFAULT '' FOR Departman_Adi
GO
ALTER TABLE dbo.Stok_Departman_Tanitimi ADD CONSTRAINT
	PK_Stok_Departman_Tanitimi PRIMARY KEY CLUSTERED 
	(
	Kurum_Kodu,
	Departman_Kodu
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Stok_Departman_Tanitimi SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Stok_Departman_Tanitimi', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Stok_Departman_Tanitimi', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Stok_Departman_Tanitimi', 'Object', 'CONTROL') as Contr_Per 