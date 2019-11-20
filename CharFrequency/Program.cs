using System;
using System.Collections.Generic;

namespace CharFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string:");
            string input = Console.ReadLine();
            Dictionary<char, int> listDictionary = new Dictionary<char, int>();

            foreach (char c in input)
            {
                if (!listDictionary.ContainsKey(c))
                {
                    listDictionary.Add(c, 1);
                }
                else
                {
                    int count = 0;
                    listDictionary.TryGetValue(c, out count);
                    listDictionary.Remove(c);
                    listDictionary.Add(c, count + 1);
                }
            }

            foreach (KeyValuePair<char, int> keyValuePair in listDictionary)
            {
                Console.WriteLine("Char {0} was counted {1} time{2}", keyValuePair.Key, keyValuePair.Value, (keyValuePair.Value > 1 ? "s" : ""));
            }
        }
    }
}
