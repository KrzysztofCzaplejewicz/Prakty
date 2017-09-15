namespace WithInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var run = new DisplayMenu(new Tasks());
            run.Display();

        }
    }
}
