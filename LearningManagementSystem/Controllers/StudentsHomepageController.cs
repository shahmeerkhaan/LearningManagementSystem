using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningManagementSystem.Models;

namespace LearningManagementSystem.Controllers
{
    public class StudentsHomepageController : Controller
    {
        [Authorize]
        // GET: StudentsHomepage
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Details()
        {
            DatabasefileEntities db = new DatabasefileEntities();

            List<Student> std = db.Students.ToList();
            List<registraton> reg = db.registratons.ToList();
            var mutliclass = from s in std
                             join r in reg on s.stdid equals r.stdid
                             into table1
                             from r in table1.ToList()
                             select new Multiclass { Student = s, Registraton = r };
            Console.WriteLine(mutliclass);
            return View(mutliclass);
        }
    }
}