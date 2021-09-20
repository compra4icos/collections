using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            foreach (int item in list) 
            {
                Console.WriteLine(item);
            }

            list.Clear();

            foreach (int item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}
