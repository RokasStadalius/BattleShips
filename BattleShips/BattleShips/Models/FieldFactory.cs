namespace BattleShips.Models
{
    public class StandartFieldFactory : IField
    {
        public Field CreateField(string name) => new StandartField(name);
    }

    public class MediumFieldFactory : IField
    {
        public Field CreateField(string name) => new MediumField(name);
    }

    public class AdvacedFieldFactory : IField
    {
        public Field CreateField(string name) => new AdvancedField(name);
    }
}
