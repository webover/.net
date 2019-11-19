using System;

namespace Homework
{
    class Duplicates
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string for which you want to remove duplicate characters: ");

            string input = Console.ReadLine();

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
