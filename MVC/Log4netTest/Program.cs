using System;

namespace Log4netTest
{
    class Program
    {
        

        private static readonly log4net.ILog log
            = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log.Info("Hello logging world!");



            try
            {
                var devideby = 1 - 1;
                var x = 10 / devideby;
            }
            catch (Exception ex)
            {
                log.Error("o kurwa, bład", ex);
            }


            Console.WriteLine("Hit enter");
            Console.ReadLine();
        }
    }
}
