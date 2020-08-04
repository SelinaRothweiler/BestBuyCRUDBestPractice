using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace BestBuyCrudBestPracticesConsoleApp
{
    public class DapperProductRepository : IProductRepository
    {
        //Field or local variable used for making querries to database
        private readonly IDbConnection _connection;

        //Constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, decimal price, int CategoryID)
        {
            
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var prods = _connection.Query<Product>("SELECT * FROM products");
            return prods;
        }

        //ERROR - Price does not have a default value
        public void CreateProduct(string newProductName)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name) VALUES (@productName);",
            new { productName = newProductName });
        }

    }
}

        
        //public void UpdateProduct(string newUpdatedProduct)
        //{
        //    _connection.Execute("UPDATE INTO PRODUCTS (Name) VALUES (@productName);",
        //        new { productName = newUpdatedProduct });
        //}