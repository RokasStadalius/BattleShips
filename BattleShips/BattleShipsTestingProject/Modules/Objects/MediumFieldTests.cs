using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
	public class MediumFieldTests
	{

		[Fact]
		public void MediumField_ShouldHaveCorrectSize()
		{
			// Arrange
			var field = new MediumField("Test Field");

			// Act
			int expectedRows = 15;
			int expectedColumns = 15;

			// Assert
			Assert.Equal(expectedRows, field.Rows);
			Assert.Equal(expectedColumns, field.Columns);
		}
	}
}
