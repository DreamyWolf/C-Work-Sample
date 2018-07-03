using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarPark
{
    public class Part
    {
        private string name;
        private double price;

        public string Name
        {
            get => name;
            set
            {
                if (value.Length<5)
                {
                    throw new ArgumentException("Invalid part name!");
                }

                name = value;
            }
        }

        public double Price
        {
            get => price;
            set
            {
                if (value<0.00)
                {
                    throw new ArgumentException("Price should be positive!");
                }

                price = value;
            }
        }

        public Part(string name,double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public Part(string name)
        {
            this.Name = name;
            this.Price = 25;
        }

        public override string ToString()
        {
            return $"-> {Name} - {Price}";
        }

    }
}