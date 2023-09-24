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
            Measurement measurement = new Measurement();
            measurement.Run("TimSort", 2000, 5, Algorithms.Sort.TimSort);
            measurement.Run("MergeSort", 2000, 5, Algorithms.Sort.MergedSort);
            measurement.Run("Sum", 2000, 5, Algorithms.Arithmetic.SumElementsVector);
            measurement.Run("Multiply", 2000, 5, Algorithms.Arithmetic.SumElementsVector);
            measurement.Run("BubbleSort", 2000, 5, Algorithms.Arithmetic.SumElementsVector);
        }
    }
}