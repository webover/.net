using System;

namespace LastWordLength
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a phrase: ");

            string input = Console.ReadLine().Trim();
            int stringLength = input.Length;

            string[] words = input.Split(" ");

            Console.WriteLine("Last word is '{0}' and it has a {1} letters length", words[words.Length - 1], words[words.Length - 1].Length);
        }
    }
}
