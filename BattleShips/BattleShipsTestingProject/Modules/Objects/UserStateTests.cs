using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
    public class UserStateTests
    {
        [Fact]
        public void SetUser_UpdatesCurrentUser()
        {
            var userState = new UserState();
            var user = new User("Testas");

            userState.SetUser(user);

            Assert.Equal(user, userState.CurrentUser);
        }

        [Fact]
        public void SetUser_Notifies()
        {
            var userState = new UserState();
            var user = new User("Testas");
            bool eventFired = false;

            userState.OnChange += () => eventFired = true;
            userState.SetUser(user);

            Assert.True(eventFired);
        }
    }
}
