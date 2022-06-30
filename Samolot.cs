using System;
using System.Text;
using System.Collections.Generic;

namespace Projekt
{
    public abstract class Samolot 
    { 
        protected double Zasieg;
        protected int Id;
        protected int LiczbaMiejsc;
        public Samolot()
        {
            this.Zasieg = 0.0;
            this.Id = 0;
            this.LiczbaMiejsc = 0;
        }
        public Samolot(double Zasieg,int Id,int LiczbaMiejsc)
        {
            if (Zasieg <= 0 || LiczbaMiejsc <= 0) throw new NiedodatnieException("Podano wartosc niedodatnia.");
            this.Zasieg = Zasieg;
            this.Id = Id;
            this.LiczbaMiejsc = LiczbaMiejsc;
        }
        public double getZasieg()
        {
            return this.Zasieg;
        }
        public int getId()
        {
            return this.Id;
        }
        public int getLiczbaMiejsc()
        {
            return this.LiczbaMiejsc;
        }
        public override string ToString()
        {
            return "   {Zasieg: " + Zasieg + "  Id: " + Id + "  Liczba miejsc: " + LiczbaMiejsc + "}";
        }
    }
    public class Dalekobiezny : Samolot
    {
        public Dalekobiezny() : base() { }
        public Dalekobiezny(double Zasieg, int Id, int LiczbaMiejsc) : base(Zasieg,Id,LiczbaMiejsc) 
        {
        }
    }
    public class Regionalny : Samolot
    {
        public Regionalny() : base() { }
        public Regionalny(double Zasieg, int Id, int LiczbaMiejsc) : base(Zasieg, Id, LiczbaMiejsc) 
        {
        }
    }
}