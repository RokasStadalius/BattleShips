namespace BattleShips.Models
{
    public class HighlightDecorator: FieldCellDecorator
    {
        private string _highlightColor;

        public HighlightDecorator(FieldCell cell, Ship draggedShip) : base(cell)
        {
            _highlightColor = GetHighlightColor(draggedShip.ShipTypeID);
        }

        private string GetHighlightColor(int shipTypeId)
        {
            return shipTypeId switch
            {
                1 => "rgba(0, 255, 0, 0.5)",
                2 => "rgba(255, 0, 0, 0.5)",
                3 => "rgba(0, 0, 255, 0.5)",
                4 => "rgba(255, 255, 0, 0.5)",
                _ => "rgba(255, 255, 255, 0.5)" 
            };
        }

        public override string GetCellColorState(bool showShips)
        {
            if (!decoratedCell.IsShot && decoratedCell.CellShip == null)
            {
                // Return the highlighted color instead of the default
                return _highlightColor;
            }
            return base.GetCellColorState(showShips);
        }
    }
}
