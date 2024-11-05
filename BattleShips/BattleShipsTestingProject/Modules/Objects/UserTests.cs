using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
    public class UserTests
    {
        [Fact]
        public void User_Constructor_SetsUserName()
        {
            string expectedUserName = "Testas";

            var user = new User(expectedUserName);

            Assert.Equal(expectedUserName, user.UserName);
        }

        [Fact]
        public void User_Constructor_GeneratesUserId()
        {
            var user = new User("Testas");

            string userId = user.UserId;

            Assert.False(string.IsNullOrEmpty(userId));
        }

        [Fact]
        public void User_Constructor_SetsUserFieldToNull()
        {
            var user = new User("Testas");

            var userField = user.userField;

            Assert.Null(userField);
        }
    }
}
