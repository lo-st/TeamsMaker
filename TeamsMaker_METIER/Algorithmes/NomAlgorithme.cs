using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsMaker_METIER.Algorithmes
{
    /// <summary>
    /// Liste des noms d'algorithmes
    /// </summary>
    public enum NomAlgorithme
    {
        ALGOTEST, GLOUTONCROISSANT, EXTREMESPREMIERS, EQUILIBREPROGRESSIF
    }


    public static class NomAlgorithmeExt
    {
        /// <summary>
        /// Affichage du nom de l'algorithme
        /// </summary>
        /// <param name="algo">NomAlgorithme</param>
        /// <returns>La chaine de caractères à afficher</returns>
        public static string Affichage(this NomAlgorithme algo)
        {
            string res = "Algorithme non nommé :(";
            switch(algo)
            {
                case NomAlgorithme.ALGOTEST: res = "Algorithme de test (à supprimer)"; break;
                case NomAlgorithme.GLOUTONCROISSANT: res = "Mon algo glouton"; break;
                case NomAlgorithme.EXTREMESPREMIERS: res = "Extrêmes premiers"; break;
                case NomAlgorithme.EQUILIBREPROGRESSIF: res = "Equilibre progressif"; break;
            }
            return res;
        }
    }
}
