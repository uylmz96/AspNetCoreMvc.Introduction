using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc2.Introduction.Filters
{
    //Attribute olarak kullanabilmek için 
    public class CustomFilter : Attribute, IActionFilter
    {
        //İşlemden Önce çalışması istenilen
        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        //İşlemden sonra çalışması istenen
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

    }
}
