CREATE TABLE [dbo].[Items] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [Laikas]              DATETIME2 (7)    NOT NULL,
    [Pavadinimas]         NVARCHAR (MAX)   NOT NULL,
    [IsDone]              BIT              NOT NULL,
    [LaisvosVietos]       INT              NOT NULL,
    [Registracijos]       INT              NOT NULL,
    [UserId]              NVARCHAR (MAX)   NULL,
    [TreniruotesDalyviai] NVARCHAR (MAX)   NULL,
    [Data]                DATETIME2 (7)    DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([Id] ASC)
);

