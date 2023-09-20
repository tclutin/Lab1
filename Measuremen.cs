using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_algorithm
{
    class Measurement
    {
        public Random random = new Random();
        public Stopwatch stopWatch = new Stopwatch();

        public int[] GenerateVector(int n)
        {
            int[] vector = new int[n];
            for (int i = 0; i < n; i++)
            {
                vector[i] = random.Next(1, 1000);
            }
            return vector;
        }
        public double Start(int[] vector, Action<int[]> operation)
        {
            stopWatch.Reset();
            stopWatch.Start();
            operation(vector);
            stopWatch.Stop();
            return stopWatch.Elapsed.TotalSeconds;
        }
        public void Run(string name, int lenOfArray, int countOfStart, Action<int[]> operation)
        {
            for (int n = 1; n <= lenOfArray; n++)
            {
                double totalTime = 0;
                for (int i = 0; i < countOfStart; i++)
                {
                    int[] vector = GenerateVector(n);
                    double runTime = Start(vector, operation);

                    totalTime += runTime;
                }
                double averageTime = totalTime / 5;
                WriteToFile(name, $"{n}:{averageTime.ToString("F8")}\n");
            }

        }
        public void RunDebug(string name, int lenOfArray, int countOfStart, Action<int[]> operation)
        {
            Console.WriteLine(name);
            for (int n = 1; n <= lenOfArray; n++)
            {
                double totalTime = 0;
                for (int i = 0; i < countOfStart; i++)
                {
                    int[] vector = GenerateVector(n);
                    double runTime = Start(vector, operation);

                    totalTime += runTime;
                    Console.WriteLine($"n = {n}, time = {runTime.ToString("F8")} seconds");
                }
                double averageTime = totalTime / 5;
                WriteToFile(name, $"{n}:{averageTime.ToString("F8")}\n");
                Console.WriteLine($"Average time for item = {n}: {averageTime.ToString("F8")} seconds");
            }

        }

        public void WriteToFile(string name, string text)
        {
            string filePath = Path.Combine(("Data/"));

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            File.AppendAllText(filePath + name + ".csv", text);
        }
    }
}
