namespace BattleShips.Models
{
    public class ShipTotalHPVisitor : IShipVisitor
    {
        public int TotalHitPoints { get; private set; } = 0;

        public void VisitDestroyer(Destroyer destroyer)
        {
            TotalHitPoints += destroyer.Length;
        }

        public void VisitSubmarine(Submarine submarine)
        {
            TotalHitPoints += submarine.Length;
        }

        public void VisitBattleship(Battleship battleship)
        {
            TotalHitPoints += battleship.Length;
        }

        public void VisitCarrier(Carrier carrier)
        {
            TotalHitPoints += carrier.Length;
        }
    }
}
