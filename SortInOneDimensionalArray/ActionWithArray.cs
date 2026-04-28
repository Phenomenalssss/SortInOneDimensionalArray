using System;
using System.Collections.Generic;
using System.Text;

namespace QuadraticSortsInOneDimensionalArray
{
    public class ActionWithArray
    {
        public static void ManuallyFill(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{i + 1}-й элемент = ");
                int value = Convert.ToInt32(Console.ReadLine());
                array[i] = value;
            }
        }

        public static void RandomFill(int[] array)
        {
            Console.WriteLine("Введите пределы значений:");
            Console.Write("Левая граница = ");
            int left = Convert.ToInt32(Console.ReadLine());
            Console.Write("Правая граница = ");
            int right = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(left, right + 1);
            }
        }

        public static void Print(int[] array)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Join(", ", array));
            Console.ResetColor();
        }

        public static void SpecialPrint(int[] array, int chet)
        {
            bool first = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == chet && !first)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    first = true;
                }
                if (i == array.Length - 1)
                {
                    Console.Write(array[i]);
                }
                else
                {
                    Console.Write(array[i]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(", ");
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
