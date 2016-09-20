using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab.adminltetheme.Helpers;

namespace lab.adminltetheme.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [UserAuthorize]
        public ActionResult GetAll()
        {
            return View();
        }
    }
}