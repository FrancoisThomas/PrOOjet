using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant un peuple. Sert de fabrique à <c>IUnite</c>.
	/// </summary>
	/// <seealso cref="IUnite"/>
    [Serializable]
    public abstract class Peuple : PrOOjet.IPeuple
    {
        public Peuple() {}

		/// <summary>
		/// Fournit une <c>IUnite</c>.
		/// </summary>
		/// <param name="joueur"> Joueur auquel appartient l'unité crée. </param>
		/// <returns> Une nouvelle <c>IUnite</c> </returns>
        public abstract IUnite creeUnite(IJoueur joueur);
    }
}
