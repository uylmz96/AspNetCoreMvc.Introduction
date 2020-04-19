using Microsoft.AspNetCore.Mvc;
using AspNetCoreMvc2.Introduction.DataSources;
using AspNetCoreMvc2.Introduction.DataSources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AspNetCoreMvc2.Introduction.ViewComponents
{
    public class ParameterListViewComponent : ViewComponent
    {
        private UylmzDbContext _context;

        public ParameterListViewComponent(UylmzDbContext dbContext)
        {
            _context = dbContext;
        }

        //Classic MVC de PartialView a karşılık gelir.
        //Eğer partial kullanmak zorunda değilseniz ViewComponent Kullanmak daha doğru olacaktır.
        //Sıklıkla kullanılan yerlerde kullanılabilir.
        //public ViewViewComponentResult Invoke()
        //{
        //    return View(new ParameterListViewModel
        //    {
        //        Parameters = _context.Parameter.ToList()
        //    });
        //}
        public ViewViewComponentResult Invoke(string Filter)
        {
            // HttpContext.Request.Query["filter"] sadece bununla querystringden veri çekilir.
            Filter = Filter ??  HttpContext.Request.Query["filter"];
            return View(new ParameterListViewModel
            {
                Parameters = Filter == null
                            ? _context.Parameter.ToList()
                            : _context.Parameter.Where(x => x.Key.ToLower().Contains(Filter.ToLower())).ToList()
            });
        }

    }
}
