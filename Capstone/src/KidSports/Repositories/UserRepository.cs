using System;
using System.Collections.Generic;
using System.Linq;
using KidSports.Models;
using Microsoft.AspNetCore.Identity;

namespace KidSports.Repositories
{
    public class UserRepository : IUserRepo
    {
        private UserManager<User> userManager;
        private ApplicationDbContext context;

        public UserRepository(UserManager<User> um, ApplicationDbContext ctx)
        {
            userManager = um;
            context = ctx;
        }

        // Create an User object and a User object that points to the User
        public User CreateUser(string firstName, string middleName, string lastName, string eMail, string password, UserRole role, out IdentityResult result)
        {
            result = null;

            // Check to see if this User already exists
            var asyncTask = userManager.FindByEmailAsync(eMail);
            asyncTask.Wait();

            var user = asyncTask.Result;
            if (user == null)
            {
                // Create a new User
                user = new User
                {
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    UserName = eMail,
                    Email = eMail
                };

                var asyncResultTask = userManager.CreateAsync(user, password);
                asyncResultTask.Wait();
                result = asyncResultTask.Result;
                if (result.Succeeded)
                {
                    // Add a role to the User
                    asyncResultTask = userManager.AddToRoleAsync(user, role.ToString());
                    asyncResultTask.Wait();
                    result = asyncResultTask.Result;
                }
                else
                {
                    result = null;  // The User already exists
                }
            }
            return user;
        }

        public User GetUserByEmail(string Email)
        {
            var asyncTask = userManager.FindByNameAsync(Email);
            var identityUser = asyncTask.Result;
            return identityUser;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public IQueryable<User> GetFilteredUsers(string SearchParam = null)
        {
            var result = context.Users.AsQueryable();
            if (SearchParam != null)
            {
                if (!string.IsNullOrEmpty(SearchParam))
                    result = result.Where(x => x.Email.Contains(SearchParam) || x.FirstName.Contains(SearchParam) || x.LastName.Contains(SearchParam));
            }
            return result;
        }
    }
}
