using System;

namespace Kwalifikacyjna
{

    public class Program
    {
        public void MainMenu(VideoRepository b)
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
                        b.GetVideos();
                        Console.WriteLine("What do you want to do now?");
                        Console.WriteLine("Show videos? - Press 1.");
                        Console.WriteLine("Go back to main menu? - Press any other button.");
                        ConsoleKeyInfo keyPressed;
                        keyPressed = Console.ReadKey();
                        if (keyPressed.Key == ConsoleKey.D1 || keyPressed.Key == ConsoleKey.NumPad1)
                        {
                            repeat = true;
                            Console.Clear();
                        }
                        else
                        {
                            repeat = false;
                        }
                    }
                    while (repeat == true);
                    Console.Clear();
                    MainMenu(b);
                    break;


            }
        }
    }
}
