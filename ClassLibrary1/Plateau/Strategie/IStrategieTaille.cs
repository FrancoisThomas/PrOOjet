using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public interface IStrategieTaille
    {
        int Taille { get; }
        int NbTours { get; }
        int NbUnites { get; }

        ICarte construitCarte();
    }
}
