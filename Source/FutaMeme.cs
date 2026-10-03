using RimWorld;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Holds the futanari supremacy MemeDef and the check for it.
	/// </summary>
	public static class FutaMeme
	{
		public const string DefName = "RJWFuta_FutanariSupremacy";

		public const string LabelKey = "RJWFutaLabelFutanari";

		private static MemeDef cachedDef;

		public static MemeDef Def
		{
			get
			{
				if (cachedDef == null)
				{
					cachedDef = DefDatabase<MemeDef>.GetNamedSilentFail(DefName);
				}

				return cachedDef;
			}
		}

		/// <summary>
		/// True when the ideology actually contains the futanari supremacy meme.
		/// </summary>
		public static bool IsActive(Ideo ideo)
		{
			if (ideo == null)
			{
				return false;
			}

			MemeDef meme = Def;
			return meme != null && ideo.HasMeme(meme);
		}
	}
}
