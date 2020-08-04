using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCrudBestPracticesConsoleApp
{
    interface IDepartmentRespository
    {
        //We're saying we need a method called GetAllDepartments that returns a collection
        //That conforms to IEnumerable<T>
        IEnumerable<Department> GetAllDepartments(); //stubbed out method
        void InsertDepartment();
    }
}
