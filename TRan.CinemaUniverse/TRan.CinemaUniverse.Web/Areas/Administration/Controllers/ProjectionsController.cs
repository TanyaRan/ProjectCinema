using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TRan.CinemaUniverse.Web.Areas.Administration.Controllers
{
    public class ProjectionsController : Controller
    {
        // GET: Administration/Projections
        public ActionResult Index()
        {
            return View();
        }
    }
}