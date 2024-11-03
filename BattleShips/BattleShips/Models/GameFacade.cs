namespace BattleShips.Models
{
    public class GameFacade
    {
        private Field gameField;
        private IShipFactory shipFactory;
        public List<Ship> availableShips;

        public GameFacade(Field field, IShipFactory factory)
        {
            gameField = field;
            shipFactory = factory;
            availableShips = new List<Ship>();
        }

        public void CreateAndAddShip(string shipType, int shipID, int shipTypeID, string shipName) //utilize ship creation with ShipFactory methods
        {
            Ship newShip = shipType.ToLower() switch
            {
                "battleship" => shipFactory.CreateBattleship(shipID, shipTypeID, shipName),
                "carrier" => shipFactory.CreateCarrier(shipID, shipTypeID, shipName),
                "destroyer" => shipFactory.CreateDestroyer(shipID, shipTypeID, shipName),
                "submarine" => shipFactory.CreateSubmarine(shipID, shipTypeID, shipName),
                _ => throw new ArgumentException("Invalid type of the ship provided.")
            };

            availableShips.Add(newShip);
        }

        public bool PlaceShip(int shipIndex, FieldCell startingCell)
        {
            if (shipIndex < 0 || shipIndex >= availableShips.Count)
                throw new ArgumentOutOfRangeException(nameof(shipIndex));

            Ship selectedShip = availableShips[shipIndex];
            if(gameField.CanPlaceShip(selectedShip, startingCell))
            {
                gameField.PlaceShipOnMap(selectedShip, startingCell);
                return true;//if ship can be placed
            }
            else
            {
                return false;//if placement is invalid
            }
        }

        public void FireAtCell (int row, int col, int shipIndex)
        {
            if (shipIndex < 0 || shipIndex >= availableShips.Count)
                throw new IndexOutOfRangeException(nameof(shipIndex));

            FieldCell targetCell = gameField.MapLayout[row][col];
            Ship attackingShip = availableShips[shipIndex];

            if (!targetCell.IsShot)
            {
                gameField.FireAtCell(targetCell, attackingShip);
            }
            else
            {
                Console.WriteLine("The cell has been shot before");
            }
        }

        public void RemoveShip(int shipIndex, FieldCell startCell)
        {
            if (shipIndex < 0 || shipIndex >= availableShips.Count)
                throw new IndexOutOfRangeException(nameof(shipIndex));

            Ship shipToRemove = availableShips[shipIndex];

            //determine occupied cells based on ship's orientation and length
            List<FieldCell> occupiedCells = new List<FieldCell>();

            if (shipToRemove.IsVertical)
            {
                for (int i = 0; i < shipToRemove.Length; i++)
                {
                    occupiedCells.Add(new FieldCell(startCell.RowIndex + i, startCell.ColIndex));
                }
            }
            else //if horizontal
            {
                for (int i = 0; i < shipToRemove.Length; i++)
                {
                    occupiedCells.Add(new FieldCell(startCell.RowIndex, startCell.ColIndex + i));
                }
            }

            foreach (var cell in occupiedCells)
            {
                gameField.MapLayout[cell.RowIndex][cell.ColIndex] = new FieldCell(cell.RowIndex, cell.ColIndex); //reset the cells occupied by ship
            }

            availableShips.RemoveAt(shipIndex);
        }

        public void UndoFireAt(int row, int col)
        {
            FieldCell targetCell = gameField.MapLayout[row][col];

            if (targetCell.IsShot)
            {
                targetCell.IsShot = false; // Reset the shot status
            }
        }

        public bool IsGameOver()
        {
            return gameField.IsOutOfShips();
        }

        public Field GetGameField()
        {
            return gameField;
        }
    }
}
