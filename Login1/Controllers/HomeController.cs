using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login1.Models;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        testEntities2 db = new testEntities2();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User us)
        {
            db.Users.Add(us);
            db.SaveChanges();
            return RedirectToAction("Login");

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User us)
        {

            var obj = db.Users.Where(x => x.Email.Equals(us.Email) && x.Password.Equals(us.Password)).FirstOrDefault();
            if (obj != null)
            {
                return RedirectToAction("Employ");
            }
            else if (us.Email == "admin" && us.Password == "admin")
            {
                return RedirectToAction("Admin");
            }
            return View();
        }
        public ActionResult Employ()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }

    }
}