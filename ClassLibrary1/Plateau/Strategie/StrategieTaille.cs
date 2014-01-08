using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public abstract class StrategieTaille : IStrategieTaille
    {
        public abstract int Taille { get; }
        public abstract int NbTours { get; }
        public abstract int NbUnites { get; }

        public ICarte construitCarte()
        {
            return new Carte(Taille);
        }
    }
}
