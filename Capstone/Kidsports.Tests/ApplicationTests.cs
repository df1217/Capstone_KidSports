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
        ApplicationController controller;


        public ApplicationTests()
        {
            repo = new FakeRepository();
            //controller = new ApplicationController();
        }

        [Fact]
        public void DoesGetAllApplications()
        {
            
            //Assert.Equal(3, applications.Count());

            Assert.Equal("Springfield", repo.GetAllApplications()[0].City);
            Assert.Equal("Cashier", repo.GetAllApplications()[1].JobTitle);
            Assert.Equal("97401", repo.GetAllApplications()[2].ZipCode);


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
           
            //Act
            ApplicationSearchModel asm = new ApplicationSearchModel();
            asm.Sport = "lacrosse";
            asm.Area = "North Eugene";

            List<Application> applications = repo.GetFilteredApplications(asm).ToList();


            //Assert
            Assert.Equal(1, applications.Count);

        }

        [Fact]
        public void IsTripleFilterQuerable()
        {
            

            //Act
            ApplicationSearchModel asm = new ApplicationSearchModel();
            //asm.Sport = "Soccer";
            //asm.Area = "Springfield";
            //asm.School = "Pleasant Hill";

            asm.Sport = "Basketball";
            asm.Area = "Churchill";
            asm.School = "Cesar Chavez";
            List<Application> applications = repo.GetFilteredApplications(asm).ToList();

            //Assert
            Assert.Equal(1, applications.Count);
        }

        [Fact]
        public void IsQuadFilterQuerable()
        {


            //Act
            ApplicationSearchModel asm = new ApplicationSearchModel();

            //asm.Sport = "lacrosse";
            //asm.Area = "North Eugene";
            //asm.School = "Madison";
            //asm.Gender= "Girls";

            asm.Sport = "Soccer";
            asm.Area = "Springfield";
            asm.School = "Pleasant Hill";
            asm.Gender = "Boys";
            List<Application> applications = repo.GetFilteredApplications(asm).ToList();

            //Assert
            Assert.Equal(1, applications.Count);
        }

       

    }
}
