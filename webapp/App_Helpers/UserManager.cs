#region Using

using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

#endregion

namespace FalcoMvc
{
    public class UserManager : UserManager<IdentityUser>
    {
        private static readonly UserStore<IdentityUser> UserStore = new UserStore<IdentityUser>();        
        private static readonly UserManager Instance = new UserManager();

        private UserManager()
            : base(UserStore)
        {
        }

        public static UserManager Create()
        {
            // We have to create our own user manager in order to override some default behavior:
            //
            //  - Override default password length requirement (6) with a length of 4
            //  - Override user name requirements to allow spaces and dots
            var passwordValidator = new MinimumLengthValidator(4);
            var userValidator = new UserValidator<IdentityUser, string>(Instance)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true,
            };

            Instance.UserValidator = userValidator;
            Instance.PasswordValidator = passwordValidator;

            return Instance;
        }

        public static void Seed()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

            // Make sure we always have at least the demo user available to login with
            // this ensures the user does not have to explicitly register upon first use
            var johnny = new IdentityUser
            {
                Id = "6bc8cee0-a03e-430b-9711-420ab0d6a596",
                Email = "admin@email.com",
                UserName = "admin",
                PasswordHash = "APc6/pVPfTnpG89SRacXjlT+sRz+JQnZROws0WmCA20+axszJnmxbRulHtDXhiYEuQ==",
                SecurityStamp = "18272ba5-bf6a-48a7-8116-3ac34dbb7f38"                
            };

            UserStore.Context.Set<IdentityUser>().AddOrUpdate(johnny);
            UserStore.Context.SaveChanges();

            

            var user = new IdentityUser
            {
                Id = "6bc8cee0-a03e-430b-9711-420ab0d6a591",
                Email = "user@email.com",
                UserName = "user",
                PasswordHash = "APc6/pVPfTnpG89SRacXjlT+sRz+JQnZROws0WmCA20+axszJnmxbRulHtDXhiYEuQ==",
                SecurityStamp = "18272ba5-bf6a-48a7-8116-3ac34dbb7f38"
            };

            UserStore.Context.Set<IdentityUser>().AddOrUpdate(user);
            UserStore.Context.SaveChanges();

            //check if exist Admin Role
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            //check if exist User Role
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }


            //assign admin's user role Admin
            var roleAdmin = roleManager.FindByName("Admin");
            var roleUser = roleManager.FindByName("User");
            var adminUserRole = new IdentityUserRole()
            {
                RoleId = roleAdmin.Id,
                UserId = johnny.Id
            };
            UserStore.Context.Set<IdentityUserRole>().AddOrUpdate(adminUserRole);
            UserStore.Context.SaveChanges();

            var userUserRole = new IdentityUserRole()
            {
                RoleId = roleUser.Id,
                UserId = user.Id
            };
            UserStore.Context.Set<IdentityUserRole>().AddOrUpdate(userUserRole);
            UserStore.Context.SaveChanges();


        }
    }
}