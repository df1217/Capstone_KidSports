using KidSports.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace KidSports.Repositories
{
    public enum UserRole { Applicant, SportsManager, Admin, WebMaster };
    public interface IUserRepo
    {
        User CreateUser(string firstName, string middleName, string lastName, string eMail, string password, UserRole role, out IdentityResult identityResult);
        User GetUserByEmail(string eMail);
        IEnumerable<User> GetAllUsers();
        IQueryable<User> GetFilteredUsers(string SearchParam);
    }
}
