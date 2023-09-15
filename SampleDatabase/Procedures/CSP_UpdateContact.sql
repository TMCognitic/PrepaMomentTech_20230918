CREATE PROCEDURE [AppUserSchema].[CSP_UpdateContact]
	@Id BIT,
	@Nom NVARCHAR(50),
	@Prenom NVARCHAR(50),
	@Actif BIT
AS
BEGIN
	UPDATE	Contact 
	SET		Nom = @Nom,
			Prenom = @Prenom,
			Actif = @Actif
	WHERE	Id = @Id

	RETURN 0;
END
