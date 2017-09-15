using System;

namespace WithInterfaces
{
    public class DisplayMenu
    {
        private readonly ITask _task;


        public DisplayMenu()
        {
        }

        public DisplayMenu(ITask task)
        {
            _task = task;
        }
        public void Display()
        {
            bool repeat = false;
            Console.WriteLine("Welcome to Video Store.");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. See list of all videos.");
            Console.WriteLine("2. Login.");
            Console.WriteLine("3. Borrow a video.");
            Console.WriteLine("4. Return video.");
            Console.WriteLine("5. Exit");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    do
                    {
                        _task.Videos();

                    } while (false);
                    Console.Clear();
                    Display();
                    break;
                case "2":
                    do
                    {
                        _task.LoginUser();
                    } while (true);
                    Console.Clear();
                    Display();
                    break;

                case "3":
                    {
                        _task.BorrowVideo();
                    }
                    while (false) ;
                    Console.Clear();
                    Display();
                    break;
            }
        }


    }
}