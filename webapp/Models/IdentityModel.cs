using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Falco.Web.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    namespace DbMigrationExample.Models
    {
        public class ApplicationUser : IdentityUser
        {
        }
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection")
            {
            }
        }
    }
}