using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet.Plateau.Strategie
{
    class StrategieNormale : StrategieTaille, IStrategieNormale
    {
        private const int TAILLE = 15;
        private const int NBTOURS = 30;
        private const int NBUNITES = 8;

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
