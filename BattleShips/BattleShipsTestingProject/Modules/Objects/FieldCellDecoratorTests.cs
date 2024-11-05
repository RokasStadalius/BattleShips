using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
	public class FieldCellDecoratorTests
	{
		private class TestFieldCell : FieldCell
		{
			public override string GetCellColorState(bool showShips)
			{
				return IsShot ? "Red" : "Green";
			}
		}

		private class TestFieldCellDecorator : FieldCellDecorator
		{
			public TestFieldCellDecorator(FieldCell cell) : base(cell) { }

			// Optionally override GetCellColorState to simulate different behavior if needed for specific tests
		}

		[Fact]
		public void FieldCellDecorator_ShouldWrapOriginalCell()
		{
			// Arrange
			var originalCell = new TestFieldCell { RowIndex = 1, ColIndex = 2, IsShot = true, IsAdjacent = false };
			var decorator = new TestFieldCellDecorator(originalCell);

			// Act & Assert
			Assert.Equal(originalCell.RowIndex, decorator.RowIndex);
			Assert.Equal(originalCell.ColIndex, decorator.ColIndex);
			Assert.Equal(originalCell.IsShot, decorator.IsShot);
			Assert.Equal(originalCell.IsAdjacent, decorator.IsAdjacent);
		}

		[Fact]
		public void GetCellColorState_ShouldReturnWrappedCellColorState()
		{
			// Arrange
			var originalCell = new TestFieldCell { IsShot = true };
			var decorator = new TestFieldCellDecorator(originalCell);

			// Act
			var colorState = decorator.GetCellColorState(true);

			// Assert
			Assert.Equal("Red", colorState);
		}
	}
}
