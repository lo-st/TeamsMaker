using TeamsMaker_METIER.JeuxTest;
using TeamsMaker_METIER.JeuxTest.Parseurs;
using TeamsMaker_METIER.Algorithmes.Realisations;

Parseur parseur = new Parseur();
JeuTest jeuTest = parseur.Parser("Test.jt");

AlgorithmeGloutonCroissant bob = new AlgorithmeGloutonCroissant();
Repartition repartition = bob.Repartir(jeuTest);

repartition.LancerEvaluation(TeamsMaker_METIER.Problemes.Probleme.SIMPLE);
Console.WriteLine(repartition.Score);