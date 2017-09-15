using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Test
{
    public class Video
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
    public class VideoRepository
    {
        public List<Video> Cart()
        {
            return new List<Video>()
            {
                new Video() { Title = "Video1", Price = 5, Quantity = 0 },
                new Video() { Title = "Video2", Price = 10, Quantity = 0 },
                new Video() { Title = "Video3", Price = 15, Quantity = 0 },
                new Video() { Title = "Video4", Price = 15, Quantity = 0 },
            };
        }
        public List<Video> Videos()
        {
            return new List<Video>()
            {
                new Video() { Title = "Video1", Price = 5, Quantity = 3 },
                new Video() { Title = "Video2", Price = 10, Quantity = 2 },
                new Video() { Title = "Video3", Price = 15, Quantity = 1 },
                new Video() { Title = "Video4", Price = 15, Quantity = 0 },
            };
        }
    }
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsLogged;

    }
    public class LoginRepository
    {
        public List<Login> Logins()
        {
            return new List<Login>()
            {
                new Login() { UserName = "Admin", Password = "12345", IsLogged = false},
                new Login() { UserName = "User", Password = "12345", IsLogged = false },
            };
        }
    }
    class Program
    {
        public static void Menu()
        {
            Console.WriteLine("VideoStore!");
            Console.WriteLine("Type '1' for login user");
            Console.WriteLine("Type '2' for Show videos");
            Console.WriteLine("Type '3' for borrow videos");
            Console.WriteLine("Type '4' for check the cart");

        }
        public static void Main(string[] args)
        {
            var log = new LoginRepository();
            var login = log.Logins();
            var videos = new VideoRepository();
            var getVideos = videos.Videos();
            var shoppingCart = videos.Cart();


            while (true)
            {
                var checkIsLogged = login.Any(x => x.IsLogged);

                Menu();
                var input = Console.ReadLine();
                Console.Clear();


                switch (input)
                {
                    case "1":
                        if (checkIsLogged)
                        {
                            Console.WriteLine("You Already logged");
                            continue;
                        }
                        Console.WriteLine("Enter UserName");
                        var userName = Console.ReadLine();
                        Console.WriteLine("Enter Password");
                        var password = Console.ReadLine();

                        var findLog = login.FirstOrDefault(x => x.UserName == userName && x.Password == password);
                        if (findLog != null)
                        {
                            findLog.IsLogged = true;
                            Console.WriteLine("You succesfull loggin in: " + findLog.UserName);
                            Thread.Sleep(1000);
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Wrong ussername or password");
                            continue;
                        }
                    case "2":
                        foreach (var video in getVideos)
                        {
                            Console.WriteLine("Title: {0}, Price: {1}, Quantity: {2}", video.Title, video.Price,
                                video.Quantity);
                        }
                        continue;
                    case "3":
                        if (checkIsLogged)
                        {
                            Console.WriteLine("What video do u wanna borrow?");
                            var pickVideo = Console.ReadLine();
                            var checkIsAvailable = getVideos.FirstOrDefault(x => x.Title == pickVideo && x.Quantity > 0);
                            var shopcart = shoppingCart.FirstOrDefault(x => x.Title == pickVideo);

                            if (checkIsAvailable != null)
                            {
                                if (shopcart != null) shopcart.Quantity++;

                                Console.WriteLine("");
                                checkIsAvailable.Quantity--;
                                Console.WriteLine("You borrowed video!");
                                continue;
                            }
                            Console.WriteLine("We don't have video or it's not available");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("You need to log");
                            Thread.Sleep(1000);
                            Console.Clear();
                            continue;
                        }

                    case "4":
                        if (checkIsLogged)
                        {
                            foreach (var video in shoppingCart)
                            {
                                Console.WriteLine("Your cart:");
                                if (video.Quantity != 0)
                                {
                                    Console.WriteLine("Title: {0}, Price: {1}, Quantity: {2}", video.Title, video.Price, video.Quantity);
                                }

                            }
                            var calcShopping = shoppingCart.Where(x => x.Quantity > 0);
                            var enumerable = calcShopping as IList<Video> ?? calcShopping.ToList();
                            foreach (var s in enumerable)
                            {
                                s.Price *= s.Quantity;

                            }
                            var totalPrice = enumerable.Sum(x => x.Price);
                            Console.WriteLine("Total price: " + totalPrice);
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("You need to log");
                            Thread.Sleep(1000);
                            continue;
                        }

                }
                break;
            }
        }

    }
}
