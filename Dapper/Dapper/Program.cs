using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Contacs;
using Contacs.Dapper;
using Contactc;
using Dapper;
using TVDBapi;

namespace Contactc
{

    public class Program
    {
        public static IPlayerRepository PlayerRepository = new PlayerRepository();

        public void InsertPlayer()
        {
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Enter the Fisrt Name, Last Name, Age");
            Console.WriteLine("First Name : ");
            String firstName = Console.ReadLine();
            Console.WriteLine("Last Name : ");
            String lastName = Console.ReadLine();
            Console.WriteLine("Age : ");
            String age = Console.ReadLine();
            Console.WriteLine("TeamId : ");
            String teamId = Console.ReadLine();
            Console.WriteLine("PlayerId : ");
            String Id = Console.ReadLine();


            Player persons = new Player
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                TeamId = int.Parse(teamId),
                Id = int.Parse(Id)


            };
            
            
            PlayerRepository.Add(persons);
            ShowPlayer();




        }

        public void InsertTeam()
        {
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Enter the Team Name, Town");
            Console.WriteLine("Team Name : ");
            String TeamName = Console.ReadLine();
            Console.WriteLine("Town : ");
            String Town = Console.ReadLine();
           


            Team team = new Team()
            {
                TeamName = TeamName,
                Town = Town,
                



            };


            PlayerRepository.Add(team);
            ShowTeam();




        }


        public void ShowPlayer()
        {
            Console.WriteLine(new string('*', 20));
            List<Player> players = PlayerRepository.GetFullPlayer();
            foreach (var cont in players)
            {
                Console.WriteLine(cont.FirstName + " " + cont.LastName + " " + cont.Age + " " + cont.TeamId + " " );
            }
            
        }

        public void ShowTeam()
        {
            Console.WriteLine(new string('*', 20));
            List<Team> teams = PlayerRepository.GetAll();
            foreach (var cont in teams)
            {
                Console.WriteLine(cont.Id + " " + cont.TeamName + " " + cont.Town + " " + cont.Id + " ");
            }

        }


        public void UpdatingData()
        {
            Console.WriteLine(new string('*', 20));
            //Updating
            Console.WriteLine("What Id do u want to Update");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What do u want to update...");
            Console.WriteLine("FirstName press 1 ");
            Console.WriteLine("last name press 2 ");
            Console.WriteLine("Age press 3 ");
            int ch = Convert.ToInt32(Console.ReadLine());
            Player player = PlayerRepository.GetFullPlayer(id);
            String Name = null;
            switch (ch)
            {
                case 1:
                    Console.WriteLine("First Name: ");
                    String FirstName = Console.ReadLine();
                    player.FirstName = FirstName;
                    Name = FirstName;
                    PlayerRepository.Update(player);
                    Find(id);
                    break;

                case 2:
                    Console.WriteLine("Last Name: ");
                    String LastName = Console.ReadLine();
                    player.LastName = LastName;
                    Name = LastName;
                    PlayerRepository.Update(player);
                    Find(id);
                    break;

                case 3:
                    Console.WriteLine("Age: ");
                    String Age = Console.ReadLine();
                    player.Age = Age;
                    Name = Age;
                    PlayerRepository.Update(player);
                    Find(id);
                    break;

            }


        }

        private void Find(int id)
        {
            Console.WriteLine(new string('*', 20));
            Player person2 = PlayerRepository.Find(id);
            if (person2 != null)
            {
                Console.WriteLine(person2.Id + " " + person2.FirstName + " " + person2.LastName + " " + person2.Age+ " "+ person2.TeamId);
            }
        }

        public void DeletePlayer()
        {
            Console.WriteLine(new string('*', 20));
            ShowPlayer();
            Console.WriteLine(new string('*', 20));

            Console.WriteLine("what do u want to delate: ");
            int id = Convert.ToInt32(Console.ReadLine());
            PlayerRepository.Remove(id);
            Player per = PlayerRepository.Find(id);
            if (per == null)
            {
                Console.WriteLine("Usunieto");
            }
            Console.WriteLine(new string('*', 20));
            ShowPlayer();

        }

        public void SelectOption()
        {
            Console.WriteLine(new string('*', 20));

            // Console.WriteLine("Jebane gówno :");
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("For...");
            Console.WriteLine("Show Team Select 1");
            Console.WriteLine("Insert Player Select 2");
            Console.WriteLine("Update Player Select 3");
            Console.WriteLine("Delete Player Select 4");
            Console.WriteLine("Insert Team Select 5");
            Console.WriteLine("Show Player Select 6");
            Console.WriteLine();
            Console.Write("Your Selection :  ");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    ShowTeam();
                    break;
                case 2:
                    InsertPlayer();
                    break;
                case 3:
                    UpdatingData();
                    break;
                case 4:
                    DeletePlayer();
                    break;
                case 5:
                    InsertTeam();
                    break;
                case 6:
                    ShowPlayer();
                    break;
                default:
                    break;
            }

            Console.WriteLine(new string('*', 20));
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.SelectOption();


            Console.ReadLine();
        }
    }
}
