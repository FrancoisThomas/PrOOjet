using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wrapper;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant la partie. Gère le jeu.
	/// </summary>
    public class Partie : IPartie
    {
        private static IPartie instance;

        private IJoueur joueur1;
        private IJoueur joueur2;
        private ICarte carte;
        private int nbTours;

		/// <summary> Joueur en train de jouer. </summary>
        private IJoueur joueurActif;
        /// <summary> Joueur en attente. </summary>
        private IJoueur joueurNonActif { get { return joueurActif == joueur1 ? joueur2 : joueur1; } }

        private Partie()
        {
            // TODO
            carte = new Carte(8);
        }

        //public ICarte getCarte() { return carte; } //TODO supprimer

        public static IPartie INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new Partie();
                return instance;
            }
        }

        public IJoueur Joueur1
        {
            get { return joueur1; }
            set { joueur1 = value; }
        }

        public IJoueur Joueur2
        {
            get { return joueur2; }
            set { joueur2 = value; }
        }

        public ICarte Carte 
        {
            get { return carte; }
            set { carte = value; }
        }

        public int NbTours
        {
            get { return nbTours; }
            set { nbTours = value; }
        }

		/// <summary>
		/// Sélectionne les unités aux coordonnées indiquées.
		/// </summary>
		/// <param name="coord"> Les coordonnées auxquelles on veut sélectionner les unités. </param>
		/// <returns> Renvoie la liste des unités aux coordonnées indiquées (null si il n'y en a pas). </returns>
        public List<IUnite> selectionneUnites(Coordonnees coord)
        {
            List<IUnite> unites = joueurActif.recupereUnites(coord);

            if (unites == null)
                unites = joueurNonActif.recupereUnites(coord);

            return unites;

        }

        
    }
}
