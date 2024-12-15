namespace BattleShips.Models
{
    public interface IShipVisitor
    {
        void VisitDestroyer(Destroyer destroyer);
        void VisitSubmarine(Submarine submarine);
        void VisitBattleship(Battleship battleship);
        void VisitCarrier(Carrier carrier);
    }
}
