using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace _1._4.SPA.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
