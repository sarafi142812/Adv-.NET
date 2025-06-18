using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using e_commerce.EF;
using e_commerce.Repository;

namespace e_commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;

        public HomeController()
        {
            _userRepository = new UserRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer c)
        {
            var user = UserRepository.Authenticate(c.Id, c.Name); // Fixed missing semicolon and added object reference
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Id, true);
                return RedirectToAction("Index", "Product");
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}