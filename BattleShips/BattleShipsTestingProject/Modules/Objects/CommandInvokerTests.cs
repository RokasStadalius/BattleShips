using BattleShips.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsTestingProject.Modules.Objects
{
    public class CommandInvokerTests
    {
        [Fact]
        public void ExecuteCommand_ShouldCallExecuteAndAddToHistory()
        {
            var commandMock = new Mock<ICommand>();
            var invoker = new CommandInvoker();

            invoker.ExecuteCommand(commandMock.Object);

            commandMock.Verify(c => c.Execute(), Times.Once);

            Assert.Single(GetCommandHistory(invoker));
        }

        [Fact]
        public void Undo_ShouldCallUndoOnLastExecutedCommand()
        {
            var commandMock = new Mock<ICommand>();
            var invoker = new CommandInvoker();
            invoker.ExecuteCommand(commandMock.Object);

            invoker.Undo();

            commandMock.Verify(c => c.Undo(), Times.Once);

            Assert.Empty(GetCommandHistory(invoker));
        }

        [Fact]
        public void Undo_ShouldDoNothingWhenHistoryIsEmpty()
        {
            var invoker = new CommandInvoker();

            var exception = Record.Exception(() => invoker.Undo());
            Assert.Null(exception);
        }

        [Fact]
        public void ExecuteMultipleCommands_ShouldUndoInCorrectOrder()
        {
            var firstCommandMock = new Mock<ICommand>();
            var secondCommandMock = new Mock<ICommand>();
            var invoker = new CommandInvoker();

            invoker.ExecuteCommand(firstCommandMock.Object);
            invoker.ExecuteCommand(secondCommandMock.Object);

            invoker.Undo();
            secondCommandMock.Verify(c => c.Undo(), Times.Once);
            firstCommandMock.Verify(c => c.Undo(), Times.Never);

            invoker.Undo();
            firstCommandMock.Verify(c => c.Undo(), Times.Once);
        }

        private Stack<ICommand> GetCommandHistory(CommandInvoker invoker)
        {
            var field = typeof(CommandInvoker).GetField("_commandHistory", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (Stack<ICommand>)field?.GetValue(invoker);
        }
    }
}