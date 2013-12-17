using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public class Viking : Peuple, IPeupleViking
    {
        private static IPeupleViking instance;

        private Viking() {}

        public static IPeupleViking INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new Viking();
                return instance;
            }
        }

        public override IUnite creeUnite(IJoueur joueur)
        {
            return new UniteViking(joueur);
        }

    }
}
