using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
	public class ShipFactoryTests
	{
		#region GermanShipFactory Tests

		[Fact]
        public void GermanShipFactory_ShouldCreateBattleship()
		{
			// Arrange
			IShipFactory factory = new GermanShipFactory();

			// Act
			Ship battleship = factory.CreateBattleship(1, 1, "Bismarck");

			// Assert
			Assert.NotNull(battleship);
			Assert.IsType<Battleship>(battleship);
		}

		[Fact]
		public void GermanShipFactory_ShouldCreateCarrier()
		{
			// Arrange
			IShipFactory factory = new GermanShipFactory();

			// Act
			Ship carrier = factory.CreateCarrier(2, 2, "Graf Zeppelin");

			// Assert
			Assert.NotNull(carrier);
			Assert.IsType<Carrier>(carrier);
			Assert.Equal("Graf Zeppelin", carrier.ShipName);
		}

		[Fact]
		public void GermanShipFactory_ShouldCreateDestroyer()
		{
			// Arrange
			IShipFactory factory = new GermanShipFactory();

			// Act
			Ship destroyer = factory.CreateDestroyer(3, 3, "Z1 Leberecht Maass");

			// Assert
			Assert.NotNull(destroyer);
			Assert.IsType<Destroyer>(destroyer);
			Assert.Equal("Z1 Leberecht Maass", destroyer.ShipName);
		}

		[Fact]
		public void GermanShipFactory_ShouldCreateSubmarine()
		{
			// Arrange
			IShipFactory factory = new GermanShipFactory();

			// Act
			Ship submarine = factory.CreateSubmarine(4, 4, "U-47");

			// Assert
			Assert.NotNull(submarine);
			Assert.IsType<Submarine>(submarine);
			Assert.Equal("U-47", submarine.ShipName);
		}

		#endregion

		#region SovietShipFactory Tests

		[Fact]
		public void SovietShipFactory_ShouldCreateBattleship()
		{
			// Arrange
			IShipFactory factory = new SovietShipFactory();

			// Act
			Ship battleship = factory.CreateBattleship(1, 1, "Sovietsky Soyuz");

			// Assert
			Assert.NotNull(battleship);
			Assert.IsType<Battleship>(battleship);
			Assert.Equal("Sovietsky Soyuz", battleship.ShipName);
		}

		[Fact]
		public void SovietShipFactory_ShouldCreateCarrier()
		{
			// Arrange
			IShipFactory factory = new SovietShipFactory();

			// Act
			Ship carrier = factory.CreateCarrier(2, 2, "Kuznetsov");

			// Assert
			Assert.NotNull(carrier);
			Assert.IsType<Carrier>(carrier);
			Assert.Equal("Kuznetsov", carrier.ShipName);
		}

		[Fact]
		public void SovietShipFactory_ShouldCreateDestroyer()
		{
			// Arrange
			IShipFactory factory = new SovietShipFactory();

			// Act
			Ship destroyer = factory.CreateDestroyer(3, 3, "Sovremenny");

			// Assert
			Assert.NotNull(destroyer);
			Assert.IsType<Destroyer>(destroyer);
			Assert.Equal("Sovremenny", destroyer.ShipName);
		}

		[Fact]
		public void SovietShipFactory_ShouldCreateSubmarine()
		{
			// Arrange
			IShipFactory factory = new SovietShipFactory();

			// Act
			Ship submarine = factory.CreateSubmarine(4, 4, "K-19");

			// Assert
			Assert.NotNull(submarine);
			Assert.IsType<Submarine>(submarine);
			Assert.Equal("K-19", submarine.ShipName);
		}

		#endregion
	}
}
