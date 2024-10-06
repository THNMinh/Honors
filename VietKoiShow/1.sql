IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241006130631_V0', N'8.0.8');

GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TBLCategory] (
    [CategoryID] varchar(50) NOT NULL,
    [CategoryName] varchar(50) NULL,
    [Species] varchar(50) NULL,
    [Size] int NULL,
    [Age] int NULL,
    [Category_Description] varchar(100) NULL,
    CONSTRAINT [PK__TBLCateg__19093A2B870AE3D6] PRIMARY KEY ([CategoryID])
);
GO

CREATE TABLE [TBLNewsType] (
    [NewsTypeID] varchar(50) NOT NULL,
    [Date] date NULL,
    [Description] varchar(255) NULL,
    CONSTRAINT [PK__TBLNewsT__9013FE2A5CA3A75C] PRIMARY KEY ([NewsTypeID])
);
GO

CREATE TABLE [TBLRole] (
    [RoleID] varchar(50) NOT NULL,
    [RoleName] varchar(50) NULL,
    [Role_Description] varchar(255) NULL,
    [Experience] int NULL,
    CONSTRAINT [PK__TBLRole__8AFACE3AE8126C23] PRIMARY KEY ([RoleID])
);
GO

CREATE TABLE [TBLVariety] (
    [VarietyID] varchar(50) NOT NULL,
    [VarietyName] varchar(50) NULL,
    [Origin] varchar(50) NULL,
    [Variety_Description] varchar(100) NULL,
    CONSTRAINT [PK__TBLVarie__08E3A048C6F34A8B] PRIMARY KEY ([VarietyID])
);
GO

CREATE TABLE [TBLCompetition] (
    [CompID] varchar(50) NOT NULL,
    [CategoryID] varchar(50) NULL,
    [CompName] varchar(50) NULL,
    [CompDescription] varchar(100) NULL,
    [Location] varchar(50) NULL,
    [StartDate] date NULL,
    [EndDate] date NULL,
    [Status] bit NULL,
    CONSTRAINT [PK__TBLCompe__AD362A76AD2BEC90] PRIMARY KEY ([CompID]),
    CONSTRAINT [FK_TBLCompetition_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [TBLCategory] ([CategoryID])
);
GO

CREATE TABLE [TBLUser] (
    [UserID] varchar(10) NOT NULL,
    [RoleID] varchar(50) NULL,
    [Password] varchar(100) NULL,
    [Email] varchar(50) NULL,
    [FullName] varchar(50) NULL,
    [Phone] varchar(20) NULL,
    CONSTRAINT [PK__TBLUser__1788CCACE01F8A26] PRIMARY KEY ([UserID]),
    CONSTRAINT [FK__TBLUser__RoleID__3B75D760] FOREIGN KEY ([RoleID]) REFERENCES [TBLRole] ([RoleID])
);
GO

CREATE TABLE [TBLNews] (
    [NewsID] varchar(50) NOT NULL,
    [NewsTypeID] varchar(50) NULL,
    [UserID] varchar(10) NULL,
    [Date] date NULL,
    CONSTRAINT [PK__TBLNews__954EBDD323D8C63D] PRIMARY KEY ([NewsID]),
    CONSTRAINT [FK__TBLNews__NewsTyp__3E52440B] FOREIGN KEY ([NewsTypeID]) REFERENCES [TBLNewsType] ([NewsTypeID]),
    CONSTRAINT [FK__TBLNews__UserID__3F466844] FOREIGN KEY ([UserID]) REFERENCES [TBLUser] ([UserID])
);
GO

CREATE TABLE [TBLKoiFish] (
    [KoiID] varchar(50) NOT NULL,
    [VarietyID] varchar(50) NULL,
    [UserID] varchar(10) NULL,
    [ResultID] varchar(50) NULL,
    [KoiName] varchar(50) NULL,
    [Size] int NULL,
    [Age] int NULL,
    CONSTRAINT [PK__TBLKoiFi__E03435B85376C1B9] PRIMARY KEY ([KoiID]),
    CONSTRAINT [FK__TBLKoiFis__UserI__44FF419A] FOREIGN KEY ([UserID]) REFERENCES [TBLUser] ([UserID]),
    CONSTRAINT [FK__TBLKoiFis__Varie__440B1D61] FOREIGN KEY ([VarietyID]) REFERENCES [TBLVariety] ([VarietyID])
);
GO

CREATE TABLE [TBLPrediction] (
    [PredictionID] varchar(50) NOT NULL,
    [KoiID] varchar(50) NULL,
    [CompID] varchar(50) NULL,
    [PredictedScore] int NULL,
    CONSTRAINT [PK__TBLPredi__BAE4C140C86C7AA4] PRIMARY KEY ([PredictionID]),
    CONSTRAINT [FK__TBLPredic__CompI__5535A963] FOREIGN KEY ([CompID]) REFERENCES [TBLCompetition] ([CompID]),
    CONSTRAINT [FK__TBLPredic__KoiID__5441852A] FOREIGN KEY ([KoiID]) REFERENCES [TBLKoiFish] ([KoiID])
);
GO

CREATE TABLE [TBLRegistration] (
    [RegistrationID] varchar(50) NOT NULL,
    [KoiID] varchar(50) NULL,
    [CompID] varchar(50) NULL,
    [Status] int NULL,
    CONSTRAINT [PK__TBLRegis__6EF58830FFE247A1] PRIMARY KEY ([RegistrationID]),
    CONSTRAINT [FK__TBLRegist__CompI__4E88ABD4] FOREIGN KEY ([CompID]) REFERENCES [TBLCompetition] ([CompID]),
    CONSTRAINT [FK__TBLRegist__KoiID__4D94879B] FOREIGN KEY ([KoiID]) REFERENCES [TBLKoiFish] ([KoiID])
);
GO

CREATE TABLE [TBLResult] (
    [ResultID] varchar(50) NOT NULL,
    [KoiID] varchar(50) NULL,
    [ResultScore] float NULL,
    [Prize] varchar(255) NULL,
    CONSTRAINT [PK__TBLResul__97690228895F78EA] PRIMARY KEY ([ResultID]),
    CONSTRAINT [FK__TBLResult__KoiID__47DBAE45] FOREIGN KEY ([KoiID]) REFERENCES [TBLKoiFish] ([KoiID])
);
GO

CREATE TABLE [TBLScore] (
    [ScoreID] varchar(50) NOT NULL,
    [KoiID] varchar(50) NULL,
    [CompID] varchar(50) NULL,
    [UserID] varchar(10) NULL,
    [ScoreShape] float NULL,
    [ScoreColor] float NULL,
    [ScorePattern] float NULL,
    [TotalScore] float NULL,
    CONSTRAINT [PK__TBLScore__7DD229F13E5E5D99] PRIMARY KEY ([ScoreID]),
    CONSTRAINT [FK__TBLScore__CompID__59063A47] FOREIGN KEY ([CompID]) REFERENCES [TBLCompetition] ([CompID]),
    CONSTRAINT [FK__TBLScore__KoiID__5812160E] FOREIGN KEY ([KoiID]) REFERENCES [TBLKoiFish] ([KoiID]),
    CONSTRAINT [FK__TBLScore__UserID__59FA5E80] FOREIGN KEY ([UserID]) REFERENCES [TBLUser] ([UserID])
);
GO

CREATE INDEX [IX_TBLCompetition_CategoryID] ON [TBLCompetition] ([CategoryID]);
GO

CREATE INDEX [IX_TBLKoiFish_ResultID] ON [TBLKoiFish] ([ResultID]);
GO

CREATE INDEX [IX_TBLKoiFish_UserID] ON [TBLKoiFish] ([UserID]);
GO

CREATE INDEX [IX_TBLKoiFish_VarietyID] ON [TBLKoiFish] ([VarietyID]);
GO

CREATE INDEX [IX_TBLNews_NewsTypeID] ON [TBLNews] ([NewsTypeID]);
GO

CREATE INDEX [IX_TBLNews_UserID] ON [TBLNews] ([UserID]);
GO

CREATE INDEX [IX_TBLPrediction_CompID] ON [TBLPrediction] ([CompID]);
GO

CREATE INDEX [IX_TBLPrediction_KoiID] ON [TBLPrediction] ([KoiID]);
GO

CREATE INDEX [IX_TBLRegistration_CompID] ON [TBLRegistration] ([CompID]);
GO

CREATE INDEX [IX_TBLRegistration_KoiID] ON [TBLRegistration] ([KoiID]);
GO

CREATE INDEX [IX_TBLResult_KoiID] ON [TBLResult] ([KoiID]);
GO

CREATE INDEX [IX_TBLScore_CompID] ON [TBLScore] ([CompID]);
GO

CREATE INDEX [IX_TBLScore_KoiID] ON [TBLScore] ([KoiID]);
GO

CREATE INDEX [IX_TBLScore_UserID] ON [TBLScore] ([UserID]);
GO

CREATE INDEX [IX_TBLUser_RoleID] ON [TBLUser] ([RoleID]);
GO

ALTER TABLE [TBLKoiFish] ADD CONSTRAINT [FK_TBLKoiFish_ResultID] FOREIGN KEY ([ResultID]) REFERENCES [TBLResult] ([ResultID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241006130631_V0', N'8.0.8');
GO

COMMIT;
GO

