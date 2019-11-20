using System;
using System.Collections.Generic;

namespace DuplicatesLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] duplicatesArray = { 1, 2, 3, 4, 4, 5, 5, 5, 6, 7, 8, 8, 9, 1, 2, 3, 4, 5, 6 };
            LinkedList<int> list = new LinkedList<int>(duplicatesArray);

            var startNode = list.First;

            while (startNode != null)
            {
                var nextNode = startNode;

                //Console.WriteLine("Checking for " + startNode.Value);

                while (nextNode.Next != null)
                {
                    if (nextNode.Next.Value.Equals(startNode.Value))
                    {
                        list.Remove(nextNode.Next);
                    }
                    else
                    {
                        nextNode = nextNode.Next;
                    }
                }

                startNode = startNode.Next;
            }

            Console.WriteLine("initial list was {0} without duplicates is {1}", String.Join("", duplicatesArray), String.Join("", list));
        }
    }
}
