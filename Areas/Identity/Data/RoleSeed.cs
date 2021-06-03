using ForumWeb.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Areas.Identity.Data
{
    public static class RoleSeed
    {
        public static async Task SeedRoleAsync(UserManager<ForumWebUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }


        //public static async Task AdminUserAsync(UserManager<ForumWebUser> userManager, RoleManager<IdentityRole> roleManager)
        //{
        //    //Seeding a Admin User
        //    var adminUser = new ForumWebUser
        //    {
        //        UserName = "Admin",
        //        Email = "admin@test.com",
        //        NickName ="AdminNick"
        //    };

        //    if (userManager.Users.All(u => u.Id != adminUser.Id))
        //    {
        //        var user = await userManager.FindByEmailAsync(adminUser.Email);
        //        if (user == null)
        //        {
        //            await userManager.CreateAsync(adminUser, "Test123-");
        //            await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());
        //        }
        //    }
        //}

    }
}
