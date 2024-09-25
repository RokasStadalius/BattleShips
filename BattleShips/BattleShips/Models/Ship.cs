namespace BattleShips.Models
{
    public class Ship
    {
        public int ShipID { get; set; }
        public string ShipName { get; set; }
        public int Length { get; set; }
        public bool IsVertical { get; set; } = true;
    }
}
