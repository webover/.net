using System;
using System.Collections.Generic;

namespace IEnumerableExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 3, 4, 6, 7, 5, 2, 1 };

            int sum = list.Sum();

            Console.WriteLine($"Int Sum {sum}");

            List<double> listDouble = new List<double> { 3.2, 4.3, 6.4, 7.3, 5.3, 2.1, 1.5 };

            double sumDouble = listDouble.Sum();

            Console.WriteLine($"Double Sum {sumDouble}");

            List<int?> nullableList = new List<int?> { 1, 2, null, 1, 2, 3, null };

            int? nullableSum = nullableList.Sum();

            Console.WriteLine($"Nullable Sum {nullableSum}");

            int min = list.Min();

            Console.WriteLine($"Int Min {min}");

            double doubleMin = listDouble.Min();

            Console.WriteLine($"Double Min {doubleMin}");

            List<double?> listDoubleNullable = new List<double?> { 3.2, 4.3, null, 7.3, 5.3, null, 1.9 };

            double? nullableMin = listDoubleNullable.Min();

            Console.WriteLine($"Nullable double Min {nullableMin}");

            int max = list.Max();

            Console.WriteLine($"Max {max}");

            double? maxNullable = listDoubleNullable.Max();

            Console.WriteLine($"Nullable Max {maxNullable}");

            int product = list.Product();

            Console.WriteLine($"Product {product}");

            double? productNullable = listDoubleNullable.Product();

            Console.WriteLine($"Nullable Product {productNullable}");

            int average = list.Average();

            Console.WriteLine($"Int Average {average}");

            double averageDouble = listDouble.Average();

            Console.WriteLine($"Double Average {averageDouble}");

            double? averageDoubleNullable = listDoubleNullable.Average();

            Console.WriteLine($"Double Nullable Average {averageDoubleNullable}");

        }
    }
}
