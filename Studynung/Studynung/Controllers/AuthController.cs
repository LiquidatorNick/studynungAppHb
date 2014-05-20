using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Studynung.Helpers;

namespace Studynung.Controllers
{
    public class AuthController : DBController
    {
        //
        // GET: /Auth/

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                var user = UsManager.Login(login, password);
                if (user != null)
                {
                    SessionHelper.User = user;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
