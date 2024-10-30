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

        protected IShipAttackStrategy AttackStrategy;
        public Ship(IShipAttackStrategy attackStrategy)
        {
            AttackStrategy = attackStrategy;
        }
        public abstract Ship MakeCopy();

        public List<FieldCell> Attack(FieldCell target)
        {
            return AttackStrategy.ExecuteAttack(target);
        }
    }
}
