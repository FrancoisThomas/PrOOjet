using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public abstract class Unite : PrOOjet.IUnite
    {
        protected const int PDVMAX = 2;
        protected const int PDMMAX = 2;
        protected const int DEFENSE = 1;
        protected const int ATTAQUE = 2;

        protected int pointsDeVie;
        protected int pointsDeMouvement;

        protected IJoueur joueur;

        protected Unite()
        {
            pointsDeVie = PDVMAX;
            pointsDeMouvement = PDMMAX;
        }

        protected Unite(IJoueur j)
        {
            pointsDeVie = PDVMAX;
            pointsDeMouvement = PDMMAX;
            joueur = j;
        }

        public int PointsDeMouvement
        {
            get
            {
                return pointsDeMouvement;
            }
            set
            {
                // TODO
            }
        }

        public int Attaque
        {
            get
            {
                return ATTAQUE * (pointsDeVie / PDVMAX);
            }
        }

        public int Defense
        {
            get
            {
                return DEFENSE * (pointsDeVie / PDVMAX);
            }
        }

        public int PointsDeVie
        {
            get
            {
                return pointsDeVie;
            }
            set
            {
                pointsDeVie = value;
            }
        }

        public IJoueur Joueur
        {
            get
            {
                return joueur;
            }
            set
            {
                joueur = value;
            }
        }

        public void diminuePointsDeMouvement(int v)
        {
            pointsDeMouvement -= v;
        }

        public void diminuePointsDeVie(int v)
        {
            pointsDeVie -= v;
        }

        public abstract bool peutBouger(ICase caseEntree);

        public bool estMort()
        {
            return pointsDeVie <= 0;
        }

    }
}
