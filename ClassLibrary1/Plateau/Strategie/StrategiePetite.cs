using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public class StrategiePetite : StrategieTaille, IStrategiePetite
    {
        private const int TAILLE = 10;
        private const int NBTOURS = 20;
        private const int NBUNITES = 6;

        override public int Taille
        {
            get { return TAILLE; }
        }

        override public int NbTours
        {
            get { return NBTOURS; }
        }

        override public int NbUnites
        {
            get { return NBUNITES; }
        }
    }
}
