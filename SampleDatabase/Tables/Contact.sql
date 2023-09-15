CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL IDENTITY, 
    [Nom] NVARCHAR(50) NOT NULL, 
    [Prenom] NVARCHAR(50) NOT NULL, 
    [Actif] BIT NOT NULL 
        CONSTRAINT DF_Contact_Actif DEFAULT 1, 
    CONSTRAINT [PK_Data] PRIMARY KEY ([Id]) 
)

GO

CREATE TRIGGER [dbo].[CTR_IO_Contact_Delete]
    ON [dbo].[Contact]
    INSTEAD OF DELETE
    AS
    BEGIN
        SET NoCount ON
        UPDATE Contact SET Actif = 0 WHERE Id In (SELECT Id FROM deleted) 
    END