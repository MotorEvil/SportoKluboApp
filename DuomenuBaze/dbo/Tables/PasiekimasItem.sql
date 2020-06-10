CREATE TABLE [dbo].[PasiekimasItem] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
    [PasiekimoLaikas]      DATETIME2 (7)    NOT NULL,
    [PasiekimoPavadinimas] NVARCHAR (MAX)   NULL,
    [PratimoPavadinimas]   NVARCHAR (MAX)   NULL,
    [UserId]               NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_PasiekimasItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);

