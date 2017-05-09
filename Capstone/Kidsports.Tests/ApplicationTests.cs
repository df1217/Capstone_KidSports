using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KidSports.Controllers;
using KidSports.Models;
using Xunit;
using Microsoft.AspNetCore.Hosting;

namespace Kidsports.Tests
{
    public class ApplicationTests
    {
        FakeAppRepository repository = new FakeAppRepository();
        ApplicationController controller;
        List<Application> AppsFromRepo;


        public ApplicationTests()
        {
            repository = new FakeAppRepository();
            AppsFromRepo = repository.GetAllApplications().ToList();
            //controller = new ApplicationController(repository);
        }

        [Fact]
        public void GetAllApplications()
        {
            //Act
            FakeAppRepository fake = new FakeAppRepository();
            List<Application> apps = fake.GetAllApplications();
            Assert.Equal(3, apps.Count());
            // Assert
            //Assert.Equal("Pleasant Hill", apps[0].AppArea.AreaName ); 
               
            //Assert.Equal(AppsFromRepo[i].AppArea,
            //    applications[i].AppArea);
            //Assert.Equal(AppsFromRepo[i].AppGender,
            //    applications[i].AppGender);
            

        }


        [Fact]
        public IQueryable<Application> GetFilteredApplications(ApplicantSearchModel searchModel)
        {
            throw new NotImplementedException();
        }


    }

}
