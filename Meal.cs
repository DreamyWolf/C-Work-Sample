using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace SteakOVERFLOOW
{
    class Meal
    {
        private string name;
        private string type;
        private List<Product> products;
        private int ordered;
        private double price;

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Invalid Command");
                }

                this.name = value;
            }
        }
        public string Type
        {
            get => type;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid Command");
                }

                this.type = value;
            }
        }
        public List<Product> Products
        {
            get => products;
            set => products = value;
        }
        public double Price
        {
            get => price;
            set { price = Products.Sum(p => p.Price) * 1.30; }
        }

        public Meal(string name, string type)
        {
            this.Name = name;
            this.Type = type;
            this.Products = new List<Product>();
        }

        public Meal(string name, string type, List<Product> products)
        {
            this.Name = name;
            this.type = type;
            this.Products = products;
        }

        public int Ordered
        {
            get { return this.ordered; }
        }

        public void AddProduct(Product p)
        {
            products.Add(p);
        }

        public bool ContainsProduct(string name)
        {
            return products.Exists(element => element.Name == name);
        }

        public double CalculatePrice()
        {
            return this.products.Sum(element => element.Price) + this.products.Sum(element => element.Price) * 0.30;
        }

        public void PrintRecipe()
        {
            Console.WriteLine(new String('-', 25));
            Console.WriteLine(this.name + " RECIPE");
            Console.WriteLine(new String('-', 25));
            products.ForEach(element => Console.WriteLine(element));
            Console.WriteLine(new String('-', 25));
        }

        public void Order()
        {
            this.ordered++;
        }

        public static Meal GetSpecialty(Dictionary<string, Meal> meals)
        {
            return meals.OrderByDescending(element => element.Value.ordered).First().Value;
        }

        public static Meal RecommendByPrice(double price, Dictionary<string, Meal> meals)
        {
            return meals.Where(element => (element.Value.Price <= price))
                .OrderByDescending(element => element.Value.Price).First().Value;
        }

        public static Meal RecommendByPriceAndType(double price, string type, Dictionary<string, Meal> meals)
        {
            return meals.Where(element => (element.Value.Price <= price) && (element.Value.type == type))
                .OrderByDescending(element => element.Value.Price).First().Value;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Type}";
        }
    }
}