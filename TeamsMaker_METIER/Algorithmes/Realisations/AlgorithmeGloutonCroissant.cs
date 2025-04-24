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
    public class AlgorithmeGloutonCroissant : Algorithme
    {
        public override Repartition Repartir(JeuTest jeuTest)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Repartition repartition = new Repartition(jeuTest);
            Personnage[] personnages = jeuTest.Personnages;
            Array.Sort(personnages, new ComparateurPersonnageParNiveauPrincipal());

            int nbPersonnageSeuls = personnages.Length;
            int index = 0;

            while (nbPersonnageSeuls >= 4)
            {
                Equipe equipe = new Equipe();
                for (int i = 0; i < 4; i++)
                {
                    equipe.AjouterMembre(personnages[index]);
                    index++;
                    nbPersonnageSeuls--;
                }
                repartition.AjouterEquipe(equipe);
            }

            stopwatch.Stop();
            this.TempsExecution = stopwatch.ElapsedMilliseconds;

            return repartition;
        }
    }
}
