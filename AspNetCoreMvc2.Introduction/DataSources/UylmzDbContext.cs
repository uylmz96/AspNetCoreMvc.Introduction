using AspNetCoreMvc2.Introduction.DataSources.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc2.Introduction.DataSources
{
    public class UylmzDbContext : DbContext
    {
        public UylmzDbContext(DbContextOptions<UylmzDbContext> options) : base(options)
        {
            //Startup.cs den connectionstring dolduruluyor...
        }
        public DbSet<Parameter> Parameter { get; set; }
    }
}
