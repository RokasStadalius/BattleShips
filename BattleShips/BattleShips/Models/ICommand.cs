namespace BattleShips.Models
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
