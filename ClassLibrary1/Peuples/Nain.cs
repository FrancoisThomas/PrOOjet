using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant le peuple nain. Sert de fabrique à <c>UnitesNain</c>.
	/// </summary>
	/// <seealso cref="UniteNain"/>
    [Serializable]
    public class Nain : Peuple, IPeupleNain
    {
        private static IPeupleNain instance;

        private Nain() {}

        public static IPeupleNain INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new Nain();
                return instance;
            }
        }

		/// <summary>
		/// Fournit une <c>UniteNain</c>.
		/// </summary>
		/// <param name="joueur"> Joueur auquel appartient l'unité crée. </param>
		/// <returns> Une nouvelle <c>UniteNain</c> </returns>
        public override IUnite creeUnite(IJoueur joueur)
        {
            return new UniteNain(joueur);
        }

        public override string ToString()
        {
            return "Nain";
        }
    }
}
