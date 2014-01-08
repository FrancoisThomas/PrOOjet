using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrOOjet;

namespace tests
{
    [TestClass]
    public class TestMonteur
    {
        [TestMethod]
        public void TestCreationMonteur()
        {
            IMonteurPartie monteur = MonteurPartie.INSTANCE;
            IMonteurPartie monteur2 = MonteurPartie.INSTANCE;

            Assert.AreEqual(monteur, monteur2);
        }

        [TestMethod]
        public void TestCreationPartie()
        {
            IPeuple nain = Nain.INSTANCE;
            IPeuple viking = Viking.INSTANCE;
            IStrategieTaille taille = new StrategieDemo();

            IPartie partie = MonteurPartie.INSTANCE.creerPartie(nain, viking, taille);

            //Assert.AreEqual(partie.Carte.Taille, taille.Taille);
        }
    }
}
