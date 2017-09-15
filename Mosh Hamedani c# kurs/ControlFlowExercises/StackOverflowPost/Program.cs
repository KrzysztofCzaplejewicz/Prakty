using System;
using System.Collections.Generic;

namespace StackOverflowPost
{
    public class Post
    {
        public static string Title { get; set; }
        public static string Description { get; set; }
        public static DateTime CreateTime = DateTime.Now;

        public static int VoteUp = 0;
        public static int VoteDown = 0;

        public static List<string> CreatePost(List<string> post)
        {
            Console.WriteLine("Please set the title of you Post: ");
            Title = Console.ReadLine();
            Console.WriteLine("Please set the description: ");
            Description = Console.ReadLine();


            Post.Voting();


            Console.WriteLine("Title: {0} \nDescription: {1}", Title, Description);
            Console.WriteLine("VoteUp: {0}", VoteUp);
            Console.WriteLine("VoteDown: {0}", VoteDown);
            Console.WriteLine("Post Created: {0}", CreateTime);

            return post;
        }



        public static void Voting()
        {
            while (true)
            {
                Console.WriteLine("Type 'voteup' or 'votedown' to vote or type 'exit' for exit");
                var input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }
                else if (input.ToLower() == "voteup")
                {
                    VoteUp++;
                }
                else if (input.ToLower() == "votedown")
                    VoteDown++;
                else
                    continue;
            }
            return;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Post.CreatePost(new List<string>());
        }
    }
}
