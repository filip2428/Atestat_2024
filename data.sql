CREATE TABLE [dbo].[Table] (
    [Număr_de_inventar]     NVARCHAR(50)           NOT NULL,
    [Titlu]                 NVARCHAR (50) NOT NULL,
    [Autor]                 NVARCHAR (50) NOT NULL,
    [Categorie]             NVARCHAR (50) NOT NULL,
    [Editură]               NVARCHAR (50) NOT NULL,
    [Exemplare_Deţinute]    INT           NULL,
    [Exemplare_Împrumutate] INT           NULL,
    [Poziție]               NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Număr_de_inventar] ASC)
);

