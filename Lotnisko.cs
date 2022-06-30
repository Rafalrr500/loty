using System;
using System.Text;
using System.Collections.Generic;

namespace Projekt
{
    public class Lotnisko
    {
        private string Miasto;
        private int Id;
        private string Nazwa;
        public Lotnisko()
        {
            this.Miasto = "Brak";
            this.Id=0;
            this.Nazwa = "Brak";
        }
        public Lotnisko(string Miasto,int Id,string Nazwa)
        {
            this.Miasto = Miasto;
            this.Id = Id;
            this.Nazwa = Nazwa;
        }
        public string getMiasto()
        {
            return this.Miasto;
        }
        public int getId()
        {
            return Id;
        }
        public string getNazwa()
        {
            return this.Nazwa;
        }
        public bool equals_(Object obj)
        {
            if (!(obj is Lotnisko)) return false;
            Lotnisko L = (Lotnisko)obj;
            if (Miasto.Equals(L.Miasto) && Id.Equals(L.Id) && Nazwa.Equals(L.Nazwa)) return true;
            return false;
        }
        public override string ToString()
        {
            return "     {Id: " + Id + "  Miasto: " + Miasto + "  Nazwa: " + Nazwa + "}";
        }
    }
}