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
        public void TestRemplissageInstancePartie()
        {
            IPartie partie = Partie.INSTANCE;
            IStrategieTaille strat = new StrategieNormale();

            partie.Carte = strat.construitCarte();
            partie.Joueur1 = new Joueur(Gaulois.INSTANCE, "j1");
            partie.Joueur2 = new Joueur(Viking.INSTANCE, "j2");

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
            partie.Joueur1 = new Joueur(Gaulois.INSTANCE, "j1");
            partie.Joueur2 = new Joueur(Viking.INSTANCE, "j2");

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

        /*
        [TestMethod]
        public void TestPoints()
        {
            MonteurPartie.INSTANCE.creerPartie(Viking.INSTANCE,Nain.INSTANCE,"1","2",new StrategieDemo());
            Partie.INSTANCE.Carte = carteTest();
            Partie.INSTANCE.ajoutPoints(Partie.INSTANCE.Joueur1);
            Partie.INSTANCE.ajoutPoints(Partie.INSTANCE.Joueur2);

            MonteurPartie.INSTANCE.creerPartie(Gaulois.INSTANCE, Viking.INSTANCE, "1", "2", new StrategieDemo());
            Partie.INSTANCE.ajoutPoints(Partie.INSTANCE.Joueur1);
            Partie.INSTANCE.ajoutPoints(Partie.INSTANCE.Joueur2);

            MonteurPartie.INSTANCE.creerPartie(Nain.INSTANCE, Gaulois.INSTANCE, "1", "2", new StrategiePetite());
            Partie.INSTANCE.ajoutPoints(Partie.INSTANCE.Joueur1);
            Partie.INSTANCE.ajoutPoints(Partie.INSTANCE.Joueur2);
            
            // TODO
        }   

        [TestMethod]
        public void TestSuggestionsDeplacement()
        {
            MonteurPartie.INSTANCE.creerPartie(Viking.INSTANCE, Nain.INSTANCE, "1", "2", new StrategieNormale());
            List<IUnite> l;
            IUnite u;

            Partie.INSTANCE.Joueur1.Unites.TryGetValue(new Coordonnees(0, 0), out l);
            u = l.Find(x => x is IUniteViking);

            Partie.INSTANCE.suggereDeplacement(u, new Coordonnees(0, 0));
         
            // TODO
        }
        */

        [TestMethod]
        public void TestFinTour()
        {
            MonteurPartie.INSTANCE.creerPartie(Viking.INSTANCE, Nain.INSTANCE, "1", "2", new StrategieNormale());

            Partie.INSTANCE.finTour();

            Assert.AreEqual(Partie.INSTANCE.JoueurActif, Partie.INSTANCE.Joueur2);
            Assert.AreEqual(Partie.INSTANCE.NbTours, 1);

            Partie.INSTANCE.finTour();

            Assert.AreEqual(Partie.INSTANCE.JoueurActif, Partie.INSTANCE.Joueur1);
            Assert.AreEqual(Partie.INSTANCE.NbTours, 2);
        }
    }
}
