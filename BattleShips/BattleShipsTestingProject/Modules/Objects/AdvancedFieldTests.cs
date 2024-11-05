using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
	public class AdvancedFieldTests
	{
		[Fact]
		public void AdvancedField_ShouldHaveCorrectSize()
		{
			// Arrange
			var field = new AdvancedField("Test Field");

			// Act
			int expectedRows = 20;
			int expectedColumns = 20;

			// Assert
			Assert.Equal(expectedRows, field.Rows);
			Assert.Equal(expectedColumns, field.Columns);
		}
	}
}
