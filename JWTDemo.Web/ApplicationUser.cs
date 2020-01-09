using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.Web
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastLoginDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastLoginIp { get; set; }
    }

    public class Role : IdentityRole<int>
    {
        //Additional custom properties
    }

    public class UserRole : IdentityUserRole<int>
    {
        //Additional custom properties
    }

    public class UserClaim : IdentityUserClaim<int>
    {
        //Additional custom properties
    }

    public class UserLogin : IdentityUserLogin<int>
    {
        //Additional custom properties
    }

    public class RoleClaim : IdentityRoleClaim<int>
    {
        //Additional custom properties
    }

    public class UserToken : IdentityUserToken<int>
    {
        //Additional custom properties
    }
}
