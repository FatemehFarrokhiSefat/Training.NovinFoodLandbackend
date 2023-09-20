CREATE TABLE [dbo].[ApplicationUsers] (
    [Username] NVARCHAR (450) NOT NULL,
    [Password] NVARCHAR (MAX) NULL,
    [Fullname] NVARCHAR (MAX) NULL,
    [Type]     INT            DEFAULT ((0)) NULL,
    [Email]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ApplicationUsers] PRIMARY KEY CLUSTERED ([Username] ASC)
);

