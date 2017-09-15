using System;
using System.Collections.Generic;

namespace ControlFlowExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>();
            while (numbers.Count <5)
            {
                Console.WriteLine("Enter a number: ");
                var number = Convert.ToInt32(Console.ReadLine());
                if (numbers.Contains(number))
                {
                    Console.WriteLine("Try again you entered this number");
                    continue;
                }
                numbers.Add(number);
            }
            numbers.Sort();
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}

