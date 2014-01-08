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
        }
    }
}
