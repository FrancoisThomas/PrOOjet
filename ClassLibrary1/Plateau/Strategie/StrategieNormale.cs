using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public class StrategieNormale : StrategieTaille, IStrategieNormale
    {
        private const int TAILLE = 15;
        private const int NBTOURS = 30;
        private const int NBUNITES = 8;

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
