using _2._2.MVC_Sumator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace _2._2.MVC_Sumator.Controllers
{
    public class SumatorController : Controller
    {
        public ActionResult SumNumbers(SumatorModel numbers)
        {
            double result = numbers.FirstNumber + numbers.SecondNumber;
            ViewBag.Result = result;

            return View();
        }
    }
}
