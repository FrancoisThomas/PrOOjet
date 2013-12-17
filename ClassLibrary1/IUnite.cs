using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public interface IUnite
    {
        int PointsDeMouvement { get; set; }
        int Attaque { get; }
        int Defense { get; }
        int PointsDeVie { get; set; }

        bool peutBouger(ICase caseEntree);
        bool estMort();

        void diminuePointsDeVie(int v);
        void diminuePointsDeMouvement(int v);

    }
}
