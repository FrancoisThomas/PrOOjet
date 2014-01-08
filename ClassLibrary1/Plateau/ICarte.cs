using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Interface d'une carte.
	/// </summary>
    public interface ICarte
    {
    	/// <summary> Taille de la carte. </summary>
        int Taille { get; }
        /// <summary> Liste des cases de la carte. La case aux coordonnées (x,y) est à l'indice <c>x*taille + y</c> </summary>
        List<ICase> Cases { get; }

		/// <summary>
		/// Fournit la case situé aux coordonnées passées en paramètre.
		/// </summary>
		/// <param name="colonne"> Indice de la colonne. Commence à 0. </param>
		/// <param name="ligne"> Indice de la ligne. Commence à 0. </param>
		/// <returns> La case aux coordonnées passées en paramètre. </returns>
        ICase getCase(int colonne, int ligne); 
    }

}
