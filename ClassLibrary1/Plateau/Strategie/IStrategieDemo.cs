using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public interface IStrategieDemo : IStrategieTaille, IStrategieDemo
    {
        private const int TAILLE = 5;
        private const int NBTOURS = 5;
        private const int NBUNITES = 4;

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
