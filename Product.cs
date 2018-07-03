using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace SteakOVERFLOOW
{
    class Product
    {
        private string name;
        private double price;
        private int weight;

        public double Price
        {
            get => price;
            set
            {
                if (value <= 0.01)
                {
                    throw new ArgumentException("Invalid Command");
                }

                this.price = value;
            }
        }
        public int Weight
        {
            get => weight;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid Command");
                }

                this.weight = value;
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("Invalid Command");
                }

                this.name = value;
            }
        }

        public Product(string name, double price, int weight)
        {
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }

        public static Product GetCheapestProduct(Dictionary<string, Product> products)
        {
            return products.OrderBy(element => element.Value.Price).First().Value;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Weight}";
        }
    }
}
