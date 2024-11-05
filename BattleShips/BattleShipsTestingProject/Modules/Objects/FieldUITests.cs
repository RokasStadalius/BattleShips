using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
    public class FieldUITests
    {
        private readonly FieldUI _fieldUI;
        private bool _eventTriggered;

        public FieldUITests()
        {
            _fieldUI = new FieldUI();
            _fieldUI.OnLogUpdated += () => _eventTriggered = true;
        }

        [Fact]
        public void OnShipPlaced_ShouldLogMessageAndTriggerEvent()
        {
            // Arrange
            var testField = new Field("TestField", 10, 10);
            var testCell = new FieldCell { RowIndex = 3, ColIndex = 5 };
            var testShip = new Destroyer(1, 2, "TestDestroyer");

            // Act
            _fieldUI.OnShipPlaced(testField, testShip, testCell);

            // Assert
            Assert.Single(_fieldUI.MessageLog);
            Assert.Contains("Ship placed at Row 3, Column 5 on Field TestField", _fieldUI.MessageLog[0]);
            Assert.True(_eventTriggered);
        }

        [Fact]
        public void OnShotFired_ShouldLogMessageAndTriggerEvent()
        {
            // Arrange
            var testField = new Field("TestField", 10, 10);
            var testCell = new FieldCell { RowIndex = 4, ColIndex = 6 };

            // Act
            _fieldUI.OnShotFired(testField, testCell);

            // Assert
            Assert.Single(_fieldUI.MessageLog);
            Assert.Contains("Shot fired at Row 4, Column 6 on Field TestField", _fieldUI.MessageLog[0]);
            Assert.True(_eventTriggered);
        }

        [Fact]
        public void OnFieldStateChanged_ShouldLogMessageAndTriggerEvent()
        {
            // Arrange
            var testField = new Field("TestField", 10, 10);

            // Act
            _fieldUI.OnFieldStateChanged(testField);

            // Assert
            Assert.Single(_fieldUI.MessageLog);
            Assert.Contains("Field TestField state changed", _fieldUI.MessageLog[0]);
            Assert.True(_eventTriggered);
        }

        [Fact]
        public void MultipleEvents_ShouldAccumulateLogsCorrectly()
        {
            // Arrange
            var testField = new Field("TestField", 10, 10);
            var testCell = new FieldCell { RowIndex = 3, ColIndex = 5 };
            var testShip = new Destroyer(1, 2, "TestDestroyer");

            // Act
            _fieldUI.OnShipPlaced(testField, testShip, testCell);
            _eventTriggered = false;
            _fieldUI.OnShotFired(testField, testCell);
            _eventTriggered = false;
            _fieldUI.OnFieldStateChanged(testField);

            // Assert
            Assert.Equal(3, _fieldUI.MessageLog.Count);
            Assert.Contains("Ship placed at Row 3, Column 5 on Field TestField", _fieldUI.MessageLog[0]);
            Assert.Contains("Shot fired at Row 3, Column 5 on Field TestField", _fieldUI.MessageLog[1]);
            Assert.Contains("Field TestField state changed", _fieldUI.MessageLog[2]);
        }
    }
}
