using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks
{
    class Program
    {
        static void Main(string[] args)
        {
            var trucks = new Dictionary<string, Truck>();
            var freights = new Dictionary<string, Freight>();

            AddTrucks(trucks);
            AddFreights(freights);
            AddFreightsToTrucks(trucks, freights);
            Console.WriteLine();
            PrintTrucks(trucks);
        }

        private static void PrintTrucks(Dictionary<string, Truck> trucks)
        {
            foreach (var truck in trucks.Values)
            {
                Console.WriteLine(truck);
            }
        }

        private static void AddFreightsToTrucks(Dictionary<string, Truck> trucks, Dictionary<string, Freight> freights)
        {
            string[] commandArgs = Console.ReadLine().Split(' ');
            while (commandArgs[0] != "END")
            {
                string truckName = commandArgs[0];
                string freightName = commandArgs[1];

                Truck truck = trucks[truckName];
                Freight freight = freights[freightName];
                try
                {
                    Console.WriteLine(truck.AddFreight(freight));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                commandArgs = Console.ReadLine().Split(' ');
            }
        }

        private static void AddFreights(Dictionary<string, Freight> freights)
        {
            string[] freightsInfo = Console.ReadLine()
                .Split(';', '=').Where(e => e != " ").ToArray();
            for (var i = 0; i < freightsInfo.Length - 1; i += 2)
            {
                string freightName = freightsInfo[i];
                double weight = double.Parse(freightsInfo[i + 1]);
                try
                {
                    Freight freight = new Freight(freightName, weight);
                    freights.Add(freightName, freight);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void AddTrucks(Dictionary<string, Truck> trucks)
        {
            string[] trucksInfo = Console.ReadLine()
                .Split(';', '=').Where(e => e != "").ToArray();
            for (var i = 0; i < trucksInfo.Length - 1; i += 2)
            {
                string truckName = trucksInfo[i];
                double capacity = double.Parse(trucksInfo[i + 1]);
                try
                {
                    Truck currenTruck = new Truck(truckName, capacity);
                    trucks.Add(truckName, currenTruck);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return trucks;
        }
    }
}
