using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
	public class StandartFieldTests
	{

		[Fact]
		public void StandartField_ShouldHaveCorrectSize()
		{
			// Arrange
			var field = new StandartField("Test Field");

			// Act
			int expectedRows = 10;
			int expectedColumns = 10;

			// Assert
			Assert.Equal(expectedRows, field.Rows);
			Assert.Equal(expectedColumns, field.Columns);
		}
	}
}
