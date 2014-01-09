using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrOOjet;

namespace tests
{
    [TestClass]
    public class TestPartie
    {
        [TestMethod]
        public void TestInstanceVidePartie()
        {
            IPartie partie = Partie.INSTANCE;

            Console.WriteLine(partie.Carte);
            Console.WriteLine(partie.Joueur1);
            Console.WriteLine(partie.Joueur2);

            Assert.IsNull(partie.Carte);            
            Assert.IsNull(partie.Joueur1);           
            Assert.IsNull(partie.Joueur2);
        }

        [TestMethod]
        public void TestRemplissageInstancePartie()
        {
            IPartie partie = Partie.INSTANCE;
            IStrategieTaille strat = new StrategieNormale();

            partie.Carte = strat.construitCarte();
            partie.Joueur1 = new Joueur(Gaulois.INSTANCE, 0, "j1");
            partie.Joueur2 = new Joueur(Viking.INSTANCE, 2, "j2");

            Console.WriteLine(partie.Carte);
            Assert.IsNotNull(partie.Carte);

            Console.WriteLine(partie.Joueur1);
            Assert.IsNotNull(partie.Joueur1);

            Console.WriteLine(partie.Joueur2);
            Assert.IsNotNull(partie.Joueur2);
        }

        [TestMethod]
        public void TestRecuperationUnites()
        {
            IPartie partie = Partie.INSTANCE;
            IStrategieTaille strat = new StrategieNormale();

            partie.Carte = strat.construitCarte();
            partie.Joueur1 = new Joueur(Gaulois.INSTANCE, 0, "j1");
            partie.Joueur2 = new Joueur(Viking.INSTANCE, 2, "j2");

            for (int i = 0; i < 2; i++)
            {
                partie.Joueur1.creeUnite(new Coordonnees(0, 0));
                partie.Joueur2.creeUnite(new Coordonnees(i, 0));
            }

            Dictionary<Coordonnees, List<IUnite>> u1 = partie.recupereUnites();

            Console.WriteLine(u1.Count);

            foreach (List<IUnite> l in u1.Values)
            {
                foreach (IUnite u in l)
                {
                    Console.WriteLine(u);
                }
            }
        }
    }
}
