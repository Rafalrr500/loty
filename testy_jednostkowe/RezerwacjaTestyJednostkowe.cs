using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace ProjektTestyJednostkowe
{
    [TestClass]
    public class RezerwacjaTestyJednostkowe
    {
        [TestMethod]
        public void TestKonstruktora()
        {
            int Id = 1;
            Klient K = new OsobaPrywatna();

            Rezerwacja R = new Rezerwacja(Id,K);

            PrivateObject po = new PrivateObject(R);

            int id = (int)po.GetField("Id");
            Klient k = (Klient)po.GetField("klient");


            Assert.AreEqual(Id, id, "Niezgodnosc id");
            Assert.AreEqual(K, k, "Niezgodnosc elementu klient");
        }

        [TestMethod]
        public void TestGetterow()
        {
            int Id = 1;
            Klient K = new OsobaPrywatna();

            Rezerwacja R = new Rezerwacja(Id, K);

            Assert.AreEqual(Id, R.getId(), "Niezgodnosc id");
            Assert.AreEqual(K, R.getKlient(), "Niezgodnosc elementu klient");
        }
    }
}
