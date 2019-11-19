using System;
using System.Collections.Generic;

namespace Majority
{
    class Majority
    {
        private static void Main()
        {
            int[] unsortedArray = { 0, 1, 1, 2, 3, 7, 7, 7, 7, 0, 7, 7, 7, 3, 4, 7, 7, 7, 7, 7, 7 };

            Dictionary<int, int> listDictionary = new Dictionary<int, int>();
            //SortedList<int, int> listDictionary = new SortedList<int, int>();

            foreach (int item in unsortedArray)
            {
                if (!listDictionary.ContainsKey(item))
                {
                    listDictionary.Add(item, 1);
                }
                else
                {
                    int count = 0;
                    listDictionary.TryGetValue(item, out count);
                    listDictionary.Remove(item);
                    listDictionary.Add(item, count + 1);
                }
            }

            /*
             * Majority Element is the number that appears more than 50% in the array/list 
             */
            bool weHaveAMajorityElement = false;

            foreach (KeyValuePair<int, int> keyValuePair in listDictionary)
            {
                if (keyValuePair.Value > unsortedArray.Length / 2)
                {
                    weHaveAMajorityElement = true;

                    float percentage = keyValuePair.Value * 100 / unsortedArray.Length;

                    Console.WriteLine("The Majority Elements for array [{0}] will be {1} with a usage percentage of {2}%", string.Join(",", unsortedArray), keyValuePair.Key, percentage);
                }
            }

            if (!weHaveAMajorityElement)
            {
                Console.WriteLine("We have no majority element for this array: [{0}]", string.Join(",", unsortedArray));
            }
        }
    }
}
