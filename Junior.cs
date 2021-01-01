using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubTenis
{
    class Junior
    {
        /// <summary>
        /// Junior
        /// Un junior est un membre qui a moins de 18 ans
        /// Ils sont initialisés au lancé du programme à partir de la date du jour
        /// </summary>
        string nom;
        string prenom;
        bool cotise;
        public Junior(string nom, string prenom)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Cotise = false;
        }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public bool Cotise { get => cotise; set => cotise = value; }

        public string Afficher()
        {
            return this.nom + " " + this.prenom;
        }

    }
}
