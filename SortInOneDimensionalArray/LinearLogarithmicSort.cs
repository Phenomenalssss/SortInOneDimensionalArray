using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace SortInOneDimensionalArray
{
    public class LinearLogarithmicSort
    {
        public static void QuickSort(int[] arr, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = arr[(left + right) / 2];
            while (i <= j)
            {
                while (arr[i] < pivot)
                { 
                    i++;
                }
                while (arr[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }
            if (left < j)
            {
                QuickSort(arr, left, j);
            }
            if (i < right)
            {
                QuickSort(arr, i, right);
            }
        }

        public static void MergeSort(int[] arr)
        {
            int n = arr.Length;
            int[] temp = new int[n];

            for(int size = 1; size < n; size *= 2)
            {
                for(int left = 0; left < n - size; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min(left + 2 * size - 1, n - 1);

                    Merge(arr, temp, left, mid, right);
                }
            }
        }

        private static void Merge(int[] arr, int[] temp, int left, int mid, int right)
        {
            int i = left;
            int j = mid + 1;
            int k = left;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                }
            }

            while (i <= mid)
            {
                temp[k++] = arr[i++];
            }

            while (j <= right)
            {
                temp[k++] = arr[j++];
            }

            for (int t = left; t <= right; t++)
            {
                arr[t] = temp[t];
            }
        }
    }
}
