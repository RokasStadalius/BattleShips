namespace BattleShips.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Field userField { get; set; }
        public User(string userName)
        {
            UserId = Guid.NewGuid().ToString();
            UserName = userName;
            userField = null;
        }
    }
}
