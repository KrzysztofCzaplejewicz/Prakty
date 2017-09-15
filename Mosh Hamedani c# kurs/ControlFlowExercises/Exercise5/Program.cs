using System;
using System.Collections.Generic;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements;
            while (true)
            {
                Console.WriteLine("enter a list of comma-separated numbers: ");
                var input = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(input))
                {
                    elements = input.Split(",");
                    if (elements.Length >= 5)
                        break;
                }
                Console.WriteLine("Invalid list");
            }
            var numbers = Numbers.GetNumbers(new List<int>(), elements);

            var smallest = Smallest.GetSmallest(new List<int>(), numbers);

            Console.WriteLine("The smallest numbers:");
            foreach (var i in smallest)
            {
                Console.WriteLine(i);
            }
        }
    }
}
