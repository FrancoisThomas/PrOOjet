using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wrapper;

namespace PrOOjet
{
    public class Partie : IPartie
    {

        private ICarte carte;

        public Partie()
        {
            // TODO
            carte = new Carte(10);
        }

        public Partie(IJoueur j1, IJoueur j2, ICarte carte)
        {
            // TODO
            carte = new Carte(5);
        }

        public ICarte getCarte() { return carte; }

        public Partie INSTANCE
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Joueur joueur1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Joueur joueur2
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<IUnite> selectionneUnites(Coordonnees coord)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
