using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AspNetCoreMvc2.Introduction.ExtensionMethods;
using AspNetCoreMvc2.Introduction.DataSources.Entities;

namespace AspNetCoreMvc2.Introduction.Controllers
{
    public class SessionDemoController : Controller
    {
        public JsonResult Index()
        {
            HttpContext.Session.SetInt32("age", 23);
            HttpContext.Session.SetString("name", "Umut");
            //Extension Methot
            HttpContext.Session.SetObject("param", new Parameter { Key = "Test", Value = "Test", Description = "Test" });
            return Json("Session Created");
        }

        public string GetSession()
        {

            return String.Format("Hello {0},You are {1} Parameter is {2}"
                                , HttpContext.Session.GetString("name")
                                , HttpContext.Session.GetInt32("age")
                                , HttpContext.Session.GetObject<Parameter>("param").Key); //ExtensionMethod
        }
    }
}