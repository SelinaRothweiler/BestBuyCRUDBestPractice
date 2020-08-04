using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCrudBestPracticesConsoleApp
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(); //stubbed out method
        void CreateProduct(string name, decimal price, int CategoryID);

    }
}
