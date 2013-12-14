using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public interface IPartie
    {
        IJoueur Joueur1 { get; set; }
        IJoueur Joueur2 { get; set; }
        ICarte Carte { get; set; }

        List<IUnite> selectionneUnites(Coordonnees coord);
    }
}
