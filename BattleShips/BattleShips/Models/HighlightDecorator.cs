namespace BattleShips.Models
{
    public class HighlightDecorator: FieldCellDecorator
    {
        public HighlightDecorator(FieldCell cell) : base(cell) { }

        public override string GetCellColorState(bool showShips)
        {
            if (!decoratedCell.IsShot && decoratedCell.CellShip == null)
            {
                //hovered color
                return "rgb(255, 255, 0)";
            }
            return base.GetCellColorState(showShips);
        }
    }
}
