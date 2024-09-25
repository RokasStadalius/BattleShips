namespace BattleShips.Models
{
    public class Ship
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
        public Ship MakeCopy(Ship ship)
        {
            ship.ShipID = this.ShipID;
            ship.ShipTypeID = this.ShipTypeID;
            ship.MaxPlacementCount = this.MaxPlacementCount;
            ship.ShipName = this.ShipName;
            ship.Length = this.Length;
            ship.IsVertical = this.IsVertical;
            return ship;
        }
    }
}
