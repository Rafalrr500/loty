using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace ProjektTestyJednostkowe
{
    [TestClass]
    public class LotniskoTestyJednostkowe
    {
        [TestMethod]
        public void TestKonstruktora()
        {
            string Miasto = "Warszawa";
            string Nazwa = "Okecie";
            int Id = 1;

            Lotnisko L = new Lotnisko(Miasto, Id, Nazwa);

            PrivateObject po = new PrivateObject(L);

            string miasto = (string)po.GetField("Miasto");
            string nazwa = (string)po.GetField("Nazwa");
            int id = (int)po.GetField("Id");

            Assert.AreEqual(Miasto, miasto, "Niezgodnosc elementu miasto");
            Assert.AreEqual(Nazwa, nazwa, "Niezgodnosc elementu nazwa");
            Assert.AreEqual(Id, id, "Niezgodnosc id");
        }

        [TestMethod]
        public void TestGetterow()
        {
            string Miasto = "Warszawa";
            string Nazwa = "Okecie";
            int Id = 1;

            Lotnisko L = new Lotnisko(Miasto, Id, Nazwa);

            Assert.AreEqual(Miasto, L.getMiasto(), "Niezgodnosc elementu miasto");
            Assert.AreEqual(Nazwa, L.getNazwa(), "Niezgodnosc elementu nazwa");
            Assert.AreEqual(Id, L.getId(), "Niezgodnosc id");
        }
    }
}
