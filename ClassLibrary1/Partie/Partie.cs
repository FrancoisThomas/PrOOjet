using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using wrapper;

namespace PrOOjet
{
	/// <summary>
	/// Classe représentant la partie. Gère le jeu.
	/// </summary>
    [Serializable]
    public class Partie : IPartie
    {
        private static IPartie instance;

        /// <summary> Joueur 1. </summary>
        private IJoueur joueur1;

        /// <summary> Joueur 2. </summary>
        private IJoueur joueur2;

        /// <summary> Joueur en train de jouer. </summary>
        private IJoueur joueurActif;

        /// <summary> La carte du jeu. </summary>
        private ICarte carte;

        /// <summary> Le nombre de tours. </summary>
        private int nbToursMax;

        /// <summary> Le nombre de tours. </summary>
        private int nbTours;

        /// <summary> Le nombre de points du Joueur 1. </summary>
        private int pointsJoueur1;

        /// <summary> Le nombre de points du Joueur 2. </summary>
        private int pointsJoueur2;

        
        /// <summary> Joueur en attente. </summary>
        public IJoueur JoueurNonActif { get { return joueurActif == joueur1 ? joueur2 : joueur1; } }

        private Partie() {}

        public static IPartie INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new Partie();
                return instance;
            }
        }

        public IJoueur Joueur1
        {
            get { return joueur1; }
            set { joueur1 = value; }
        }

        public IJoueur Joueur2
        {
            get { return joueur2; }
            set { joueur2 = value; }
        }

        public IJoueur JoueurActif
        {
            get { return joueurActif; }
            set { joueurActif = value; }
        }

        public ICarte Carte 
        {
            get { return carte; }
            set { carte = value; }
        }

        public int NbToursMax
        {
            get { return nbToursMax; }
            set { nbToursMax = value; }
        }

        public int NbTours
        {
            get { return nbTours; }
            set { nbTours = value; }
        }

        public int PointsJoueur1
        {
            get { return pointsJoueur1; }
            set { pointsJoueur1 = value; }
        }

        public int PointsJoueur2
        {
            get { return pointsJoueur2; }
            set { pointsJoueur2 = value; }
        }

        /// <summary>
		/// Sélectionne les unités aux coordonnées indiquées.
		/// </summary>
		/// <param name="coord"> Les coordonnées auxquelles on veut sélectionner les unités. </param>
		/// <returns> Renvoie la liste des unités aux coordonnées indiquées (null si il n'y en a pas). </returns>
        public List<IUnite> selectionneUnites(Coordonnees coord)
        {
            List<IUnite> unites = joueurActif.recupereUnites(coord);

            if (unites == null)
                unites = JoueurNonActif.recupereUnites(coord);

            return unites;
        }

        /// <summary>
        /// Sélectionne l'unité aux coordonnées indiquées ayant le plus de défense.
        /// </summary>
        /// <param name="coord"> Les coordonnées auxquelles on veut sélectionner l'unité. </param>
        /// <returns> Renvoie l'unité aux coordonnées indiquées ayant le plus de défense (null si il n'y en a pas). </returns>
        public IUnite selectionneUniteDefensive(Coordonnees coord)
        {
            List<IUnite> unites = JoueurNonActif.recupereUnites(coord);
            IUnite res = null;
            if (unites != null)
            {
                res = unites.ElementAt(0);
                foreach (IUnite u in unites)
                {
                    if (u.Defense > res.Defense)
                        res = u;
                }
            }
            return res;
        }

        /// <summary>
        /// Renvoie le dictionnaire des unités de la partie, avec leurs coordonees.
        /// </summary>
        public Dictionary<Coordonnees, List<IUnite>> recupereUnites()
        {
            Dictionary<Coordonnees, List<IUnite>> unit1 = joueur1.Unites;
            Dictionary<Coordonnees, List<IUnite>> unit2 = joueur2.Unites;
            
            return unit1.Concat(unit2).GroupBy(d => d.Key)
                        .ToDictionary(k => k.Key, v => v.First().Value.Union(v.Last().Value).ToList());
        }

        /// <summary>
        /// Renvoie la carte annotée selons les deplacements possibles.
        /// </summary>
        public List<int> suggereDeplacement(IUnite unite, Coordonnees pos)
        {
            List<int> carteAnnotee = new List<int>();
            WrapperCarte wrap = new WrapperCarte();

            int posUnite = pos.posX * carte.Taille + pos.posY;

            // Liste carteInt représentant la carte sous forme d'entiers.
            List<int> carteInt = new List<int>();
            foreach (ICase c in carte.Cases)
	        {
		        if (c is ICaseDesert)
                    carteInt.Add((int)ECase.DESERT);
                if (c is ICaseEau)
                    carteInt.Add((int)ECase.EAU);
                if (c is ICaseMontagne)
                    carteInt.Add((int)ECase.MONTAGNE);
                if (c is ICaseForet)
                    carteInt.Add((int)ECase.FORET);
                if (c is ICasePlaine)
                    carteInt.Add((int)ECase.PLAINE);
	        }

            // Dictionnary ennemis représentant la position des ennemis sous forme (position -> nombre d'ennemis).
            Dictionary<int, int> ennemis = new Dictionary<int,int>();
            IJoueur j = unite.Joueur == joueurActif ? JoueurNonActif : joueurActif;

            for (int i = 0; i < j.Unites.Count; i++)
			{
			    Coordonnees c = j.Unites.Keys.ElementAt(i);
                ennemis.Add(c.posX + c.posY * carte.Taille, j.Unites.Values.ElementAt(i).Count);
			}

            // Appel aux méthodes dédiées de la librairie
            if (unite is IUniteGaulois)
                carteAnnotee = wrap.suggestionDeplacementGaulois(posUnite, carteInt, carte.Taille, ennemis);  
            if (unite is IUniteNain)
                carteAnnotee = wrap.suggestionDeplacementNain(posUnite, carteInt, carte.Taille, ennemis);
            if (unite is IUniteViking)
                carteAnnotee = wrap.suggestionDeplacementViking(posUnite, carteInt, carte.Taille, ennemis);

            return carteAnnotee;
        }

        /// <summary>
        /// Déplace une unité du joueur actif.
        /// </summary>
        /// <param name="unite"> L'unité à déplacer. </param>
        /// <param name="ancienneCoord"> Les anciennes coordonnées. </param>
        /// <param name="nouvelleCoord"> Les nouvelles coordonnées. </param>
        public void deplaceUnite(IUnite unite, Coordonnees ancienneCoord, Coordonnees nouvelleCoord)
        {
            joueurActif.deplaceUnite(unite, ancienneCoord, nouvelleCoord);
        }

        /// <summary>
        /// Méthode de combat.
        /// </summary>
        /// <param name="attaquant">Unité attaquante.</param>
        /// <param name="defenseur">Unité défendante.</param>
        /// <returns><c>true</c> si le défenseur est mort.</returns>
        public bool attaque(IUnite attaquant, IUnite defenseur)
        {
            WrapperCombat wrap = new WrapperCombat();
            wrap.combattre(attaquant.PointsDeVie, 
                           attaquant.PointsDeVieMax, 
                           defenseur.PointsDeVie, 
                           defenseur.PointsDeVieMax,
                           attaquant.Attaque,
                           defenseur.Defense);

            // Test si les unités sont toujours en vie.
            if (wrap.getVieAttaquant() > 0)
            {
                attaquant.PointsDeVie = wrap.getVieAttaquant();
                joueurActif.placeUniteEnFin(attaquant);
            }
            else
                joueurActif.supprimeUnite(attaquant);

            if (wrap.getVieDefenseur() > 0)
            {
                defenseur.PointsDeVie = wrap.getVieDefenseur();
                JoueurNonActif.placeUniteEnFin(defenseur);
            }
            else
            {
                Console.WriteLine(defenseur);
                JoueurNonActif.supprimeUnite(defenseur);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gère la fin de tour d'un joueur. Ajoute les points du tour à ceux du joueur actif.
        /// Si le joueur est Joueur2, incrémente le nombre de tours.
        /// </summary>
        public void finTour()
        {
            if (joueurActif == joueur2)
                nbTours++;

            // Remet des points de mouvements aux unités aant bougées.
            Dictionary<Coordonnees, List<IUnite>> d = recupereUnites();
            foreach (List<IUnite> l in d.Values)
                foreach (IUnite unit in l)
                    unit.reinitialiseMouvement();

            ajoutPoints(joueurActif);
            joueurActif = JoueurNonActif;
        }

        /// <summary>
        /// Determine si la partie est terminée.
        /// </summary>
        /// <returns><c>true</c> si la partie est terminée.</returns>
        public bool terminee()
        {
            return NbTours > NbToursMax;
        }

        /// <summary>
        /// Ajoute les points du tour à un joueur.
        /// </summary>
        /// <param name="j">Le joueur auquel on ajoute des points</param>
        public void ajoutPoints(IJoueur j)
        {
            WrapperCarte wrap = new WrapperCarte();

            // Liste carteInt représentant la carte sous forme d'entiers.
            List<int> carteInt = new List<int>();
            foreach (ICase c in carte.Cases)
            {
                if (c is ICaseDesert)
                    carteInt.Add((int)ECase.DESERT);
                if (c is ICaseEau)
                    carteInt.Add((int)ECase.EAU);
                if (c is ICaseMontagne)
                    carteInt.Add((int)ECase.MONTAGNE);
                if (c is ICaseForet)
                    carteInt.Add((int)ECase.FORET);
                if (c is ICasePlaine)
                    carteInt.Add((int)ECase.PLAINE);
            }

            Dictionary<int, int> unites = new Dictionary<int, int>();

            for (int i = 0; i < j.Unites.Count; i++)
            {
                Coordonnees c = j.Unites.Keys.ElementAt(i);
                unites.Add(c.posX + c.posY * carte.Taille, j.Unites.Values.ElementAt(i).Count);
            }


            // Ajout des points au bon joueur en fonction de son peuple.
            if (j.Peuple is IPeupleGaulois)
            {
                if (j == joueur1)
                    pointsJoueur1 += wrap.pointsTourGaulois(carteInt, carte.Taille, unites);
                else
                    PointsJoueur2 += wrap.pointsTourGaulois(carteInt, carte.Taille, unites);
            }
            if (j.Peuple is IPeupleNain)
            {
                if (j == joueur1)
                    pointsJoueur1 += wrap.pointsTourNain(carteInt, carte.Taille, unites);
                else
                    PointsJoueur2 += wrap.pointsTourNain(carteInt, carte.Taille, unites);
            }
            if (j.Peuple is IPeupleViking)
            {
                if (j == joueur1)
                    pointsJoueur1 += wrap.pointsTourViking(carteInt, carte.Taille, unites);
                else
                    PointsJoueur2 += wrap.pointsTourViking(carteInt, carte.Taille, unites);
            }
        }

        public void sauvegarder(string nomFichier)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream flux = null;
            try
            {
                //On ouvre le flux en mode création / écrasement de fichier et on
                //donne au flux le droit en écriture seulement.
                flux = new FileStream(nomFichier, FileMode.Create, FileAccess.Write);
                //Et hop ! On sérialise !
                formatter.Serialize(flux, this);
                //On s'assure que le tout soit écrit dans le fichier.
                flux.Flush();
                Console.WriteLine("sauvegarde réussie.");
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            {
                //Et on ferme le flux.
                if (flux != null)
                    flux.Close();
            }
        }

        public static void charger(string nomFichier)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            
            try
            {
                //On ouvre le fichier en mode lecture seule. De plus, puisqu'on a sélectionné le mode Open,
                //si le fichier n'existe pas, une exception sera levée.
                flux = new FileStream(nomFichier, FileMode.Open, FileAccess.Read);
                instance = (Partie)formatter.Deserialize(flux);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (flux != null)
                    flux.Close();
            }
        }
    }
}
