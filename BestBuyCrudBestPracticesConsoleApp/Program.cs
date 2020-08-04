using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BestBuyCrudBestPracticesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            #endregion

            // MySqlConnection Object (we can access this class's members using --> conn)
            IDbConnection conn = new MySqlConnection(connString);

                  //DapperDepartmentsRepository Object (we can access this class's members using --> repo)
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);

                  //Prints them to the console using the PrintDepartment() (see below)
            Console.WriteLine("Hello user, here are the current departments: ");
            Console.WriteLine("Please press enter...");

            var depos = repo.GetAllDepartments();
            Print(depos);
            
            Console.WriteLine("Do you want to add a department?");
            string userResponse = Console.ReadLine(); //User response, variable declaration

            if(userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What's the name of your new department?");
                    userResponse = Console.ReadLine();

                repo.InsertDepartment(userResponse);
            }

            DapperProductRepository prodrepo = new DapperProductRepository(conn);

            Console.WriteLine("Hello user, here are the current products: ");
            Console.WriteLine("Please press enter...");

            var prods = prodrepo.GetAllProducts();
            Print(prods);

            Console.WriteLine("Do you want to add another product?");
            string userReply = Console.ReadLine();

            if (userReply.ToLower() == "yes")
            {
                Console.WriteLine("What's the name of your new product?");
                userReply = Console.ReadLine();

                prodrepo.CreateProduct(userReply);
            }

        }
            //Departments
            private static void Print(IEnumerable<Department> depos)
            {
                foreach (var depo in depos)
                {
                    Console.WriteLine($"Id: {depo.DepartmentId} Nme: {depo.Name}");
                }
            }

            //Products
            private static void Print(IEnumerable<Product> prodrepo)
            {
                foreach (var prod in prodrepo)
                {
                    Console.WriteLine($"Id: {prod.ProductId} Nme: {prod.Name}");
                }
            }
    }
}
