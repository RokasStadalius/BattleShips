namespace BattleShips.Models
{
    public interface IFieldObserver
    {
        void OnShipPlaced(Field field, Ship ship, FieldCell cell);
        void OnShotFired(Field field, FieldCell cell);
        void OnFieldStateChanged(Field field);
    }
}
