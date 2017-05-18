using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KidSports.Models;
using KidSports.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Kidsports.Tests
{
    public class FakeRepository : IApplicationRepo
    {
        User user1;
        User user2;
        User user3;
        List<Application> applications;

        public FakeRepository()

        {
            user1 = new User() { FirstName = "Paul", MiddleName = "M", LastName = "Smith" };
            user2 = new User() { FirstName = "Scott", MiddleName = "J", LastName = "Kinney" };
            user3 = new User() { FirstName = "Belinda", MiddleName = "L", LastName = "Carlisle" };
            applications = new List<Application>();

            Application app1 = new Application()
            {

                //ApplicationID = 1,
                DOB = new DateTime(1999 / 10 / 29),
                Address = "933 32nd St.",
                City = "Springfield",

                State = new State() { StateID = 1, StateName = "Oregon" },
                ZipCode = "97475",
                AppArea = new Area() { AreaName = "Springfield" },
                AppSchool = new School() { SchoolName = "Pleasant Hill" },

                AppSport = new Sport() { SportName = "Soccer", Gender = "Boys", MaxGrade = 7 },

                StatesLived = new List<AppStateJoin>() { new AppStateJoin
                {
                    ApplicationID = 1, StateID = 1
                }
                  
                },
                CountriesLived = new List<Country> {
                    new Country() {CountryName = "Canada" },
                },
                CurrentEmployer = "Best Buy",
                JobTitle = "Stocker",

                //YearCoached = new List<PreviousYearsCoached> {
                //    new PreviousYearsCoached() {YearCoached = 2010}
                //},
                //PrevGradesCoached = new List<PreviousGradessCoached> {
                //    new PreviousGradessCoached() {GradeName = "8th" }
                //},
                YearsExperience = 7
            };

            applications.Add(app1);








            Application app2 = new Application()
            {
                //ApplicationID = 2,
                PreviousLastNames = new List<LastName>{
                    new LastName() { Name = "Law" }
                },
                DOB = new DateTime(1975 / 1 / 10),
                Address = "1123 W. 10th St.",
                City = "Eugene",
                State = new State() { StateID = 1, StateName = "Oregon" },
                ZipCode = "97402",

                AppArea = new Area() { AreaName = "Churchill" },
                AppSchool = new School() { SchoolName = "Cesar Chavez" },

                AppSport = new Sport() { SportName = "Basketball", Gender = "Boys" },

                StatesLived = new List<AppStateJoin>() { new AppStateJoin
                {
                    ApplicationID = 1, StateID = 1
                }
                },
                CountriesLived = new List<Country> {
                    new Country() {CountryName = "Mexico" }
                },
                CurrentEmployer = "Lowe's",
                JobTitle = "Cashier",

                //YearCoached = new List<PreviousYearsCoached> {
                //    new PreviousYearsCoached() {YearCoached = 2005}
                //},
                //PrevGradesCoached = new List<PreviousGradessCoached> {
                //    new PreviousGradessCoached() {GradeName = "6th" }
                //},

                YearsExperience = 5,
            };

            applications.Add(app2);



            Application app3 = new Application()
            {
                //ApplicationID = 3,


                PreviousLastNames = new List<LastName>{
                    new LastName() { Name = "Law" }
                },
                DOB = new DateTime(1979 / 16 / 5),
                //DOB = DateTime.Parse("1/1/1950"),
                Address = "333 Sussex St.",
                City = "Eugene",
                State = new State() { StateID = 1, StateName = "Oregon" },
                ZipCode = "97401",

                AppArea = new Area() { AreaName = "North Eugene" },
                AppSchool = new School() { SchoolName = "Madison" },

                AppSport = new Sport() { SportName = "lacrosse", Gender = "Girls" },

                StatesLived = new List<AppStateJoin>() { new AppStateJoin
                {
                    ApplicationID = 1, StateID = 1
                }
                },
                CountriesLived = new List<Country> {
                    new Country() {CountryName = "Canada" }
                },
                CurrentEmployer = "IDX",
                JobTitle = "Tech Support",

               
                

                YearsExperience = 1,
            };

            //user1.UserApplications.Add(app1);
            //user2.UserApplications.Add(app2);
            //user3.UserApplications.Add(app3);

        }

        public List<Application> GetAllApplications()
        {
            return applications;
        }

        public IQueryable<Application> GetFilteredApplications(ApplicantSearchModel searchModel)
        {
            //set up using applications to test
            var result = applications.AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.Area))
                    result = result.Where(x => x.AppArea.AreaName == searchModel.Area);

                if (!string.IsNullOrEmpty(searchModel.School))
                    result = result.Where(x => x.AppSchool.SchoolName == searchModel.School);

                if (!string.IsNullOrEmpty(searchModel.Sport))
                    result = result.Where(x => x.AppSport.SportName == searchModel.Sport);

                if (!string.IsNullOrEmpty(searchModel.Gender))
                    result = result.Where(x => x.AppGender == searchModel.Gender);

                if (!string.IsNullOrEmpty(searchModel.Grade))
                    result = result.Where(x => x.AppGrade == searchModel.Grade);
            }
            return result;
        }

        public int Update(Application application)
        {
            throw new NotImplementedException();
        }

        public Application GetApplicationByID(int id)
        {
            throw new NotImplementedException();
        }

        public Application CreateApp(Application app)
        {
            throw new NotImplementedException();
        }
    }

}

