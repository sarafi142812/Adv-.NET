using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            int a = 10;
            int b = 20;
            int c = a + b;

            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;

            string[] names = new string[3];
            names[0] = "John";
            names[1] = "Rafi";
            names[2] = "Rezuan";

            ViewBag.Name = names;

            return View();
        }
    }
}