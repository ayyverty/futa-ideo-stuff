using RimWorld;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Social opinion thought for the Futanari standing precept (shared by the
	/// Hated and Approved variants). Believers form an opinion of futanari pawns
	/// they observe, unless they have the Futa Lover trait.
	/// </summary>
	public class ThoughtWorker_Precept_Social_FutaStanding : ThoughtWorker_Precept_Social
	{
		protected override ThoughtState ShouldHaveThought(Pawn p, Pawn otherPawn)
		{
			if (FutaTrait.HasFutaLover(p))
			{
				return false;
			}

			return FutaUtil.IsFuta(otherPawn);
		}
	}
}