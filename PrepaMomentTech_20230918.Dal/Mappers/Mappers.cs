using PrepaMomentTech_20230918.Dal.Entities;
using System.Data;

namespace PrepaMomentTech_20230918.Dal.Mappers
{
    internal static class Mappers
    {
        internal static Contact ToContact(this IDataRecord record)
        {
            return new Contact()
            {
                Id = (int)record["Id"],
                Nom = (string)record["Nom"],
                Prenom = (string)record["Prenom"],
                Actif = (bool)record["Actif"]
            };
        }
    }
}
