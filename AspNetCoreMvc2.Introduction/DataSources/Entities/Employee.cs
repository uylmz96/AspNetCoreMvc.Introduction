using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc2.Introduction.DataSource.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name="First Name")]
        public string Name { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "City")]
        public int CityId { get; set; }
    }
}
