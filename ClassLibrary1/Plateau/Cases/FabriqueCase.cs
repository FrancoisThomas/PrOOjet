using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
	/// <summary>
	/// Fabrique de <c>ICase</c>.
	/// </summary>
    public class FabriqueCase : PrOOjet.IFabriqueCase
    {
        private static IFabriqueCase instance;

        private CaseMontagne montagne;
        private CasePlaine plaine;
        private CaseDesert desert;
        private CaseEau eau;
        private CaseForet foret;

        private FabriqueCase() {}

        public static IFabriqueCase INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new FabriqueCase();
                return instance;
            }
        }

        public ICaseMontagne CaseMontagne
        {
            get
            {
                if (montagne == null)
                    montagne = new CaseMontagne();
                return montagne;
            }
        }

        public ICasePlaine CasePlaine
        {
            get
            {
                if (plaine == null)
                    plaine = new CasePlaine();
                return plaine;
            }
        }

        public ICaseDesert CaseDesert
        {
            get
            {
                if (desert == null)
                    desert = new CaseDesert();
                return desert;
            }
        }

        public ICaseEau CaseEau
        {
            get
            {
                if (eau == null)
                    eau = new CaseEau();
                return eau;
            }
        }

        public ICaseForet CaseForet
        {
            get
            {
                if (foret == null)
                    foret = new CaseForet();
                return foret;
            }
        }

		/// <summary>
		/// Fournit une case.
		/// </summary>
		/// <param name="cle"> Indique le type de case à fournir. </param>
		/// <returns> La case correspondant à la clé. </returns>
		/// <exception cref="ArgumentException"> Levée si la clé n'est pas valide. </exception>
        public ICase creeCase(string cle)
        {
            if (cle == "desert" || cle == "d")
                return FabriqueCase.INSTANCE.CaseDesert;
            if (cle == "eau" || cle == "e")
                return FabriqueCase.INSTANCE.CaseEau;
            if (cle == "montagne" || cle == "m")
                return FabriqueCase.INSTANCE.CaseMontagne;
            if (cle == "foret" || cle == "f")
                return FabriqueCase.INSTANCE.CaseForet;
            if (cle == "plaine" || cle == "p")
                return FabriqueCase.INSTANCE.CasePlaine;
            throw new System.ArgumentException();
        }
    }
}
