using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.SqlClient;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace WebMVCTest1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //test linq
            //string[] strarr = { "a1x", "b2x", "c3y" };
            //var elem = from element in strarr
            //           where element.Contains("x")
            //           select element;

            //foreach (var item in elem)
            //{
            //    Console.WriteLine(item);
            //}

            //Regex regx = new Regex("^[a-zA-Z0-9]+$"); //Regex(@"\d+");
            //Match match = regx.Match("1 test 23");
            //if (regx.IsMatch("x12") )
            //{
            //    Console.WriteLine("match");
            //}

            //System.GC.Collect();
            //System.GC.WaitForPendingFinalizers();

            ViewBag.mydata1 = "";

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
    }
}