using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public class StrategieDemo : StrategieTaille, IStrategieDemo
    {
        private const int TAILLE = 5;
        private const int NBTOURS = 5;
        private const int NBUNITES = 4;

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
            get { return NbUnites; }
        }
    }
}
