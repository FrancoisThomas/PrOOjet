using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant le peuple viking. Sert de fabrique à <c>UnitesViking</c>.
	/// </summary>
	/// <seealso cref="UniteViking"/>
    public class Viking : Peuple, IPeupleViking
    {
        private static IPeupleViking instance;

        private Viking() {}

        public static IPeupleViking INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new Viking();
                return instance;
            }
        }

		/// <summary>
		/// Fournit une <c>UniteViking</c>.
		/// </summary>
		/// <param name="joueur"> Joueur auquel appartient l'unité crée. </param>
		/// <returns> Une nouvelle <c>UniteViking</c> </returns>
        public override IUnite creeUnite(IJoueur joueur)
        {
            return new UniteViking(joueur);
        }

    }
}
