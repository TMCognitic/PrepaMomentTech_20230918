CREATE PROCEDURE [AppUserSchema].[CSP_AllContact]
	@All bit = 0
AS
BEGIN
	IF @All = 1
	BEGIN
		SELECT Id, Nom, Prenom, Actif FROM Contact;
	END
	ELSE
	BEGIN
		SELECT Id, Nom, Prenom, Actif FROM Contact WHERE Actif = 1;
	END
	RETURN 0
END

