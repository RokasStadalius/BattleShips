namespace BattleShips.Models
{
    public class ShotsData
    {
        public int Hits { get; set; }
        public int MissedShots { get; set; }
        public int TotalShots { get; set; }



        public ShotsData(int hits, int missedshots, int totalshots) { 
        
            this.Hits = hits;
            this.MissedShots = missedshots;
            this.TotalShots = totalshots;
        }
    }
}
