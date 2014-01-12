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

        /// <summary> Joueur 1. </summary>
        private IJoueur joueur1;

        /// <summary> Joueur 2. </summary>
        private IJoueur joueur2;

        /// <summary> Joueur en train de jouer. </summary>
        private IJoueur joueurActif;

        /// <summary> La carte du jeu. </summary>
        private ICarte carte;

        /// <summary> Le nombre de tours. </summary>
        private int nbToursMax;

        /// <summary> Le nombre de tours. </summary>
        private int nbTours;

        /// <summary> Le nombre de points du Joueur 1. </summary>
        private int pointsJoueur1;

        /// <summary> Le nombre de points du Joueur 2. </summary>
        private int pointsJoueur2;

        
        /// <summary> Joueur en attente. </summary>
        private IJoueur joueurNonActif { get { return joueurActif == joueur1 ? joueur2 : joueur1; } }

        private Partie()
        {
            // TODO
            //carte = new Carte(8);
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

        public IJoueur JoueurActif
        {
            get { return joueurActif; }
            set { joueurActif = value; }
        }

        public ICarte Carte 
        {
            get { return carte; }
            set { carte = value; }
        }

        public int NbToursMax
        {
            get { return nbToursMax; }
            set { nbToursMax = value; }
        }

        public int NbTours
        {
            get { return nbTours; }
            set { nbTours = value; }
        }

        public int PointsJoueur1
        {
            get { return pointsJoueur1; }
            set { pointsJoueur1 = value; }
        }

        public int PointsJoueur2
        {
            get { return pointsJoueur2; }
            set { pointsJoueur2 = value; }
        }

        public void finTour()
        {
            if (joueurActif == joueur2)
                nbTours++;
            if (nbTours == nbToursMax)
                // TODO : methode de fin de partie
                return;
            ajoutPoints(joueurActif);
            joueurActif = joueurNonActif;
        }

        public void ajoutPoints(IJoueur j)
        {
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

        /// <summary>
        /// Renvoie le dictionnaire des unités de la partie, avec leurs coordonees.
        /// </summary>
        public Dictionary<Coordonnees, List<IUnite>> recupereUnites()
        {
            Dictionary<Coordonnees, List<IUnite>> unit1 = joueur1.Unites;
            Dictionary<Coordonnees, List<IUnite>> unit2 = joueur2.Unites;
            
            return unit1.Concat(unit2).GroupBy(d => d.Key)
                        .ToDictionary(k => k.Key, v => v.First().Value.Union(v.Last().Value).ToList());
        }

        /// <summary>
        /// Renvoie la carte annotée selons les deplacements possibles.
        /// </summary>
        public List<int> suggereDeplacement(IUnite unite, Coordonnees pos)
        {
            List<int> carteAnnotee = new List<int>();
            WrapperCarte wrap = new WrapperCarte();

            int posUnite = pos.posX * carte.Taille + pos.posY;
            List<int> carteInt = new List<int>();
            foreach (ICase c in carte.Cases)
	        {
		        if (c is ICaseDesert)
                    carteInt.Add((int)ECase.DESERT);
                if (c is ICaseEau)
                    carteInt.Add((int)ECase.EAU);
                if (c is ICaseMontagne)
                    carteInt.Add((int)ECase.MONTAGNE);
                if (c is ICaseForet)
                    carteInt.Add((int)ECase.FORET);
                if (c is ICasePlaine)
                    carteInt.Add((int)ECase.PLAINE);
	        }

            Dictionary<int, int> ennemis = new Dictionary<int,int>();

            for (int i = 0; i < joueurNonActif.Unites.Count; i++)
			{
			    Coordonnees c = joueurNonActif.Unites.Keys.ElementAt(i);
                ennemis.Add(c.posX + c.posY * carte.Taille, joueurNonActif.Unites.Values.ElementAt(i).Count);
			}


            if (unite is IUniteGaulois)
                carteAnnotee = wrap.suggestionDeplacementGaulois(posUnite, carteInt, carte.Taille, ennemis);  
            if (unite is IUniteNain)
                carteAnnotee = wrap.suggestionDeplacementNain(posUnite, carteInt, carte.Taille, ennemis);
            if (unite is IUniteViking)
                carteAnnotee = wrap.suggestionDeplacementViking(posUnite, carteInt, carte.Taille, ennemis);

            return carteAnnotee;
        }
    }
}
