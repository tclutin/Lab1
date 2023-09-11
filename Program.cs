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
                vector[i] = random.Next(1, 10);
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

        public static void PrintVector(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                Console.WriteLine(vector[i]);
            }
        }

        public static double Run(int n, Func<int[], long> operation)
        {
            int[] vector = GenerateVector(n);
            stopWatch.Start();
            operation(vector);
            stopWatch.Stop();
            return stopWatch.Elapsed.TotalSeconds;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Multiply: ");
            for (int n = 0; n <= 2000; n++)
            {
                double totalTime = 0;
                for (int i = 0; i < 5; i++)
                {
                    double runTime = Run(n, MultiplyElementsVector);

                    totalTime += runTime;
                    Console.WriteLine($"n = {n}, time = {runTime.ToString("F8")} seconds");
                }
                double averageTime = totalTime / 5;
                Console.WriteLine($"Average time for item = {n}: {averageTime.ToString("F8")} seconds");
            }
        }
    }
}