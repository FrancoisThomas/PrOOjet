using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant une unité viking.
	/// </summary>
    public class UniteViking : Unite, IUniteViking
    {
    	/// <summary>
    	/// Constructeur.
    	/// </summary>
    	/// <param name="j"> Le joueur auquel appartient l'unité créée. </param>
        public UniteViking(IJoueur j) : base(j) {}
    }
}
