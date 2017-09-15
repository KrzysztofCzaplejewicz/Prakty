using System.Threading;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new Text();
            text.Height = 200;
            text.Copy();
            text.Duplicate();

            Thread.Sleep(2000);
        }
    }
}
