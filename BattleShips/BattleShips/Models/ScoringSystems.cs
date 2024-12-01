namespace BattleShips.Models
{
    public sealed class PrecisionScoring : ScoringSystemTemplate
    {
        protected override int ComputeBaseScore(ShotsData data) {
            return data.Hits * 10;
        }

        protected override int ComputeBonusScore(ShotsData data)
        {
            return -data.MissedShots * 2;
        }
    }

    public sealed class EfficiencyScoring : ScoringSystemTemplate
    {
        protected override int ComputeBaseScore(ShotsData data)
        {
            return data.Hits * 10;
        }

        protected override int ComputeBonusScore(ShotsData data)
        {
            double efficiency = data.Hits / (double)data.TotalShots;
            return (int)(efficiency * 50);
        }
    }
}
