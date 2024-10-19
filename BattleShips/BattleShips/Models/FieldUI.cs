namespace BattleShips.Models
{
    public class FieldUI : IFieldObserver
    {
        public List<string> MessageLog { get; private set; } = new List<string>();
        public event Action OnLogUpdated;

        public void OnShipPlaced(Field field, Ship ship, FieldCell cell)
        {
            MessageLog.Add($"{DateTime.Now.ToString()}:   Ship placed at Row {cell.RowIndex}, Column {cell.ColIndex} on Field {field.Name}");
            OnLogUpdated?.Invoke();
        }

        public void OnShotFired(Field field, FieldCell cell)
        {
            MessageLog.Add($"{DateTime.Now.ToString()}:   Shot fired at Row {cell.RowIndex}, Column {cell.ColIndex} on Field {field.Name}");
            OnLogUpdated?.Invoke();
        }

        public void OnFieldStateChanged(Field field)
        {
            MessageLog.Add($"{DateTime.Now.ToString()}:   Field {field.Name} state changed.");
            OnLogUpdated?.Invoke();
        }
    }

}
