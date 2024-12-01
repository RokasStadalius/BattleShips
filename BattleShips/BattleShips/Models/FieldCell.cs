namespace BattleShips.Models
{
    public class FieldCell
    {
        public int ColIndex { get; set; }
        public int RowIndex { get; set; }
        public Ship CellShip { get; set; }
        public bool IsShot { get; set; }
        public bool IsAdjacent { get; set; }

        public CellFlyweight CellFlyweight { get; set; }

        public virtual string GetCellColorState(bool showShips)
        {
            if (IsShot)
            {
                if (CellShip != null)
                    return CellFlyweight.ColorShipHit; // Ship is hit
                return CellFlyweight.ColorWaterHit; // Water is hit
            }
            else
            {
                if (CellShip != null && showShips)
                    return CellFlyweight.ColorShip; // Ship present
                return CellFlyweight.ColorWater; // Empty water cell
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is FieldCell other)
            {
                return RowIndex == other.RowIndex && ColIndex == other.ColIndex;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RowIndex, ColIndex);
        }
        public FieldCell(int RowIndex, int ColIndex, CellFlyweight flyweight = null) { 
            this.RowIndex = RowIndex;
            this.ColIndex = ColIndex;
            this.CellShip = null;
            this.IsShot = false;
            this.IsAdjacent = false;
            CellFlyweight = flyweight;
        }
        public FieldCell() { }
    }
}
