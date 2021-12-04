using Microsoft.AspNetCore.Mvc;
using ModulerTasarimYapilanmasi.Models;
using System.Collections.Generic;

namespace ModulerTasarimYapilanmasi.ViewComponents
{
    //[NonViewComponent] //ViewComponent özelliğini ezebilmekteyiz.
    public class EmployeeViewComponent : ViewComponent
    {
        // Tasarlanan ViewComponent çağırılıp render edildiğinde içerisinde çalışmasını istediğimiz kodları bu imzada bir metodun içerisine yerleştirmeliyiz. Async'de olabilmektedir
        public IViewComponentResult Invoke(int id)
        {
            List<Employee> datas = new List<Employee>
            {
                new Employee { Name = "Emre", SurName = "Polat" },
                new Employee { Name = "Omama", SurName = "Kasem" }
            };
            return View(datas);
            //return View("Employee.cshtml"); // Eğer Default.cshtml yerine farklı bir view ismi belirtilecekse buraya o yazılmalıdır.
        }
    }
}
