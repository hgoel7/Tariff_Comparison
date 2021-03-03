using System;
using System.Linq;
using System.Collections.Generic;

namespace Tariff_Comparison
{
    class TariffComparison
    {
        public List<Product> GetProducts(int TotalConsumption)
        {
            List<Product>productList = new List<Product>();
            productList.Add(new ProductA().GetTotalCost(TotalConsumption));
            productList.Add(new ProductB().GetTotalCost(TotalConsumption));
            return productList;
        } 

    }

    class Product
    {
        public Product(string productName, double calculatedCost)
        {
            name = productName;
            cost = calculatedCost;
        }
        public string name; 
        public double cost;
    }

    interface IProduct
    {
        public Product GetTotalCost(int TotalConsumption);
    }
    class ProductA : IProduct
    {
        public Product GetTotalCost(int TotalConsumption)
        {
            double cost = (5 * 12) + ((0.22) * (TotalConsumption));
            return new Product( "basic electricity tariff", cost);
        }
    }

    class ProductB : IProduct
    {
        public Product GetTotalCost(int TotalConsumption)
        {
            double cost = 800 + ((0.30) * Math.Max(0, TotalConsumption - 4000) );
            return new Product("Packaged tariff", cost);
        }
    }
}
