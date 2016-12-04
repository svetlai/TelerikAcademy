using _2._2.MVC_Sumator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2._2.MVC_Sumator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Sumator(SumatorModel numbers)
        {
            ViewBag.Message = "Your sumator page.";

            double result = numbers.FirstNumber + numbers.SecondNumber;
            ViewBag.Result = result;

            return View();
        }
    }
}