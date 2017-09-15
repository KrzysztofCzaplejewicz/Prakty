using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string>();
            while (true)
            {
                Console.WriteLine("Type a name (or hit 'ENTER' to quit): ");
                var input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                names.Add(input);
            }
            if (names.Count > 2)
            {
                Console.WriteLine("{0}, {1}, and {2} others like your post", names[0], names[1], names.Count - 2);
            }
            else switch (names.Count)
            {
                case 2:
                    Console.WriteLine("{0}, {1} like your post", names[0], names[1]);
                    break;
                case 1:
                    Console.WriteLine("{0} like your post", names[0]);
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
            
        }
    }
}
