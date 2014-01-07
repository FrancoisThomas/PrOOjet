using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant une unité.
	/// </summary>
    public abstract class Unite : PrOOjet.IUnite
    {
    	/// <value> Points de vie maximum. </value>
        protected const int PDVMAX = 2;
        /// <value> Points de mouvements maximum. </value>
        protected const int PDMMAX = 2;
        /// <value> Points de défense. </value>
        protected const int DEFENSE = 1;
        /// <value> Points d'attaque. </value>
        protected const int ATTAQUE = 2;

        protected int pointsDeVie;
        protected int pointsDeMouvement;

        protected IJoueur joueur;

        protected Unite() // TODO A virer
        {
            pointsDeVie = PDVMAX;
            pointsDeMouvement = PDMMAX;
        }

        protected Unite(IJoueur j)
        {
            pointsDeVie = PDVMAX;
            pointsDeMouvement = PDMMAX;
            joueur = j;
        }

		/// <summary> Points de mouvements de l'unité </summary>
        public int PointsDeMouvement
        {
            get
            {
                return pointsDeMouvement;
            }
            set
            {
                // TODO
            }
        }

        /// <summary> Valeur d'attaque effective de l'unité (calculée en fonction de ses points de vie). </summary>
        public int Attaque
        {
            get
            {
                return ATTAQUE * (pointsDeVie / PDVMAX);
            }
        }

        /// <summary> Valeur de défense effective de l'unité (calculée en fonction de ses points de vie). </summary>
        public int Defense
        {
            get
            {
                return DEFENSE * (pointsDeVie / PDVMAX);
            }
        }

        /// <summary> Points de vie restants à l'unité </summary>
        public int PointsDeVie
        {
            get
            {
                return pointsDeVie;
            }
            set
            {
                pointsDeVie = value;
            }
        }

        public IJoueur Joueur
        {
            get
            {
                return joueur;
            }
            set
            {
                joueur = value;
            }
        }

		/// <summary>
		/// Diminue les points de mouvements de l'unité.
		/// </summary>
		/// <param name="v"> La valeur à retirer aux points de mouvements de l'unité. </param>
        public void diminuePointsDeMouvement(int v)
        {
            pointsDeMouvement -= v;
        }

		/// <summary>
		/// Diminue les points de vie de l'unité.
		/// </summary>
		/// <param name="v"> La valeur à retirer aux points de vie de l'unité. </param>
        public void diminuePointsDeVie(int v)
        {
            pointsDeVie -= v;
        }

		/// <summary>
		/// Détermine si l'unité peut bouger sur une case.
		/// </summary>
		/// <param name="caseEntree"> Case sur laquelle l'unité doit avancer. </param>
		/// <returns> <c>true</c> si l'unité peut aller sur la case en paramètre. </returns>
        public abstract bool peutBouger(ICase caseEntree); // TODO Ecrire un comportement "standard" à overrider si besoin ?

		/// <summary>
        /// Détermine si une unité est décédée.
        /// </summary>
        /// <returns> <c>true</c> si l'unité est morte. </returns>
        public bool estMort()
        {
            return pointsDeVie <= 0;
        }

    }
}
