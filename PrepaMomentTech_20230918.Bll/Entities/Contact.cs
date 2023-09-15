using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaMomentTech_20230918.Bll.Entities
{
    public class Contact
    {
        internal Contact(int id, string nom, string prenom, bool actif)
            : this(nom, prenom, actif)
        {
            Id = id;
        }

        public Contact(string nom, string prenom, bool actif)
        {
            Nom = nom;
            Prenom = prenom;
            Actif = actif;
        }

        public int Id { get; init; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool Actif { get; set; }
    }
}
