using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Arithmetic
    {
        public static void SumElementsVector(int[] vector)
        {
            long result = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                result += vector[i];
            }
        }

        public static void MultiplyElementsVector(int[] vector)
        {
            long result = 1;
            for (int i = 0; i < vector.Length; i++)
            {
                result *= vector[i];
            }
        }
    }

    public class Others
    {
    }
}
