using System;
using System.Collections.Generic;
using System.Text;


namespace Projekt
{
public class Rezerwacja
    {
        private int Id;
        private Klient klient;
        public Rezerwacja(int Id, Klient klient)
        {
            this.Id = Id;
            this.klient = klient;
        }
        public int getId()
        {
            return this.Id;
        }
        public Klient getKlient()
        {
            return this.klient;
        }
        public override string ToString()
        {
            return " Id: " + Id + "\n     " + this.getKlient().ToString() + "\n        ";
        }
    }
}
