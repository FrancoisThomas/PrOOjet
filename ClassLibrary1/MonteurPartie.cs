using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
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

        public IPartie creerPartie(IPeuple peuple1, IPeuple peuple2, int tailleCarte)
        {
            IPartie partie = Partie.INSTANCE;
            partie.Joueur1 = new Joueur(peuple1, 0, "j1");
            partie.Joueur2 = new Joueur(peuple2, 1, "j2");
            partie.Carte = new Carte(tailleCarte);

            //TODO Recuperer coordonnes de depart pour j1 et j2
            Coordonnees c1 = null;
            Coordonnees c2 = null;

            for (int i = 0; i < (4 * tailleCarte) / 5; i++) {
                partie.Joueur1.creeUnite(c1);
                partie.Joueur2.creeUnite(c2);
            }

            return partie;
        }
    }
}
