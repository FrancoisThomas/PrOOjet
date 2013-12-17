using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrOOjet
{
    public class Gaulois : Peuple, IPeupleGaulois
    {
        private static IPeupleGaulois instance;

        private Gaulois() {}

        public static IPeupleGaulois INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new Gaulois();
                return instance;
            }
        }

        public override IUnite creeUnite(IJoueur joueur)
        {
            return new UniteGaulois(joueur);
        }
    }
}
