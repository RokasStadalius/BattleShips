namespace BattleShips.Models
{
    public class DestroyerAttackStrategy : IShipAttackStrategy
    {
        public List<FieldCell> ExecuteAttack(FieldCell target)
        {
            return new List<FieldCell> { target };
        }
    }

    public class SubmarineAttackStrategy : IShipAttackStrategy
    {
        public List<FieldCell> ExecuteAttack(FieldCell target)
        {
            return new List<FieldCell>
        {
            target,
            new FieldCell(target.RowIndex - 1, target.ColIndex),
            new FieldCell(target.RowIndex + 1, target.ColIndex),
            new FieldCell(target.RowIndex, target.ColIndex - 1),
            new FieldCell(target.RowIndex, target.ColIndex + 1)
        };
        }
    }

    public class BattleshipAttackStrategy : IShipAttackStrategy
    {
        public List<FieldCell> ExecuteAttack(FieldCell target)
        {
            return new List<FieldCell>
        {
            new FieldCell(target.RowIndex, target.ColIndex),
            new FieldCell(target.RowIndex, target.ColIndex + 1),
            new FieldCell(target.RowIndex, target.ColIndex + 2),
            new FieldCell(target.RowIndex, target.ColIndex + 3)
        };
        }
    }

    public class CarrierAttackStrategy : IShipAttackStrategy
    {
        public List<FieldCell> ExecuteAttack(FieldCell target)
        {
            return new List<FieldCell>
        {
            target,
            new FieldCell(target.RowIndex - 1, target.ColIndex - 1),
            new FieldCell(target.RowIndex - 1, target.ColIndex + 1),
            new FieldCell(target.RowIndex + 1, target.ColIndex - 1),
            new FieldCell(target.RowIndex + 1, target.ColIndex + 1),
            new FieldCell(target.RowIndex - 1, target.ColIndex),
            new FieldCell(target.RowIndex + 1, target.ColIndex),
            new FieldCell(target.RowIndex, target.ColIndex - 1),
            new FieldCell(target.RowIndex, target.ColIndex + 1)
        };
        }
    }
}
