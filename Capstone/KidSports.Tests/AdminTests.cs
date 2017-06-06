using Xunit;
using KidSports.Models.ViewModels;
using KidSports.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Kidsports.Tests
{
    public class AdminTests
    {
      
        private AdminController controller;


        [Fact]
        public void CanAddUser()
        {
            //Arrange
            var vm = new UpdateUserViewModel();
            vm.FirstName = "Paul";
            vm.MiddleName = "S";
            vm.LastName = "Jones";
            vm.Email = "jonesp@gmail.com";
            //vm.Role = "Sport manager";

            //Act
            controller.AddUser(vm);

            //Assert
            Assert.Equal("Paul", vm.FirstName);
            Assert.Equal("Jones", vm.LastName);

        }

        [Fact]
        public void CanDeleteUser()
        { }


    }
}
