using System;
using System.Globalization;

namespace RangeException
{
    class Program
    {

        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;

            Console.Write($"Choose a number between {start} and {end}: ");

            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new InvalidRangeException<int>($"The range should be between {start} and {end}!", start, end);
            }

            Console.Write("Enter date in format dd-mm-yyyy: ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd-mm-yyyy", CultureInfo.InvariantCulture);

            DateTime startDate = DateTime.Parse("01-01-1980");
            DateTime endDate = DateTime.Parse("01-01-2020");

            if (date < startDate || date > endDate)
            {
                throw new InvalidRangeException<DateTime>($"Accepted range is between {String.Format("{0:dd-MM-yyyy}", startDate)} and {String.Format("{0:dd-MM-yyyy}", endDate)}!", startDate, endDate);
            }
        }
    }
}
