using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace ProjektTestyJednostkowe
{
    [TestClass]
    public class FirmaTestyJednostkowe
    {
        [TestMethod]
        public void TestKonstruktora()
        {
            string NazwaFirmy = "Firmaa";
            string NIP = "1234";
            int Id = 1;

            Firma F = new Firma(Id,NazwaFirmy,NIP);

            PrivateObject po = new PrivateObject(F);

            string nazwafirmy = (string)po.GetField("NazwaFirmy");
            string nip = (string)po.GetField("NIP");
            int id = (int)po.GetField("Id");

            Assert.AreEqual(NazwaFirmy, nazwafirmy, "Niezgodnosc elementu nazwa firmy");
            Assert.AreEqual(NIP, nip, "Niezgodnosc elementu nip");
            Assert.AreEqual(Id, id, "Niezgodnosc id");
        }

        [TestMethod]
        public void TestGetterow()
        {
            string NazwaFirmy = "Firmaa";
            string NIP = "1234";
            int Id = 1;

            Firma F = new Firma(Id, NazwaFirmy, NIP);

            Assert.AreEqual(NazwaFirmy, F.getNazwaFirmy(), "Niezgodnosc elementu nazwa firmy");
            Assert.AreEqual(NIP, F.getNIP(), "Niezgodnosc elementu nip");
            Assert.AreEqual(Id, F.getId(), "Niezgodnosc id");
        }
    }
}
