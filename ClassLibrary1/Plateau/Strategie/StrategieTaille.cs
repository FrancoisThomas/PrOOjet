using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet.Plateau.Strategie
{
    abstract class StrategieTaille : IStrategieTaille
    {
        int Taille { get; }
        int NbTours { get; }
        int NbUnites { get; }

        public ICarte construitCarte()
        {
            return new Carte(Taille);
        }
    }
}
