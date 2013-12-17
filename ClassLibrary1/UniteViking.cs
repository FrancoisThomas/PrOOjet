using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public class UniteViking : Unite, IUniteViking
    {
        public UniteViking(IJoueur j) : base(j) {}

        public override bool peutBouger(ICase caseEntree)
        {
            return (PointsDeMouvement > 1);
        }
    }
}
