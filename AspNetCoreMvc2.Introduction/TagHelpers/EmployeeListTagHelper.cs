using AspNetCoreMvc2.Introduction.DataSource.Entities;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc2.Introduction.TagHelpers
{
    [HtmlTargetElement("employee-list")]
    public class EmployeeListTagHelper : TagHelper
    {
        private List<Employee> _employees;
        public EmployeeListTagHelper()
        {
            _employees = new List<Employee>
            {
                new Employee{Id=1,Name="Umut",LastName="Yılmaz"},
                new Employee{Id=2,Name="Saniye",LastName="Yılmaz"},
                new Employee{Id=3,Name="Yakup Enes",LastName="Öğüt"},
                new Employee{Id=4,Name="Mustafa",LastName="Yılmaz"}
            };
        }

        //Attribute yazarken isimlendirmeler önemli
        [HtmlAttributeName(ListCountAttributeName)]
        public int ListCount { get; set; }
        private const string ListCountAttributeName = "count";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var query = _employees.Take(ListCount);


            StringBuilder sb = new StringBuilder();
            foreach (var item in query)
            {
                sb.AppendFormat("<h2><a href='/Employee/Detail/{0}'>{1}</a></h2>",item.Id,item.Name);
            }

            output.Content.SetHtmlContent(sb.ToString());
            base.Process(context, output);  
        }
    }
}
