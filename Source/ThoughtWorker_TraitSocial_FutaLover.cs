using RimWorld;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Trait-based social opinion: a pawn with the Futa Lover trait gains
	/// positive opinion of futanari pawns, regardless of ideology.
	/// </summary>
	public class ThoughtWorker_TraitSocial_FutaLover : ThoughtWorker
	{
		protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn otherPawn)
		{
			if (!FutaTrait.HasFutaLover(pawn))
			{
				return false;
			}

			return FutaUtil.IsFuta(otherPawn);
		}
	}
}