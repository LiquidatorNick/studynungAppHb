//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Studynung.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
            this.LaboratoryProcesses = new HashSet<LaboratoryProcess>();
        }
    
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<LaboratoryProcess> LaboratoryProcesses { get; set; }
    }
}
