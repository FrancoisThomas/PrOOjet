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
        public int posX;
        /// <summary> Ordonnée. </summary>
        public int posY;

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

        public override bool Equals(object obj)
        {
            return (obj != null)
                && (obj is Coordonnees) 
                && ((Coordonnees)obj).posX == this.posX 
                && ((Coordonnees)obj).posY == this.posY;
        }

        public override int GetHashCode()
        {
            int hash = (int) (posX ^ (posX >> 32));
            hash = 31 * hash + (int) (posY ^ (posY >> 32));
            return hash;
        }

        public override string ToString()
        {
            return "(" + posX + ";" + posY + ")";
        }
    }
}
