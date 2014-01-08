using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Interface du monteur de la partie.
	/// </summary>
	/// <seealso cref="IPartie"/>
    public interface IMonteurPartie
    {
    	/// <summary>
		/// Méthode de création de la partie. Crée la carte, les joueurs et les unités.
		/// </summary>
		/// <param name="peuple1"> Peuple du premier joueur. </param>
		/// <param name="peuple2"> Peuple du second joueur. </param>
		/// <param name="tailleCarte"> Taille de la carte. </param>
		/// <returns> La partie créée. </returns>
		/// <seealso cref="IPartie"/>
		/// <seealso cref="ICarte"/>
		/// <seealso cref="IJoueur"/>
		/// <seealso cref="IUnite"/>
        IPartie creerPartie(IPeuple peuple1, IPeuple peuple2, IStrategieTaille tailleCarte);
    }
}
