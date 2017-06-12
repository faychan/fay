CREATE TABLE [dbo].[SYSUser] (
    [SYSUserID]             INT           IDENTITY (1, 1) NOT NULL,
    [LoginName]             VARCHAR (50)  NOT NULL,
    [PasswordEncryptedText] VARCHAR (200) NOT NULL,
    [RowCreatedSYSUserID]   INT           NOT NULL,
    [RowCreatedDateTime]    DATETIME      DEFAULT (getdate()) NULL,
    [RowModifiedSYSUserID]  INT           NOT NULL,
    [RowMOdifiedDateTime]   DATETIME      DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([SYSUserID] ASC)
);

CREATE TABLE [dbo].[LOOKUPRole] (
    [LOOKUPRoleID]         INT           IDENTITY (1, 1) NOT NULL,
    [RoleName]             VARCHAR (100) DEFAULT ('') NULL,
    [RoleDescription]      VARCHAR (500) DEFAULT ('') NULL,
    [RowCreatedSYSUserID]  INT           NOT NULL,
    [RowCreatedDateTime]   DATETIME      DEFAULT (getdate()) NULL,
    [RowModifiedSYSUserID] INT           NOT NULL,
    [RowModifiedDateTime]  DATETIME      DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([LOOKUPRoleID] ASC)
);

CREATE TABLE [dbo].[SYSUserRole] (
    [SYSUserRoleID]        INT      IDENTITY (1, 1) NOT NULL,
    [SYSUserID]            INT      NOT NULL,
    [LOOKUPRoleID]         INT      NOT NULL,
    [IsActive]             BIT      DEFAULT ((1)) NULL,
    [RowCreatedSYSUserID]  INT      NOT NULL,
    [RowCreatedDateTime]   DATETIME DEFAULT (getdate()) NULL,
    [RowModifiedSYSUserID] INT      NOT NULL,
    [RowModifiedDateTime]  DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([SYSUserRoleID] ASC),
    FOREIGN KEY ([LOOKUPRoleID]) REFERENCES [dbo].[LOOKUPRole] ([LOOKUPRoleID]),
    FOREIGN KEY ([SYSUserID]) REFERENCES [dbo].[SYSUser] ([SYSUserID])
);

CREATE TABLE [dbo].[SYSUserProfile] (
    [SYSUserProfileID]     INT          IDENTITY (1, 1) NOT NULL,
    [SYSUserID]            INT          NOT NULL,
    [FirstName]            VARCHAR (50) NOT NULL,
    [LastName]             VARCHAR (50) NOT NULL,
    [Gender]               CHAR (1)     NOT NULL,
    [RowCreatedSYSUserID]  INT          NOT NULL,
    [RowCreatedDateTime]   DATETIME     DEFAULT (getdate()) NULL,
    [RowModifiedSYSUserID] INT          NOT NULL,
    [RowModifiedDateTime]  DATETIME     DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([SYSUserProfileID] ASC),
    FOREIGN KEY ([SYSUserID]) REFERENCES [dbo].[SYSUser] ([SYSUserID])
);



CREATE TABLE [dbo].[pelanggan] (
    [id_pelanggan] INT           IDENTITY (1, 1) NOT NULL,
    [no_id]        VARCHAR (1)   NOT NULL,
    [nama]         VARCHAR (255) NOT NULL,
    [alamat]       VARCHAR (255) NOT NULL,
    [no_tlp1]      VARCHAR (255) NOT NULL,
    [no_tlp2]      VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_pelanggan] ASC)
);

CREATE TABLE [dbo].[menu] (
    [id_menu] INT           IDENTITY (1, 1) NOT NULL,
    [menu] VARCHAR (255) NOT NULL,
    [stock]      INT           NOT NULL,
    [harga]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id_menu] ASC)
);



CREATE TABLE [dbo].[laporan] (
    [id_laporan]   INT           IDENTITY (1, 1) NOT NULL,
    [id_menu]   INT           NOT NULL,
    [id_pelanggan] INT           NOT NULL,
    [keterangan]   VARCHAR (255) NOT NULL,
    [meja]     INT           NOT NULL,
    [quantity]     INT           NOT NULL,
    [harga]        INT           NOT NULL,
    [jumlah]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id_laporan] ASC),
    FOREIGN KEY ([id_menu]) REFERENCES [dbo].[menu] ([id_menu]),
    FOREIGN KEY ([id_pelanggan]) REFERENCES [dbo].[pelanggan] ([id_pelanggan])
);

