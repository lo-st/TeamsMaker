using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TeamsMaker_METIER.Algorithmes.Outils;
using TeamsMaker_METIER.JeuxTest;   
using TeamsMaker_METIER.Personnages;

namespace TeamsMaker_METIER.Algorithmes.Realisations
{
    class AlgorithmeExtremesPremiers : Algorithme
    {
        #region --- Attributs ---
        #endregion

        #region --- Propriétés ---
        #endregion

        #region --- Constructeur ---
        #endregion

        #region --- Méthodes ---

        /// <summary>
        /// Renvoie une répartition qui comprend les équipes de 4 joueurs en respectant l'algotithme
        /// </summary>
        /// <param name="jeuTest"></param>
        /// <returns>Renvoie une répartition de joueurs</returns>
        public override Repartition Repartir(JeuTest jeuTest)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Repartition repartition = new Repartition(jeuTest);
            Personnage[] personnages = jeuTest.Personnages;
            Array.Sort(personnages, new ComparateurPersonnageParNiveauPrincipal());

            // stockage des index des 4 personnages à inclure dans une équipe
            int indexPremierePersonne = 0;
            int indexDeuxiemePersonne = 1;
            int indexDernierePersonne = personnages.Length - 1;
            int indexAvantDernierePersonne = personnages.Length - 2;

            //stockage du nombre de personnages encore seuls
            int nbPersonnagesRestant = personnages.Length;

            // tant qu'il y a plus de 4 personnages seuls
            while (nbPersonnagesRestant >= 4)
            {
                // on créer une équipe et on ajoute les 4 personnage avec les indexs créés précédemment
                Equipe equipe = new Equipe();
                equipe.AjouterMembre(personnages[indexPremierePersonne]);
                equipe.AjouterMembre(personnages[indexDeuxiemePersonne]);
                equipe.AjouterMembre(personnages[indexDernierePersonne]);
                equipe.AjouterMembre(personnages[indexAvantDernierePersonne]);
                repartition.AjouterEquipe(equipe);

                // on incrémente et décremente les index pour resserrer l'étaux
                indexPremierePersonne += 2;
                indexDeuxiemePersonne++;
                indexDernierePersonne -= 2;
                indexAvantDernierePersonne--;

                // on diminue le nombre de personnages seuls de 4
                nbPersonnagesRestant -= 4;
            }

            stopwatch.Stop();
            this.TempsExecution = stopwatch.ElapsedMilliseconds;

            return repartition;
        }
        #endregion
    }
}
