using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
	public class MediumFieldFactoryTests
	{
		[Fact]
		public void MediumFieldFactory_ShouldCreateMediumField()
		{
			// Arrange
			var factory = new MediumFieldFactory();
			var fieldName = "TestMediumField";

			// Act
			var field = factory.CreateField(fieldName);

			// Assert
			Assert.IsType<MediumField>(field);
			Assert.Equal(fieldName, field.Name);
		}
	}
}
