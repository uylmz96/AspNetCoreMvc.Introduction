using AspNetCoreMvc2.Introduction.DataSources.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AspNetCoreMvc2.Introduction.DataSources.Models
{
    public class ParameterListViewModel
    {
        public List<Parameter> Parameters { get; set; }
    }
}