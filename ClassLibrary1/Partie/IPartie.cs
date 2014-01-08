using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Interface de la partie. Gère le jeu.
	/// </summary>
    public interface IPartie
    {
        IJoueur Joueur1 { get; set; }
        IJoueur Joueur2 { get; set; }
        ICarte Carte { get; set; }
        int NbTours { get; set; }
		
		/// <summary>
		/// Sélectionne les unités aux coordonnées indiquées.
		/// </summary>
		/// <param name="coord"> Les coordonnées auxquelles on veut sélectionner les unités.
        List<IUnite> selectionneUnites(Coordonnees coord);
    }
}
