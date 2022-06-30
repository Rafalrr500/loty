using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Projekt
{
    class Program
    {
        public static void wczytaj(LiniaLotnicza linialotnicza)
        {
            Klient klient1 = new OsobaPrywatna(1, "Jan", "Nowak", "111");
            Klient klient2 = new Firma(2, "Firmaa", "222");
            Klient klient3 = new OsobaPrywatna(3, "Jan", "Nowak", "333");
            Klient klient4 = new Firma(4, "FFirma", "444");
            linialotnicza.dodajKlienta(klient1);
            linialotnicza.dodajKlienta(klient2);
            linialotnicza.dodajKlienta(klient3);
            linialotnicza.dodajKlienta(klient4);
            Samolot samolot1 = new Dalekobiezny(1000.0, 1, 100);
            Samolot samolot2 = new Regionalny(500.0, 2, 50);
            Samolot samolot3 = new Dalekobiezny(800.8, 3, 88);
            Samolot samolot4 = new Regionalny(500.0, 4, 74);
            Samolot samolot5 = new Dalekobiezny(1000.0, 5, 155);
            Samolot samolot6 = new Regionalny(500.0, 6, 63);
            linialotnicza.dodajSamolot(samolot1);
            linialotnicza.dodajSamolot(samolot2);
            linialotnicza.dodajSamolot(samolot3);
            linialotnicza.dodajSamolot(samolot4);
            linialotnicza.dodajSamolot(samolot5);
            linialotnicza.dodajSamolot(samolot6);
            Lotnisko lotnisko1 = new Lotnisko("Warszawa", 1, "Okecie");
            Lotnisko lotnisko2 = new Lotnisko("Londyn", 2, "Heathrow");
            Lotnisko lotnisko3 = new Lotnisko("Krakow", 3, "Balice");
            Lotnisko lotnisko4 = new Lotnisko("Waszyngton", 4, "Kennedy'ego");
            Lotnisko lotnisko5 = new Lotnisko("wroclaw", 5, "Strachowice");
            Lotnisko lotnisko6 = new Lotnisko("Berlin", 6, "Brandenburg");
            linialotnicza.dodajLotnisko(lotnisko1);
            linialotnicza.dodajLotnisko(lotnisko2);
            linialotnicza.dodajLotnisko(lotnisko3);
            linialotnicza.dodajLotnisko(lotnisko4);
            linialotnicza.dodajLotnisko(lotnisko5);
            linialotnicza.dodajLotnisko(lotnisko6);
            Trasa trasa1 = new Trasa(1, 800.0, 120, lotnisko1, lotnisko2);
            Trasa trasa2 = new Trasa(2, 2000.4, 320, lotnisko2, lotnisko4);
            Trasa trasa3 = new Trasa(3, 900.5, 180, lotnisko3, lotnisko1);
            Trasa trasa4 = new Trasa(4, 1499.9, 220, lotnisko4, lotnisko3);
            linialotnicza.dodajTrase(trasa1);
            linialotnicza.dodajTrase(trasa2);
            linialotnicza.dodajTrase(trasa3);
            linialotnicza.dodajTrase(trasa4);
            Lot lot1 = new Lot(1, samolot1, trasa1);
            Lot lot2 = new Lot(2, samolot3, trasa2);
            linialotnicza.dodajLot(lot1);
            linialotnicza.dodajLot(lot2);
            Rezerwacja rezerwacja1 = new Rezerwacja(1, klient1);
            Rezerwacja rezerwacja2 = new Rezerwacja(2, klient2);
            lot1.dodajRezerwacje(rezerwacja1);
            lot2.dodajRezerwacje(rezerwacja2);
        }
        public static void Usun_lot(LiniaLotnicza linialotnicza)
        {
            int id;
            Przeglad_lotow(linialotnicza);
            Console.WriteLine("Podaj Id lotu ktory chcesz usunac: ");
            id = Convert.ToInt32(Console.ReadLine());
            if (linialotnicza.czyZawieraLot(id)) linialotnicza.usunLot(id);
            else Console.WriteLine("Operacja nie powiodla sie. Podano niepoprawne dane.");
            linialotnicza.Zapisz_na_plik_Loty();
        }
        public static void Usun_trase(LiniaLotnicza linialotnicza)
        {
            int Id;
            Przeglad_tras(linialotnicza);
            Console.WriteLine("Podaj Id trasy, ktora chcesz usunac");
            Id = Convert.ToInt32(Console.ReadLine());
            if (linialotnicza.czyZawieraTrasa(Id))
            {
                for (int i = 0; i < linialotnicza.getLoty().Count; i++)
                {
                    Lot L = linialotnicza.getLoty()[i];
                    if (L.getTrasa().getId().Equals(Id)) linialotnicza.usunLot(L.getId());
                }
                linialotnicza.usunTrase(Id);
            }
            else Console.WriteLine("Operacja nie powiodla sie. Podano niepoprawne dane.");
            linialotnicza.Zapisz_na_plik_Loty();
            linialotnicza.Zapisz_na_plik_Trasy();
        }
        public static void Przeglad_tras(LiniaLotnicza linialotnicza)
        {
            foreach (Trasa T in linialotnicza.getTrasa())
            {
                Console.WriteLine(T.ToString());
            }
        }
    public static void Dodaj_trase(LiniaLotnicza linialotnicza)
        {
            try
            {
                int Id1 = 1;
                int Id2, Id3;
                double Dystans;
                int Czas;
                Lotnisko lotnisko1 = new Lotnisko();
                Lotnisko lotnisko2 = new Lotnisko();
                Console.WriteLine("Wprowadz dystans trasy:");
                Dystans = Convert.ToDouble(Console.ReadLine()); ;
                Console.WriteLine("Wprowadz czas w minutach potzrebny na pokonanie trasy:");
                Czas = Convert.ToInt32(Console.ReadLine());
                Przeglad_lotnisk(linialotnicza);
                do
                {
                    Console.WriteLine("Wprowadz Id lotniska startowego:");
                    Id2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Wprowadz Id lotniska koncowego:");
                    Id3 = Convert.ToInt32(Console.ReadLine());
                    if (Id2 == Id3) Console.WriteLine("Podano niepoprawne dane");
                } while (Id2 == Id3);
                foreach (Lotnisko L in linialotnicza.getLotnisko())
                {
                    if (L.getId().Equals(Id2)) lotnisko1 = L;
                    if (L.getId().Equals(Id3)) lotnisko2 = L;
                }
                if (linialotnicza.getTrasa().Count > 0) Id1 += linialotnicza.getTrasa()[linialotnicza.getTrasa().Count - 1].getId();
                linialotnicza.dodajTrase(new Trasa(Id1, Dystans, Czas, lotnisko1, lotnisko2));
                linialotnicza.Zapisz_na_plik_Trasy();
            }
            catch(NiedodatnieException niedodatnie)
            {
                Console.WriteLine(niedodatnie.Message);
            }
        }
        public static void Zarezerwuj_lot(LiniaLotnicza linialotnicza)
        {
            int Id1;
            int Id2;
            int Id3=1;
            Lot lot = new Lot();
            Przeglad_lotow(linialotnicza);
            Console.WriteLine("Wprowadz Id lotu, na ktory chcesz zarezerwowac bilet");
            Id1 = Convert.ToInt32(Console.ReadLine());
            Przeglad_klientow(linialotnicza);
            Console.WriteLine("Wprowadz Id klienta");
            Id2 = Convert.ToInt32(Console.ReadLine());
            foreach(Lot L in linialotnicza.getLoty())
            {
                if(L.getId().Equals(Id1))
                {
                    lot = L;
                }
            }
            if (lot.getRezerwacja().Count > 0) Id3 += lot.getRezerwacja()[lot.getRezerwacja().Count - 1].getId();
            if (lot.getRezerwacja().Count < lot.getSamolot().getLiczbaMiejsc())
            {
                foreach (Klient K in linialotnicza.getKlient())
                {
                    if (K.getId().Equals(Id2))
                    {
                        if (!(lot.czyZawieraKlient(Id2))) lot.dodajRezerwacje(new Rezerwacja(Id3, K));
                    }
                }
            }
            linialotnicza.Zapisz_na_plik_Loty();
        }
        public static void Usun_rezerwacje(LiniaLotnicza linialotnicza)
        {
            int Id1, Id2;
            
            Console.WriteLine("Dostepne Loty:\n");
            foreach (Lot a in linialotnicza.getLoty())
            {
                Console.WriteLine("ID:{" + a.getId() + "} " + "Trasa:{ " + a.getTrasa() + "}");
            }
            Console.WriteLine("Prosze o podanie Id wybranego przez siebie lotu");
            Id1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Rezerwacja przypisane do wybranego lotu:\n");
            foreach (Lot L in linialotnicza.getLoty())
            {
                if (L.getId().Equals(Id1))
                {
                    Przeglad_rezerwacji(L);
                    break;
                }
            }
            Console.WriteLine("Prosze o podanie Id rezerwacji, ktora chcesz usunac:");
            Id2 = Convert.ToInt32(Console.ReadLine());
            foreach (Lot L in linialotnicza.getLoty())
            {
                if (L.getId().Equals(Id1))
                {
                    L.usunRezerwacje(Id2);
                    break;
                }
            }
            linialotnicza.Zapisz_na_plik_Loty();
        }
        public static void Przeglad_rezerwacji(LiniaLotnicza linialotnicza)
        {
            int Id;
            Przeglad_lotow(linialotnicza);
            Console.WriteLine("Wprowadz Id lotu, ktorego rezerwacje chcesz zobaczyc:");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dokonane rezerwacje:\n");
            foreach (Lot L in linialotnicza.getLoty())
            {
                if(L.getId().Equals(Id))
                {
                    foreach(Rezerwacja R in L.getRezerwacja())
                    {
                        Console.WriteLine(R.ToString());
                    }
                }
            }
        }
        public static void Przeglad_rezerwacji(Lot lot)
        {
            foreach (Rezerwacja R in lot.getRezerwacja())
            {
                Console.WriteLine(R.ToString());
            }
        }
        public static void Wolne_miejsca(LiniaLotnicza linialotnicza)
        {
            int Id;
            Console.WriteLine("Dostepne Loty:\n");
            foreach (Lot L in linialotnicza.getLoty())
            {
                Console.WriteLine(L.ToString());
            }
            Console.WriteLine("Prosze o podanie Id wybranego przez siebie lotu");
            Id = Convert.ToInt32(Console.ReadLine());
            foreach (Lot L in linialotnicza.getLoty())
            {
                if (L.getId().Equals(Id))
                {
                    if(L.getRezerwacja().Count() < L.getSamolot().getLiczbaMiejsc())
                    {
                        int wolne = L.getSamolot().getLiczbaMiejsc() - L.getRezerwacja().Count();
                        Console.WriteLine("Jest jeszcze " + wolne + " wolnych miejsc na wybrany lot");
                    }
                    else Console.WriteLine("Niestety pula miejsc na wybrany lot została wyczerpana");
                }
            }
        }

        public static void Przeglad_klientow(LiniaLotnicza linialotnicza)
        {
            Console.WriteLine("Dostepni klienci:\n");
            foreach (Klient K in linialotnicza.getKlient())
            {
                Console.WriteLine(K.ToString());
            }
        }
        public static void Usun_klienta(LiniaLotnicza linialotnicza)
        {
            int id;
            Przeglad_klientow(linialotnicza);
            Console.WriteLine("Podaj Id klienta, ktorego chcesz usunac: ");
            id = Convert.ToInt32(Console.ReadLine());
            if (linialotnicza.czyZawieraKlient(id))
            {
                for (int i = 0; i < linialotnicza.getLoty().Count; i++)
                {
                Lot L = linialotnicza.getLoty()[i];
                for (int j = 0; j < L.getRezerwacja().Count; j++)
                {
                    Rezerwacja R = L.getRezerwacja()[j];
                    if (R.getKlient().getId().Equals(id)) L.usunRezerwacje(R.getId());
                }
                }
                linialotnicza.usunKlienta(id);
            }
            else Console.WriteLine("Operacja nie powiodla sie. Podano niepoprawne dane.");
            linialotnicza.Zapisz_na_plik_Loty();
            linialotnicza.Zapisz_na_plik_Klienci();
        }
        public static void Dodaj_firme(LiniaLotnicza linialotnicza)
        {
            string NazwaFirmy;
            int Id = 1;
            string NIP;
            Console.WriteLine("Wprowadz nazwe firmy:");
            NazwaFirmy = Console.ReadLine();
            Console.WriteLine("Wprowadz NIP:");
            NIP = Console.ReadLine();
            if (linialotnicza.getKlient().Count > 0) Id += linialotnicza.getKlient()[linialotnicza.getKlient().Count - 1].getId();
            linialotnicza.dodajKlienta(new Firma(Id, NazwaFirmy, NIP));
            linialotnicza.Zapisz_na_plik_Klienci();
        }
        public static void Dodaj_osobe(LiniaLotnicza linialotnicza)
        {
            string Imie;
            string Nazwisko;
            int Id = 1;
            string Pesel;
            Console.WriteLine("Wprowadz Imie:");
            Imie = Console.ReadLine();
            Console.WriteLine("Wprowadz Nazwisko:");
            Nazwisko = Console.ReadLine();
            Console.WriteLine("Wprowadz Pesel:");
            Pesel = Console.ReadLine();
            if (linialotnicza.getKlient().Count > 0) Id += linialotnicza.getKlient()[linialotnicza.getKlient().Count - 1].getId();
            Klient K = new OsobaPrywatna(Id, Imie, Nazwisko, Pesel);
            linialotnicza.dodajKlienta(new OsobaPrywatna(Id,Imie,Nazwisko,Pesel));
            linialotnicza.Zapisz_na_plik_Klienci();
        }
        public static void Usun_samolot(LiniaLotnicza linialotnicza)
        {
            int id;
            Przeglad_samolotow(linialotnicza);
            Console.WriteLine("Podaj Id samolotu, ktory chcesz usunac: ");
            id = Convert.ToInt32(Console.ReadLine());
            if (linialotnicza.czyZawieraSamolot(id))
            {
                for (int i = 0; i < linialotnicza.getLoty().Count; i++)
                {
                    Lot L = linialotnicza.getLoty()[i];
                    if (L.getSamolot().getId().Equals(id)) linialotnicza.usunLot(L.getId());
                }
                linialotnicza.usunSamolot(id);
            }
            else Console.WriteLine("Operacja nie powiodla sie. Podano niepoprawne dane.");
            linialotnicza.Zapisz_na_plik_Loty();
            linialotnicza.Zapisz_na_plik_Samoloty();
        }
        public static void Przeglad_samolotow(LiniaLotnicza linialotnicza)
        {
            Console.WriteLine("Dostepne samoloty:\n");
            foreach (Samolot S in linialotnicza.getSamolot())
            {
                Console.WriteLine(S.ToString());
            }
        }
        public static void Dodaj_samolot(LiniaLotnicza linialotnicza)
        {
            try
            {
                double Zasieg;
                int Id = 1;
                int LiczbaMiejsc;
                Console.WriteLine("Wprowadz Zasieg:");
                Zasieg = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Wprowadz Liczbe Miejsc");
                LiczbaMiejsc = Convert.ToInt32(Console.ReadLine());
                if (linialotnicza.getSamolot().Count > 0) Id += linialotnicza.getSamolot()[linialotnicza.getSamolot().Count - 1].getId();
                if (Zasieg > 2000)
                {
                    linialotnicza.dodajSamolot(new Dalekobiezny(Zasieg, Id, LiczbaMiejsc));
                }
                else
                {
                    linialotnicza.dodajSamolot(new Regionalny(Zasieg, Id, LiczbaMiejsc));
                }
                linialotnicza.Zapisz_na_plik_Samoloty();
            }
            catch (NiedodatnieException niedodatnie)
            {
                Console.WriteLine(niedodatnie.Message);
            }
        }
        public static void Przeglad_lotnisk(LiniaLotnicza linialotnicza)
        {
            Console.WriteLine("Dostepne lotniska:\n");
            foreach (Lotnisko L in linialotnicza.getLotnisko())
            {
                Console.WriteLine(L.ToString());
            }
        }
        public static void Usun_lotnisko(LiniaLotnicza linialotnicza)
        {
            int id;
            Przeglad_lotnisk(linialotnicza);
            Console.WriteLine("Podaj Id lotniska, ktore chcesz usunac: ");
            id = Convert.ToInt32(Console.ReadLine());
            if (linialotnicza.czyZawieraLotnisko(id))
            {
                for (int i = 0; i < linialotnicza.getLoty().Count; i++)
                {
                    Lot L = linialotnicza.getLoty()[i];
                    if (L.getTrasa().getLotnisko1().getId().Equals(id) || L.getTrasa().getLotnisko2().getId().Equals(id)) linialotnicza.usunLot(L.getId());
                }
                for (int i = 0; i < linialotnicza.getTrasa().Count; i++)
                {
                    Trasa T = linialotnicza.getTrasa()[i];
                    if (T.getLotnisko1().getId().Equals(id) || T.getLotnisko2().getId().Equals(id)) linialotnicza.usunTrase(T.getId());
                }
                linialotnicza.usunLotnisko(id);
            }
            else Console.WriteLine("Operacja nie powiodla sie. Podano niepoprawne dane.");
            linialotnicza.Zapisz_na_plik_Loty();
            linialotnicza.Zapisz_na_plik_Trasy();
            linialotnicza.Zapisz_na_plik_Lotniska();
        }
        public static void Dodaj_lotnisko(LiniaLotnicza linialotnicza)
        {
            string Miasto;
            int Id=1;
            string Nazwa;
            Console.WriteLine("Wprowadz nazwe lotniska");
            Nazwa = Console.ReadLine();
            Console.WriteLine("Wprowadz miasto, w ktorym znajduje sie lotnisko");
            Miasto = Console.ReadLine();
            if (linialotnicza.getLotnisko().Count > 0) Id += linialotnicza.getLotnisko()[linialotnicza.getLotnisko().Count - 1].getId();
            linialotnicza.dodajLotnisko(new Lotnisko(Miasto, Id, Nazwa));
            linialotnicza.Zapisz_na_plik_Lotniska();
        }
        public static void Przeglad_lotow(LiniaLotnicza linialotnicza)
        {
            Console.WriteLine("Dostepne loty:\n");
            foreach (Lot L in linialotnicza.getLoty())
            {
                Console.WriteLine(L.ToString());
            }
        }
        public static void Generuj_lot(LiniaLotnicza linialotnicza)
        {
            int Id;
            Random rand = new Random();
            Lot lot = new Lot();
            int numer_trasa;
            int numer_samolot;
            bool czy_istnieje = false;
            foreach(Samolot S in linialotnicza.getSamolot())
            {
                foreach(Trasa T in linialotnicza.getTrasa())
                {
                    if (S.getZasieg() >= T.getDystans() && linialotnicza.getTrasa().Count > 0 && linialotnicza.getSamolot().Count > 0) czy_istnieje = true;
                }
            }
            if (czy_istnieje == true)
            {
                do
                {
                    numer_trasa = rand.Next(0, linialotnicza.getTrasa().Count - 1);
                    numer_samolot = rand.Next(0, linialotnicza.getSamolot().Count - 1);
                } while (linialotnicza.getSamolot()[numer_samolot].getZasieg() < linialotnicza.getTrasa()[numer_trasa].getDystans());
                Id = 1;
                if (linialotnicza.getLoty().Count > 0) Id += linialotnicza.getLoty()[linialotnicza.getLoty().Count - 1].getId();
                linialotnicza.dodajLot(new Lot(Id, linialotnicza.getSamolot()[numer_samolot], linialotnicza.getTrasa()[numer_trasa]));
                linialotnicza.Zapisz_na_plik_Loty();
            }
            else Console.WriteLine("Niestety w naszej bazie nie ma obiektow klasy Samolot oraz Trasa, ktore spelnialyby zalozenia wymagane przez generator");
        }
        static void Main(string[] args)
        {
            LiniaLotnicza linialotnicza = new LiniaLotnicza("AirFly");
            int wybor;
            wczytaj(linialotnicza);
            Console.WriteLine("Witaj w programie do zarzadzania Lotniskiem\nWybierz interesujace Cie opcje, aby sprawnie poruszać sie po Menu");
            do
            {
                Console.WriteLine("\n1.Loty\n2.Lotniska\n3.Samoloty\n4.Klienci\n5.Rezerwacje\n6.Trasy\n7.Exit"); // Wprowadzenie//
                do
                {
                    wybor = Convert.ToInt32(Console.ReadLine());
                    if (wybor != 1 && wybor != 2 && wybor != 3 && wybor != 4 && wybor != 5 && wybor != 6 && wybor != 7) // Petla zabezpieczajaca//
                    {
                        Console.WriteLine("Podałeś nieprawidlowa odpowiedz");
                    }
                } while (wybor != 1 && wybor != 2 && wybor != 3 && wybor != 4 && wybor != 5 && wybor != 6 && wybor != 7); // Sprawdza poparwnosc wprowadzonego znaku//
                Console.Clear();
                switch (wybor)
                {
                    case 1: //Loty//
                        Console.WriteLine("1.Usuwanie Lotow\n2.Generowanie Lotow\n3.Przegladnie Lotow\n4.Exit");
                        do
                        {
                            wybor = Convert.ToInt32(Console.ReadLine());
                            if (wybor != 1 && wybor != 2 && wybor != 3 && wybor != 4) // Petla zabezpieczajaca//
                            {
                                Console.WriteLine("Podałeś nieprawidlowa odpowiedz");
                            }
                        } while (wybor != 1 && wybor != 2 && wybor != 3 && wybor != 4);
                        switch (wybor)
                        {
                            case 1: // Usuwanie Lotow//
                                Usun_lot(linialotnicza);
                                break;
                            case 2:// Generowanie Lotow//
                                Generuj_lot(linialotnicza);
                                break;
                            case 3: //Przegladanie Lotow//
                                Przeglad_lotow(linialotnicza);
                                break;
                            case 4: 
                                break;
                        }
                        break;

                    case 2: // Lotniska//
                        Console.WriteLine("1.Dodaj Lotnisko\n2.Usun Lotnisko\n3.Przegladaj Dostepne Lotniska\n4.Exit");
                        do
                        {
                            wybor = Convert.ToInt32(Console.ReadLine());
                            if (wybor != 1 && wybor != 2 && wybor != 3 && wybor != 4) // Petla zabezpieczajaca//
                            {
                                Console.WriteLine("Podałeś nieprawidlowa odpowiedz");
                            }
                        } while (wybor != 1 && wybor != 2 && wybor != 3 && wybor != 4);
                        switch (wybor)
                        {
                            case 1: // Dodawanie Lotnisk//
                                Dodaj_lotnisko(linialotnicza);
                                break;
                            case 2: // Usuwanie Lotnisk//
                                Usun_lotnisko(linialotnicza);
                                break;
                            case 3: //Przegladanie Lotnisk// 
                                Przeglad_lotnisk(linialotnicza);
                                break;
                            case 4:// Wyjscie//
                                break;

                        }
                        break;
                        
                    case 3:
                        Console.WriteLine("1.Dodaj Samolot\n2.Usun Samolot\n3.Przegladaj Dostepne Samoloty\n4.Exit");
                        do
                        {
                            wybor = Convert.ToInt32(Console.ReadLine());
                            if (wybor != 1 && wybor != 2 && wybor != 3 && wybor != 4) // Petla zabezpieczajaca//
                            {
                                Console.WriteLine("Podałeś nieprawidlowa odpowiedz");
                            }
                        } while (wybor != 1 && wybor != 2 && wybor != 3 && wybor != 4);
                        switch (wybor)
                        {
                            case 1: // Dodawanie Samolotu//
                                Dodaj_samolot(linialotnicza);
                                break;
                            case 2: // Usuwanie Samolotu//
                                Usun_samolot(linialotnicza); 
                                break;
                            case 3: //Przegladanie Samolotow/ 
                                Przeglad_samolotow(linialotnicza);
                                break;
                            case 4://Wyjscie//
                                break;

                        }
                        break;
                        
                    case 4:
                        Console.WriteLine("1.Dodaj Klienta\n2.Usun Klienta\n3.Przegladaj Klientow\n4.Exit");
                        do
                        {
                            wybor = Convert.ToInt32(Console.ReadLine());
                            if (wybor != 1 && wybor != 2 && wybor != 3 && wybor != 4) // Petla zabezpieczajaca//
                            {
                                Console.WriteLine("Podałeś nieprawidlowa odpowiedz");
                            }
                        } while (wybor != 1 && wybor != 2 && wybor != 3 && wybor != 4);
                        switch (wybor)
                        {
                            case 1: // Dodawanie Klienta//
                                Console.WriteLine("1.Dodaj Osobe\n2.Dodaj Firme\n3.Exit");
                                do
                                {
                                    wybor = Convert.ToInt32(Console.ReadLine());
                                    if (wybor != 1 && wybor != 2 && wybor != 3) // Petla zabezpieczajaca//
                                    {
                                        Console.WriteLine("Podałeś nieprawidlowa odpowiedz");
                                    }
                                } while (wybor != 1 && wybor != 2 && wybor != 3);
                                switch (wybor)
                                {
                                    case 1://Dodaj Osobe
                                        Dodaj_osobe(linialotnicza);
                                        break;
                                    case 2: //Dodaj Firme//
                                        Dodaj_firme(linialotnicza);
                                        break;
                                    case 3: //Wyjscie//
                                        break;
                                }
                                break;
                            case 2: // Usuwanie Klientow//
                                Usun_klienta(linialotnicza);
                                break;
                            case 3: //Przegladanie Klientow/ 
                                Przeglad_klientow(linialotnicza);
                                break;
                            case 4:// Wyjscie//
                                break;

                        }
                        break;
                        
                    case 5://Rezerwacje//
                        Console.WriteLine("1.Zarezerwuj lot\n2.Usun rezerwacje\n3.Przeglad rezerwacji\n4.Sprawdz wolne miejsca\n5.Exit");
                        do
                        {
                            wybor = Convert.ToInt32(Console.ReadLine());
                            if (wybor != 1 && wybor != 2 && wybor != 3 && wybor != 4 && wybor != 5)
                            {
                                Console.WriteLine("Podałeś nieprawidlowa odpowiedz");
                            }
                        } while (wybor != 1 && wybor != 2 && wybor != 3 && wybor != 4 && wybor != 5);
                        switch (wybor)
                        {
                            case 1: // Rezerwacja lotu
                                Zarezerwuj_lot(linialotnicza);
                                break;
                            case 2:// Usuwanie rezerwacji
                                Usun_rezerwacje(linialotnicza);
                                break;
                            case 3: // Przeglad rezerwacji
                                Przeglad_rezerwacji(linialotnicza);
                                break;
                            case 4: // Wolne miejsca
                                Wolne_miejsca(linialotnicza);
                                break;
                            case 5:
                                break;
                        }
                        break;
                    
                    case 6://TRASA//
                        Console.WriteLine("1.Dodaj Trase\n2.Usun Trase\n3.Przegladaj Trasy\n4.Exit");
                        do
                        {
                            wybor = Convert.ToInt32(Console.ReadLine());
                            if (wybor != 1 && wybor != 2 && wybor != 3 & wybor != 4)
                            {
                                Console.WriteLine("Podałeś nieprawidlowa odpowiedz");
                            }
                        } while (wybor != 1 && wybor != 2 && wybor != 3 & wybor != 4);
                        switch (wybor)
                        {
                            case 1: // Dodaj Trase//
                                Dodaj_trase(linialotnicza);
                                break;
                            case 2:// Usun Trase//
                                Usun_trase(linialotnicza);
                                break;
                            case 3: // Przegladaj Trasy//
                                Przeglad_tras(linialotnicza);
                                break;
                            case 4:
                                break;
                        }
                        break;
                    case 7:
                        wybor = 0;
                        break;
                }
            } while (wybor != 0);
        }
    }
}
