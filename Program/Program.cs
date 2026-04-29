using QuadraticSortsInOneDimensionalArray;
using SortInOneDimensionalArray;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива = ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Console.Write("Как заполнить массив? (0 - рандомно, 1 - вручную)\n>> ");
            int typeOfFill = Convert.ToInt32(Console.ReadLine());
            if (typeOfFill == 0)
            {
                ActionWithArray.RandomFill(array);
            }
            else if (typeOfFill == 1)
            {
                ActionWithArray.ManuallyFill(array);
            }
            Console.WriteLine("Массив:");
            ActionWithArray.Print(array);
            Console.WriteLine("Выберете задание, введя его номер из списка:\n1. Разные сортировки массива\n2. Сортировка массива по возрастанию, начиная с первого четного элемента." +
                "\n3. Поиск ai и bj в двух отсортированных по неубыванию массивах при условии того, что ai + bj = S");
            Console.Write(">> ");
            int type = Convert.ToInt32(Console.ReadLine());
            switch (type)
            {
                case 1:
                    {
                        Console.WriteLine("Выберите алгоритм сортировки, введя его номер из списка:" +
                            "\n1. Пузырёк\n2. Пузырёк с флагом\n3. Шейкерная\n4. Методом простого выбора (простой перебор)\n5. Вставками" +
                            "\n6. Сортировка Шелла\n7. Быстрая сортировка\n8. Сортировка слиянием\n9. Сортировка подсчётом\n10. LSD Radix Sort");
                        Console.Write(">> ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                {
                                    QuadraticSort.Bubble(array);
                                    break;
                                }
                            case 2:
                                {
                                    QuadraticSort.BubbleWithFlag(array);
                                    break;
                                }
                            case 3:
                                {
                                    QuadraticSort.Shaker(array);
                                    break;
                                }
                            case 4:
                                {
                                    QuadraticSort.SimpleChoice(array);
                                    break;
                                }
                            case 5:
                                {
                                    QuadraticSort.Insertion(array);
                                    break;
                                }
                            case 6:
                                {
                                    QuadraticSort.Shell(array);
                                    break;
                                }
                            case 7:
                                {
                                    LinearLogarithmicSort.QuickSort(array, 0, array.Length - 1);
                                    break;
                                }
                            case 8:
                                {
                                    LinearLogarithmicSort.MergeSort(array);
                                    break;
                                }
                            case 9:
                                {
                                    LinearSort.Counting(array);
                                    break;
                                }
                            case 10:
                                {
                                    LinearSort.LSDRadix(array);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        Console.WriteLine("Отсортированный массив:");
                        ActionWithArray.Print(array);
                        break;
                    }
                case 2:
                    {
                        int firstChetI = -1;
                        int firstChet = 0;
                        for(int k = 0; k < array.Length; k++)
                        {
                            if (array[k] % 2 == 0 && firstChetI == -1)
                            {
                                firstChetI = k;
                                firstChet = array[k];
                            }
                        }
                        if (firstChetI != -1)
                        {
                            int i, j, temp;
                            for (i = firstChetI + 1; i < array.Length; i++)
                            {
                                for (j = firstChetI + 1; j < array.Length - 1; j++)
                                {
                                    if (array[j] > array[j + 1])
                                    {
                                        temp = array[j];
                                        array[j] = array[j + 1];
                                        array[j + 1] = temp;
                                    }
                                }
                            }
                        }
                        ActionWithArray.SpecialPrint(array, firstChet);
                        break;
                    }
                case 3:
                    {
                        int[] arrayA = array;
                        int[] arrayB = new int[n];
                        Console.Write("Как заполнить второй массив? (0 - рандомно, 1 - вручную)\n>> ");
                        typeOfFill = Convert.ToInt32(Console.ReadLine());
                        if (typeOfFill == 0)
                        {
                            ActionWithArray.RandomFill(arrayB);
                        }
                        else if (typeOfFill == 1)
                        {
                            ActionWithArray.ManuallyFill(arrayB);
                        }
                        Console.WriteLine("Второй массив:");
                        ActionWithArray.Print(arrayB);
                        Console.WriteLine();
                        Console.WriteLine("Отсортированный массив A:");
                        LinearLogarithmicSort.MergeSort(arrayA);
                        ActionWithArray.Print(arrayA);
                        Console.WriteLine("Отсортированный массив B:");
                        LinearLogarithmicSort.MergeSort(arrayB);
                        ActionWithArray.Print(arrayB);
                        Console.Write("Введите S = ");
                        int S = Convert.ToInt32(Console.ReadLine());
                        int countPair = 0;
                        for(int i = 0, j = arrayB.Length - 1; i < arrayA.Length && j >= 0;)
                        {
                            if (arrayA[i] + arrayB[j] == S)
                            {
                                countPair++;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"----- {countPair} -----");
                                Console.ResetColor();
                                Console.WriteLine($"{arrayA[i]} + {arrayB[j]} = {S}");
                                Console.WriteLine($"i = {i}, j = {j}");
                                Console.ResetColor();
                                i++;
                                j--;
                            }
                            else if (arrayA[i] + arrayB[j] < S)
                            {
                                i++;
                            }
                            else
                            {
                                j--;
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            Console.Write("Ещё раз? (0 - нет, 1 - да)\n>> ");
            int repeat = Convert.ToInt32(Console.ReadLine());
            if (repeat == 1)
            {
                Main(args);
            }
        }
    }
}