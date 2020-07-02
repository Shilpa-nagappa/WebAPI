using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppSample.Common;
namespace WebAppSample.Controllers
{
    public class HomeController : Controller
    {
        [TrackExecution]
        public string Index()
        {
            return " Index action invoked";
        }

        public string welcome()
        {
            throw new Exception("Exception Occured");
        }

        //public ActionResult Index()
        //{
        //    ViewBag.Title = "Home Page";

        //    return View();
        //}
    }
}

