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
            IPeuple viking = Viking.INSTANCE;
            IJoueur joueur = new Joueur(viking, 0, "J1");

            Assert.AreEqual(joueur.Peuple, viking);
            Assert.IsNotNull(joueur.Unites);
        }

        [TestMethod]
        public void TestAjoutUnite()
        {
            IPeuple viking = Viking.INSTANCE;
            IJoueur joueur = new Joueur(viking, 0, "J1");

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
    }
}
