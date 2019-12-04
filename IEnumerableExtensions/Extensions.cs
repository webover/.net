using System;
using System.Collections.Generic;

namespace IEnumerableExtensions
{
    public static class Extensions
    {
        //
        // 
        // 
        public static T Sum<T>(this IEnumerable<T> source) where T : struct
        {
            //Dynamic vs Types
            // https://dev.to/morganw09/benchmarking-and-exploring-c-s-dynamic-keyword-1l5i
            // Overall, if you have a choice to use regular types or dynamic, always go with regular types. The compiler will check your code and then give you better performance.

            var sum = default(T);

            foreach (var number in source)
            {
                sum += (dynamic)number;
            }

            return sum;

            //return source.Aggregate(default(T), (current, number) => (dynamic)current + number);
        }

        public static T? Sum<T>(this IEnumerable<T?> source) where T : struct
        {
            var sum = default(T);

            foreach (var number in source)
            {
                if (number.HasValue)
                {
                    sum += (dynamic)number;
                }
            }

            return sum;
            /*return source.Where(nullable => nullable.HasValue)
                         .Aggregate(
                             default(T),
                             (current, nullable) => (dynamic)current + nullable.GetValueOrDefault());*/
        }
        /*public static V Sum<T, V>(this IEnumerable<T> source, Func<T, V> selector) where V : struct
        {
            return source.Select(selector).Sum();
        }
        public static V? Sum<T, V>(this IEnumerable<T> source, Func<T, V?> selector) where V : struct
        {
            return source.Select(selector).Sum();
        }*/
        public static T Min<T>(this IEnumerable<T> source) where T : struct
        {
            if (source.IsEmpty())
            {
                throw new ArgumentNullException("source");
            }

            T minValue = default(T);
            bool started = false;

            foreach (var num in source)
            {
                if (!started || (dynamic)minValue > num)
                {
                    started = true;
                    minValue = num;
                }
            }

            return minValue;
        }

        public static T? Min<T>(this IEnumerable<T?> source) where T : struct
        {
            if (source.IsEmpty())
            {
                throw new ArgumentNullException("source");
            }

            T minValue = default(T);
            bool started = false;

            foreach (var num in source)
            {
                if (!started || (num.HasValue && (dynamic)minValue > num))
                {
                    started = true;
                    minValue = (dynamic)num;
                }
            }

            return minValue;
        }

        public static T Max<T>(this IEnumerable<T> source) where T : struct
        {
            if (source.IsEmpty())
            {
                throw new ArgumentNullException("source");
            }

            T maxValue = default(T);
            bool started = false;

            foreach (T num in source)
            {
                if (!started || (dynamic)maxValue < num)
                {
                    started = true;
                    maxValue = num;
                }
            }

            return maxValue;
        }

        public static T? Max<T>(this IEnumerable<T?> source) where T : struct
        {
            if (source.IsEmpty())
            {
                throw new ArgumentNullException("source");
            }

            T maxValue = default(T);
            bool started = false;

            foreach (var num in source)
            {
                if (!started || (num.HasValue && (dynamic)maxValue < num))
                {
                    started = true;
                    maxValue = (dynamic)num;
                }
            }

            return maxValue;
        }
        public static T Product<T>(this IEnumerable<T> source) where T : struct
        {
            if (source.IsEmpty())
            {
                throw new ArgumentNullException("source");
            }

            //T product = <T>.MinValue;
            T product = (dynamic)1;

            foreach (var num in source)
            {
                product *= (dynamic)num;
            }

            return product;
        }

        public static T? Product<T>(this IEnumerable<T?> source) where T : struct
        {
            if (source.IsEmpty())
            {
                throw new ArgumentNullException("source");
            }

            //T product = <T>.MinValue;
            T product = (dynamic)1;

            foreach (var num in source)
            {
                if (num.HasValue)
                {
                    product *= (dynamic)num;
                }
            }

            return product;
        }

        public static T Average<T>(this IEnumerable<T> source) where T : struct
        {
            T product = (dynamic)1;
            int count = 0;

            foreach (var num in source)
            {
                count++;
                product *= (dynamic)num;
            }

            return (dynamic)product / count;
        }

        public static T? Average<T>(this IEnumerable<T?> source) where T : struct
        {
            T product = (dynamic)1;
            int count = 0;

            foreach (var num in source)
            {
                count++;

                if (num.HasValue)
                {
                    product *= (dynamic)num;
                }

            }

            return (dynamic)product / count;
        }

        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));

            using (IEnumerator<T> enumerator = enumerable.GetEnumerator())
                return !enumerator.MoveNext();
        }
    }
}
