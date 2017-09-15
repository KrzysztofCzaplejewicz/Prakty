using System;

namespace Exercise5Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a series of numbers separated by comma.");
            var input = Console.ReadLine();
            var numbers = input.Split(',');
            var max = Convert.ToInt32(numbers[0]);
            foreach (var str in numbers)
            {
                var number = Convert.ToInt32(str);
                if (number > max)
                {
                    max = number;
                }
            }
            Console.WriteLine("Max is: " + max);

        }
    }
}
