using LearningManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    [Authorize]
    public class TeacherHomepageController : Controller
    {
        // GET: TeacherHomepage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CourseToTeach()
        {
            DatabasefileEntities db = new DatabasefileEntities();

            List<Teacher> tea = db.Teachers.ToList();
            List<registraton> reg = db.registratons.ToList();
            var mutliclass = from t in tea join r in reg on t.Tid equals r.Tid
                             into table1 from r in table1.ToList()
                             select new Multiclass { Teacher = t, Registraton=r };
            Console.WriteLine(mutliclass);
            return View(mutliclass);
            
        }

    }
}