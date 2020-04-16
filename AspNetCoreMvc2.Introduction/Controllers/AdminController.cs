using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc2.Introduction.Controllers
{
    public class AdminController : Controller
    {
        public string Save()
        {
            return "Saved";
        }
        public string Delete()
        {
            return "Deleted";
        }
        public string Update()
        {
            return "Updated";
        }
    }
}