using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant une unité naine.
	/// </summary>
    public class UniteNain : Unite, IUniteNain
    {
    	/// <summary>
    	/// Constructeur.
    	/// </summary>
    	/// <param name="j"> Le joueur auquel appartient l'unité créée. </param>
        public UniteNain(IJoueur j) : base(j) {}

		/// <summary>
		/// Détermine si l'unité peut bouger sur une case.
		/// </summary>
		/// <param name="caseEntree"> Case sur laquelle l'unité doit avancer. </param>
		/// <returns> <c>true</c> si l'unité peut aller sur la case en paramètre. </returns>
        public override bool peutBouger(ICase caseEntree)
        {
            return (PointsDeMouvement > 1);
        }
    }
}
