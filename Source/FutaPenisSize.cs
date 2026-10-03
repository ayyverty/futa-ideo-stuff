using System.Collections.Generic;
using rjw;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Enforces a minimum penis size on futanari. RJW stores genital size as
	/// the sex part hediff's relative severity, where 0.5 is the average of the
	/// roll and 0.6 is where the hediff enters its Large stage. Anything smaller
	/// is raised to Large; larger sizes are left untouched.
	/// </summary>
	public static class FutaPenisSize
	{
		/// <summary>
		/// Severity of the Large stage, the first band above average.
		/// </summary>
		public const float LargeSeverity = 0.6f;

		/// <summary>
		/// Raises every penis on the pawn to at least Large. Does nothing for
		/// pawns that are not futanari.
		/// </summary>
		public static void EnlargePenises(Pawn pawn)
		{
			if (!FutaUtil.IsFuta(pawn))
			{
				return;
			}

			List<Hediff> genitals = pawn.GetGenitalsList();

			for (int i = 0; i < genitals.Count; i++)
			{
				Hediff hediff = genitals[i];

				if (hediff == null || !(hediff is ISexPartHediff part) || !Genital_Helper.is_penis(hediff))
				{
					continue;
				}

				Enlarge(part.GetPartComp());
			}
		}

		private static void Enlarge(HediffComp_SexPart comp)
		{
			// An uninitialised part has no size to work from, and a forced size
			// is owned by whatever set it - leave both alone.
			if (comp == null || comp.baseSize <= 0f || comp.HasForcedSize || comp.GetSeverity() >= LargeSeverity)
			{
				return;
			}

			// Must go through SetSeverity rather than Hediff.Severity: RJW only
			// copies an externally set severity into baseSize while paused.
			comp.SetSeverity(LargeSeverity);
		}
	}
}
