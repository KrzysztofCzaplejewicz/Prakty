using System;
using System.Collections.Generic;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>();
            while (true)
            {
                Console.WriteLine("Enter a number or write 'Quit' to exit");
                var input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;
                var number = Convert.ToInt32(input);
                numbers.Add(number);
            }

            var uniques = GetUniques(numbers);
            Console.WriteLine("uniques numbers: ");
            foreach (var unique in uniques)
            {
                Console.WriteLine(unique);
            }
        }

        public static List<int> GetUniques(List<int> numbers)
        {
            var uniques = new List<int>();
            foreach (var number in numbers)
            {
                if (!uniques.Contains(number))
                {
                    uniques.Add(number);
                }

            }
            return uniques;
        }
    }
}
