/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
CREATE USER [AppUser]
	FOR LOGIN [AppUser]
GO

GRANT CONNECT TO [AppUser]
GO

ALTER ROLE [AppUserRole]
ADD MEMBER AppUser;
GO

EXEC [AppUserSchema].[CSP_AddContact] @Nom = N'Doe', @Prenom = N'John'
EXEC [AppUserSchema].[CSP_AddContact] @Nom = N'Doe', @Prenom = N'Jane'
EXEC [AppUserSchema].[CSP_AddContact] @Nom = N'Smith', @Prenom = N'Hannibal'