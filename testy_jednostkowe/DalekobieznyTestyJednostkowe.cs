using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace ProjektTestyJednostkowe
{
    [TestClass]
    public class DalekobieznyTestyJednostkowe
    {
        [TestMethod]
        public void TestKonstruktora()
        {
            double Zasieg = 1000.5;
            int LiczbaMiejsc = 120;
            int Id = 1;

            Dalekobiezny D = new Dalekobiezny(Zasieg, Id, LiczbaMiejsc);

            PrivateObject po = new PrivateObject(D);

            double zasieg = (double)po.GetField("Zasieg");
            int liczbamiejsc = (int)po.GetField("LiczbaMiejsc");
            int id = (int)po.GetField("Id");

            Assert.AreEqual(Zasieg, zasieg, "Niezgodnosc elementu zasieg");
            Assert.AreEqual(LiczbaMiejsc, liczbamiejsc, "Niezgodnosc elementu liczba miejsc");
            Assert.AreEqual(Id, id, "Niezgodnosc id");
        }

        [TestMethod]
        public void TestGetterow()
        {
            double Zasieg = 1000.5;
            int LiczbaMiejsc = 120;
            int Id = 1;

            Dalekobiezny D = new Dalekobiezny(Zasieg, Id, LiczbaMiejsc);

            Assert.AreEqual(Zasieg, D.getZasieg(), "Niezgodnosc elementu zasieg");
            Assert.AreEqual(LiczbaMiejsc, D.getLiczbaMiejsc(), "Niezgodnosc elementu liczba miejsc");
            Assert.AreEqual(Id, D.getId(), "Niezgodnosc id");
        }
    }
}
