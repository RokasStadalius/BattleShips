namespace BattleShips.Models
{
    public abstract class Ship
    {
        public int ShipID { get; set; }
        public int ShipTypeID { get; set; }
        public int MaxPlacementCount { get; set; }
        public string ShipName { get; set; }
        public int Length { get; set; }
        public bool IsVertical { get; set; } = false;
        public Ship()
        {

        }
        public abstract Ship MakeCopy();
    }
}
