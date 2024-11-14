using System;

namespace BinarySearch
{
    // Klasa służąca to liczenia iteracji w danym algorytmie oraz liczenie średniej dla n wywyołań danego algorytmu
    public class Iteraction
    {
        public int licznik; // liczy ilość iteracji
        double srednia;
        public int[] wynikiDoSredniej; // przechowywanie wyników do polczenia z nich średniej
        int indeks; //indeks do tablicy

        public Iteraction()
        {
            this.licznik = 0;
            this.srednia = 0;
            this.wynikiDoSredniej = new int[10];
            this.indeks = 0;
        }

        public void Dodaj() // Inkrementacja licznika
        {
            licznik++;
        }
        public void Zakoncz() // zakoczenie algorytmu
        {
            wynikiDoSredniej[indeks] = licznik;
            licznik = 0;
            indeks++;
        }
        public double ZwrocSrednia() // zwracanie wartosci sredniej
        {
            foreach(var i in wynikiDoSredniej)
            {
                srednia += i;
            }
            return Convert.ToDouble(srednia / wynikiDoSredniej.Length);
        }
        public void Reset() // resetowanie przed użyciem innego algorytmu
        {
            licznik = 0;
            indeks = 0;
            srednia = 0;
        }
    }


    class Program
    {

        public static int BinarySearch(int[] tablica, int szukana, Iteraction iterator)
        {
            int poczatek;
            int srodek;
            int koniec;

            poczatek = 0;
            koniec = tablica.Length - 1;
            srodek = (poczatek + koniec) / 2;

            while(poczatek <= koniec)
            {
                iterator.Dodaj();
                if (tablica[srodek] == szukana) {
                    iterator.Zakoncz();
                    return srodek;
                } 
                else if(tablica[srodek] > szukana)
                {
                    poczatek = srodek + 1;
                    srodek = (poczatek + koniec) / 2;
                }
                else
                {
                    koniec = srodek - 1;
                    srodek = (poczatek + koniec) / 2;
                }
                

            }
            iterator.Zakoncz();
            return -1;
        }


        public static void BubbleSort(int[] tablica)
        {
            int i;
            int j;
            int temp;
            bool czyPosorotwana;
            for(i = 0; i < tablica.Length - 1; i++)
            {
                czyPosorotwana = true;
                for(j = 0; j < tablica.Length - i - 1; j++)
                {
                    if(tablica[j] < tablica[j + 1])
                    {
                        temp = tablica[j];
                        tablica[j] = tablica[j + 1];
                        tablica[j + 1] = temp;
                        czyPosorotwana = false;
                    }
                }
                if (czyPosorotwana == true) break;
            }
        }




        public static void ShowTable(int[] tablica)
        {
            foreach(var  i in tablica)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("");
        }



        static void Main(string[] args)
        {
            Random rnd = new Random();
            Iteraction iterator = new Iteraction();

            int iloscElemetowWTablicy;
            int szukanaLiczba;
            int i;
            int j;
            int k;

            iloscElemetowWTablicy = 100;

            for(i = 0; i < 10; i++)
            {
                Console.WriteLine($"Ilość Elementów w tablicy: {iloscElemetowWTablicy}");
                int[] tablica = new int[iloscElemetowWTablicy];
                for (j = 0; j < 10; j++)
                {
                    szukanaLiczba = rnd.Next(1, 2000);
                    for (k = 0; k < iloscElemetowWTablicy; k++)
                    {
                        tablica[k] = rnd.Next(1, 2000);
                    }
                    BubbleSort(tablica);
                    Console.Write($"Aktualnie szukana liczba: {szukanaLiczba} \t pozycja liczby: {BinarySearch(tablica, szukanaLiczba, iterator)} \n");
                }
                Console.WriteLine($"Średnia 10 wysuzkiwań dla tablicy {iloscElemetowWTablicy} elementowej wynosi: {iterator.ZwrocSrednia()}");
                iloscElemetowWTablicy += 100;
                Console.WriteLine();
                iterator.Reset();
            }


            /*
            ShowTable(tablica);

            BubbleSort(tablica);

            ShowTable(tablica);

            Console.WriteLine(BinarySearch(tablica, 4));

            */
        }
    }
}
