using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Studynung.Database;
using Studynung.Helpers;
using Studynung.Managers;

namespace Studynung.Controllers
{
    public class DBController : Controller
    {
        public readonly UserManager UsManager;

        public DBController()
        {
            UsManager = new UserManager();
        }

        protected override void Dispose(bool disposing)
        {
            UsManager.Dispose();
            base.Dispose(disposing);
        }
    }
}
