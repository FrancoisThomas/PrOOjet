using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrOOjet;

namespace tests
{
    [TestClass]
    public class TestJoueur
    {
        [TestMethod]
        public void TestCreationJoueur()
        {
            IJoueur joueur = new Joueur(Viking.INSTANCE, "J1");

            Assert.AreEqual(joueur.Peuple, Viking.INSTANCE);
            Assert.IsNotNull(joueur.Unites);
        }

        [TestMethod]
        public void TestAjoutUnite()
        {
            IPeuple viking = Viking.INSTANCE;
            IJoueur joueur = new Joueur(viking, "J1");

            for (int i = 0; i < 10; i++)
            {
                joueur.creeUnite(new Coordonnees(i%5, i%5));
                Console.WriteLine(joueur.recupereUnites(new Coordonnees(i%5, i%5)).Count);
            }

            Console.WriteLine(joueur.recupereUnites(new Coordonnees(0, 0)));

            Assert.IsNotNull(joueur.recupereUnites(new Coordonnees(2, 2)));

            foreach (List<IUnite> l in joueur.Unites.Values)
            {
                Console.WriteLine();
                foreach (IUnite u in l)
                {
                    Console.WriteLine(u);
                    Assert.IsTrue(u is IUniteViking);   
                }
            }
        }

        [TestMethod]
        public void TestManipulationUnites()
        {
            IJoueur joueur = new Joueur(Nain.INSTANCE, "J1");
            List<IUnite> l;
            IUnite u;

            for (int i = 0; i < 10; i++)
                joueur.creeUnite(new Coordonnees(0, 0));

            joueur.Unites.TryGetValue(new Coordonnees(0, 0), out l);
            u = l.Find(x => x is IUniteNain);

            joueur.deplaceUnite(u, new Coordonnees(0, 0), new Coordonnees(8, 4));
            Assert.IsTrue(joueur.Unites.TryGetValue(new Coordonnees(8, 4), out l));

            joueur.deplaceUnite(u, new Coordonnees(8, 4), new Coordonnees(0, 0));
            Assert.IsFalse(joueur.Unites.TryGetValue(new Coordonnees(8, 4), out l));

            joueur.Unites.TryGetValue(new Coordonnees(0, 0), out l);
            u = l.Find(x => x is IUniteNain);

            joueur.placeUniteEnFin(u);
            IUnite ubis = l.FindLast(x => x is IUniteNain);
            Assert.AreEqual(u, ubis);

            joueur.deplaceUnite(u, new Coordonnees(0, 0), new Coordonnees(8, 4));
            joueur.supprimeUnite(u);
            Assert.IsFalse(joueur.Unites.TryGetValue(new Coordonnees(8, 4), out l));
        }
    }
}
