using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace ProjektTestyJednostkowe
{
    [TestClass]
    public class RegionalnyTestyJednostkowe
    {
        [TestMethod]
        public void TestKonstruktora()
        {
            double Zasieg = 1000.5;
            int LiczbaMiejsc = 120;
            int Id = 1;

            Regionalny R = new Regionalny(Zasieg, Id, LiczbaMiejsc);

            PrivateObject po = new PrivateObject(R);

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

            Regionalny R = new Regionalny(Zasieg, Id, LiczbaMiejsc);

            Assert.AreEqual(Zasieg, R.getZasieg(), "Niezgodnosc elementu zasieg");
            Assert.AreEqual(LiczbaMiejsc, R.getLiczbaMiejsc(), "Niezgodnosc elementu liczba miejsc");
            Assert.AreEqual(Id, R.getId(), "Niezgodnosc id");
        }
    }
}
