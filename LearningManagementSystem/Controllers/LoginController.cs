using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningManagementSystem.Models;
using System.Web.Security;

namespace LearningManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(admin Ad)
        {
            using(var context = new DatabasefileEntities())
            {
                bool isvalidId = context.admins.Any(x => x.Admin_id == Ad.Admin_id);
                bool isvalidPass = context.admins.Any(x => x.AdminPassword == Ad.AdminPassword);
                if (isvalidId)
                {
                    if (isvalidPass)
                    {
                        FormsAuthentication.SetAuthCookie(Ad.Admin_id.ToString(), false);
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Admin Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Admin id");
                }
            }
            return View();
        }
        public ActionResult StudentLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentLogin(Student std)
        {
            using (var context = new DatabasefileEntities())
            {
                bool isvalidId = context.Students.Any(x => x.stdid == std.stdid);
                bool isvalidPass = context.Students.Any(x => x.stdid == std.stdid);
                if (isvalidId)
                {
                    if (isvalidPass)
                    {
                        FormsAuthentication.SetAuthCookie(std.stdid.ToString(), false);
                        return RedirectToAction("Index", "StudentsHomepage");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid  Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid  id");
                }
            }
            return View();
        }

        public ActionResult TeacherLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TeacherLogin(Teacher t)
        {
            using (var context = new DatabasefileEntities())
            {
                bool isvalidId = context.Teachers.Any(x => x.Tid == t.Tid);
                bool isvalidPass = context.Teachers.Any(x => x.TPassword == t.TPassword);
                if (isvalidId)
                {
                    if (isvalidPass)
                    {
                        
                        FormsAuthentication.SetAuthCookie(t.Tid.ToString(), false);
                        return RedirectToAction("Index", "TeacherHomepage");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid  Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid  id");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}