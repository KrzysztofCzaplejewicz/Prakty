using System;
using System.Collections.Generic;
using System.IO;

namespace FileExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Prakty\\test.txt";
            var x = File.ReadAllText(path);
            var split = x.Split(" ");
            var list = new List<string>();
            foreach (var s in split)
            {
                list.Add(s);
            }
            var longest = list[0];
            foreach (var word in list)
            {
                if (word.Length > longest.Length)
                {
                    longest = word;
                }
                
            }
            Console.WriteLine(longest);

            var count = list.Count;
            Console.WriteLine(count);
            Console.WriteLine(x);
        }
    }
}
