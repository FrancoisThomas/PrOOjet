using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Interface d'un joueur.
	/// </summary>
    public interface IJoueur
    {
    	/// <summary>
    	/// Dictionnaire des unités du joueur.
    	/// Clés : Coordonnées de la case sur laquelle sont les unités.
    	/// Valeurs : Liste d'unités sur la case aux coordonnées clés.
    	/// </summary>
        Dictionary<Coordonnees, List<IUnite>> Unites { get; }
        /// <summary> Peuple choisi par le joueur. </summary>
        IPeuple Peuple { get; }

		/// <summary>
		/// Fournit la liste des unités sur la case aux coordonnées passées en paramètre.
		/// </summary>
		/// <param name="coord"> Coordonnées des unités à récuperer. </param>
		/// <returns> La liste des unités sur la case, <c>null</c> si il n'y en a aucune. </returns>
        List<IUnite> recupereUnites(Coordonnees coord);
        
        /// <summary>
		/// Ajoute une nouvelle unité aux coordonnées en paramètre.
		/// </summary>
		/// <remarks> L'unité appartient au peuple du joueur. </remarks>
		/// <remarks> Si il y a déja une ou des unité(s) aux coordonnées, l'unité est ajoutée à la liste. </remarks>
		/// <param name="c"> Coordonnées auxquels ajouter l'unité. </param>
        void creeUnite(Coordonnees c);

        /// <summary>
        /// Déplace une unité.
        /// </summary>
        /// <param name="unite"> L'unité à déplacer. </param>
        /// <param name="ancienneCoord"> Les anciennes coordonnées. </param>
        /// <param name="nouvelleCoord"> Les nouvelles coordonnées. </param>
        void deplaceUnite(IUnite unite, Coordonnees ancienneCoord, Coordonnees nouvelleCoord);

        /// <summary>
        /// Supprime une unité.
        /// </summary>
        /// <param name="unite"> L'unité à supprimer. </param>
        void supprimeUnite(IUnite unite);
    }
}
