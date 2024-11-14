using System;
using System.Diagnostics;
using System.Threading;

namespace Zadanie1
{
    class IteracjeAlgorytm
    {
        public int ilosc;
        public double[] tablicaIlosci;
        public double srednia;
        int index;

        public IteracjeAlgorytm()
        {
            ilosc = 0;
            tablicaIlosci = new double[35];
            srednia = 0;
            index = 0;
        }

        public void Dodawanie()
        {
            this.ilosc++;
        }
        public void Koniec()
        {
            
            tablicaIlosci[index] = ilosc;
            index++;
            ilosc = 0;
        }
        public double LiczenieSredniej()
        {
            for(int a = 0; a < tablicaIlosci.Length; a++)
            {
                srednia += tablicaIlosci[a];
            }
            srednia = srednia / tablicaIlosci.Length;
            return srednia;
        }
        public void WyswietlIlosc()
        {
            Console.WriteLine("");
            Console.WriteLine(ilosc);
        }
        public double OdchylenieStandardowe()
        {
            double sumaWartosciMinusSredniaDoKwadratu = 0;
            for(int a = 0; a < tablicaIlosci.Length; a++)
            {
                sumaWartosciMinusSredniaDoKwadratu += Math.Pow((tablicaIlosci[a] - LiczenieSredniej()), 2);
            }
            return (Math.Sqrt((1/(Convert.ToDouble(tablicaIlosci.Length) - 1))*sumaWartosciMinusSredniaDoKwadratu));
        }
        public double BladWzgledny()
        {
            return OdchylenieStandardowe() / LiczenieSredniej();
        }

    }
    class CzasAlgorytm
    {
        public Stopwatch watch;
        double[] czasy;
        public double srednia;
        int index;

        public CzasAlgorytm()
        {
            this.watch =  new Stopwatch();
            czasy = new double[35];
            srednia = 0;
            index = 0;
        }

        public void Start()
        {
            watch.Start();
        }
        public void Koniec()
        {
            watch.Stop();
            czasy[index] = watch.Elapsed.TotalMilliseconds;
            index++;
            watch.Reset();
        }
        public double SredniaCzasow()
        {
            for(int a =0; a < czasy.Length; a++)
            {
                srednia += czasy[a];
            }
            srednia = srednia / czasy.Length;
            return srednia;
        }

        public double OdchylenieStandardoweCzasow()
        {
            double sumaWartosciMinusSredniaDoKwadratu = 0;
            for (int a = 0; a < czasy.Length; a++)
            {
                sumaWartosciMinusSredniaDoKwadratu += Math.Pow((czasy[a] - SredniaCzasow()), 2);
            }
            return (Math.Sqrt((1 / (Convert.ToDouble(czasy.Length) - 1)) * sumaWartosciMinusSredniaDoKwadratu));
        }
        public double BladWzgledny()
        {
            return OdchylenieStandardoweCzasow() / SredniaCzasow();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            IteracjeAlgorytm iteracja = new IteracjeAlgorytm();
            CzasAlgorytm czas = new CzasAlgorytm();
           
            Random rd = new Random();
            // Algorytm wyszukiwania
            for(int b = 0; b < 35; b++)
            {
                // Generowanie losow tablicy
                czas.Start();
                int dlugoscTablicy = rd.Next(1, 50);
                int[] tablica = new int[dlugoscTablicy];
                for (int a = 0; a < dlugoscTablicy; a++)
                {
                    tablica[a] = rd.Next(1, 100);
                }
                //Sortowanie tablicy
                Array.Sort(tablica);
                //Wyszukiwanie Binarne
                int poczatek = 0;
                int koniec = tablica.Length - 1;
                int srodek = (poczatek + koniec) / 2;
                int szukana = rd.Next(1, 100);
                do
                {
                    iteracja.Dodawanie();
                    if (srodek > szukana)
                    {
                        koniec = srodek - 1;
                        srodek = (poczatek + koniec) / 2;
                    }
                    else if (srodek < szukana)
                    {
                        poczatek = srodek + 1;
                        srodek = (poczatek + koniec) / 2;
                    }
                    if (szukana == srodek) break;
                } while (poczatek < koniec);
                Console.WriteLine(iteracja.ilosc);
                Console.WriteLine(czas.watch.Elapsed.TotalMilliseconds);
                czas.Koniec();
                iteracja.Koniec();
                
            }
            //Wyswietlanie Informacji
            Console.WriteLine($"Średnia ilość iteracji wyosi: {iteracja.LiczenieSredniej()}");
            Console.WriteLine($"Odchylenie standardowe dla iteracji wynosi: {iteracja.OdchylenieStandardowe()}");
            Console.WriteLine($"Błąd względny wynosi: {iteracja.BladWzgledny()}");

            Console.WriteLine($"Średnia ilość czasow wynosi: {czas.SredniaCzasow()} ms");
            Console.WriteLine($"Odchylenie standardowe dla iteracji wynosi: {czas.OdchylenieStandardoweCzasow()} ms");
            Console.WriteLine($"Błąd względny wynosi: {czas.BladWzgledny()}");
        }
    }
}
