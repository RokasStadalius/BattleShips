namespace BattleShips.Models
{
    public abstract class FieldCellDecorator : FieldCell
    {
        protected FieldCell decoratedCell;

        public FieldCellDecorator(FieldCell cell)
        {
            this.decoratedCell = cell;
            this.ColIndex = cell.ColIndex;
            this.RowIndex = cell.RowIndex;
            this.CellShip = cell.CellShip;
            this.IsShot = cell.IsShot;
            this.IsAdjacent = cell.IsAdjacent;
        }

        public override string GetCellColorState(bool showShips)
        {
            return decoratedCell.GetCellColorState(showShips);
        }
    }
}
