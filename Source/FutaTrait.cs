using RimWorld;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Holds the Futa Lover TraitDef and the check for it.
	/// </summary>
	public static class FutaTrait
	{
		public const string DefName = "RJWFuta_FutaLover";

		private static TraitDef cachedDef;

		public static TraitDef Def
		{
			get
			{
				if (cachedDef == null)
				{
					cachedDef = DefDatabase<TraitDef>.GetNamedSilentFail(DefName);
				}

				return cachedDef;
			}
		}

		/// <summary>
		/// True when the pawn has the Futa Lover trait.
		/// </summary>
		public static bool HasFutaLover(Pawn pawn)
		{
			TraitDef def = Def;
			return pawn?.story?.traits != null && def != null && pawn.story.traits.HasTrait(def);
		}
	}
}