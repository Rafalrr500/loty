using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace ProjektTestyJednostkowe
{
    [TestClass]
    public class OsobaPrywatnaTestyJednostkowe
    {
        [TestMethod]
        public void TestKonstruktora()
        {
            string Imie = "Jan";
            string Nazwisko = "Kowalski";
            string Pesel = "1234";
            int Id = 1;

            OsobaPrywatna O = new OsobaPrywatna(Id,Imie,Nazwisko,Pesel);

            PrivateObject po = new PrivateObject(O);

            string imie = (string)po.GetField("Imie");
            string nazwisko = (string)po.GetField("Nazwisko");
            string pesel = (string)po.GetField("Pesel");
            int id = (int)po.GetField("Id");

            Assert.AreEqual(Imie, imie, "Niezgodnosc elementu imie");
            Assert.AreEqual(Nazwisko, nazwisko, "Niezgodnosc elementu nazwisko");
            Assert.AreEqual(Pesel, pesel, "Niezgodnosc elementu pesel");
            Assert.AreEqual(Id, id, "Niezgodnosc id");
        }

        [TestMethod]
        public void TestGetterow()
        {
            string Imie = "Jan";
            string Nazwisko = "Kowalski";
            string Pesel = "1234";
            int Id = 1;

            OsobaPrywatna O = new OsobaPrywatna(Id, Imie, Nazwisko, Pesel);

            Assert.AreEqual(Imie, O.getImie(), "Niezgodnosc elementu imie");
            Assert.AreEqual(Nazwisko, O.getNazwisko(), "Niezgodnosc elementu nazwisko");
            Assert.AreEqual(Pesel, O.getPesel(), "Niezgodnosc elementu pesel");
            Assert.AreEqual(Id, O.getId(), "Niezgodnosc id");
        }
    }
}
