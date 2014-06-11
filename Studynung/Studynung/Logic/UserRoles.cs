using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Studynung.Logic
{
    public enum UserRoles
    {
        [Description("User")]
        User,

        [Description("Administrator")]
        Administrator,
        
        [Description("Student")]
        Student,

        [Description("Teacher")]
        Teacher
    }
}