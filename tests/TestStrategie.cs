using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrOOjet;

namespace tests
{
    [TestClass]
    public class TestStrategie
    {
        [TestMethod]
        public void TestCreationCarte()
        {
            IStrategieTaille strategie = new StrategieDemo();
            ICarte carte = strategie.construitCarte();

            foreach (ICase c in carte.Cases)
            {
                Console.WriteLine(c);
            }

            Assert.AreEqual(carte.Taille, strategie.Taille);
            Assert.AreEqual(strategie.Taille, 5);
            Assert.AreEqual(strategie.NbUnites, 4);
            Assert.AreEqual(strategie.NbTours, 5);
        }
    }
}
