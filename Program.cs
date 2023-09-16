using System;
using System.Data;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Lab1_algorithm
{
    public class Program
    {
        public static Random random = new Random();
        public static Stopwatch stopWatch = new Stopwatch();

        public static int[] GenerateVector(int n)
        {
            int[] vector = new int[n];
            for (int i = 0; i < n; i++)
            {
                vector[i] = random.Next(1, 1000);
            }
            return vector;
        }

        public static long SumElementsVector(int[] vector)
        {
            long result = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                result += vector[i];
            }
            return result;
        }

        public static long MultiplyElementsVector(int[] vector)
        {
            long result = 1;
            for (int i = 0; i < vector.Length; i++)
            {
                result *= vector[i];
            }
            return result;
        }

        public static int[] BubbleSort(int[] vector)
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
            return vector;
        }

        public static int FindPivot(int[] vector, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            int temp = 0;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (vector[i] < vector[maxIndex])
                {
                    pivot++;
                    temp = vector[i];
                    vector[i] = vector[pivot];
                    vector[pivot] = temp;
                }
            }
            pivot++;
            temp = vector[maxIndex];
            vector[maxIndex] = vector[pivot];
            vector[pivot] = temp;

            return pivot;
        }
        public static void QuickSort(int[] vector, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return;
            }
            int pivot = FindPivot(vector, minIndex, maxIndex);
            QuickSort(vector, minIndex, pivot - 1);
            QuickSort(vector, pivot + 1, maxIndex);
        }

        public static int QuickPow(int x, int n)
        {
            int c = x;
            int k = n;
            int f;
            if (k % 2 == 1)
                f = c;
            else
                f = 1;
            do
            {
                k = k / 2;
                c = c * c;
                if (k % 2 == 1)
                    f = f * c;
            }
            while (k != 0);
            return f;
        }

        public static void PrintVector(int[] vector)
        {
            foreach (var item in vector)
            {
                Console.WriteLine(item);
            }
        }

        public static double Run(int n, Func<int[], int[]> operation)
        {
            int[] vector = GenerateVector(n);
            stopWatch.Reset();
            stopWatch.Start();
            operation(vector);
            stopWatch.Stop();
            return stopWatch.Elapsed.TotalSeconds;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Bubbler2004: ");
            for (int n = 1; n <= 2000; n++)
            {
                double totalTime = 0;
                for (int i = 0; i < 5; i++)
                {
                    double runTime = Run(n, BubbleSort);

                    totalTime += runTime;
                    Console.WriteLine($"n = {n}, time = {runTime.ToString("F8")} seconds");
                }
                double averageTime = totalTime / 5;
                Console.WriteLine($"Average time for item = {n}: {averageTime.ToString("F8")} seconds");
            }
        }
    }
}