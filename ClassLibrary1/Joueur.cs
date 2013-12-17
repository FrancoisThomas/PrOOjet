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
        private IPeuple peuple;
        private Dictionary<Coordonnees, List<IUnite>> unites;

        public Joueur(IPeuple p, int c, string n)
        {
            peuple = p;
            couleur = c;
            nom = n;
            unites = new Dictionary<Coordonnees, List<IUnite>>();
        }

        public Dictionary<Coordonnees, List<IUnite>> Unites
        {
            get
            {
                return unites;
            }
        }

        public List<IUnite> recupereUnites(Coordonnees coord)
        {
            return (coord != null && unites.ContainsKey(coord)) ? unites[coord] : null;
        }

        public void getCouleur()
        {
            throw new System.NotImplementedException();
        }

        public string getNom()
        {
            throw new System.NotImplementedException();
        }

        public IPeuple Peuple
        {
            get { return peuple; }
        }

        public void creeUnite(Coordonnees c)
        {
            IUnite u = peuple.creeUnite(this);

            if (!unites.ContainsKey(c))
            {
                List<IUnite> l = new List<IUnite>();
                l.Add(u);
                unites.Add(c, l);
            }
            else
            {
                List<IUnite> l = unites[c];
                l.Add(u);
            }
        }
    }
}
