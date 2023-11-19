using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            return View();
        }
        //GET : /Classes/List
        public ActionResult ListClasses()
        {
            ClassesDataController controller = new ClassesDataController();
            IEnumerable<Classes> Classes = controller.ListClasses();
            return View(Classes);
        }

        //GET : /Classes/ShowClasses/{id}
        public ActionResult ShowClasses(int id)
        {
            ClassesDataController controller = new ClassesDataController();
            Classes NewClasses = controller.FindClasses(id);
            return View(NewClasses);
        }
    }
}