﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWithAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public List<Customer> Get()
        {
            return new List<Customer> {
                new Customer {Id=1 , FirstName="Umut",LastName="Yılmaz" },
                new Customer {Id=1 , FirstName="Saniye",LastName="Yılmaz" },
                new Customer {Id=1 , FirstName="Hanife",LastName="Yılmaz" },
                new Customer {Id=1 , FirstName="Aliiksan",LastName="Yılmaz" }
            };
        }

    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

}