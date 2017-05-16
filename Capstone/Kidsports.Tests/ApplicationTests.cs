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
        FakeRepository repo;
        List<Application> applications = new List<Application>();


        public ApplicationTests()
        {
  
        }

        [Fact]
        public void DoesGetAllApplications()
        {
            repo = new FakeRepository();
            //Assert.Equal(3, applications.Count());
          
            Assert.Equal("Springfield", repo.GetAllApplications()[0].City);
            //Assert.Equal(repo.GetAllApplications()[0].Address, "Springfield");



        }

        [Fact]
        public void IsDoubleFilterQuerable()
        {
            repo = new FakeRepository();
            //Act
            ApplicantSearchModel asm = new ApplicantSearchModel();
            asm.Sport = "lacrosse";
            asm.Area = "North Eugene";

            List<Application> applications = repo.GetFilteredApplications(asm).ToList();
            

            //Assert
            Assert.Equal(1, applications.Count);

        }
    }
}
