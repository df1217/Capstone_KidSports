using KidSports.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace KidSports.Repositories
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context =
                app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            UserManager<IdUser> userManager =
                app.ApplicationServices.GetRequiredService<UserManager<IdUser>>();
            RoleManager<IdentityRole> roleManager =
                app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            UserRepository userRepo = new UserRepository(userManager, context);
            User user;

            if (!context.Users.Any())
            {

                var asyncRoleTask = roleManager.FindByNameAsync(UserRole.Admin.ToString());
                if (asyncRoleTask.Result == null)
                {
                    var asyncResultTask = roleManager.CreateAsync(
                        new IdentityRole(UserRole.Admin.ToString()));
                    asyncResultTask.Wait();
                }

                asyncRoleTask = roleManager.FindByNameAsync(UserRole.Applicant.ToString());
                if (asyncRoleTask.Result == null)
                {
                    var asyncResultTask = roleManager.CreateAsync(
                        new IdentityRole(UserRole.Applicant.ToString()));
                    asyncResultTask.Wait();
                }

                asyncRoleTask = roleManager.FindByNameAsync(UserRole.SportsManager.ToString());
                if (asyncRoleTask.Result == null)
                {
                    var asyncResultTask = roleManager.CreateAsync(
                        new IdentityRole(UserRole.SportsManager.ToString()));
                    asyncResultTask.Wait();
                }

                asyncRoleTask = roleManager.FindByNameAsync(UserRole.WebMaster.ToString());
                if (asyncRoleTask.Result == null)
                {
                    var asyncResultTask = roleManager.CreateAsync(
                        new IdentityRole(UserRole.WebMaster.ToString()));
                    asyncResultTask.Wait();
                }

                // Add a user for testing
                string firstName = "Test";
                string middleName = "User";
                string lastName = "One";
                string email = "testuserone@gmail.com";
                string userName = email;
                string password = "Test123.";

                IdentityResult result;
                user = userRepo.CreateUser(firstName, middleName, lastName, email, password, UserRole.Applicant, out result);

                if (result.Succeeded)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
        }
    }
}