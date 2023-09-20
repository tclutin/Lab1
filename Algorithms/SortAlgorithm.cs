using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Sort
    {
        public static void TimSort(int[] arr)
        {
            int minRun = 32;
            int len = arr.Length;

            for (int i = 0; i < len; i += minRun)
            {
                InsertionSortBoost(arr, i, Math.Min((i + minRun - 1), (len - 1)));
            }

            for (int size = minRun; size < len; size = 2 * size)
            {
                for (int left = 0; left < len; left += 2 * size)
                {
                    int mid = Math.Min((left + size - 1), (len - 1));
                    int right = Math.Min((left + 2 * size - 1), (len - 1));

                    if (mid < right)
                    {
                        MergedSortBoost(arr, left, mid, right);
                    }
                }
            }
        }
        private static void InsertionSortBoost(int[] arr, int start, int end)
        {
            for (int i = start + 1; i <= end; i++)
            {
                int temp = arr[i];
                int j = i - 1;

                while (j >= start && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = temp;
            }
        }
        private static void MergedSortBoost(int[] arr, int left, int mid, int right)
        {
            int len1 = mid - left + 1;
            int len2 = right - mid;

            int[] leftArr = new int[len1];
            int[] rightArr = new int[len2];

            for (int i = 0; i < len1; i++)
            {
                leftArr[i] = arr[left + i];
            }

            for (int i = 0; i < len2; i++)
            {
                rightArr[i] = arr[mid + i + 1];
            }

            int a = 0;
            int b = 0;
            int c = left;

            while (a < len1 && b < len2)
            {
                if (leftArr[a] < rightArr[b])
                {
                    arr[c] = leftArr[a];
                    a++;
                }
                else
                {
                    arr[c] = rightArr[b];
                    b++;
                }
                c++;
            }

            while (a < len1)
            {
                arr[c] = leftArr[a];
                a++;
                c++;
            }

            while (b < len2)
            {
                arr[c] = rightArr[b];
                b++;
                c++;
            }
        }

        public static void BubbleSort(int[] vector)
        {
            for (int i = 0; i < vector.Length - 1; i++)
            {
                for (int j = 0; j < vector.Length - i - 1; j++)
                {
                    if (vector[j] > vector[j + 1])
                    {
                        int n = vector[j];
                        vector[j] = vector[j + 1];
                        vector[j + 1] = n;
                    }
                }
            }
        }
        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = temp;
            }
        }
        public static void MergedSort(int[] arr)
        {
            if (arr.Length > 1)
            {
                int mid = (arr.Length) / 2;

                int[] leftArr = new int[mid];
                int[] rightArr = new int[arr.Length - mid];

                for (int i = 0; i < mid; i++)
                {
                    leftArr[i] = arr[i];
                }

                for (int i = mid; i < arr.Length; i++)
                {
                    rightArr[i - mid] = arr[i];
                }

                MergedSort(leftArr);
                MergedSort(rightArr);

                int a = 0;
                int b = 0;
                int c = 0;

                while (a < leftArr.Length && b < rightArr.Length)
                {
                    if (leftArr[a] < rightArr[b])
                    {
                        arr[c] = leftArr[a];
                        a += 1;
                    }
                    else
                    {
                        arr[c] = rightArr[b];
                        b += 1;
                    }
                    c += 1;
                }

                while (a < leftArr.Length)
                {
                    arr[c] = leftArr[a];
                    a += 1;
                    c += 1;
                }

                while (b < rightArr.Length)
                {
                    arr[c] = rightArr[b];
                    b += 1;
                    c += 1;
                }
            }
        }
    }
}
