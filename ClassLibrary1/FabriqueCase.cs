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
            throw new System.NotImplementedException();
        }
    
        public CaseMontagne montagne
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public CasePlaine plaine
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public CaseDesert desert
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public CaseEau eau
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public CaseForet foret
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private ICase creeCaseMontagne()
        {
            throw new System.NotImplementedException();
        }

        private ICase creeCasePlaine()
        {
            throw new System.NotImplementedException();
        }

        private ICase creeCaseDesert()
        {
            throw new System.NotImplementedException();
        }

        private ICase creeCaseEau()
        {
            throw new System.NotImplementedException();
        }

        private ICase creeCaseForet()
        {
            throw new System.NotImplementedException();
        }

        public ICase creeCase(string cle)
        {
            throw new System.NotImplementedException();
        }
    }
}
