using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApps.Factories;

namespace WebApps.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.userName = Cipher.Encrypt(User.Identity.Name);
            return View();
        }
    }
}
