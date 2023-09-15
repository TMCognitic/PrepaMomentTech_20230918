using PrepaMomentTech_20230918.Bll.Entities;
using DalContact = PrepaMomentTech_20230918.Dal.Entities.Contact;

namespace PrepaMomentTech_20230918.Bll.Mappers
{
    internal static class Mappers
    {
        public static DalContact ToDal(this Contact contact)
        {
            return new DalContact()
            {
                Id = contact.Id,
                Nom = contact.Nom,
                Prenom = contact.Prenom,
                Actif = contact.Actif
            };
        }

        public static Contact ToBll(this DalContact contact)
        {
            return new Contact(contact.Id, contact.Nom, contact.Prenom, contact.Actif);
        }
    }
}
