using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace ProjektTestyJednostkowe
{
    [TestClass]
    public class TrasaTestyJednostkowe
    {
        [TestMethod]
        public void TestKonstruktora()
        {
            double Dystans = 1000.5;
            int Czas = 120;
            int Id = 1;
            Lotnisko L1 = new Lotnisko();
            Lotnisko L2 = new Lotnisko();

            Trasa T = new Trasa(Id,Dystans,Czas,L1,L2);

            PrivateObject po = new PrivateObject(T);

            double dystans = (double)po.GetField("Dystans");
            int czas = (int)po.GetField("Czas");
            int id = (int)po.GetField("Id");
            Lotnisko l1 = (Lotnisko)po.GetField("lotnisko1");
            Lotnisko l2 = (Lotnisko)po.GetField("lotnisko2");

            Assert.AreEqual(Dystans, dystans, "Niezgodnosc elementu dystans");
            Assert.AreEqual(Czas, czas, "Niezgodnosc elementu czas");
            Assert.AreEqual(Id, id, "Niezgodnosc id");
            Assert.AreEqual(L1, l1, "Niezgodnosc elementu lotnisko1");
            Assert.AreEqual(L2, l2, "Niezgodnosc elementu lotnisko2");
        }

        [TestMethod]
        public void TestGetterow()
        {
            double Dystans = 1000.5;
            int Czas = 120;
            int Id = 1;
            Lotnisko L1 = new Lotnisko();
            Lotnisko L2 = new Lotnisko();

            Trasa T = new Trasa(Id, Dystans, Czas, L1, L2);

            Assert.AreEqual(Dystans, T.getDystans(), "Niezgodnosc elementu dystans");
            Assert.AreEqual(Czas, T.getCzas(), "Niezgodnosc elementu czas");
            Assert.AreEqual(Id, T.getId(), "Niezgodnosc id");
            Assert.AreEqual(L1, T.getLotnisko1(), "Niezgodnosc elementu lotnisko1");
            Assert.AreEqual(L2, T.getLotnisko2(), "Niezgodnosc elementu lotnisko2");
        }
    }
}
