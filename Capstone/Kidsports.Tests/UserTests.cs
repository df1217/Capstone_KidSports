using KidSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Kidsports.Tests
{
    public class UserTests
    {
        
        [Fact]
        public void CanCreateUser()
        {
            //Arrange
            var n = new User();

            //Act
            n.FirstName = "Sean";
            n.MiddleName = "M";
            n.LastName = "Smith";

            //Assert
            Assert.True(n.FirstName == "Sean");
            Assert.False(n.MiddleName == "L");
            Assert.True(n.LastName == "Smith");
        }

        [Fact]
        public void CanUpdateUserInfo()
        {
            //Arrange
            var n = new User { FirstName = "Joan", LastName = "Walters" };

            //Act
            n.LastName = "Jones";

            //Assert
            Assert.Equal("Jones", n.LastName);
        }

        
    }
}
