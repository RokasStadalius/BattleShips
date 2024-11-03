using BattleShips.Services;

namespace BattleShips.Models
{
    public class PlaceShipCommand : ICommand
    {
        private readonly GameFacade _gameFacade;
        private readonly int _shipIndex;
        private readonly FieldCell _startingCell;

        public PlaceShipCommand(GameFacade gameFacade, int shipIndex, FieldCell startingCell)
        {
            _gameFacade = gameFacade;
            _shipIndex = shipIndex;
            _startingCell = startingCell;
        }

        public void Execute()
        {
            if (_shipIndex < 0 || _shipIndex >= _gameFacade.availableShips.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(_shipIndex), "Ship index is out of range.");
            }
            _gameFacade.PlaceShip(_shipIndex, _startingCell);
        }

        public void Undo()
        {
            _gameFacade.RemoveShip(_shipIndex, _startingCell);
        }
    }
}
