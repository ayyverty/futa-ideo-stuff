using RimWorld;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Mood thought for the Futanari standing precept (shared by the Hated and
	/// Approved variants). Applies only to non-futanari believers who lack the
	/// Futa Lover trait, and only while futanari are present among the colony's
	/// colonists or slaves.
	/// </summary>
	public class ThoughtWorker_Precept_Mood_FutaStanding : ThoughtWorker_Precept
	{
		protected override ThoughtState ShouldHaveThought(Pawn p)
		{
			if (FutaTrait.HasFutaLover(p))
			{
				return false;
			}

			if (FutaUtil.IsFuta(p))
			{
				return false;
			}

			return FutaUtil.HasFutaInColony(p);
		}
	}
}