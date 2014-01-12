using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant un joueur.
	/// </summary>
    public class Joueur : PrOOjet.IJoueur
    {
        private string nom;
        private int couleur;
        private IPeuple peuple;
        private Dictionary<Coordonnees, List<IUnite>> unites;

		/// <summary>
		/// Constructeur.
		/// </summary>
		/// <param name="p"> Peuple du joueur. </param>
		/// <param name="c"> Couleur du joueur. </param>
		/// <param name="n"> Nom du joueur. </param>
        public Joueur(IPeuple p, int c, string n)
        {
            peuple = p;
            couleur = c;
            nom = n;
            unites = new Dictionary<Coordonnees, List<IUnite>>();
        }

		/// <summary>
    	/// Dictionnaire des unités du joueur.
    	/// Clés : Coordonnées de la case sur laquelle sont les unités.
    	/// Valeurs : Liste d'unités sur la case aux coordonnées clés.
    	/// </summary>
        public Dictionary<Coordonnees, List<IUnite>> Unites
        {
            get
            {
                return unites;
            }
        }

		/// <summary>
		/// Fournit la liste des unités sur la case aux coordonnées passées en paramètre.
		/// </summary>
		/// <param name="coord"> Coordonnées des unités à récuperer. </param>
		/// <returns> La liste des unités sur la case, <c>null</c> si il n'y en a aucune. </returns>
        public List<IUnite> recupereUnites(Coordonnees coord)
        {
            return (coord != null && unites.ContainsKey(coord)) ? unites[coord] : null;
        }
		
/*
        public void getCouleur()
        {
            throw new System.NotImplementedException();
        }

        public string getNom()
        {
            throw new System.NotImplementedException();
        }
*/
		/// <summary> Peuple du joueur. </summary>
        public IPeuple Peuple
        {
            get { return peuple; }
        }

		/// <summary>
		/// Ajoute une nouvelle unité aux coordonnées en paramètre.
		/// </summary>
		/// <remarks> L'unité appartient au peuple du joueur. </remarks>
		/// <remarks> Si il y a déja une ou des unité(s) aux coordonnées, l'unité est ajoutée à la liste. </remarks>
		/// <param name="c"> Coordonnées auxquels ajouter l'unité. </param>
        public void creeUnite(Coordonnees c)
        {
            IUnite u = peuple.creeUnite(this);

            if (!unites.ContainsKey(c))
            {
                List<IUnite> l = new List<IUnite>();
                l.Add(u);
                unites.Add(c, l);
            }
            else
            {
                List<IUnite> l = unites[c];
                l.Add(u);
            }
        }

        /// <summary>
        /// Déplace une unité du joueur actif.
        /// </summary>
        /// <param name="unite"> L'unité à déplacer. </param>
        /// <param name="ancienneCoord"> Les anciennes coordonnées. </param>
        /// <param name="nouvelleCoord"> Les nouvelles coordonnées. </param>
        public void deplaceUnite(IUnite unite, Coordonnees ancienneCoord, Coordonnees nouvelleCoord)
        {
            List<IUnite> unitesCoord;
            if (!unites.TryGetValue(ancienneCoord, out unitesCoord))
                return;

            if (unitesCoord.Contains(unite))
            {
                unitesCoord.Remove(unite);
                if (unites.TryGetValue(nouvelleCoord, out unitesCoord))
                    unitesCoord.Add(unite);
                else
                {
                    unitesCoord = new List<IUnite>();
                    unitesCoord.Add(unite);
                    unites.Add(nouvelleCoord, unitesCoord);
                }
            }

            //Console.WriteLine(Math.Abs(ancienneCoord.posX - nouvelleCoord.posX) + Math.Abs(ancienneCoord.posY - nouvelleCoord.posY));
            unite.diminuePointsDeMouvement(unite.PointsDeMouvement);
        }

        public override string ToString()
        {
            return "Joueur " + nom + " , peuple : " + peuple;
        }
    }
}
