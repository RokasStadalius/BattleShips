namespace BattleShips.Models
{
    public class UserState
    {
        public User CurrentUser { get; private set; }
        public event Action OnChange;

        public void SetUser(User user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
