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
        public void TestCreationPartieMonteur()
        {
            IStrategieTaille strat = new StrategieNormale();

            IPartie partie = MonteurPartie.INSTANCE.creerPartie(Gaulois.INSTANCE, Nain.INSTANCE, "j1", "j2" ,strat);
        }
    }
}
