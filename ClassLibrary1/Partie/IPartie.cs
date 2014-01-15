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
        IJoueur JoueurNonActif { get; }
        ICarte Carte { get; set; }
        int NbToursMax{ get; set; }
        int NbTours { get; set; }
        int PointsJoueur1 { get; set; }
        int PointsJoueur2 { get; set; }

		
		/// <summary>
		/// Sélectionne les unités aux coordonnées indiquées.
		/// </summary>
		/// <param name="coord"> Les coordonnées auxquelles on veut sélectionner les unités. </param>
        List<IUnite> selectionneUnites(Coordonnees coord);

        IUnite selectionneUniteDefensive(Coordonnees coord);

        /// <summary>
        /// Renvoi la liste des unités de la partie.
        /// </summary>
        Dictionary<Coordonnees, List<IUnite>> recupereUnites();

        /// <summary>
        /// Renvoi la carte annotée selons les deplacements possibles.
        /// </summary>
        List<int> suggereDeplacement(IUnite unite, Coordonnees pos);

        /// <summary>
        /// Déplace une unité du joueur actif.
        /// </summary>
        /// <param name="unite"> L'unité à déplacer. </param>
        /// <param name="ancienneCoord"> Les anciennes coordonnées. </param>
        /// <param name="nouvelleCoord"> Les nouvelles coordonnées. </param>
        void deplaceUnite(IUnite unite, Coordonnees ancienneCoord, Coordonnees nouvelleCoord);

        bool attaque(IUnite attaquant, IUnite defenseur);

        void finTour();

        void ajoutPoints(IJoueur j);

        bool terminee();

        void sauvegarder(string nomFichier);
    }
}
