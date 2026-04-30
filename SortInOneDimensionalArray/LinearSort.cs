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
            int maxDigit = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (maxDigit < MaxDigit(array[i]))
                {
                    maxDigit = MaxDigit(array[i]);
                }
            }
            List<int>[] currentArray = new List<int>[19];
            for (int i = 0; i < currentArray.Length; i++)
            {
                currentArray[i] = new List<int>();
            }
            for (int i = 0; i < array.Length; i++)
            {
                int k = Discharge(array[i], 1) + 9;
                currentArray[k].Add(array[i]);
            }
            List<int>[] nextArray = new List<int>[19];
            for (int i = 0; i < nextArray.Length; i++)
            {
                nextArray[i] = new List<int>();
            }
            int r = 2;
            while (r <= maxDigit)
            {
                for(int j = 0; j < currentArray.Length; j++)
                {
                    foreach(var number in currentArray[j])
                    {
                        int k = Discharge(number, r) + 9;
                        nextArray[k].Add(number);
                    }
                }
                currentArray = nextArray;
                nextArray = new List<int>[19];
                for (int i = 0; i < nextArray.Length; i++)
                {
                    nextArray[i] = new List<int>();
                }
                r++;
            }
            int l = 0;
            for(int i = 0; i < currentArray.Length; i++)
            {
                foreach(var number in currentArray[i])
                {
                    array[l] = number;
                    l++;
                }
            }
        }

        private static int MaxDigit(int N)
        {
            int maxDigit = 0;
            while (N != 0)
            {
                N /= 10;
                maxDigit++;
            }
            return maxDigit;
        }

        private static int Discharge(int N, int discharge)
        {
            int number = 0;
            while (discharge > 0)
            {
                number = N % 10;
                N /= 10;
                discharge--;
            }
            return number;
        }
    }
}
