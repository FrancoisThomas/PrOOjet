using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wrapper;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant la carte. Contient la liste des cases de la carte.
	/// </summary>
    public class Carte : ICarte
    {
        private int taille;
        private List<ICase> cases;
        private IFabriqueCase fabriqueCase;

		/// <summary>
		/// Constructeur.
		/// </summary>
		/// <param name="tailleCarte"> Taille de la carte. </param>
        public Carte(int tailleCarte)
        {
            taille = tailleCarte;
            fabriqueCase = FabriqueCase.INSTANCE;
            String[] typesCases = { "d", "e", "m", "f", "p" };
            WrapperCarte wrap = new WrapperCarte();
            List<int> tab = wrap.genereCarte(taille);
            
            /*List<int> tab = new List<int>();
            for (int i = 0; i < taille * taille; i++)
                tab.Add(i%5);*/

            List<ICase> l = new List<ICase>();

            for (int i = 0; i < taille*taille; i++)
                l.Add(fabriqueCase.creeCase(typesCases[tab.ElementAt(i)]));
            cases = l;
        }

		/// <summary>
		/// Taille de la carte.
		/// </summary>
        public int Taille 
        { 
            get
            {
                return taille;
            }

        }

		/// <summary>
		/// Liste des cases de la carte.
		/// </summary>
        public List<ICase> Cases
        { 
            get 
            { 
                return cases; 
            }

        }

		/// <summary>
		/// Fournit la case situé aux coordonnées passées en paramètre.
		/// </summary>
		/// <param name="colonne"> Indice de la colonne. Commence à 0. </param>
		/// <param name="ligne"> Indice de la ligne. Commence à 0. </param>
		/// <returns> La case aux coordonnées passées en paramètre. </returns>
        public ICase getCase(int colonne, int ligne) // TODO utiliser des Coordonnes à la place des entiers ?
        {
            return cases.ElementAt(ligne * taille + colonne);
        }

        public override string ToString()
        {
            string res = "Carte de taille " + Taille + "\n";
            for (int i = 0; i < Taille; i++)
            {
                for (int j = 0; j < Taille; j++)
                {
                    res += cases.ElementAt(i * Taille + j) + " ";
                }
                res += "\n";
            }
            return res;
        }
    }
}
