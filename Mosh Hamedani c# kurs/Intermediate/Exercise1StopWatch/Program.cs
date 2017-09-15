using System;
using System.Threading;

namespace Exercise1StopWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            for (int i = 0; i < 2; i++)
            {
                stopwatch.start();
                Thread.Sleep(1000);

                stopwatch.stop(DateTime.Now);

                Console.WriteLine(stopwatch.getInterval());
                Console.WriteLine("press enter to run the stopwatch again");
                Console.ReadLine();
            }
        }
    }
}
