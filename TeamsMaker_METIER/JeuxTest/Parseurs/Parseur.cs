using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsMaker_METIER.Personnages;
using TeamsMaker_METIER.Personnages.Classes;

namespace TeamsMaker_METIER.JeuxTest.Parseurs
{
    /// <summary>
    /// Parseur de fichier .jt
    /// </summary>
    public class Parseur
    {
        // parse une ligne pour créer le person
        private Personnage ParserLigne(string ligne)
        {
            string[] morceaux = ligne.Split(' ');
            Classe classe = (Classe)Enum.Parse(typeof(Classe), morceaux[0]);
            int levelPrincipal = Int32.Parse(morceaux[1]);
            int levelSecondaire = Int32.Parse(morceaux[2]);
            Personnage personnage = new Personnage(classe, levelPrincipal, levelSecondaire);
            return personnage;
        }

        public JeuTest Parser(string nomFichier)
        {
            JeuTest jeuTest = new JeuTest();
            string cheminFichier = Path.Combine(Directory.GetCurrentDirectory(),
            "JeuxTest/Fichiers/" + nomFichier);
            using (StreamReader stream = new StreamReader(cheminFichier))
            {
                string ligne;
                while ((ligne = stream.ReadLine()) != null)
                {
                    //Traiter une ligne
                    Personnage personnage = this.ParserLigne(ligne);
                    jeuTest.AjouterPersonnage(personnage);
                }
            }
            return jeuTest;
        }
    }
}
