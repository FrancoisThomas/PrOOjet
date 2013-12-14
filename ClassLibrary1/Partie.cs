using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wrapper;

namespace PrOOjet
{
    public class Partie : IPartie
    {
        private static IPartie instance;

        private IJoueur joueur1;
        private IJoueur joueur2;
        private ICarte carte;

        private Partie()
        {
            // TODO
            carte = new Carte(10);
        }

        private Partie(IJoueur j1, IJoueur j2, ICarte carte)
        {
            // TODO
            carte = new Carte(5);
        }

        public ICarte getCarte() { return carte; }

        public static IPartie INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new Partie();
                return instance;
            }
        }

        public IJoueur Joueur1 { get; set; }
        public IJoueur Joueur2 { get; set; }
        public ICarte Carte { get; set; }

        public List<IUnite> selectionneUnites(Coordonnees coord)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
