using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public interface IJoueur
    {
        Dictionary<Coordonnees, List<IUnite>> Unites { get; }
        IPeuple Peuple { get; }

        List<IUnite> recupereUnites(Coordonnees coord);
        void creeUnite(Coordonnees c);
    }
}
