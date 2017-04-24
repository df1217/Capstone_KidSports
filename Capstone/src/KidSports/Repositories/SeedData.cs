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
            UserManager<User> userManager =
                app.ApplicationServices.GetRequiredService<UserManager<User>>();
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
                string firstName = "John";
                string middleName = "Test";
                string lastName = "Doe";
                string email = "Johndoe@gmail.com";
                string userName = email;
                string password = "Test123.";

                IdentityResult result;
                user = userRepo.CreateUser(firstName, middleName, lastName, email, password, UserRole.Applicant, out result);

                string firstName2 = "Jane";
                string middleName2 = "Test";
                string lastName2 = "Doe";
                string email2 = "Janedoe@gmail.com";
                string userName2 = email;
                string password2 = "Test123.";

                IdentityResult result2;
                user = userRepo.CreateUser(firstName2, middleName2, lastName2, email2, password2, UserRole.SportsManager, out result2);


                string firstName3 = "Bob";
                string middleName3 = "Test";
                string lastName3 = "Doe";
                string email3 = "Bobdoe@gmail.com";
                string userName3 = email;
                string password3 = "Test123.";

                IdentityResult result3;
                user = userRepo.CreateUser(firstName3, middleName3, lastName3, email3, password3, UserRole.Admin, out result3);
            }
        }
    }
}