using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
    public class AttackStrategyTests
    {
        [Fact]
        public void DestroyerAttackStrategy_ShouldReturnSingleTargetCell()
        {
            var strategy = new DestroyerAttackStrategy();
            var target = new FieldCell(2, 2);

            var result = strategy.ExecuteAttack(target);

            Assert.Single(result);
            Assert.Equal(target, result[0]);
        }

        [Fact]
        public void SubmarineAttackStrategy_ShouldReturnCrossPattern()
        {
            var strategy = new SubmarineAttackStrategy();
            var target = new FieldCell(2, 2);

            var result = strategy.ExecuteAttack(target);

            // Assert: Expect 5 cells in a cross pattern
            Assert.Equal(5, result.Count);
            Assert.Contains(new FieldCell(2, 2), result); // Center
            Assert.Contains(new FieldCell(1, 2), result); // Up
            Assert.Contains(new FieldCell(3, 2), result); // Down
            Assert.Contains(new FieldCell(2, 1), result); // Left
            Assert.Contains(new FieldCell(2, 3), result); // Right
        }

        [Fact]
        public void BattleshipAttackStrategy_ShouldReturnHorizontalLinePattern()
        {
            var strategy = new BattleshipAttackStrategy();
            var target = new FieldCell(2, 2);

            var result = strategy.ExecuteAttack(target);

            // Assert: Expect 4 cells in a horizontal line
            Assert.Equal(4, result.Count);
            Assert.Contains(new FieldCell(2, 2), result);
            Assert.Contains(new FieldCell(2, 3), result);
            Assert.Contains(new FieldCell(2, 4), result);
            Assert.Contains(new FieldCell(2, 5), result);
        }

        [Fact]
        public void CarrierAttackStrategy_ShouldReturnSurroundPattern()
        {
            var strategy = new CarrierAttackStrategy();
            var target = new FieldCell(2, 2);

            var result = strategy.ExecuteAttack(target);

            // Assert: Expect 9 cells surrounding the target
            Assert.Equal(9, result.Count);
            Assert.Contains(new FieldCell(2, 2), result); // Center
            Assert.Contains(new FieldCell(1, 1), result); // Top-left
            Assert.Contains(new FieldCell(1, 3), result); // Top-right
            Assert.Contains(new FieldCell(3, 1), result); // Bottom-left
            Assert.Contains(new FieldCell(3, 3), result); // Bottom-right
            Assert.Contains(new FieldCell(1, 2), result); // Up
            Assert.Contains(new FieldCell(3, 2), result); // Down
            Assert.Contains(new FieldCell(2, 1), result); // Left
            Assert.Contains(new FieldCell(2, 3), result); // Right
        }

        [Fact]
        public void Clone_ShouldReturnNewInstanceOfDestroyerAttackStrategy()
        {
            var strategy = new DestroyerAttackStrategy();

            var clone = strategy.Clone();

            Assert.IsType<DestroyerAttackStrategy>(clone);
            Assert.NotSame(strategy, clone);
        }

        [Fact]
        public void Clone_ShouldReturnNewInstanceOfSubmarineAttackStrategy()
        {
            var strategy = new SubmarineAttackStrategy();

            var clone = strategy.Clone();

            Assert.IsType<SubmarineAttackStrategy>(clone);
            Assert.NotSame(strategy, clone);
        }

        [Fact]
        public void Clone_ShouldReturnNewInstanceOfBattleshipAttackStrategy()
        {
            var strategy = new BattleshipAttackStrategy();

            var clone = strategy.Clone();

            Assert.IsType<BattleshipAttackStrategy>(clone);
            Assert.NotSame(strategy, clone);
        }

        [Fact]
        public void Clone_ShouldReturnNewInstanceOfCarrierAttackStrategy()
        {
            var strategy = new CarrierAttackStrategy();

            var clone = strategy.Clone();

            Assert.IsType<CarrierAttackStrategy>(clone);
            Assert.NotSame(strategy, clone);
        }
    }
}
