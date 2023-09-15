CREATE PROCEDURE [AppUserSchema].[CSP_AddContact]
	@Nom NVARCHAR(50),
	@Prenom NVARCHAR(50)
AS
BEGIN
	INSERT INTO Contact (Nom, Prenom) VALUES (@Nom, @Prenom);
	RETURN 0
END