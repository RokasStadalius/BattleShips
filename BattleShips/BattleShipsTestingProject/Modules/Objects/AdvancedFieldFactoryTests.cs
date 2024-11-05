using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
	public class AdvancedFieldFactoryTests
	{
		[Fact]
		public void AdvancedFieldFactory_ShouldCreateAdvancedField()
		{
			// Arrange
			var factory = new AdvancedFieldFactory();
			var fieldName = "TestAdvancedField";

			// Act
			var field = factory.CreateField(fieldName);

			// Assert
			Assert.IsType<AdvancedField>(field);
			Assert.Equal(fieldName, field.Name);
		}
	}
}
