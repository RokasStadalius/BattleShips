namespace BattleShips.Models
{
    public class Fleet : ShipComponent
    {
        private readonly List<ShipComponent> _components = new List<ShipComponent>();

        public void Add(ShipComponent component)
        {
            _components.Add(component);
        }

        public void Remove(ShipComponent component) 
        {
            _components.Remove(component);
        }

        public override int GetLength()
        {
            return _components.Sum(c => c.GetLength());
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("Fleet details: ");
            foreach (var component in _components)
            {
                component.DisplayDetails();
            }
        }
    }
}
