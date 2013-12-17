using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public class Nain : Peuple, IPeupleNain
    {
        private static IPeupleNain instance;

        private Nain() {}

        public static IPeupleNain INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new Nain();
                return instance;
            }
        }

        public override IUnite creeUnite(IJoueur joueur)
        {
            return new UniteNain(joueur);
        }
    }
}
