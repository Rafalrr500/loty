using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    public class Lot
    {
        private List<Rezerwacja> rezerwacje = new List<Rezerwacja>();
        private Samolot samolot;
        private Trasa trasa;
        private int Id;
        public Lot()
        {
            this.Id = 0;
            this.samolot = new Regionalny();
            this.trasa = new Trasa();
        }
        public Lot(int Id, Samolot samolot, Trasa trasa)
        {
            this.Id = Id;
            this.samolot = samolot;
            this.trasa = trasa;
        }
        public int getId()
        {
            return Id;
        }
        public List<Rezerwacja> getRezerwacja()
        {
            return rezerwacje;
        }
        public Samolot getSamolot()
        {
            return samolot;
        }
        public Trasa getTrasa()
        {
            return trasa;
        }
        public void dodajRezerwacje(Rezerwacja rezerwacja)
        {
            rezerwacje.Add(rezerwacja);
        }
        public void usunRezerwacje(int id)
        {
            for (int i = 0; i < rezerwacje.Count; i++)
            {
                Rezerwacja R = rezerwacje[i];
                if (R.getId().Equals(id)) rezerwacje.Remove(R);
            }
        }
        public void stanRezerwacji()
        {
            foreach (Rezerwacja R in this.rezerwacje)
            {
                Console.WriteLine(R.ToString());
            }
        }
        public bool czyZawieraRezerwacja(int id)
        {
            foreach(Rezerwacja R in rezerwacje)
            {
                if (R.getId().Equals(id)) return true;
            }
            return false;
        }
        public bool czyZawieraKlient(int id)
        {
            foreach (Rezerwacja R in rezerwacje)
            {
                if (R.getKlient().getId().Equals(id)) return true;
            }
            return false;
        }
        public override string ToString()
        {
            String napis = new String(" Id: " + this.Id + "\n [Trasa: " + this.trasa.ToString() + "\n  Samolot: " + this.samolot.ToString() + "\n  Lista rezerwacji: ");
            if (rezerwacje.Count != 0)
            {
                int k = 1;
                foreach (Rezerwacja R in rezerwacje)
                {
                    napis += "\n    " + k + ". " + R.ToString();
                    k++;
                }
            }
            else napis += "brak";
            return napis + "\n ]";
        }
    }
}
