using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
	public class StandartFieldFactoryTests
	{
		[Fact]
		public void StandartFieldFactory_ShouldCreateStandartField()
		{
			// Arrange
			var factory = new StandartFieldFactory();
			var fieldName = "TestStandartField";

			// Act
			var field = factory.CreateField(fieldName);

			// Assert
			Assert.IsType<StandartField>(field);
			Assert.Equal(fieldName, field.Name);  // Assuming Field has a Name property
		}
	}
}
