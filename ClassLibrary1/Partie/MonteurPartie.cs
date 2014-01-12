using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Implémentation du monteur de la <c>IPartie</c>.
	/// </summary>
	/// <seealso cref="IPartie"/>
    public class MonteurPartie : PrOOjet.IMonteurPartie
    {
        private static IMonteurPartie instance;

        private MonteurPartie() {}

        public static IMonteurPartie INSTANCE
        {
            get 
            {
                if (instance == null)
                    instance = new MonteurPartie();
                return instance;
            }
        }

		/// <summary>
		/// Méthode de création de la partie. Crée la carte, les joueurs et les unités.
		/// </summary>
		/// <param name="peuple1"> Peuple du premier joueur. </param>
		/// <param name="peuple2"> Peuple du second joueur. </param>
		/// <param name="strategie"> Taille de la carte. </param>
		/// <returns> La partie créée. </returns>
		/// <seealso cref="IPartie"/>
		/// <seealso cref="ICarte"/>
		/// <seealso cref="IJoueur"/>
		/// <seealso cref="IUnite"/>
        public IPartie creerPartie(IPeuple peuple1, IPeuple peuple2, IStrategieTaille strategie)
        {
            IPartie partie = Partie.INSTANCE;
            partie.Joueur1 = new Joueur(peuple1, 0, "j1");
            partie.Joueur2 = new Joueur(peuple2, 1, "j2");
            partie.JoueurActif = partie.Joueur1;
            partie.Carte = strategie.construitCarte();
            partie.NbTours = strategie.NbTours;

            //TODO Recuperer coordonnes de depart pour j1 et j2

            Coordonnees c1 = new Coordonnees(1,3);
            Coordonnees c2 = new Coordonnees(1,4);
            //Coordonnees c2 = new Coordonnees(strategie.Taille-1,strategie.Taille-1);


            for (int i = 0; i < strategie.NbUnites ; i++) {
                partie.Joueur1.creeUnite(c1);
                partie.Joueur2.creeUnite(c2);
            }

            return partie;
        }
    }
}
