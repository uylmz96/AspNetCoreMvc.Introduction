using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc2.Introduction.DataSource.Entities;
using AspNetCoreMvc2.Introduction.DataSource.Models;
using AspNetCoreMvc2.Introduction.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreMvc2.Introduction.Controllers
{
    public class EmployeeController : Controller
    {
        private ICalculator _calculator;

        public EmployeeController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var employeeAddNewModel = new EmployeeAddNewModel
            {
                Employee = new Employee(),
                Cities = new List<SelectListItem> //Combobox için yapılması gereken.
                {
                    new SelectListItem{Text="Ankara",Value="6"},
                    new SelectListItem{Text="İstanbul",Value="34"},
                    new SelectListItem{Text="Kocaeli",Value="41"}
                }
            };
            return View(employeeAddNewModel);
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            return View();
        }

        public IActionResult Calculate()
        {
            return Json(_calculator.Calculate(100));
        }

    }
}
