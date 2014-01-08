using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet.Plateau.Strategie
{
    class StrategieDemo : IStrategieDemo
    {
        private const int TAILLE = 5;

        public ICarte construitCarte()
        {
            return new Carte(TAILLE);
        }
    }
}
