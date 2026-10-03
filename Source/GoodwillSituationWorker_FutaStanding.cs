using RimWorld;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Goodwill situation for a faction that hates futanari meeting one that
	/// worships them. Vanilla only ships a meme against meme worker, so the
	/// Hated standing precept is checked here instead. The player faction is
	/// the one whose opinion counts; Ideology evaluates goodwill that way.
	/// </summary>
	public class GoodwillSituationWorker_FutaStanding : GoodwillSituationWorker
	{
		public override int GetNaturalGoodwillOffset(Faction other)
		{
			PreceptDef hated = FutaPrecept.HatedDef;
			Ideo selfIdeo = Faction.OfPlayer?.ideos?.PrimaryIdeo;
			Ideo otherIdeo = other?.ideos?.PrimaryIdeo;

			if (hated == null || selfIdeo == null || otherIdeo == null)
			{
				return 0;
			}

			if (!selfIdeo.HasPrecept(hated) || !FutaMeme.IsActive(otherIdeo))
			{
				return 0;
			}

			return def.naturalGoodwillOffset;
		}
	}

	/// <summary>
	/// The mirror of the above: the player faction worships futanari supremacy
	/// and the other faction holds the Hated standing precept.
	/// </summary>
	public class GoodwillSituationWorker_FutaStandingReversed : GoodwillSituationWorker
	{
		public override int GetNaturalGoodwillOffset(Faction other)
		{
			PreceptDef hated = FutaPrecept.HatedDef;
			Ideo selfIdeo = Faction.OfPlayer?.ideos?.PrimaryIdeo;
			Ideo otherIdeo = other?.ideos?.PrimaryIdeo;

			if (hated == null || selfIdeo == null || otherIdeo == null)
			{
				return 0;
			}

			if (!FutaMeme.IsActive(selfIdeo) || !otherIdeo.HasPrecept(hated))
			{
				return 0;
			}

			return def.naturalGoodwillOffset;
		}
	}
}
