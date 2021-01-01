using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubTenis
{
    class Match
    {
        string nom1;
        int score1;
        int score2;
        string nom2;

        /// <summary>
        /// Class Match
        /// Un match possède deux noms d'equipes qui s'affrontent ainsi que leur score
        /// Avec les noms d'équipes ont retrouvera directement les joueurs appartenants à cette equipe pour l'attribution des points
        /// </summary>

        public string Nom1 { get => nom1; set => nom1 = value; }
        public int Score1 { get => score1; set => score1 = value; }
        public int Score2 { get => score2; set => score2 = value; }
        public string Nom2 { get => nom2; set => nom2 = value; }

        public Match()
        { }
        public Match(string nom1, int score1, string nom2, int score2)
        {
            this.Nom1 = nom1;
            this.Score1 = score1;
            this.Score2 = score2;
            this.Nom2 = nom2;
        }

        public string Afficher()
        {
            return this.nom1 + " " + this.score1 + " " + this.nom2 + " " + this.score2;
        }


        //METHODE 
        public string MatchSimple(Equipe A, Equipe B)
        {
            if (this.Score1 == -1 || this.Score2 == -1)
            {
                if (this.Score1 == -1)
                { A.Point = A.Point - 1; B.Point = B.Point + 2; A.Annuler++; B.Victoire++; return "Victoire par forfait pour " + B.NomEquipe; }
                else
                { B.Point = B.Point - 1; A.Point = A.Point + 2; B.Annuler++; A.Victoire++; return "Victoire par forfait pour " + A.NomEquipe; }
            }
            else
            {
                if (this.Score1 > this.Score2)
                { A.Point = A.Point + 2; A.Victoire++; B.Défaite++; return "Victoire pour " + A.NomEquipe; }
                else
                { B.Point = B.Point + 2; A.Défaite++; B.Victoire++; return "Victoire pour " + B.NomEquipe; }
                
            }
            
        }

        public string MatchDouble(Equipe A, Equipe B, Equipe C, Equipe D) //MATCH A+B VS C+D
        {
            if (score1 > score2)
            { B.Point = B.Point + 1; A.Point = A.Point + 1; A.Victoire++; C.Défaite++; B.Victoire++; D.Défaite++; return "Victoire pour " + A.NomEquipe; }// VictoireICTOIRE A ET B
            else
            { D.Point = D.Point + 1; C.Point = C.Point + 1; C.Victoire++; A.Défaite++; D.Victoire++; B.Défaite++; return "Victoire pour " + C.NomEquipe; }// VICTOIRE C ET D
        }
    }
}
