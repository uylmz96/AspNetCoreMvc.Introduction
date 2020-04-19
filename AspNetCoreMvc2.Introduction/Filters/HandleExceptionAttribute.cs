using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AspNetCoreMvc2.Introduction.Filters
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public string ViewName { get; set; } = "Error";
        public Type ExceptionType { get; set; } = null;

        //public override void OnException(ExceptionContext context)
        //{
        //    var result = new ViewResult { ViewName = "Error" }; //Bu view 'ı bul ve çalıştır.

        //    //Burada viewda kullanmak için bir data oluşturuyoruz.
        //    var modelDateProvider = new EmptyModelMetadataProvider();
        //    result.ViewData = new ViewDataDictionary(modelDateProvider, context.ModelState);
        //    result.ViewData.Add("HandleException",context.Exception);

        //    context.Result = result;
        //    context.ExceptionHandled = true; //Hatayı handle ettik diyerek core'un başka bir işlem yapmaya çalışmasını önlüyoruz.
        //}

        public override void OnException(ExceptionContext context)
        {
            if (ExceptionType != null)
            {
                if (ExceptionType == context.Exception.GetType())
                {
                    var result = new ViewResult { ViewName = ViewName }; //Bu view 'ı bul ve çalıştır.

                    //Burada viewda kullanmak için bir data oluşturuyoruz.
                    var modelDateProvider = new EmptyModelMetadataProvider();
                    result.ViewData = new ViewDataDictionary(modelDateProvider, context.ModelState);
                    result.ViewData.Add("HandleException", context.Exception);

                    context.Result = result;
                    context.ExceptionHandled = true; //Hatayı handle ettik diyerek core'un başka bir işlem yapmaya çalışmasını önlüyoruz.

                }
            }
        }
    }
}
