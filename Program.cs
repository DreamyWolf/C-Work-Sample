using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string[] command = Console.ReadLine().Split(';');
            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "Team":
                        AddTeam(teams, command);
                        break;
                    case "Add":
                        AddPlayer(teams, command);
                        break;
                    case "Remove":
                        RemovePlayer(teams, command);
                        break;
                    case "Rating":
                        RatingTeam(teams, command);
                        break;
                }

                command = Console.ReadLine().Split(';');
            }

        }

        private static void RatingTeam(Dictionary<string, Team> teams, string[] command)
        {
            Console.WriteLine($"{command[1]} -> {teams[command[1]].Rating}");
        }

        private static void RemovePlayer(Dictionary<string, Team> teams, string[] command)
        {
            if (!teams.ContainsKey(command[1]))
            {
                Console.WriteLine($"Team {command[1]} does not exists.");
                return;
            }

            try
            {
                teams[command[1]].RemovePlayer(command[2]);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddPlayer(Dictionary<string, Team> teams, string[] command)
        {
            Player player = null;
            try
            {
                player = new Player(command[2],
                    int.Parse(command[3]),
                    int.Parse(command[4]),
                    int.Parse(command[5]),
                    int.Parse(command[6]),
                    int.Parse(command[7]));
                if (!teams.ContainsKey(command[1]))
                {
                    Console.WriteLine($"Team {command[1]} does not exists.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            teams[command[1]].AddPlayer(player);
        }

        private static void AddTeam(Dictionary<string, Team> teams, string[] command)
        {
            if (teams.ContainsKey(command[1]))
            {
                Console.WriteLine("Team already exists!");
                return;
            }
            teams.Add(command[1], new Team(command[1]));
        }
    }
}
