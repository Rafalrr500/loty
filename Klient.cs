using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
  public abstract class Klient
    {
        protected int Id=0;
        
        public Klient(int Id)
        {
            this.Id = Id;
        }
        public Klient()
        {
            this.Id = 0;
        }
        public int getId()
        {
            return Id;
        }
        public override string ToString()
        {
            return "";
        }
    }
    public class OsobaPrywatna : Klient
    {
        protected string Imie;
        protected string Nazwisko;
        protected string Pesel;
        public OsobaPrywatna() : base()
        {
            this.Imie = "Brak";
            this.Nazwisko = "Brak";
            this.Pesel = "0";
        }
        public OsobaPrywatna(int Id, string Imie, string Nazwisko, string Pesel) :base(Id)
        {
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
            this.Pesel = Pesel;
        }
        public string getImie()
        {
            return Imie;
        }
        public string getNazwisko()
        {
            return Nazwisko;
        }
        public string getPesel()
        {
            return Pesel;
        }
        public override string ToString()
        {
            return "   Osoba prywatna: {Id: " + this.getId() + "  Imie: " + this.getImie() + "  Nazwisko: " + this.getNazwisko() + "  Pesel: " + this.getPesel() + "}";
        }
    }
    public class Firma : Klient
    {
        protected string NazwaFirmy;
        protected string NIP;
        public Firma()
        {
            this.NazwaFirmy = "Brak";
            this.NIP = "0";
        }
        public Firma(int Id, string NazwaFirmy, string NIP) : base(Id)
        {
            this.NazwaFirmy = NazwaFirmy;
            this.NIP = NIP;
        }
        public string getNazwaFirmy()
        {
            return NazwaFirmy;
        }
        public string getNIP()
        {
            return NIP;
        }
        public override string ToString()
        {
            return "   Firma: {Id: " + this.getId() + "  Nazwa firmy: " + this.getNazwaFirmy() + "  Pesel: " + this.getNIP() + "}";
        }
    }
}
