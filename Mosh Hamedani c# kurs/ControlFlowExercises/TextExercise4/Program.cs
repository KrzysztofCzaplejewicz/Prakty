using System;

namespace TextExercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a few words separated by a space.");
            var input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("error");
                return;
            }
            var variablename = "";
            foreach (var word in input.Split(" "))
            {
                var wordInPascalCase = char.ToUpper(word[0]) + word.ToLower().Substring(1);
                variablename += wordInPascalCase;
            }
            Console.WriteLine(variablename);
        }
    }
}
