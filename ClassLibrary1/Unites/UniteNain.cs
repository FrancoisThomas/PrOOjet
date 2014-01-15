using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant une unité naine.
	/// </summary>
    [Serializable]
    public class UniteNain : Unite, IUniteNain
    {
        public UniteNain() {}

    	/// <summary>
    	/// Constructeur.
    	/// </summary>
    	/// <param name="j"> Le joueur auquel appartient l'unité créée. </param>
        public UniteNain(IJoueur j) : base(j) {}
    }
}
