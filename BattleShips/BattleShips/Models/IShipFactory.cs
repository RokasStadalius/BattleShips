namespace BattleShips.Models
{
    public interface IShipFactory
    {
        Ship CreateDestroyer(int shipID, int shipTypeID, string shipName);
        Ship CreateSubmarine(int shipID, int shipTypeID, string shipName);
        Ship CreateBattleship(int shipID, int shipTypeID, string shipName);
        Ship CreateCarrier(int shipID, int shipTypeID, string shipName);
    }
}
