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

        public static void Main(string[] args)
        {

            AlgorithmProfiler profiler = new AlgorithmProfiler();

            profiler.Run("TimSortProfiler", 2000, 5, Algorithms.Sort.TimSort);
            profiler.Run("BubblerProfiler", 2000, 5, Algorithms.Sort.BubbleSort);
            profiler.Run("MergeProfiler", 2000, 5, Algorithms.Sort.MergedSort);

            profiler.Run("SumProfiler", 2000, 5, Algorithms.Arithmetic.SumElementsVector);

            profiler.Run("MultiplyProfiler", 2000, 5, Algorithms.Arithmetic.MultiplyElementsVector);
            profiler.Run("SumProfiler", 2000, 5, Algorithms.Arithmetic.SumElementsVector);


            /*debug
            var x = measurement.GenerateVector(5);

            foreach ( var v in x )
            {
                Console.WriteLine(v);
            }
            for (int n = 1; n <= x.Length; n++)
            {
                var segment = new ArraySegment<int>(x, 0, n).ToArray();
                foreach (var item in segment)
                {
                    Console.Write($"arr+{item} ");
                }
                Console.WriteLine();
            }*/
        }
    }
}