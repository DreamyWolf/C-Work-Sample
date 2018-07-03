using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks
{
    class Freight
    {
        private string name;
        private double weight;

        public Freight(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name
        {
            get => name;
            set
            {
                if (value.Trim().Length == 0)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }
        public double Weight
        {
            get => weight;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Weight cannot be negative");
                }

                weight = value;
            }
        }

        public override string ToString()
        {
            return this.Name ;
        }
    }
}
