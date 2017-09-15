using System;

namespace StackExercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();
            int ini = 5;
            int max = 10;
            for (int i = ini; i <= max; i++)
                stack.Push(i);
            //            stack.Clear();
            for (int i = ini; i <= max; i++)
                Console.WriteLine(stack.Pop());


        }
    }
}
