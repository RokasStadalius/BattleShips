using BattleShips.Services;

namespace BattleShips.Models
{
    public class FireAtCellCommand : ICommand
    {
        private readonly GameFacade _gameFacade;
        private readonly int _row;
        private readonly int _col;
        private readonly int _shipIndex;

        public FireAtCellCommand(GameFacade gameFacade, int row, int col, int shipIndex)
        {
            _gameFacade = gameFacade;
            _row = row;
            _col = col;
            _shipIndex = shipIndex;
        }

        public void Execute()
        {
            _gameFacade.FireAtCell(_row, _col, _shipIndex);
        }

        public void Undo()
        {
            _gameFacade.UndoFireAt(_row, _col);
        }
    }
}
