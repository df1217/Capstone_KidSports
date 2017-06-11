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
        User AdminCreateUser(string firstName, string middleName, string lastName, string eMail, UserRole role, out IdentityResult result);
        User GetUserByEmail(string eMail);
        IEnumerable<User> GetAllUsers();
        IQueryable<User> GetFilteredUsers(string SearchParam);
        int Update(User user);
        User GetDetailedUser(User user);
        User GetUserByID(int id);
        User GetUserByIdentityID(string applicantID);
        string GetRoleNameByIdentityID(string id);
        void DeleteUserByID(string id);
        void DeleteUserRoles(string id);
    }
}