using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public class Joueur : PrOOjet.IJoueur
    {
        private string nom;
        private int couleur;

        public Joueur(Peuple peuple, int couleur, string nom)
        {
            throw new System.NotImplementedException();
        }
    
        public Peuple peuple
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Unite unites
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<IUnite> recupereUnites(Coordonnees coord)
        {
            throw new System.NotImplementedException();
        }

        public void getCouleur()
        {
            throw new System.NotImplementedException();
        }

        public string getNom()
        {
            throw new System.NotImplementedException();
        }

        public Peuple getPeuple()
        {
            throw new System.NotImplementedException();
        }
    }
}
