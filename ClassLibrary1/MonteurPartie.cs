using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public class MonteurPartie : PrOOjet.IMonteurPartie
    {
        private static IMonteurPartie instance;

        private MonteurPartie()
        {
            throw new System.NotImplementedException();
        }

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

            return partie;
        }
    }
}
