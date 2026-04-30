namespace QuadraticSortsInOneDimensionalArray
{
    public class QuadraticSort
    {
        public static void Bubble(int[] array)
        {
            int i, j, temp;
            for (i = 1; i < array.Length; i++)
            {
                for (j = 0; j < array.Length - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
                //ActionWithArray.Print(array);
            }
        }

        public static void BubbleWithFlag(int[] array)
        {
            int i, j, t;
            bool exchange;
            i = 1;
            do
            {
                exchange = false;
                for (j = 0; j < array.Length - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        t = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = t;
                        exchange = true;
                    }
                }
                i++;
                //ActionWithArray.Print(array);
            }
            while (exchange);
        }

        public static void Shaker(int[] array)
        {
            int i, j, t, k;
            int L = 0, R = array.Length - 1;
            k = R;
            do
            {
                for (j = R; j > L; j--)
                    if (array[j - 1] > array[j])
                    {
                        t = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = t;
                        k = j;
                    }
                L = k;
                for (j = L; j < R; j++)
                    if (array[j] > array[j + 1])
                    {
                        t = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = t;
                        k = j;
                    }
                R = k;
                //ActionWithArray.Print(array);
            }
            while (L < R);
        }

        public static void SimpleChoice(int[] array)
        {
            int i, j, imin, t;
            for (i = 0; i < array.Length - 1; i++)
            {
                imin = i;
                for (j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[imin])
                        imin = j;
                }
                t = array[i];
                array[i] = array[imin];
                array[imin] = t;
                //ActionWithArray.Print(array);
            }
        }

        public static void Insertion(int[] array)
        {
            int i, j, t;
            for (i = 1; i < array.Length; i++)
            {
                t = array[i];
                for (j = i - 1; j >= 0 && array[j] > t; j--)
                {
                    array[j + 1] = array[j];
                }
                array[j + 1] = t;
                //ActionWithArray.Print(array);
            }
        }

        public static void Shell(int[] array)
        {
            int i, j, step, temp;
            for (step = array.Length / 2; step > 0; step /= 2)
            {
                for (i = step; i < array.Length; i++)
                {
                    temp = array[i];
                    for (j = i; j >= step; j -= step)
                    {
                        if (temp < array[j - step])
                        {
                            array[j] = array[j - step];
                        }
                        else
                        {
                            break;
                        }
                    }
                    array[j] = temp;
                }
            }
        }
    }
}
