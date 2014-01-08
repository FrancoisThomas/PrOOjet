using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant des coordonnées en deux dimensions.
	/// </summary>
    public class Coordonnees
    {
    	/// <summary> Abscisse. </summary>
        private int posX;
        /// <summary> Ordonnée. </summary>
        private int posY;

		/// <summary>
		/// Constructeur.
		/// </summary>
		/// <param name="x"> Abscisse. </param>
		/// <param name="y"> Ordonnée. </param>
        public Coordonnees(int x, int y)
        {
            posX = x;
            posY = y;
        }
    }
}
