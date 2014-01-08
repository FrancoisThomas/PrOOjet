using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet.Plateau.Strategie
{
    class StrategiePetite : StrategieTaille, IStrategiePetite
    {
        private const int TAILLE = 10;
        private const int NBTOURS = 20;
        private const int NBUNITES = 6;

        public int Taille
        {
            get { return TAILLE; }
        }

        public int NbTours
        {
            get { return NBTOURS; }
        }

        public int NbUnites
        {
            get { return NbUnites; }
        }
    }
}
