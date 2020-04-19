using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using AspNetCoreMvc2.Introduction.DataSource.Entities;
using AspNetCoreMvc2.Introduction.DataSource.Models;
using AspNetCoreMvc2.Introduction.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc2.Introduction.Controllers
{
    public class DefaultController : Controller
    {
        //Tüm Result türleri IActionResult interface inden türediği için standart bunu kullanabilirim -UY
        public string Index()
        {
            return "Hello World! -Uylmz96";
        }

        [Route("~/Index")]
        [HandleException(ViewName ="DivideByZeroError",ExceptionType =typeof(DivideByZeroException))]
        [HandleException(ViewName = "Error", ExceptionType = typeof(SecurityException))]
        public IActionResult Index2()
        {
            //Attribute olarak içeride alınabilecek exceptiontype a göre farklı bir viewa gitmek için attribute de belirtmiştik.
            throw new SecurityException(); 
            throw new DivideByZeroException("Some Exception occured!");
            ViewBag.Message = "Hello View! -Uylmz96";
            return View();
        }

        public IActionResult Index3()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,Name="Umut",LastName="Yılmaz"},
                new Employee{Id=1,Name="Saniye",LastName="Yılmaz"},
                new Employee{Id=1,Name="Yakup Enes",LastName="Öğüt"},
                new Employee{Id=1,Name="Mustafa",LastName="Yılmaz"}
            };

            List<string> cities = new List<string> { "Istanbul", "Ankara" };

            var model = new EmployeeViewModel
            {
                Employees = employees,
                Cities = cities
            };

            return View(model);
        }

        public IActionResult Index4()
        {
            //UY-200405
            //HttpResponse lu cevap dönmek için StatusCodeResult kullanılır.
            //StatusCodeResult IActionResult dan inherit olmuştur.
            return new StatusCodeResult(404); //HTTP404
            return new StatusCodeResult(400); //HTTP400
            return new StatusCodeResult(200); //HTTP200
        }

        public IActionResult Index5()
        {
            //UY-200405 
            //Bir aksiyon sonucunda başka bir yer tetkiklenmek istendiğinde.
            //RedirectResult IActionResult dan inherit olmuştur.            
            return new RedirectResult("/Default/Index4");
            //return RedirectToAction("Index2");

        }

        public IActionResult Index6()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,Name="Umut",LastName="Yılmaz"},
                new Employee{Id=1,Name="Saniye",LastName="Yılmaz"},
                new Employee{Id=1,Name="Yakup Enes",LastName="Öğüt"},
                new Employee{Id=1,Name="Mustafa",LastName="Yılmaz"}
            };
            return Json(employees);
        }

        public IActionResult RazorDemo()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,Name="Umut",LastName="Yılmaz"},
                new Employee{Id=1,Name="Saniye",LastName="Yılmaz"},
                new Employee{Id=1,Name="Yakup Enes",LastName="Öğüt"},
                new Employee{Id=1,Name="Mustafa",LastName="Yılmaz"}
            };

            List<string> cities = new List<string> { "Istanbul", "Ankara" };

            var model = new EmployeeViewModel
            {
                Employees = employees,
                Cities = cities
            };

            return View(model);
        }


        //Get : /Default/Index7?key=y
        public IActionResult Index7(string key)
        {
            
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,Name="Umut",LastName="YILMAZ"},
                new Employee{Id=1,Name="Saniye",LastName="YILMAZ"},
                new Employee{Id=1,Name="Yakup Enes",LastName="OGUT"},
                new Employee{Id=1,Name="Mustafa",LastName="YILMAZ"}
            };

            if (!String.IsNullOrEmpty(key))
            {
                var result = employees.Where(x => x.Name.ToLower().Contains(key.ToLower()));
                return Json(result);
            }

            return Json(employees);
        }

        public IActionResult EmployeeForm()
        {
            return View();
        }

        //Get : /Default/RouteData/96
        public new IActionResult RouteData(int Id)
        {
            return Json(Id);
        }
    }
}