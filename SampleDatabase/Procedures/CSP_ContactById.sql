CREATE PROCEDURE [AppUserSchema].[CSP_ContactById]
	@Id INT
AS
BEGIN
	SELECT Id, Nom, Prenom, Actif FROM Contact WHERE Id = @Id;
	RETURN 0
END