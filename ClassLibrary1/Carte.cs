using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wrapper;

namespace PrOOjet
{
    public class Carte : ICarte
    {
        private int taille;
        private List<ICase> cases;
        private IFabriqueCase fabriqueCase;

        public Carte(int tailleCarte)
        {
            taille = tailleCarte;
            String[] typesCases = { "d", "e", "m", "f", "p" };
            List<int> tab = WrapperCarte.genereCarte(taille);
            List<ICase> l = new List<ICase>();

            for (int i = 0; i < taille*taille; i++)
                l.Add(fabriqueCase.creeCase(typesCases[tab.ElementAt(i)]));
            cases = l;
        }

        public int Taille 
        { 
            get { return taille; } 
        }

        public List<ICase> Cases 
        { 
            get { return cases; } 
        }

        public ICase getCase(int colonne, int ligne)
        {
            return cases.ElementAt(ligne * taille + colonne);
        }
    }
}
