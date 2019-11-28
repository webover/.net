using System;
using System.Collections.Generic;

namespace ReverseLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] defaults = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            LinkedList<int> list = new LinkedList<int>(defaults);

            var nextNode = list.First;

            LinkedList<int> reversedList = Reverse(nextNode, list);
            //LinkedList<int> reversedList = ReverseSecond(list);

            Console.WriteLine("initial list was {0} -> reversed -> {1}", String.Join("", defaults), String.Join("", reversedList));

        }

        private static LinkedList<int> Reverse(LinkedListNode<int> node, LinkedList<int> list)
        {
            if (node.Next != null)
            {
                var next = node.Next;
                list.Remove(next);
                list.AddFirst(next.Value);

                return Reverse(node, list);
            }
            else
            {
                return list;
            }
        }

        private static LinkedList<int> ReverseSecond(LinkedList<int> list)
        {
            var startNode = list.First;

            while (startNode != null)
            {
                var nextNode = startNode;

                while (nextNode.Next != null)
                {
                    var next = nextNode.Next;
                    list.Remove(next);
                    list.AddFirst(next.Value);
                    // Console.WriteLine("Checking for " + next.Value);
                }

                startNode = startNode.Next;
            }

            return list;
        }
    }
}
