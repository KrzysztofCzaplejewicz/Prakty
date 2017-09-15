using System;
using System.Collections.Generic;

namespace TextExercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a few numbers separated by a hyphen");
            var input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input))
            {
                return;
            }

            var numbers = new List<int>();
            foreach (var number in input.Split("-"))
            {
                numbers.Add(Convert.ToInt32(number));
            }

            var uniques = new List<int>();
            var includeDuplicates = false;
            foreach (var number in numbers)
            {
                if (!uniques.Contains(number))
                {
                    uniques.Add(number);
                }
                else
                {
                    includeDuplicates = true;
                    break;
                }
            }
            if (includeDuplicates)
            {
                Console.WriteLine("duplicated");
            }
        }
    }
}
