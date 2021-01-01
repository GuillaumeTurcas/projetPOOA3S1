using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubTenis
{
    class Statistique
    {
        string Competition_Realiser_Sur_Total;
        double Moyenne_Joueur_Par_Competition;
        string Statistique_Competition;
        string CategorieHomme;
        string CategorieFemme;
        string CategorieEnfant;
        /// <summary>
        /// statistique
        /// il fonctionne directement sans interaction de l'utilisateur
        /// </summary>
        public Statistique()
        {
            this.Competition_Realiser_Sur_Total1 = "0";
            this.Moyenne_Joueur_Par_Competition1 = 0;
            this.Statistique_Competition1 = "0";
            this.CategorieHomme1 = "0";
            this.CategorieFemme1 = "0";
            this.CategorieEnfant1 = "0";
        }
        public Statistique(string Competition_Realiser_Sur_Total, double Moyenne_Joueur_Par_Competition, string Statistique_Competition, string CategorieHomme, string CategorieFemme, string CategorieEnfant)
        {
            this.Competition_Realiser_Sur_Total1 = Competition_Realiser_Sur_Total;
            this.Moyenne_Joueur_Par_Competition1 = Moyenne_Joueur_Par_Competition;
            this.Statistique_Competition1 = Statistique_Competition;
            this.CategorieHomme1 = CategorieHomme;
            this.CategorieFemme1 = CategorieFemme;
            this.CategorieEnfant1 = CategorieEnfant;
        }

        public string Competition_Realiser_Sur_Total1 { get => Competition_Realiser_Sur_Total; set => Competition_Realiser_Sur_Total = value; }
        public double Moyenne_Joueur_Par_Competition1 { get => Moyenne_Joueur_Par_Competition; set => Moyenne_Joueur_Par_Competition = value; }
        public string Statistique_Competition1 { get => Statistique_Competition; set => Statistique_Competition = value; }
        public string CategorieHomme1 { get => CategorieHomme; set => CategorieHomme = value; }
        public string CategorieFemme1 { get => CategorieFemme; set => CategorieFemme = value; }
        public string CategorieEnfant1 { get => CategorieEnfant; set => CategorieEnfant = value; }


        //METHODES
        public int RealiserTot(List<Competition> lCompet)
        {
            int cpt = 0;
            foreach (Competition C in lCompet)
            {
                if (C.Realise == true)
                { cpt++; }
            }
            return cpt;
        }

        public void RvsAFAire(List<Competition> lCompet)// NB COMPET REALISER SUR LE TOTAL 
        {
            this.Competition_Realiser_Sur_Total = "Realisé : " + RealiserTot(lCompet) + " sur " + lCompet.Count;
        }

        public void MoyenJparCompet(List<Equipe> Lequipe, List<Competition> lCompet)// MOYENNE DE JOUEURS PAR COMPETITION
        {
            if (lCompet.Count == 0) this.Moyenne_Joueur_Par_Competition = 0;
            else this.Moyenne_Joueur_Par_Competition = Lequipe.Count / lCompet.Count;
        }
        public void StatCompetClub(List<Equipe> Lequipe)
        {
            int vtot = 0; int dtot = 0; int annuletot = 0;
            foreach (Equipe E in Lequipe)
            {
                vtot = vtot + E.Victoire;
                dtot = dtot + E.Défaite;
                annuletot = annuletot + E.Annuler;
            }
            this.Statistique_Competition = "Victoire total: " + vtot + "  Defaite total:" + dtot + " Annulés total:" + annuletot;
        }

        public void RepartitionParCategorie(List<Equipe> Lequipe)
        {
            int vH = 0; int dH = 0; int annuleH = 0; int vF = 0; int dF = 0; int annuleF = 0; int vE = 0; int dE = 0; int annuleE = 0;
            foreach (Equipe E in Lequipe)
            {
                if (E.Sexe == "Femme")
                {
                    vF = vF + E.Victoire;
                    dF = dF + E.Défaite;
                    annuleF = annuleF + E.Annuler;
                }
                if (E.Sexe == "Homme")
                {
                    vH = vH + E.Victoire;
                    dH = dH + E.Défaite;
                    annuleH = annuleH + E.Annuler;
                }
                if (E.Sexe == "Enfant")
                {
                    vE = vE + E.Victoire;
                    dE = dE + E.Défaite;
                    annuleE = annuleE + E.Annuler;
                }
            }
            this.CategorieEnfant = "Victoire total: " + vE + "  Defaite total:" + dE + " Annulés total:" + annuleE;
            this.CategorieFemme = "Victoire total: " + vF + "  Defaite total:" + dF + " Annulés total:" + annuleF;
            this.CategorieHomme = "Victoire total: " + vH + "  Defaite total:" + dH + " Annulés total:" + annuleH;
        }

    }
}
