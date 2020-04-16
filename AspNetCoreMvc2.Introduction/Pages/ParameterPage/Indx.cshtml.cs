using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc2.Introduction.DataSources;
using AspNetCoreMvc2.Introduction.DataSources.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreMvc2.Introduction.Pages.ParameterPage
{
    public class IndxModel : PageModel
    {
        #region Singelton
        private readonly UylmzDbContext _context;

        public IndxModel(UylmzDbContext context)
        {
            _context = context;
        }
        #endregion
        public List<Parameter> Parameters { get; set; }
        public void OnGet(string search)
        {
            Parameters = String.IsNullOrEmpty(search)
                ? _context.Parameter.ToList()
                : _context.Parameter.Where(x => x.Key.ToLower().Contains(search.ToLower())).ToList();
        }


        [BindProperty] //.cshtml dosyasında Parameter ile başlayan property leri buradaki değişkene bind eder
        public Parameter Parameter { get; set; }

        public IActionResult OnPost()
        {
            _context.Parameter.Add(Parameter);
            _context.SaveChanges();
            return RedirectToAction("/ParameterPage/Indx");
        }
    }
}