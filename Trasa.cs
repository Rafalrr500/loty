using System;
using System.Text;
using System.Collections.Generic;

namespace Projekt
{
    public class Trasa
    {
        private double Dystans;
        private Lotnisko lotnisko1;
        private Lotnisko lotnisko2;
        private int Czas;
        private int Id;
        public Trasa()
        {
            this.Dystans = 0.0;
            this.Czas = 0;
            this.Id = 0;
        }
        public Trasa(int Id, double Dystans, int Czas, Lotnisko lotnisko1, Lotnisko lotnisko2)
        {
            if (Dystans <= 0 || Czas <= 0) throw new NiedodatnieException("Podano wartosc niedodatnia.");
            this.lotnisko1 = lotnisko1;
            this.lotnisko2 = lotnisko2;
            this.Dystans = Dystans;
            this.Czas = Czas;
            this.Id = Id;
        }
        public double getDystans()
        {
            return this.Dystans;
        }
        public int getCzas()
        {
            return this.Czas;
        }
        public Lotnisko getLotnisko1()
        {
            return lotnisko1;
        }
        public Lotnisko getLotnisko2()
        {
            return lotnisko2;
        }
        public int getId()
        {
            return Id;
        }
        public override string ToString()
        {
            String napis = new String("\n    Id: " + this.Id + "\n    {Dystans: " + this.Dystans + "\n    Lotnisko startowe: " + this.lotnisko1 + "\n    Lotnisko koncowe:  " + this.lotnisko2 + "\n    Czas: " + this.Czas + "\n    }");
            return napis;
        }
    }
}