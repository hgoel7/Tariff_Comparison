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
                List<Product> productList = tariffComparison.GetProducts(consumption);
                Console.WriteLine("Consumption (kWh/ year) : " + consumption);
                foreach(Product product in productList.OrderBy(product => product.cost))
                {
                    Console.WriteLine("Name : " + product.name);
                    Console.WriteLine("Cost : € {0}/year", product.cost);
                }
            }
            Console.Read();
        }
    }
}
