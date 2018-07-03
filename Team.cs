using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamAdvanced
{
    class Team
    {
        private Dictionary<string, Player> players;
        private string name;
        private int rating;

        public Team(string name)
        {
            this.name = name;
            this.players = new Dictionary<string, Player>();
        }
        public string Name
        {
            get => name;
            set
            {
                if (String.IsNullOrEmpty(value) || value.Trim().Length == 0)
                {
                    throw new ArgumentException("Name should not be empty");
                }

                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                return (int)Math.Ceiling(players.Values.Average(p => p.GetStatistics()));
            }

        }

        public void AddPlayer(Player player)
        {
            if (this.players.ContainsKey(player.Name))
            {
                throw new ArgumentException($"{player.Name} is already in {this.name}!");
            }
            else this.players.Add(player.Name, player);
        }
        public void RemovePlayer(string playerName)
        {
            if (this.players.ContainsKey(playerName))
            {
                throw new ArgumentException($"{playerName} is not in {this.name} team.");
            }
            else this.players.Remove(playerName);
        }

    }
}
