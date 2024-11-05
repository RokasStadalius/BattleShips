using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
	public class PrototypeTests
	{
		[Fact]
		public void Destroyer_Clone_CreatesCorrectClone()
		{
			// Arrange
			var originalDestroyer = new Destroyer(1, 1, "Destroyer-1")
			{
				IsVertical = true
			};

			// Act
			var clonedDestroyer = (Destroyer)originalDestroyer.Clone();


			// Assert
			Assert.NotSame(originalDestroyer, clonedDestroyer);
			Assert.Equal(originalDestroyer.ShipID, clonedDestroyer.ShipID);
			Assert.Equal(originalDestroyer.ShipTypeID, clonedDestroyer.ShipTypeID);
			Assert.Equal(originalDestroyer.ShipName, clonedDestroyer.ShipName);
			Assert.Equal(originalDestroyer.MaxPlacementCount, clonedDestroyer.MaxPlacementCount);
			Assert.Equal(originalDestroyer.Length, clonedDestroyer.Length);
			Assert.Equal(originalDestroyer.IsVertical, clonedDestroyer.IsVertical);
			Assert.NotSame(originalDestroyer.AttackStrategy, clonedDestroyer.AttackStrategy);
		}

		[Fact]
		public void Submarine_Clone_CreatesCorrectClone()
		{
			// Arrange
			var originalSubmarine = new Submarine(2, 2, "Submarine-1")
			{
				IsVertical = false
			};

			// Act
			var clonedSubmarine = (Submarine)originalSubmarine.Clone();

			// Assert
			Assert.NotSame(originalSubmarine, clonedSubmarine);
			Assert.Equal(originalSubmarine.ShipID, clonedSubmarine.ShipID);
			Assert.Equal(originalSubmarine.ShipTypeID, clonedSubmarine.ShipTypeID);
			Assert.Equal(originalSubmarine.ShipName, clonedSubmarine.ShipName);
			Assert.Equal(originalSubmarine.MaxPlacementCount, clonedSubmarine.MaxPlacementCount);
			Assert.Equal(originalSubmarine.Length, clonedSubmarine.Length);
			Assert.Equal(originalSubmarine.IsVertical, clonedSubmarine.IsVertical);
			Assert.NotSame(originalSubmarine.AttackStrategy, clonedSubmarine.AttackStrategy);
		}

		[Fact]
		public void Battleship_Clone_CreatesCorrectClone()
		{
			// Arrange
			var originalBattleship = new Battleship(3, 3, "Battleship-1")
			{
				IsVertical = true
			};

			// Act
			var clonedBattleship = (Battleship)originalBattleship.Clone();

			// Assert
			Assert.NotSame(originalBattleship, clonedBattleship);
			Assert.Equal(originalBattleship.ShipID, clonedBattleship.ShipID);
			Assert.Equal(originalBattleship.ShipTypeID, clonedBattleship.ShipTypeID);
			Assert.Equal(originalBattleship.ShipName, clonedBattleship.ShipName);
			Assert.Equal(originalBattleship.MaxPlacementCount, clonedBattleship.MaxPlacementCount);
			Assert.Equal(originalBattleship.Length, clonedBattleship.Length);
			Assert.Equal(originalBattleship.IsVertical, clonedBattleship.IsVertical);
			Assert.NotSame(originalBattleship.AttackStrategy, clonedBattleship.AttackStrategy);
		}

		[Fact]
		public void Carrier_Clone_CreatesCorrectClone()
		{
			// Arrange
			var originalCarrier = new Carrier(4, 4, "Carrier-1")
			{
				IsVertical = false
			};

			// Act
			var clonedCarrier = (Carrier)originalCarrier.Clone();

			// Assert
			Assert.NotSame(originalCarrier, clonedCarrier);
			Assert.Equal(originalCarrier.ShipID, clonedCarrier.ShipID);
			Assert.Equal(originalCarrier.ShipTypeID, clonedCarrier.ShipTypeID);
			Assert.Equal(originalCarrier.ShipName, clonedCarrier.ShipName);
			Assert.Equal(originalCarrier.MaxPlacementCount, clonedCarrier.MaxPlacementCount);
			Assert.Equal(originalCarrier.Length, clonedCarrier.Length);
			Assert.Equal(originalCarrier.IsVertical, clonedCarrier.IsVertical);
			Assert.NotSame(originalCarrier.AttackStrategy, clonedCarrier.AttackStrategy);
		}
	}
}
