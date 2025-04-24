using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsMaker_METIER.Algorithmes.Outils;
using TeamsMaker_METIER.JeuxTest;
using TeamsMaker_METIER.Personnages;

namespace TeamsMaker_METIER.Algorithmes.Realisations
{
    internal class AlgorithmeEquilibreProgressif : Algorithme
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

            int nbPersonnagesSeuls = personnages.Length;
            int? indicePerso = null;
            List<int?> indicesPersonnagesAvecEquipe = new List<int?>();
            double? scoreMin = null;
            Personnage? personnageOptimal = null;

            // tant qu'on peut encore faire des équipes
            while (nbPersonnagesSeuls >= 4)
            {
                Equipe equipe = new Equipe();
                // tant que l'équipe n'est pas au complet
                for (int i = 0; i < 4; i++)
                {
                    // pour chaque personnage
                    for (int indexPersonnageSansEquipe = 0; indexPersonnageSansEquipe < personnages.Length; indexPersonnageSansEquipe++)
                    {
                        // s'il est seul
                        if (!indicesPersonnagesAvecEquipe.Contains(indexPersonnageSansEquipe))
                        {
                            // on calcul le score de l'équipe avec le nouveau personnage 
                            double scoreEquipe = 0;
                            foreach (Personnage membre in equipe.Membres)
                            {
                                scoreEquipe += membre.LvlPrincipal;
                            }
                            scoreEquipe += personnages[indexPersonnageSansEquipe].LvlPrincipal;
                            scoreEquipe /= equipe.Membres.Length + 1;
                            scoreEquipe = 50 - scoreEquipe;
                            scoreEquipe *= scoreEquipe;
                            // si c'est la première ittération on attribue le score et on enregistre le personnage
                            if (scoreMin == null)
                            {
                                scoreMin = scoreEquipe;
                                indicePerso = indexPersonnageSansEquipe;
                                personnageOptimal = personnages[indexPersonnageSansEquipe];
                            }                               
                            // si le score de l'équipe avec ce nouveau personnage est optimal on enregistre ce nouveau score et on enregistre le personnage
                            if (scoreMin > scoreEquipe)
                            {
                                scoreMin = scoreEquipe;
                                indicePerso = indexPersonnageSansEquipe;
                                personnageOptimal = personnages[indexPersonnageSansEquipe];
                            }
                        }
                    }
                    // ajout du personnage à l'équipe
                    indicesPersonnagesAvecEquipe.Add(indicePerso);
                    equipe.AjouterMembre(personnageOptimal);
                    nbPersonnagesSeuls -= 1;
                    scoreMin = null;
                }
                // on ajoute l'équipe à la répartition
                repartition.AjouterEquipe(equipe);
            }

            stopwatch.Stop();
            this.TempsExecution = stopwatch.ElapsedMilliseconds;

            return repartition;
        }
        #endregion
    }
}
