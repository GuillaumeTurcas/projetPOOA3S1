using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubTenis
{
    /// <summary>
    /// IComparable
    /// </summary>
    interface IComparabe //on ne s'en servira pas car la data grid est mieux mais on a quand meme mis pour montrer quon sait l'utiliser en temps voulu
    {
        int CompareTo(object val);
    }
}
