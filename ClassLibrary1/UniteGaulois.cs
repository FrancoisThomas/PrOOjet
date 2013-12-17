using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public class UniteGaulois : Unite, IUniteGaulois
    {
        public UniteGaulois(IJoueur j) : base(j) {}

        public override bool peutBouger(ICase caseEntree)
        {
            return ((caseEntree.GetType() == typeof(ICasePlaine) && PointsDeMouvement > 0) || PointsDeMouvement > 1);
        }

    }
}
