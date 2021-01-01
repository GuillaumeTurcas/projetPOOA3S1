using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubTenis
{
    class Stage
    {
        //ATTRIBUT
        List<Cours> lCours;

        internal List<Cours> LCours { get => lCours; set => lCours = value; }

        public Stage(List<Cours> lCours)
        { this.LCours = lCours; }
        /*
        //METHODE
        public string ToString()
        {
            string afficherstage = "";
            foreach (Cours C in this.lcours)
            {
                afficherstage = afficherstage + "\n" + C.Affichage();
            }

        }*/
    }
}
