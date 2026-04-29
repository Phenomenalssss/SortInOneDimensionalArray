using QuadraticSortsInOneDimensionalArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortInOneDimensionalArray
{
    public static class LinearSort
    {
        public static void Counting(int[] array)
        {
            int[] counts = new int[2001];
            for(int i = 0; i < array.Length; i++)
            {
                counts[array[i] + 1000]++;
            }
            Console.WriteLine("Массив-счётчик:");
            for(int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{i - 1000}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" => ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{counts[i]}");
                    Console.ResetColor();
                }
            }
            for(int i = 0, j = 0; i < counts.Length && j < array.Length; i++)
            {
                while (counts[i] > 0)
                {
                    array[j] = i - 1000;
                    j++;
                    counts[i]--;
                }
            }
        }

        public static void LSDRadix(int[] array)
        {

        }
    }
}
