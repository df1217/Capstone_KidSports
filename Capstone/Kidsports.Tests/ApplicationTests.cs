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
        public void IsSingleFilterQuerable()
        {
            repo = new FakeRepository();
            //Act
            ApplicationSearchModel asm = new ApplicationSearchModel();
            //asm.Area = "Churchill";
            asm.Area = "Springfield";

            List<Application> applications = repo.GetFilteredApplications(asm).ToList();

            //Assert
            Assert.Equal(1, applications.Count);

        }

        [Fact]
        public void IsDoubleFilterQuerable()
        {
            repo = new FakeRepository();
            //Act
            ApplicationSearchModel asm = new ApplicationSearchModel();
            asm.Sport = "lacrosse";
            asm.Area = "North Eugene";

            //asm.Sport = "Basketball";
            //asm.Area = "Churchill";

            List<Application> applications = repo.GetFilteredApplications(asm).ToList();


            //Assert
            Assert.Equal(1, applications.Count);

        }

        [Fact]
        public void IsTripleFilterQuerable()
        {
            repo = new FakeRepository();

            //Act
            ApplicationSearchModel asm = new ApplicationSearchModel();
            //asm.Sport = "Soccer";
            //asm.Area = "Springfield";
            //asm.School = "Pleasant Hill";

            asm.Sport = "Basketball";
            asm.Area = "Churchill";
            asm.School = "Cesar Chavez";

            //Assert
            Assert.Equal(1, applications.Count);
        }
    }
}
