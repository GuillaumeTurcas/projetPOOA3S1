using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubTenis
{
    static class ListStatic
    {

        /// <summary>
        /// Entrepose toutes les list statics que nous aurons besoin au fur et à mesure du programme
        /// Indispensable por avoir un accès n'importe où et le mettre dans une datagrid
        /// Une datagrid est la meilleure chose pour afficher une liste 
        /// </summary>
        

        public static List<Membre> lMembre = new List<Membre>();
        public static List<Salarie> lSalarie = new List<Salarie>();
        public static List<Equipe> lEquipe = new List<Equipe>();
        public static List<Competition> lCompet = new List<Competition>();
        public static List<Statistique> lStat = new List<Statistique>();
        public static List<Junior> lJunior = new List<Junior>();
        public static List<Match> lMatch = new List<Match>();
    }
}
