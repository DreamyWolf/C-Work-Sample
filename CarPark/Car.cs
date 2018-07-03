using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class Car
    {
        private string manufacturer;
        private string model;
        private double loadCapacity;
        private readonly List<Part> parts = new List<Part>();
        private int Fuel = 100;
        public static int OrdersCount = 0;
        public IReadOnlyCollection<Part> Parts => parts.AsReadOnly();

        public string Manufacturer
        {
            get => manufacturer;
            set
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("Invalid manufacturer name!");
                }

                manufacturer = value;
            }
        }

        public string Model
        {
            get => model;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Invalid model name!");
                }

                model = value;
            }
        }

        public double LoadCapacity
        {
            get => loadCapacity;
            set
            {
                if (value<0.00)
                {
                    throw new ArgumentException("Invalid load capacity!");
                }

                loadCapacity = value;
            }
        }

        public Car(string manufacturer, string model, double loadCapacity)
        {
            Manufacturer = manufacturer;
            Model = model;
            LoadCapacity = loadCapacity;
        }

        

        public void AddPart(Part part)
        {
            parts.Add(part);
        }

        public void AddMultipleParts(List<Part> partsList)
        {
           parts.AddRange(partsList);
        }

        public void RemovePartByName(string s)
        {
            parts.Remove(parts.Single(p => p.Name == s));
        }

        public double GetCarPrice()
        {
            return parts.Sum(x => x.Price);
        }

        public bool ContainsPart(string s) => Parts.Any(x => x.Name == s);

        public Part GetMostExpensivePart() => Parts.OrderByDescending(x => x.Price).First();


        public IEnumerable<Part> GetPartsWithPriceAbove(double minPrice) =>
            Parts.Where(x => x.Price > minPrice);
        

        public void Drive(double distance)
        {
            if (Fuel <=0)
            {
                throw new ArgumentException("Drive is not possible");
            }

            else Fuel -= (int)(distance * LoadCapacity * 0.2);
            
        }
        public override string ToString() =>    
        $@"
{Model} made by {Manufacturer}
Available parts:
{string.Join("\n",parts)}
With total price of: {parts.Sum(p =>p.Price)} lv";
    }
}
