using System;
using System.Linq;
using System.Threading;

namespace VideoStore
{
    public class Program
    {

        static void Main(string[] args)
        {
            var log = new LoginRepository();
            var b = new VideoRepository();
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
                            var videos = b.GetVideos();
                            foreach (var v in videos)
                            {
                                Console.WriteLine("Title: " + v.Title + " " + "Price: " + v.Price + " " + "Quantity: " + v.Quantity);
                            }
                        }
                        else
                        {
                            repeat = false;
                        }
                    }
                    while (repeat == true);
                    Console.Clear();
                    Main(args);
                    break;

                case "2":
                    do
                    {

                        var login = log.GetLogins();

                        Console.Clear();
                        Console.WriteLine("Insert the Username: ");
                        //var login = new Login();
                        var userName = Console.ReadLine();
                        Console.WriteLine("Please insert the Password");
                        var password = Console.ReadLine();

                        var findUSer = login.FirstOrDefault(x => x.UserName == userName && x.Password == password);


                        if (findUSer != null)
                        {

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You Succesfull login " + findUSer.UserName);
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(1000);
                            Console.Clear();
                            Main(args);


                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong Password or Username");
                            Console.ForegroundColor = ConsoleColor.White;
                            //Console.WriteLine("Try Again?");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Main(args);

                        }

                    } while (repeat == true);
                    Console.Clear();
                    Main(args);
                    break;

                case "3":
                    {
                        Console.WriteLine("Are you logged?");
                        var videos = b.GetVideos();
                        Console.WriteLine("What Video do u want to borrow?");
                        var pickVideo = Console.ReadLine();
                        var findVideo = videos.FirstOrDefault(x => x.Title == pickVideo && x.Quantity > 0);
                        if (findVideo != null)
                        {
                            findVideo.Quantity--;
                            Console.WriteLine("You borrowed the " + findVideo.Title);
                            Thread.Sleep(1000);
                            Console.Clear();
                            Main(args);
                        }
                        else
                        {
                            Console.WriteLine("You can't borrow the Video");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Main(args);
                        }
                    }
                    while (false) ;
                    Console.Clear();
                    Main(args);
                    break;

                case "4":
                    {

                    }
                    while (repeat == true) ;
                    Console.Clear();
                    Main(args);
                    break;

                case "5":
                    {
                        Console.WriteLine("ByeBye");
                        Thread.Sleep(700);
                        break;
                    }


            }

        }

    }

}





