using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
	public class RoomTests
	{
		[Fact]
		public void RoomInitialization_Test()
		{
			// Arrange
			string roomName = "Test Room";
			string roomType = "Public";

			// Act
			var room = new Room(roomName, roomType);

			// Assert
			Assert.NotNull(room.RoomId);
			Assert.Equal(roomName, room.RoomName);
			Assert.False(room.IsGameStarted);
			Assert.Equal(roomType, room.RoomType);
			Assert.True(room.UserFields.Count == 0);
			Assert.Equal(2, room.MaxPlayerCount);
		}

		[Fact]
		public void Room_FullCapacity_Test()
		{
			// Arrange
			var room = new Room("Test Room", "Public");
			var user1 = new User("TestUser");
			var user2 = new User("TestUser2");
			var field1 = new StandartField("Test Field");
			var field2 = new StandartField("Test Field2");

			// Act
			room.UserFields.Add(new Tuple<Field, User, bool>(field1, user1, false));
			room.UserFields.Add(new Tuple<Field, User, bool>(field2, user2, false));

			// Assert
			Assert.True(room.IsFull);
			Assert.Equal(2, room.CurrentPlayerCount);
		}

		[Fact]
		public void Room_SetPlayerReady_StartsGameWhenAllReady_Test()
		{
			// Arrange
			var room = new Room("Test Room", "Public");
			var user1 = new User("TestUser");
			var user2 = new User("TestUser2");
			var field1 = new StandartField("Test Field");
			var field2 = new StandartField("Test Field2");
			user1.UserId = "1";
			user2.UserId = "2";

			room.UserFields.Add(new Tuple<Field, User, bool>(field1, user1, false));
			room.UserFields.Add(new Tuple<Field, User, bool>(field2, user2, false));

			// Act
			room.SetPlayerReady("1");

			room.SetPlayerReady("2");

			// Assert
			Assert.True(room.IsGameStarted);
		}

		[Fact]
		public void Room_ChangeTurn_AlternatesTurns_Test()
		{
			// Arrange
			var room = new Room("Test Room", "Public");
			var user1 = new User("TestUser");
			var user2 = new User("TestUser2");
			var field1 = new StandartField("Test Field");
			var field2 = new StandartField("Test Field2");
			user1.UserId = "1";
			user2.UserId = "2";

			room.UserFields.Add(new Tuple<Field, User, bool>(field1, user1, true));
			room.UserFields.Add(new Tuple<Field, User, bool>(field2, user2, true));
			room.CurrentUserTurnID = "1";

			// Act
			room.ChangeTurn();
			// Assert
			Assert.Equal("2", room.CurrentUserTurnID);

			// Act - change back
			room.ChangeTurn();

			// Assert
			Assert.Equal("1", room.CurrentUserTurnID);
		}
	}

}