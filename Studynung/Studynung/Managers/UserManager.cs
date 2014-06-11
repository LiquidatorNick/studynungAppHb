using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Studynung.Database;

namespace Studynung.Managers
{
    public class BaseManager
    {
        public readonly Studynung.Database.StudynungContainer DB = new StudynungContainer();

        public void Dispose()
        {
            DB.Dispose();
        }
    }

    public class UserManager : BaseManager
    {
        public User Login(string login, string password)
        {
            
            var user = DB.Users.FirstOrDefault(u => u.Login.ToUpper() == login.ToUpper());
            if (user != null)
            {
                if (user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
    }
}