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
        IJoueur JoueurActif { get; set; }
        ICarte Carte { get; set; }
        int NbTours { get; set; }
        int PointsJoueur1 { get; set; }
        int PointsJoueur2 { get; set; }

		
		/// <summary>
		/// Sélectionne les unités aux coordonnées indiquées.
		/// </summary>
		/// <param name="coord"> Les coordonnées auxquelles on veut sélectionner les unités. </param>
        List<IUnite> selectionneUnites(Coordonnees coord);

        /// <summary>
        /// Renvoi la liste des unités de la partie.
        /// </summary>
        Dictionary<Coordonnees, List<IUnite>> recupereUnites();

        /// <summary>
        /// Renvoi la carte annotée selons les deplacements possibles.
        /// </summary>
        List<int> suggereDeplacement(IUnite unite, Coordonnees pos);
    }
}
