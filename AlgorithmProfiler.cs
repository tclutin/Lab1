using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_algorithm
{
    public class AlgorithmProfiler
    {
        public Random random = new Random();
        public Stopwatch stopwatch = new Stopwatch();

        public int[] GenerateVector(int n)
        {
            int[] vector = new int[n];
            for (int i = 0; i < n; i++)
            {
                vector[i] = random.Next(1, 1000);
            }
            return vector;

        }
        public double MeasureSpeed(int[] vector, Action<int[]> algorithm)
        {
            stopwatch.Reset();
            stopwatch.Start();
            algorithm(vector);
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalSeconds;
        }

        public void Run(string name, int lenOfArray, int countOfStart, Action<int[]> algorithm)
        {
            int[] vector = GenerateVector(lenOfArray);
            for (int n = 1; n <= vector.Length; n++)
            {
                double totalTime = 0;
                int[] segment = new ArraySegment<int>(vector, 0, n).ToArray();

                for (int i = 0; i < countOfStart; i++)
                {
                    double runTime = MeasureSpeed(segment, algorithm);
                    totalTime += runTime;
                }
                double averageTime = totalTime / 5;
                WriteToFile(name, $"{n};{averageTime.ToString("F8")}\n");
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
