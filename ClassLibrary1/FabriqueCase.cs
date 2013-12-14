using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public class FabriqueCase : PrOOjet.IFabriqueCase
    {
        public FabriqueCase()
        {
        }
    
        public CaseMontagne montagne;
        public CasePlaine plaine;
        public CaseDesert desert;
        public CaseEau eau;
        public CaseForet foret;
       

        public ICaseMontagne creeCaseMontagne()
        {
            if (montagne == null)
                montagne = new CaseMontagne();
            return montagne;
        }

        public ICasePlaine creeCasePlaine()
        {
            if (plaine == null)
                plaine = new CasePlaine();
            return plaine;
        }

        public ICaseDesert creeCaseDesert()
        {
            if (desert == null)
                desert = new CaseDesert();
            return desert;
        }

        public ICaseEau creeCaseEau()
        {
            if (eau == null)
                eau = new CaseEau();
            return eau;
        }

        public ICaseForet creeCaseForet()
        {
            if (foret == null)
                foret = new CaseForet();
            return foret;
        }

        public ICase creeCase(string cle)
        {
            if (cle == "desert" || cle == "d")
                return creeCaseDesert();
            if (cle == "eau" || cle == "e")
                return creeCaseEau();
            if (cle == "montagne" || cle == "m")
                return creeCaseMontagne();
            if (cle == "foret" || cle == "f")
                return creeCaseForet();
            if (cle == "plaine" || cle == "p")
                return creeCasePlaine();
            throw new System.ArgumentException();
        }
    }
}
