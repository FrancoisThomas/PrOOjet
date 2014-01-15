using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant le peuple gaulois. Sert de fabrique à <c>UnitesGaulois</c>.
	/// </summary>
	/// <seealso cref="UniteGaulois"/>
    [Serializable]
    public class Gaulois : Peuple, IPeupleGaulois
    {
        private static IPeupleGaulois instance;

        private Gaulois() {}

        public static IPeupleGaulois INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new Gaulois();
                return instance;
            }
        }

		/// <summary>
		/// Fournit une <c>UniteGaulois</c>.
		/// </summary>
		/// <param name="joueur"> Joueur auquel appartient l'unité crée. </param>
		/// <returns> Une nouvelle <c>UniteGaulois</c> </returns>
        public override IUnite creeUnite(IJoueur joueur)
        {
            return new UniteGaulois(joueur);
        }

        public override string ToString()
        {
            return "Gaulois";
        }
    }
}
