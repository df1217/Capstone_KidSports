﻿using KidSports.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace KidSports.Repositories
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            List<School> SouthEugene = new List<School>();
            List<School> Springfield = new List<School>();
            List<School> NorthEugene = new List<School>();
            List<School> Sheldon = new List<School>();
            List<School> Churchill = new List<School>();
            List<School> Willamette = new List<School>();

            #region Context And Identity Managers
            ApplicationDbContext context =
                app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            UserManager<User> userManager =
                app.ApplicationServices.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            UserRepository userRepo = new UserRepository(userManager, context);
            User user;
            #endregion

            #region Users
            if (!context.Users.Any())
            {

                #region Roles
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

                #endregion

                #region User Details
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
                #endregion
            }
            #endregion

            #region States
            if (!context.States.Any())
            {
                //List<State> States = new List<State>();
                context.States.Add(new State { StateName = "Alabama" });
                context.States.Add(new State { StateName = "Alaska" });
                context.States.Add(new State { StateName = "Arizona" });
                context.States.Add(new State { StateName = "Arkansas" });
                context.States.Add(new State { StateName = "California" });
                context.States.Add(new State { StateName = "Colorado" });
                context.States.Add(new State { StateName = "Connecticut" });
                context.States.Add(new State { StateName = "Delaware" });
                context.States.Add(new State { StateName = "Florida" });
                context.States.Add(new State { StateName = "Georgia" });
                context.States.Add(new State { StateName = "Hawaii" });
                context.States.Add(new State { StateName = "Idaho" });
                context.States.Add(new State { StateName = "Illinois " });
                context.States.Add(new State { StateName = "Indiana" });
                context.States.Add(new State { StateName = "Iowa" });
                context.States.Add(new State { StateName = "Kansas" });
                context.States.Add(new State { StateName = "Kentucky" });
                context.States.Add(new State { StateName = "Louisiana" });
                context.States.Add(new State { StateName = "Maine" });
                context.States.Add(new State { StateName = "Maryland" });
                context.States.Add(new State { StateName = "Massachusett" });
                context.States.Add(new State { StateName = "Michigan" });
                context.States.Add(new State { StateName = "Minnesota" });
                context.States.Add(new State { StateName = "Mississippi" });
                context.States.Add(new State { StateName = "Missouri" });
                context.States.Add(new State { StateName = "Montana " });
                context.States.Add(new State { StateName = "Nebraska" });
                context.States.Add(new State { StateName = "Nevada" });
                context.States.Add(new State { StateName = "New Hampshire" });
                context.States.Add(new State { StateName = "New Jersey" });
                context.States.Add(new State { StateName = "New Mexico" });
                context.States.Add(new State { StateName = "New York" });
                context.States.Add(new State { StateName = "North Carolina" });
                context.States.Add(new State { StateName = "North Dakota" });
                context.States.Add(new State { StateName = "Ohio" });
                context.States.Add(new State { StateName = "Oklahoma" });
                context.States.Add(new State { StateName = "Oregon" });
                context.States.Add(new State { StateName = "Pennsylvania" });
                context.States.Add(new State { StateName = "Rhode Island" });
                context.States.Add(new State { StateName = "South Carolina" });
                context.States.Add(new State { StateName = "South Dakota" });
                context.States.Add(new State { StateName = "Tennessee" });
                context.States.Add(new State { StateName = "Texas" });
                context.States.Add(new State { StateName = "Utah" });
                context.States.Add(new State { StateName = "Vermont" });
                context.States.Add(new State { StateName = "Virginia" });
                context.States.Add(new State { StateName = "Washington" });
                context.States.Add(new State { StateName = "West Virginia" });
                context.States.Add(new State { StateName = "Wisconsin" });
                context.States.Add(new State { StateName = "Wyoming" });
                context.SaveChanges();
                //context.States.AddRange(States);
            }
            #endregion

            #region Schools
            if (!context.Schools.Any())
            {
                SouthEugene.Add(new School() { SchoolName = "Camas Ridge" });
                SouthEugene.Add(new School() { SchoolName = "Charlamagne" });
                SouthEugene.Add(new School() { SchoolName = "Edgewood" });
                SouthEugene.Add(new School() { SchoolName = "Edison" });
                SouthEugene.Add(new School() { SchoolName = "Far Horizon Montessori" });
                SouthEugene.Add(new School() { SchoolName = "O'hara Catholic" });
                SouthEugene.Add(new School() { SchoolName = "Oak Hill" });
                SouthEugene.Add(new School() { SchoolName = "Ridgeline Montessori" });
                SouthEugene.Add(new School() { SchoolName = "Roosevelt" });
                SouthEugene.Add(new School() { SchoolName = "Spencers Butte" });
                SouthEugene.Add(new School() { SchoolName = "South Eugene" });
                SouthEugene.Add(new School() { SchoolName = "The Village School" });

                Springfield.Add(new School() { SchoolName = "Agnes Stewart" });
                Springfield.Add(new School() { SchoolName = "Briggs" });
                Springfield.Add(new School() { SchoolName = "Centinnial" });
                Springfield.Add(new School() { SchoolName = "Douglas Gardens" });
                Springfield.Add(new School() { SchoolName = "Guy Lee" });
                Springfield.Add(new School() { SchoolName = "Hamlin" });
                Springfield.Add(new School() { SchoolName = "Maple" });
                Springfield.Add(new School() { SchoolName = "Mt Vernon" });
                Springfield.Add(new School() { SchoolName = "Page" });
                Springfield.Add(new School() { SchoolName = "Pleasant View" });
                Springfield.Add(new School() { SchoolName = "Ridge View" });
                Springfield.Add(new School() { SchoolName = "River Bend" });
                Springfield.Add(new School() { SchoolName = "Springfield" });
                Springfield.Add(new School() { SchoolName = "Thurston" });
                Springfield.Add(new School() { SchoolName = "Two River/Dos Rios" });
                Springfield.Add(new School() { SchoolName = "Walterville" });
                Springfield.Add(new School() { SchoolName = "Yolanda" });

                NorthEugene.Add(new School() { SchoolName = "Aubrey Park" });
                NorthEugene.Add(new School() { SchoolName = "Corridor" });
                NorthEugene.Add(new School() { SchoolName = "Howard" });
                NorthEugene.Add(new School() { SchoolName = "North Eugene / El Camino Real" });
                NorthEugene.Add(new School() { SchoolName = "Spring Creek" });
                NorthEugene.Add(new School() { SchoolName = "Yujin Gakuen" });

                Sheldon.Add(new School() { SchoolName = "Bertha Holt" });
                Sheldon.Add(new School() { SchoolName = "Buena Vista" });
                Sheldon.Add(new School() { SchoolName = "Cal Young" });
                Sheldon.Add(new School() { SchoolName = "Coburg Charter" });
                Sheldon.Add(new School() { SchoolName = "Eugene Christian" });
                Sheldon.Add(new School() { SchoolName = "Gilham" });
                Sheldon.Add(new School() { SchoolName = "Marist Christian" });
                Sheldon.Add(new School() { SchoolName = "Sheldon" });
                Sheldon.Add(new School() { SchoolName = "Monroe" });
                Sheldon.Add(new School() { SchoolName = "St Paul Catholic" });
                Sheldon.Add(new School() { SchoolName = "Willagillespie" });

                Churchill.Add(new School() { SchoolName = "Adams" });
                Churchill.Add(new School() { SchoolName = "ATA / Jefferson" });
                Churchill.Add(new School() { SchoolName = "Cesar Chavez" });
                Churchill.Add(new School() { SchoolName = "Family School" });
                Churchill.Add(new School() { SchoolName = "Kennedy" });
                Churchill.Add(new School() { SchoolName = "McCornack" });
                Churchill.Add(new School() { SchoolName = "Twin Oaks" });
                Churchill.Add(new School() { SchoolName = "Willamette Christian" });

                Willamette.Add(new School() { SchoolName = "Cascade" });
                Willamette.Add(new School() { SchoolName = "Clear Lake" });
                Willamette.Add(new School() { SchoolName = "Danebo" });
                Willamette.Add(new School() { SchoolName = "Fairfield" });
                Willamette.Add(new School() { SchoolName = "Irving" });
                Willamette.Add(new School() { SchoolName = "Kalapula" });
                Willamette.Add(new School() { SchoolName = "Malabon" });
                Willamette.Add(new School() { SchoolName = "Meadow View" });
                Willamette.Add(new School() { SchoolName = "Prairie Mountain" });
                Willamette.Add(new School() { SchoolName = "Shasta" });
                Willamette.Add(new School() { SchoolName = "Willamette" });

                context.Schools.AddRange(SouthEugene);
                context.Schools.AddRange(Springfield);
                context.Schools.AddRange(NorthEugene);
                context.Schools.AddRange(Sheldon);
                context.Schools.AddRange(Churchill);
                context.Schools.AddRange(Willamette);

                context.SaveChanges();
            }
            #endregion

            #region Districts
            if (context.Schools.Any() && !context.Areas.Any())
            {
                List<Area> Districts = new List<Area>();
                Districts.Add(new Area() { AreaName = "South Eugene", AreaSchools = SouthEugene });
                Districts.Add(new Area() { AreaName = "Springfield", AreaSchools = Springfield });
                Districts.Add(new Area() { AreaName = "North Eugene", AreaSchools = NorthEugene });
                Districts.Add(new Area() { AreaName = "Sheldon", AreaSchools = Sheldon });
                Districts.Add(new Area() { AreaName = "Churchill", AreaSchools = Churchill });
                Districts.Add(new Area() { AreaName = "Willamette", AreaSchools = Willamette });

                context.Areas.AddRange(Districts);
                context.SaveChanges();
            }
            #endregion


            #region Sports
            if (!context.Sports.Any())
            {
                List<Sport> sports = new List<Sport>();
                sports.Add(new Sport() { SportName = "Basketball" });
                sports.Add(new Sport() { SportName = "Baseball" });
                sports.Add(new Sport() { SportName = "Soccer" });
                sports.Add(new Sport() { SportName = "Football" });

                context.Sports.AddRange(sports);
                context.SaveChanges();
            }
            #endregion

            #region Grades
            if (!context.Grades.Any())
            {
                List<Grade> grades = new List<Grade>();
                grades.Add(new Grade() { GradeName = "Kindergarten" });
                grades.Add(new Grade() { GradeName = "1st"  });
                grades.Add(new Grade() { GradeName = "2nd" });
                grades.Add(new Grade() { GradeName = "3rd"  });
                grades.Add(new Grade() { GradeName = "4th" });
                grades.Add(new Grade() { GradeName = "5th" });
                grades.Add(new Grade() { GradeName = "6th" });
                grades.Add(new Grade() { GradeName = "7th" });
                grades.Add(new Grade() { GradeName = "8th" });
                grades.Add(new Grade() { GradeName = "9th" });

                context.Grades.AddRange(grades);
                context.SaveChanges();
            }
            #endregion

            #region Experience
            if (!context.Experiences.Any())
            {
                List<Experience> experience = new List<Experience>();
                experience.Add(new Experience() { ExperienceName = "Elementary School" });
                experience.Add(new Experience() { ExperienceName = "Middle School" });
                experience.Add(new Experience() { ExperienceName = "High School" });
                experience.Add(new Experience() { ExperienceName = "Collegiate" });

                context.Experiences.AddRange(experience);
                context.SaveChanges();
            }
            #endregion

            #region UpdateApplink
            if (!context.AppLinks.Any())
            {
                AppLink nfhs = new AppLink();
                AppLink pca = new AppLink();
                AppLink pledge = new AppLink();
                AppLink voucher = new AppLink();

                nfhs.Key = "NFHS";
                nfhs.Link = "https://nfhslearn.com/courses/61064/concussion-in-sports";

                pca.Key = "PCA";
                pca.Link = "http://shopping.positivecoach.org/Double-Goal-Coach?search=Course";

                pledge.Key = "Pledge";
                pledge.Link = "http://kidsports.azurewebsites.net/CoachEthicContract.pdf";

                voucher.Key = "Voucher";
                voucher.Link = "EmeraldKidSports16";

                context.AppLinks.Add(nfhs);
                context.AppLinks.Add(pca);
                context.AppLinks.Add(pledge);
                context.AppLinks.Add(voucher);
                context.SaveChanges();
            }
            #endregion
        }
    }
}