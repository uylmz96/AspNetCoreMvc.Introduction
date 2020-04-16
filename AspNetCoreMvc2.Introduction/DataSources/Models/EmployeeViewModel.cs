using AspNetCoreMvc2.Introduction.DataSource.Entities;
using System.Collections.Generic;

namespace AspNetCoreMvc2.Introduction.DataSource.Models
{
    public class EmployeeViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<string> Cities { get; set; }
    }
}