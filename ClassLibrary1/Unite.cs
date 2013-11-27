using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public abstract class Unite : PrOOjet.IUnite
    {
        private int pointsDeVie;
        private int defense;
        private int attaque;
        private int pointsDeMouvement;

        public Unite(Joueur joueur)
        {
            throw new System.NotImplementedException();
        }

        public Joueur joueur
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void setPointsDeMouvement(ICase caseEntree)
        {
            throw new System.NotImplementedException();
        }

        public bool peutBouger(ICase caseEntree)
        {
            throw new System.NotImplementedException();
        }

        public void setPointsDeVie()
        {
            throw new System.NotImplementedException();
        }

        public Boolean estMort()
        {
            throw new System.NotImplementedException();
        }

        public int getPointsDeMouvement()
        {
            throw new System.NotImplementedException();
        }

        public int getAttaque()
        {
            throw new System.NotImplementedException();
        }

        public int getDefense()
        {
            throw new System.NotImplementedException();
        }

        public int getPointsDeVie()
        {
            throw new System.NotImplementedException();
        }
    }
}
