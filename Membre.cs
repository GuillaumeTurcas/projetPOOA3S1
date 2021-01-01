using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubTenis
{
    class Membre : Personne, IComparable<Membre>
    {
        string titre; //loisir ou compétition
        bool cotisation;
        bool captain;

        

        public Membre(string nom, string prenom, string birthday, string sexe, string adresse, string ville, string numeroTel, string titre, bool cotisation, bool captain) : base(nom, prenom, birthday, sexe, adresse, ville, numeroTel)
        {
            this.titre = titre;
            this.cotisation = cotisation;
            this.captain = captain;

        }

        /// <summary>
        /// Module membre avec constructeurs
        /// </summary>

        public string Titre
        {
            get { return this.titre; }
            set { this.titre = value; }
        }

        public bool Cotisation
        {
            get { return this.cotisation; }
            set { this.cotisation = value; }
        }

        public bool Capitaine { get => this.captain; set => this.captain = value; }

        
        public new String Afficher() //Permet de return un string utile pour la sauvegarde quand on ecrira directement sur le .txt
        {
            return base.Afficher() + " " + titre + " " + Convert.ToString(cotisation) + " " + Convert.ToString(captain);
        }

        public bool Equals(Membre M) //permet de savoir si deux membres sont identiques
        {
            return this.Nom == M.Nom && this.Prenom == M.Prenom;
        }

        public int CompareTo(Membre m)
        {
            return Nom.CompareTo(m.Nom);
        }
    }
}
