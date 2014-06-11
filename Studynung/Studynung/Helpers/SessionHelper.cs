using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Studynung.Database;
using Studynung.Logic;

namespace Studynung.Helpers
{
    public static class SessionHelper
    {
        private static HttpSessionState Session
        {

            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                    return HttpContext.Current.Session;
                else
                    return null;
            }
        }

        private static HttpCookieCollection CookiesRequest
        {
            get { return HttpContext.Current.Request.Cookies; }
        }

        private static HttpCookieCollection CookiesResponse
        {
            get { return HttpContext.Current.Response.Cookies; }
        }

        private static T Get<T>(string key) where T : class
        {
            if (Session == null)
                return default(T);

            return Session[key] as T;
        }

        private static void Set(string key, object value, bool useCookies = false)
        {
            if (Session == null)
                return;

            Session[key] = value;

            if (useCookies == true && CookiesResponse != null && !string.IsNullOrEmpty(value.ToString()))
                CookiesResponse.Add(new HttpCookie(key)
                {
                    Value = value.ToString(),
                    Expires = DateTime.Now.AddMonths(1)
                });
        }

        public static User User
        {
            get { return Get<User>("currentuser"); }
            set { Set("currentuser", value); }
        }

        public static bool IsAutorize
        {
            get { return User != null; }
        }

        public static bool IsUserAdmin()
        {
            if (User != null)
            {
                return User.Roles.Any(r => r.Name == UserRoles.Administrator.ToString());
            }
            return false;
        }

        public static bool IsUserTeacher()
        {
            if (User != null)
            {
                return User.Roles.Any(r => r.Name == UserRoles.Teacher.ToString());
            }
            return false;
        }

        public static bool IsUserStudent()
        {
            if (User != null)
            {
                return User.Roles.Any(r => r.Name == UserRoles.Student.ToString());
            }
            return false;
        }
    }
}