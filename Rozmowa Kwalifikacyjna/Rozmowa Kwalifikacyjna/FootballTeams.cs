//using System;
//using System.Collections.Generic;

//namespace Rozmowa_Kwalifikacyjna
//{
//    public class FootballTeams
//    {
//        public FootballTeams() { }

//        List<string> teams;
//        public void ListInit();


//        public void AddTeams()
//        {
//            Console.WriteLine("Enter a team to be added: ");
//            string userinput = Console.ReadLine();
//            if (teams.Count < 10)
//            {
//                if (userinput != "Colchester")
//                {
//                    teams.Add(userinput);
//                    foreach (var item in teams)
//                        Console.Write(item.ToString() + " ");
//                }
//                else
//                    Console.Write("NOT ALLOWED");
//            }
//            else
//                Console.Write("MAXIMUM LIMIT REACHED");
//        }


//        public void DisplayTeams()
//        {
//            foreach (var item in teams)
//                Console.Write(item.ToString() + " ");
//        }

//        public void TeamSearch()
//        {
//            Console.WriteLine("Please enter the team you wish to search for: ");
//            string userinput = Console.ReadLine();
//            if (teams.Contains(userinput))
//                Console.WriteLine("Success, team " + userinput);
//        }

//        public void Delete()
//        {
//            Console.WriteLine("Enter a team you wish to delete: ");
//            string userinput = Console.ReadLine();
//            teams.Remove(userinput);
//            foreach (var item in teams)
//                Console.Write(item.ToString() + " ");
//        }
//    }
//}