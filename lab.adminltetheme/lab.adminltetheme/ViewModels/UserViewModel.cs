using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.adminltetheme.ViewModels
{
    public class UserViewModel
    {
        public Int32 UserId { get; set; }

        public String UserName { get; set; }

        public Byte[] Password { get; set; }

        public String Email { get; set; }

        public String Comment { get; set; }

        public Boolean IsApproved { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? LastActivityDate { get; set; }

        public DateTime LastPasswordChangeDate { get; set; }

        //public Boolean IsLoggedIn { get; set; }

        //public virtual ICollection<Role> Roles { get; set; }
    }
}