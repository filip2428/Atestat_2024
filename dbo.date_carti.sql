CREATE TABLE [dbo].[date_carti] (
	[Nr_crt]				int NOT NULL IDENTITY,
    [Titlu]                 NVARCHAR (50) NOT NULL,
    [Autor]                 NVARCHAR (50) NOT NULL,
    [Categorie]             NVARCHAR (50) NOT NULL,
    [Editură]               NVARCHAR (50) NULL,
    [Poziție]               NVARCHAR (50) NOT NULL,
    [Număr_de_inventar]     NVARCHAR (50) NOT NULL,
	[Nr_Copie]				NVARCHAR (50) NOT NULL,			
    [Disponibil] NCHAR(10) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Nr_crt])

);

