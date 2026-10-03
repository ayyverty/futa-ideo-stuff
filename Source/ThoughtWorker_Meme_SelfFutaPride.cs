using RimWorld;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Mood thought tied to the FutanariSupremacy meme rather than a precept:
	/// a futanari believer of the meme takes pride in their own form.
	/// </summary>
	public class ThoughtWorker_Meme_SelfFutaPride : ThoughtWorker
	{
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			return FutaMeme.IsActive(p?.Ideo) && FutaUtil.IsFuta(p);
		}
	}
}