namespace BattleShips.Models
{
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }
}
