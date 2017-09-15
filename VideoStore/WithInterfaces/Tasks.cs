using System;
using System.Linq;
using System.Threading;
using VideoStore;

namespace WithInterfaces
{
    public class Tasks : ITask
    {


        public void BorrowVideo()
        {
            var menu = new DisplayMenu();
            var b = new VideoRepository();
            Console.WriteLine("Are you logged?");
            var videos = b.GetVideos();
            Console.WriteLine("What Video do u want to borrow?");
            var pickVideo = Console.ReadLine();
            var findVideo = videos.FirstOrDefault(x => x.Title == pickVideo && x.Quantity > 0);
            if (findVideo != null)
            {
                Console.WriteLine("You borrowed the " + findVideo.Title);
                Thread.Sleep(1000);
                //                Console.Clear();
                //                menu.Display();
            }
            else
            {
                Console.WriteLine("You can't borrow the Video");
                Thread.Sleep(1000);
                //                Console.Clear();
                //                menu.Display();
            }
        }

        public void LoginUser()
        {
            var log = new LoginRepository();
            var login = log.GetLogins();
            var menu = new DisplayMenu();

            Console.Clear();
            Console.WriteLine("Insert the Username: ");
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
                menu.Display();



            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong Password or Username");
                Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine("Try Again?");
                Thread.Sleep(1000);
                Console.Clear();
                menu.Display();


            }
        }
        public void Videos()
        {
            var menu = new DisplayMenu();
            var b = new VideoRepository();
            b.GetVideos();
            Console.WriteLine("Show videos");


            //            Console.Clear();
            if (b != null)
            {
                var videos = b.GetVideos();
                foreach (var v in videos)
                {
                    Console.WriteLine("Title: " + v.Title + " " + "Price: " + v.Price + " " + "Quantity: " + v.Quantity);

                }
            }





        }
    }
}