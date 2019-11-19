using System;

namespace Homework
{
    class Duplicates
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine("Your string is: " + input);

            string withoutDuplicates = removeDuplicate(input);

            Console.WriteLine("String without duplicates will be: " + withoutDuplicates);
        }

        static string removeDuplicate(string input)
        {
            string result = "";

            foreach(char value in input)
            {
                if(result.IndexOf(value) == -1)
                {
                    result += value;
                }
            }

            return result;
        }
    }
}
