using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BattleShips.Models
{
	public abstract class ScoringSystemTemplate
	{
		public int CalculateScore(ShotsData data)
		{
			int baseScore = ComputeBaseScore(data);
			int bonusScore = ComputeBonusScore(data);

			return baseScore + bonusScore;
		}

		protected abstract int ComputeBaseScore(ShotsData data);
		protected abstract int ComputeBonusScore(ShotsData data);
	}
}
