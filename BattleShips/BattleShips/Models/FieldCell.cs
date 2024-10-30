namespace BattleShips.Models
{
    public class FieldCell
    {
        public int ColIndex { get; set; }
        public int RowIndex { get; set; }
        public Ship? CellShip { get; set; }
        public bool IsShot { get; set; }
        public bool IsAdjacent { get; set; }

        private string color_Water = "rgb(79, 240, 202)";
        private string color_Water_Hit = "rgb(42, 0, 148)";
        private string color_Ship = "rgb(122, 196, 43)";
        private string color_Ship_Hit = "rgb(227, 72, 48)";

        public string GetCellColorState(bool showShips)
        {
            if (IsShot)
            {
                if (CellShip != null)
                    return color_Ship_Hit;
                else
                    return color_Water_Hit;
            }
            else
            {
                if (CellShip != null && showShips)
                    return color_Ship;
                else
                    return color_Water;
            }
        }

        public FieldCell(int RowIndex, int ColIndex) { 
            this.RowIndex = RowIndex;
            this.ColIndex = ColIndex;
            this.CellShip = null;
            this.IsShot = false;
            this.IsAdjacent = false;
        }
        public FieldCell() { }
    }
}
