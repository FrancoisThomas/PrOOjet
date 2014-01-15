using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant une unité gauloise.
	/// </summary>
    [Serializable]
    public class UniteGaulois : Unite, IUniteGaulois
    {
        public UniteGaulois() {}

    	/// <summary>
    	/// Constructeur.
    	/// </summary>
    	/// <param name="j"> Le joueur auquel appartient l'unité créée. </param>
        public UniteGaulois(IJoueur j) : base(j) { }

    }
}
