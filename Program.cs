using System;
using System.Linq;
using System.Collections.Generic;

namespace Tariff_Comparison
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Please enter total consumption in kWh/Yr");
            //int consumption = Convert.ToInt32(Console.ReadLine());
            int[] consumptions = new int[]{1050, 2000, 3500, 4500, 6000};
            TariffComparison tariffComparison = new TariffComparison();
            foreach( int consumption in consumptions)
            {
                tariffComparison.CompareTariffAndPrint(consumption);
            }
            Console.Read();
        }
    }


    class TariffComparison
    {
        IList<Product> productList;

        public void CompareTariffAndPrint(int consumption)
        {
            GetProducts(consumption);
            Console.WriteLine("Consumption (kWh/ year) : " + consumption);
            foreach(Product product in productList)
            {
                Console.WriteLine("Name : " + product.name);
                Console.WriteLine("Cost : € {0}/year", product.cost);
            }
        }

        private void GetProducts(int TotalConsumption)
        {
            productList = new List<Product>();
            productList.Add(ProductA.GetTotalCost(TotalConsumption));
            productList.Add(ProductB.GetTotalCost(TotalConsumption));
            productList.OrderBy( product => product.cost);
        } 

    }

    public class Product
    {
        public Product(string productName, double calculatedCost)
        {
            name = productName;
            cost = calculatedCost;
        }
        public string name; 
        public double cost;
    }

    static class ProductA
    {
        public static Product GetTotalCost(int TotalConsumption)
        {
            double cost = (5 * 12) + ((0.22) * (TotalConsumption));
            return new Product( "basic electricity tariff", cost);
        }
    }

    static class ProductB
    {
        public static Product GetTotalCost(int TotalConsumption)
        {
            double cost = 800 + ((0.30) * Math.Max(0, TotalConsumption - 4000) );
            return new Product("Packaged tariff", cost);
        }
    }
}
