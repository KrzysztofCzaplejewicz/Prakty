using System;

namespace TextExercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a time value in the 24-hour time format (e.g. 19:00).");
            var input = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid Time.");
                return;
            }

            var components = input.Split(":");
            if (components.Length != 2)
            {
                Console.WriteLine("Invalid Time.");
                return;
            }

            try
            {
                var hour = Convert.ToInt32(components[0]);
                var minute = Convert.ToInt32(components[1]);
                if (hour <= 23 && hour >= 0 && minute <= 59 && minute >= 0)
                {
                    Console.WriteLine("ok");
                }
                else
                {
                    Console.WriteLine("invalid time");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("invalid time");
                throw;
            }
        }
    }
}
