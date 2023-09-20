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
            //measurement.Run("Tim", 2000, 5, Algorithms.Sort.TimSort);
           // measurement.Run("Merge", 2000, 5, Algorithms.Sort.MergedSort);
            measurement.RunDebug("Bubble", 20222, 5, Algorithms.Sort.BubbleSort);
         //   measurement.Run("Sum", 2000, 5, Algorithms.Arithmetic.SumElementsVector);
        }
    }
}