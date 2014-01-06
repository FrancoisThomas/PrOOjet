using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Interface de peuple. Sert de fabrique à <c>IUnite</c>
	/// </summary>
	/// <seealso cref="IUnite"/>
    public interface IPeuple
    {
    	/// <summary>
		/// Fournit une <c>IUnite</c>.
		/// </summary>
		/// <param name="joueur"> Joueur auquel appartient l'unité crée. </param>
		/// <returns> Une nouvelle <c>IUnite</c> </returns>
        IUnite creeUnite(IJoueur joueur);
    }
}
