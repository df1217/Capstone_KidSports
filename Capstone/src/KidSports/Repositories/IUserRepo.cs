using KidSports.Models;
using Microsoft.AspNetCore.Identity;

namespace KidSports.Repositories
{
    public enum UserRole { Applicant, SportsManager, Admin, WebMaster };
    public interface IUserRepo
    {
        User CreateUser(string firstName, string middleName, string lastName, string eMail, string password, UserRole role, out IdentityResult identityResult);
        User GetUserByEmail(string eMail);
    }
}
