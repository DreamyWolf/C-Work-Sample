using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks
{
    class Truck
    {
        private string name;
        private double loadCapacity;
        private List<Freight> freights;

        public Truck(string name, double loadcapacity)
        {
            Name = name;
            LoadCapacity = loadcapacity;
            Freights = new List<Freight>();
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

        public double LoadCapacity
        {
            get => loadCapacity;
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Weight cannot be negative");
                }

                loadCapacity = value;
            }
        }

        public IReadOnlyList<Freight> Freights
        {
            get => freights.AsReadOnly();
        }

        public string AddFreight(Freight freight)
        {
            double capacityLeft = loadCapacity - this.Freights.Sum(f => f.Weight);
            if (capacityLeft<freight.Weight)
            {
                throw new ArgumentException($"{this.name} can't loaded {freight.Name}");
            }
            this.freights.Add(freight);
            return this.Name + " loaded " + freight.Name;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name).Append(" - ");
            if (this.Freights.Count == 0)
            {
                sb.Append("Nothing loaded");
            }
            else
            {
                sb.Append(string.Join(", ", this.Freights));
            }
            return sb.ToString();    
        }
    }
}

