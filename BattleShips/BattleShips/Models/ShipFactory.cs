namespace BattleShips.Models
{
    public class GermanShipFactory : IShipFactory
    {
        public Ship CreateBattleship(int shipID, int shipTypeID, string shipName)
        {
            return new Battleship(shipID, shipTypeID, shipName);
        }

        public Ship CreateCarrier(int shipID, int shipTypeID, string shipName)
        {
           return new Carrier(shipID,shipTypeID, shipName);
        }

        public Ship CreateDestroyer(int shipID, int shipTypeID, string shipName)
        {
            return new Destroyer(shipID, shipTypeID, shipName);
        }

        public Ship CreateSubmarine(int shipID, int shipTypeID, string shipName)
        {
            return new Submarine(shipID, shipTypeID, shipName);
        }
    }

    public class SovietShipFactory : IShipFactory
    {
        public Ship CreateBattleship(int shipID, int shipTypeID, string shipName)
        {
            return new Battleship(shipID, shipTypeID, shipName);
        }

        public Ship CreateCarrier(int shipID, int shipTypeID, string shipName)
        {
            return new Carrier (shipID, shipTypeID, shipName);
        }

        public Ship CreateDestroyer(int shipID, int shipTypeID, string shipName)
        {
            return new Destroyer(shipID, shipTypeID, shipName);
        }

        public Ship CreateSubmarine(int shipID, int shipTypeID, string shipName)
        {
            return new Submarine(shipID, shipTypeID, shipName);
        }
    }
}
