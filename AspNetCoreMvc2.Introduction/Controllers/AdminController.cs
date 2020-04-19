using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc2.Introduction.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        [Route("")]
        [Route("Save")]
        [Route("~/Save")]

        public string Save()
        {
            return "Saved";
        }

        [Route("Delete/{id?}")]
        public string Delete(int id=-1)
        {
            return "Deleted";
        }
        [Route("Update")]
        public string Update()
        {
            return "Updated";
        }
    }
}