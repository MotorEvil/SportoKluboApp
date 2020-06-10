CREATE TABLE [dbo].[workoutUsers] (
    [UserId]       NVARCHAR (450)   NOT NULL,
    [TreniruoteId] UNIQUEIDENTIFIER NOT NULL,
    [Attended]     BIT              DEFAULT (CONVERT([bit],(0))) NOT NULL,
    CONSTRAINT [PK_workoutUsers] PRIMARY KEY CLUSTERED ([UserId] ASC, [TreniruoteId] ASC),
    CONSTRAINT [FK_workoutUsers_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_workoutUsers_Items_TreniruoteId] FOREIGN KEY ([TreniruoteId]) REFERENCES [dbo].[Items] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_workoutUsers_TreniruoteId]
    ON [dbo].[workoutUsers]([TreniruoteId] ASC);

