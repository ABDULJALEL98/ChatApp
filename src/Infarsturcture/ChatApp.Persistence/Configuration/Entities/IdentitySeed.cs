using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Persistence.Configuration.Entities;
public class IdentitySeed
{
    public static async Task SeedUserAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        //create role
        if (!roleManager.Roles.Any())
        {

            var roles = new List<IdentityRole>()
            {
                new IdentityRole(){Name="Admin"},
                new IdentityRole(){Name="Moderator"},
                new IdentityRole(){Name="Member"},
            };
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);

            }
        }
        //create user

        if (!userManager.Users.Any())
        {
            var user = new AppUser()
            {
                UserName = "ali",
                Email = "ali@ali.com",
                Country = "Eg",
                City = "cairo",
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 11, 11),
                KnownAs = "lol",
                EmailConfirmed = true,

            };
            await userManager.CreateAsync(user, "Aa@123456");
            await userManager.AddToRoleAsync(user, "Admin");


        }




    }
}