using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp.functionality;

namespace TestingApp.Test
{
    public class UserManagementTesting
    {
        [Fact]
        public void ADD_CreateUser() 
        {
            // Arrange
            var userManagement = new UserManagement();

            // Act
            userManagement.Add(new("Abhash", "Kumar"));

            //Assert
            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser); // checking usermanagement list is not empty
            Assert.Equal("Abhash", savedUser.firstName);
            Assert.Equal("Kumar", savedUser.LastName);
            Assert.False(savedUser.VerifiedEmail);
        }

        [Fact]
        public void Update_UpdateMobileNumber()
        {
            // Arrange
            var userManagement = new UserManagement();

            //Act
            userManagement.Add(new("Abhash", "Kumar"));

            var firstUser = userManagement.AllUsers.First();
            firstUser.Phone = "7278244981";

            userManagement.UpdatePhone(firstUser);

            //Assert
            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser);
            Assert.Equal("7278244981", savedUser.Phone);
        }
    }
}
