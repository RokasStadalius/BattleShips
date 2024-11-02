namespace BattleShips.Models
{
    public interface IShipAttackStrategy
    {
        List<FieldCell> ExecuteAttack(FieldCell target);
        IShipAttackStrategy Clone();
    }
}
