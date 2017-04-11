using KidSports.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Repositories
{
    public class UserRepository : IUserRepo
    {
        private UserManager<IdUser> userManager;
        private ApplicationDbContext context;

        public UserRepository(UserManager<IdUser> um, ApplicationDbContext ctx)
        {
            userManager = um;
            context = ctx;
        }

        // Create an IdUser object and a User object that points to the IdUser
        public User CreateUser(string firstName, string middleName, string lastName, string eMail, string password, UserRole role, out IdentityResult identityResult)
        {
            User user = null;
            identityResult = null;

            // Check to see if this IdUser already exists
            var asyncTask = userManager.FindByEmailAsync(eMail);
            asyncTask.Wait();

            var identityUser = asyncTask.Result;
            if (identityUser == null)
            {
                // Create a new IdUser
                identityUser = new IdUser
                {
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    UserName = eMail,
                    Email = eMail
                };

                var asyncResultTask = userManager.CreateAsync(identityUser, password);
                asyncResultTask.Wait();
                identityResult = asyncResultTask.Result;
                if (identityResult.Succeeded)
                {
                    // Add a role to the IdUser
                    asyncResultTask = userManager.AddToRoleAsync(identityUser, role.ToString());
                    asyncResultTask.Wait();
                    identityResult = asyncResultTask.Result;
                    if (identityResult.Succeeded)
                    {
                        // Create a User that points to the IdUser
                        user = new User();
                        user.IdUserID = identityUser.Id;
                        //user.UserName = identityUser.UserName;
                        //user.FirstName = identityUser.FirstName;
                        //user.MiddleName = identityUser.MiddleName;
                        //user.LastName = identityUser.LastName;
                        //user.Email = identityUser.Email;
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                }
                else
                {
                    identityResult = null;  // The User already exists
                }
            }

            return user;
        }

        public IdUser GetIdUserByEmail(string Email)
        {
            var asyncTask = userManager.FindByNameAsync(Email);
            var identityUser = asyncTask.Result;
            return identityUser;
        }

    }
}
