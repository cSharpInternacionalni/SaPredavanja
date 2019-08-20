using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDBankomat;

namespace BankomatAppTests
{
    [TestClass]
    public class BankomatTests
    {
        [DataTestMethod]
        [DataRow(-200, 500)]
        [DataRow(0, 150)]
        [DataRow(50, 50)]
        [DataRow(-50, 50)]
        public void Depozit_PozIznos(int pocetnoStanje, uint depozit)
        {
            //Arrange
            int ocekivano = (int)(pocetnoStanje + depozit);
            Bankomat b = new Bankomat();
            b.Stanje = pocetnoStanje;

            //Act
            b.Depozit(depozit);

            //Assert
            Assert.AreEqual(ocekivano, b.Stanje);
        }

        [TestMethod]
        public void Depozit_Nula()
        {
            //Arrange
            Bankomat b = new Bankomat();

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => b.Depozit(0));
        }
    }
}
