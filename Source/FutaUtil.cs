using rjw;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Single source of truth for futanari detection.
	/// </summary>
	public static class FutaUtil
	{
		/// <summary>
		/// True when the pawn is humanlike and has both a penis and a vagina,
		/// which is exactly what RJW's Sex.Futa represents.
		/// </summary>
		public static bool IsFuta(Pawn pawn)
		{
			if (pawn == null || pawn.Destroyed || pawn.health == null)
			{
				return false;
			}

			if (pawn.RaceProps == null || !pawn.RaceProps.Humanlike)
			{
				return false;
			}

			return GenderHelper.GetSex(pawn) == GenderHelper.Sex.Futa;
		}

		/// <summary>
		/// True when at least one futanari is present among the pawn's faction's
		/// colonists or slaves on the same map.
		/// </summary>
		public static bool HasFutaInColony(Pawn pawn)
		{
			if (pawn == null || pawn.Map == null || pawn.Map.mapPawns == null)
			{
				return false;
			}

			foreach (Pawn candidate in pawn.Map.mapPawns.FreeColonists)
			{
				if (IsFuta(candidate))
				{
					return true;
				}
			}

			foreach (Pawn candidate in pawn.Map.mapPawns.AllPawnsSpawned)
			{
				if (candidate.IsSlaveOfColony && IsFuta(candidate))
				{
					return true;
				}
			}

			return false;
		}
	}
}
