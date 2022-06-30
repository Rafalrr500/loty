using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace ProjektTestyJednostkowe
{
    [TestClass]
    public class LotTestyJednostkowe
    {
        [TestMethod]
        public void TestKonstruktora()
        {
            int Id = 1;
            Samolot S = new Regionalny();
            Trasa T = new Trasa();

            Lot L = new Lot(Id,S,T);

            PrivateObject po = new PrivateObject(L);

            int id = (int)po.GetField("Id");
            Samolot s = (Samolot)po.GetField("samolot");
            Trasa t = (Trasa)po.GetField("trasa");

            Assert.AreEqual(Id, id, "Niezgodnosc id");
            Assert.AreEqual(S, s, "Niezgodnosc elementu samolot");
            Assert.AreEqual(T, t, "Niezgodnosc elementu trasa");
        }

        [TestMethod]
        public void TestGetterow()
        {
            int Id = 1;
            Samolot S = new Regionalny();
            Trasa T = new Trasa();

            Lot L = new Lot(Id, S, T);

            Assert.AreEqual(Id, L.getId(), "Niezgodnosc id");
            Assert.AreEqual(S, L.getSamolot(), "Niezgodnosc elementu samolot");
            Assert.AreEqual(T, L.getTrasa(), "Niezgodnosc elementu trasa");
        }

        [TestMethod]
        public void TestMetodydodajRezerwacje()
        {
            int Id = 1;
            Samolot S = new Regionalny();
            Trasa T = new Trasa();
            Rezerwacja R = new Rezerwacja(1, new Firma());

            Lot L = new Lot(Id, S, T);
            L.dodajRezerwacje(R);

            Assert.AreEqual(Id, L.getId(), "Niezgodnosc id");
            Assert.AreEqual(S, L.getSamolot(), "Niezgodnosc elementu samolot");
            Assert.AreEqual(T, L.getTrasa(), "Niezgodnosc elementu trasa");
            Assert.AreEqual(1, L.getRezerwacja().Count, "Blad podczas dodawania");
        }

        [TestMethod]
        public void TestMetodyusunRezerwacje()
        {
            int Id = 1;
            Samolot S = new Regionalny();
            Trasa T = new Trasa();
            Rezerwacja R = new Rezerwacja(1, new Firma());

            Lot L = new Lot(Id, S, T);
            L.dodajRezerwacje(R);
            L.usunRezerwacje(R.getId());

            Assert.AreEqual(Id, L.getId(), "Niezgodnosc id");
            Assert.AreEqual(S, L.getSamolot(), "Niezgodnosc elementu samolot");
            Assert.AreEqual(T, L.getTrasa(), "Niezgodnosc elementu trasa");
            Assert.AreEqual(0, L.getRezerwacja().Count, "Blad podczas dodawania");
        }
    }
}
