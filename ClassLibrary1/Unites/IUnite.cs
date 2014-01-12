using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Interface d'unité.
	/// </summary>
    public interface IUnite
    {
    	/// <summary> Points de mouvements de l'unité </summary>
        int PointsDeMouvement { get; set; }
        /// <summary> Valeur d'attaque effective de l'unité (calculée en fonction de ses points de vie). </summary>
        int Attaque { get; }
        /// <summary> Valeur de défense effective de l'unité (calculée en fonction de ses points de vie). </summary>
        int Defense { get; }
        /// <summary> Points de vie restants à l'unité </summary>
        int PointsDeVie { get; set; }
        /// <summary> Joueur auquel appartient l'unité </summary>
        IJoueur Joueur { get; }

		/// <summary>
		/// Détermine si l'unité peut bouger sur une case.
		/// </summary>
		/// <param name="caseEntree"> Case sur laquelle l'unité doit avancer. </param>
		/// <returns> <c>true</c> si l'unité peut aller sur la case en paramètre. </returns>
        bool peutBouger(ICase caseEntree);
        
        /// <summary>
        /// Détermine si une unité est décédée.
        /// </summary>
        /// <returns> <c>true</c> si l'unité est morte. </returns>
        bool estMort();

		/// <summary>
		/// Diminue les points de vie de l'unité.
		/// </summary>
		/// <param name="v"> La valeur à retirer aux points de vie de l'unité. </param>
        void diminuePointsDeVie(int v);
        
		/// <summary>
		/// Diminue les points de mouvements de l'unité.
		/// </summary>
		/// <param name="v"> La valeur à retirer aux points de mouvements de l'unité. </param>
        void diminuePointsDeMouvement(int v);

    }
}
