using BattleShips.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
    public class FieldTests
    {
        private Field CreateField(int rows = 10, int columns = 10) => new Field("Test Field", rows, columns);

        [Fact]
        public void Constructor_ShouldInitializeField_WithCorrectDimensions()
        {
            var field = CreateField(10, 10);

            Assert.Equal(10, field.Rows);
            Assert.Equal(10, field.Columns);
            Assert.NotNull(field.MapLayout);
            Assert.Equal(10, field.MapLayout.Length);
            Assert.Equal(10, field.MapLayout[0].Length);
        }

        [Fact]
        public void PlaceShipOnMap_ShouldPlaceShipInSpecifiedCells()
        {
            var field = CreateField();
            var ship = new Battleship(1,1,"Testas");
            ship.IsVertical = false;
            var startingCell = new FieldCell(0, 0);

            field.PlaceShipOnMap(ship, startingCell);

            for (int i = 0; i < ship.Length; i++)
            {
                Assert.Equal(ship.ShipTypeID, field.MapLayout[0][i].CellShip.ShipTypeID);
                Assert.Equal(ship.ShipName, field.MapLayout[0][i].CellShip.ShipName);
                Assert.Equal(ship.Length, field.MapLayout[0][i].CellShip.Length);
            }
        }

        [Fact]
        public void PlaceShipOnMap_ShouldThrowException_WhenPlacementIsInvalid()
        {
            var field = CreateField();
            var ship = new Battleship(1, 1, "Testas");
            ship.IsVertical = false;
            var startingCell = new FieldCell(0, 7);

            Assert.Throws<InvalidOperationException>(() => field.PlaceShipOnMap(ship, startingCell));
        }

        [Fact]
        public void FireAtCell_ShouldUpdateCellStatusAndNotifyObservers()
        {
            var field = CreateField();
            var observerMock = new Mock<IFieldObserver>();
            field.RegisterObserver(observerMock.Object);
            var cell = new FieldCell(0, 0);
            var ship = new Battleship(1, 1, "Testas");
            ship.IsVertical = true;
            field.PlaceShipOnMap(ship, cell);

            field.FireAtCell(cell, ship);

            Assert.True(field.MapLayout[0][0].IsShot);
            observerMock.Verify(o => o.OnShotFired(field, cell), Times.Once);
        }

        [Fact]
        public void CanPlaceShip_ShouldReturnFalse_WhenShipOverflowsField()
        {
            var field = CreateField();
            var ship = new Battleship(1, 1, "Testas");
            ship.IsVertical = true;
            var startingCell = new FieldCell(7, 0);

            var result = field.CanPlaceShip(ship, startingCell);

            Assert.False(result);
        }

        [Fact]
        public void CanPlaceShip_ShouldReturnTrue_WhenPositionIsValid()
        {
            var field = CreateField();
            var ship = new Battleship(1, 1, "Testas");
            ship.IsVertical = true;
            var startingCell = new FieldCell(0, 0);

            var result = field.CanPlaceShip(ship, startingCell);

            Assert.True(result);
        }

        [Fact]
        public void IsOutOfShips_ShouldReturnTrue_WhenAllShipsAreShot()
        {
            var field = CreateField();
            var ship = new Battleship(1, 1, "Testas");
            ship.IsVertical = true;
            ship.Length = 1;
            var startingCell = new FieldCell(0, 0);
            field.PlaceShipOnMap(ship, startingCell);
            field.FireAtCell(startingCell, ship);

            var result = field.IsOutOfShips();

            Assert.True(result);
        }

        [Fact]
        public void IsOutOfShips_ShouldReturnFalse_WhenUnshotShipsRemain()
        {
            var field = CreateField();
            var ship = new Battleship(1, 1, "Testas");
            ship.IsVertical = true;
            var startingCell = new FieldCell(0, 0);
            field.PlaceShipOnMap(ship, startingCell);

            var result = field.IsOutOfShips();

            Assert.False(result);
        }
    }
}
