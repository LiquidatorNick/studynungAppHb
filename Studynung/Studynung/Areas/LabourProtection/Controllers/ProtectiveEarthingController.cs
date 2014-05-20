using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studynung.Areas.LabourProtection.Controllers
{
    public class ProtectiveEarthingController : Controller
    {
        //
        // GET: /LabourProtection/ProtectiveEarthing/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("Partials/_menu");
        }

        public ActionResult Title()
        {
            return PartialView("Partials/_title");
        }

        public ActionResult Calc()
        {
            return PartialView("Partials/_calc");
        }

        public ActionResult Theory()
        {
            return PartialView("Partials/_theory");
        }
    }
}
