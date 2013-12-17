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

        private IJoueur joueurActif;
        private IJoueur joueurNonActif { get { return joueurActif == joueur1 ? joueur2 : joueur1; } }

        private Partie()
        {
            // TODO
            carte = new Carte(8);
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

        public IJoueur Joueur1
        {
            get { return joueur1; }
            set { joueur1 = value; }
        }

        public IJoueur Joueur2
        {
            get { return joueur2; }
            set { joueur2 = value; }
        }

        public ICarte Carte 
        {
            get
            {
                return carte;
            }
            set
            {
                carte = value;
            }
        }

        public List<IUnite> selectionneUnites(Coordonnees coord)
        {
            List<IUnite> unites = joueurActif.recupereUnites(coord);

            if (unites == null)
                unites = joueurNonActif.recupereUnites(coord);

            return unites;

        }

        
    }
}
