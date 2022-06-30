using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace ProjektTestyJednostkowe
{
    [TestClass]
    public class LiniaLotniczaTestyJednostkowe
    {
        [TestMethod]
        public void TestKonstruktora()
        {
            string NazwaLinii = "PLL LOT";

            LiniaLotnicza L = new LiniaLotnicza(NazwaLinii);

            PrivateObject po = new PrivateObject(L);

            string nazwalinii = (string)po.GetField("NazwaLinii");

            Assert.AreEqual(NazwaLinii, nazwalinii, "Niezgodnosc elementu nazwa linii");
        }

        [TestMethod]
        public void TestMetodygetNazwaLinii()
        {
            string NazwaLinii = "PLL LOT";

            LiniaLotnicza L = new LiniaLotnicza(NazwaLinii);

            Assert.AreEqual(NazwaLinii, L.getNazwaLinii(), "Niezgodnosc elementu nazwa linii");
        }

        [TestMethod]
        public void TestMetod_dodaj_get_czyZawiera()
        {
            string NazwaLinii = "PLL LOT";
            Samolot S = new Regionalny();
            Lot LL = new Lot();
            Klient K = new Firma();
            Trasa T = new Trasa();
            Lotnisko LLL = new Lotnisko();

            LiniaLotnicza L = new LiniaLotnicza(NazwaLinii);
            L.dodajSamolot(S);
            L.dodajLot(LL);
            L.dodajKlienta(K);
            L.dodajTrase(T);
            L.dodajLotnisko(LLL);

            Assert.AreEqual(1, L.getSamolot().Count, "Blad podczas dodawania samolotu");
            Assert.AreEqual(1, L.getLoty().Count, "Blad podczas dodawania lotu");
            Assert.AreEqual(1, L.getKlient().Count, "Blad podczas dodawania klienta");
            Assert.AreEqual(1, L.getTrasa().Count, "Blad podczas dodawania trasy");
            Assert.AreEqual(1, L.getLotnisko().Count, "Blad podczas dodawania lotniska");
            Assert.AreEqual(true, L.czyZawieraSamolot(S.getId()), "Niezgodnosc elementu samolot");
            Assert.AreEqual(true, L.czyZawieraLot(LL.getId()), "Niezgodnosc elementu lot");
            Assert.AreEqual(true, L.czyZawieraKlient(K.getId()), "Niezgodnosc elementu klient");
            Assert.AreEqual(true, L.czyZawieraTrasa(T.getId()), "Niezgodnosc elementu trasa");
            Assert.AreEqual(true, L.czyZawieraLotnisko(LLL.getId()), "Niezgodnosc elementu lotnisko");
        }
    }
}
