using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public interface IPartie
    {
        List<IUnite> selectionneUnites(Coordonnees coord);
        ICarte getCarte();
    }
}
