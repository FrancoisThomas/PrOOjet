using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public interface IMonteurPartie
    {
        IPartie creerPartie(IPeuple peuple1, IPeuple peuple2, int tailleCarte);
    }
}
