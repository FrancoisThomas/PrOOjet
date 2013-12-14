using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public abstract class Peuple : PrOOjet.IPeuple
    {

        public Peuple() { throw new System.NotImplementedException(); }

        public Peuple(Joueur joueur)
        {
            throw new System.NotImplementedException();
        }
    
        public Joueur joueur
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public IUnite creeUnite()
        {
            throw new System.NotImplementedException();
        }
    }
}
