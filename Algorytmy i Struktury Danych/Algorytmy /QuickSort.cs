
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = { 1, 6, 5, 12, 2, 3, 5, 6, 7 };
            foreach(var i in tab)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\nQuickSort: ");
            QuickSort(tab, 0, tab.Length - 1);
            foreach (var i in tab)
            {
                Console.Write($"{i} ");
            }
            Console.ReadKey();
        }

        static public void QuickSort(int[] tab, int left, int right)
        {
            int piwot = tab[(left + right) / 2];
            int i = left;
            int j = left;
            tab[(left + right) / 2] = tab[right];

            while (i < right)
            {
                if (tab[i] < piwot)
                {
                    int temp = tab[i];
                    tab[i] = tab[j];
                    tab[j] = temp;
                    j++;
                    i++;
                }
                else
                {
                    i++;
                }
            }
            tab[right] = tab[j];
            tab[j] = piwot;

            if(left < j - 1)
            {
                QuickSort(tab, left, j - 1);
            }
            if(right > j + 1)
            {
                QuickSort(tab, j + 1, right);
            }

        }
    }
}
