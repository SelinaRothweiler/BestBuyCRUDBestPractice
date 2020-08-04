using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCrudBestPracticesConsoleApp
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int OnSale { get; set; }
        public string StockLevel { get; set; }
    }
}
