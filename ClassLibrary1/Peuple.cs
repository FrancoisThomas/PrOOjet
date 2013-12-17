using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public abstract class Peuple : PrOOjet.IPeuple
    {
        public Peuple() {}

        public abstract IUnite creeUnite(IJoueur joueur);
    }
}
