using AspNetCoreMvc2.Introduction.DataSource.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AspNetCoreMvc2.Introduction.DataSource.Models
{
    public class EmployeeAddNewModel
    {
        public Employee Employee { get; set; }
        public List<SelectListItem> Cities { get; internal set; }
    }
}