using GoogleRecaptcha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoogleRecaptcha.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Comment comment)
        {
             if (!ModelState.IsValid)
            {
                //TODO: Comment saving logic here
                return View();
            }
            return View();
        }
    }
}