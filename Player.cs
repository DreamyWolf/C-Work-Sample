using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamAdvanced
{
    class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int drible;
        private int shooting;
        private int pass;

        public Player(string name, int endurance, int sprint, int drible, int shooting, int pass)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Drible = drible;
            this.Shooting = shooting;
            this.Pass = pass;
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

        private int Endurance
        {
            get => endurance;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }
            }
        }

        private int Sprint
        {
            get => sprint;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }

        private int Drible
        {
            get => drible;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Drible should be between 0 and 100.");
                }

                this.drible = value;
            }
        }

        private int Shooting
        {
            get => shooting;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

        private int Pass
        {
            get => pass;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Pass should be between 0 and 100.");
                }

                this.pass = value;
            }
        }

        public int GetStatistics()
        {
            return (int)Math.Ceiling((Endurance + Sprint + Drible + Shooting + Pass) / 5.0);
        }
    }
}
