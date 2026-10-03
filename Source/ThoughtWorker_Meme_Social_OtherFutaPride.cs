using RimWorld;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Social opinion thought tied to the FutanariSupremacy meme rather than a
	/// precept: believers respect futanari pawns they observe.
	/// </summary>
	public class ThoughtWorker_Meme_Social_OtherFutaPride : ThoughtWorker
	{
		protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn otherPawn)
		{
			return FutaMeme.IsActive(pawn?.Ideo) && FutaUtil.IsFuta(otherPawn);
		}
	}
}