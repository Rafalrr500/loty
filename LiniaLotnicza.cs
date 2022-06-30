using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Projekt
{
    public class LiniaLotnicza
    {
        private string NazwaLinii;
        private List<Samolot> samoloty = new List<Samolot>();
        private List<Lot> loty = new List<Lot>();
        private List<Klient> klienci = new List<Klient>();
        private List<Trasa> trasy = new List<Trasa>();
        private List<Lotnisko> lotniska = new List<Lotnisko>();
        public LiniaLotnicza(string NazwaLinii)
        {
            this.NazwaLinii = NazwaLinii;
        }
        public string getNazwaLinii()
        {
            return NazwaLinii;
        }
        public List<Samolot> getSamolot()
        {
            return samoloty;
        }
        public List<Lot> getLoty()
        {
            return loty;
        }
        public List<Trasa> getTrasa()
        {
            return trasy;
        }
        public List<Klient> getKlient()
        {
            return klienci;
        }
        public List<Lotnisko> getLotnisko()
        {
            return lotniska;
        }
        public void dodajSamolot(Samolot samolot)
        {
            samoloty.Add(samolot);
        }
        public void usunSamolot(int id)
        {
            for (int i = 0; i < samoloty.Count; i++)
            {
                Samolot S = samoloty[i];
                if (S.getId().Equals(id)) samoloty.Remove(S);
            }
        }
        public void stanSamolotow()
        {
            foreach(Samolot S in this.samoloty)
            {
                Console.WriteLine(S.ToString());
            }
        }
        public bool czyZawieraSamolot(int id)
        {
            foreach (Samolot S in samoloty)
            {
                if (S.getId().Equals(id)) return true;
            }
            return false;
        }
        public void Zapisz_na_plik_Samoloty()
        {
            StreamWriter sw1 = new StreamWriter("samoloty.txt");
            foreach (Samolot S in this.getSamolot())
            {
                sw1.WriteLine(S.ToString());
            }
            sw1.Close();
        }
        public void dodajLot(Lot lot)
        {
            loty.Add(lot);
        }
        public void usunLot(int id)
        {
            for (int i = 0; i < loty.Count; i++)
            {
                Lot L = loty[i];
                if (L.getId().Equals(id)) loty.Remove(L);
            }
        }
        public void stanLotow()
        {
            foreach (Lot L in this.loty)
            {
                Console.WriteLine(L.ToString());
            }
        }
        public bool czyZawieraLot(int id)
        {
            foreach (Lot L in loty)
            {
                if (L.getId().Equals(id)) return true;
            }
            return false;
        }
        public void Zapisz_na_plik_Loty()
        {
            StreamWriter sw1 = new StreamWriter("loty.txt");
            foreach (Lot L in this.getLoty())
            {
                sw1.WriteLine(L.ToString());
            }
            sw1.Close();
        }
        public void dodajTrase(Trasa trasa)
        {
            trasy.Add(trasa);
        }
        public void usunTrase(int id)
        {
            for (int i = 0; i < trasy.Count; i++)
            {
                Trasa T = trasy[i];
                if (T.getId().Equals(id)) trasy.Remove(T);
            }
        }
        public void stanTras()
        {
            foreach (Trasa T in this.trasy)
            {
                Console.WriteLine(T.ToString());
            }
        }
        public bool czyZawieraTrasa(int id)
        {
            foreach (Trasa T in trasy)
            {
                if (T.getId().Equals(id)) return true;
            }
            return false;
        }
        public void Zapisz_na_plik_Trasy()
        {
            StreamWriter sw1 = new StreamWriter("trasy.txt");
            foreach (Trasa T in this.getTrasa())
            {
                sw1.WriteLine(T.ToString());
            }
            sw1.Close();
        }
        public void dodajKlienta(Klient klient)
        {
            klienci.Add(klient);
        }
        public void usunKlienta(int id)
        {
            for (int i = 0; i < klienci.Count; i++)
            {
                Klient K = klienci[i];
                if (K.getId().Equals(id)) klienci.Remove(K);
            }
        }
        public void stanKlientow()
        {
            foreach (Klient K in this.klienci)
            {
                Console.WriteLine(K.ToString());
            }
        }
        public bool czyZawieraKlient(int id)
        {
            foreach (Klient K in klienci)
            {
                if (K.getId().Equals(id)) return true;
            }
            return false;
        }
        public void Zapisz_na_plik_Klienci()
        {
            StreamWriter sw1 = new StreamWriter("klienci.txt");
            foreach (Klient K in this.getKlient())
            {
                sw1.WriteLine(K.ToString());
            }
            sw1.Close();
        }
        public void dodajLotnisko(Lotnisko lotnisko)
        {
            lotniska.Add(lotnisko);
        }
        public void usunLotnisko(int id)
        {
            for (int i = 0; i < lotniska.Count; i++)
            {
                Lotnisko L = lotniska[i];
                if (L.getId().Equals(id)) lotniska.Remove(L);
            }
        }
        public void stanLotnisk()
        {
            foreach (Lotnisko L in this.lotniska)
            {
                Console.WriteLine(L.ToString());
            }
        }
        public bool czyZawieraLotnisko(int id)
        {
            foreach (Lotnisko L in lotniska)
            {
                if (L.getId().Equals(id)) return true;
            }
            return false;
        }
        public void Zapisz_na_plik_Lotniska()
        {
            StreamWriter sw1 = new StreamWriter("lotniska.txt");
            foreach (Lotnisko L in this.getLotnisko())
            {
                sw1.WriteLine(L.ToString());
            }
            sw1.Close();
        }
    }
}
