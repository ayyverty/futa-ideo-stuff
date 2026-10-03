using RimWorld;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Holds the Futanari standing PreceptDefs and their issue.
	/// </summary>
	public static class FutaPrecept
	{
		public const string IssueDefName = "RJWFuta_FutanariStanding";

		public const string HatedDefName = "RJWFuta_Futanari_Hated";

		public const string NeutralDefName = "RJWFuta_Futanari_Neutral";

		public const string ApprovedDefName = "RJWFuta_Futanari_Approved";

		private static PreceptDef hatedDef;

		private static PreceptDef neutralDef;

		private static PreceptDef approvedDef;

		public static PreceptDef HatedDef
		{
			get
			{
				if (hatedDef == null)
				{
					hatedDef = DefDatabase<PreceptDef>.GetNamedSilentFail(HatedDefName);
				}

				return hatedDef;
			}
		}

		public static PreceptDef NeutralDef
		{
			get
			{
				if (neutralDef == null)
				{
					neutralDef = DefDatabase<PreceptDef>.GetNamedSilentFail(NeutralDefName);
				}

				return neutralDef;
			}
		}

		public static PreceptDef ApprovedDef
		{
			get
			{
				if (approvedDef == null)
				{
					approvedDef = DefDatabase<PreceptDef>.GetNamedSilentFail(ApprovedDefName);
				}

				return approvedDef;
			}
		}
	}
}