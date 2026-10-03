using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Applies Harmony patches and injects the Futanari standing precept into
	/// every generated ideology. FutanariSupremacy ideologies are exempt and
	/// rely on the meme's own Perfect Form effects instead; all other ideologies
	/// default to the Hated precept.
	/// </summary>
	[StaticConstructorOnStartup]
	public static class HarmonyPatches
	{
		static HarmonyPatches()
		{
			new Harmony("toast.FutanariSupremacy").PatchAll(Assembly.GetExecutingAssembly());
		}

		internal static void TryAddFutaStandingPrecept(Ideo ideo)
		{
			if (ideo == null || FutaMeme.IsActive(ideo))
			{
				return;
			}

			PreceptDef hated = FutaPrecept.HatedDef;
			if (hated == null)
			{
				return;
			}

			if (ideo.HasPrecept(hated))
			{
				return;
			}

			if (FutaPrecept.NeutralDef != null && ideo.HasPrecept(FutaPrecept.NeutralDef))
			{
				return;
			}

			if (FutaPrecept.ApprovedDef != null && ideo.HasPrecept(FutaPrecept.ApprovedDef))
			{
				return;
			}

			ideo.AddPrecept(PreceptMaker.MakePrecept(hated), false, null, null);
			ideo.RecachePrecepts();
			AccessTools.Method(typeof(Ideo), "RecachePossibleSituationalThoughts")?.Invoke(ideo, null);
		}
	}

	[HarmonyPatch(typeof(IdeoGenerator), nameof(IdeoGenerator.GenerateIdeo))]
	public static class Patch_IdeoGenerator_GenerateIdeo
	{
		static void Postfix(Ideo __result)
		{
			HarmonyPatches.TryAddFutaStandingPrecept(__result);
		}
	}

	[HarmonyPatch(typeof(IdeoGenerator), nameof(IdeoGenerator.GenerateClassicIdeo))]
	public static class Patch_IdeoGenerator_GenerateClassicIdeo
	{
		static void Postfix(Ideo __result)
		{
			HarmonyPatches.TryAddFutaStandingPrecept(__result);
		}
	}

	[HarmonyPatch(typeof(IdeoGenerator), nameof(IdeoGenerator.GenerateNoExpansionIdeo))]
	public static class Patch_IdeoGenerator_GenerateNoExpansionIdeo
	{
		static void Postfix(Ideo __result)
		{
			HarmonyPatches.TryAddFutaStandingPrecept(__result);
		}
	}

	[HarmonyPatch(typeof(IdeoGenerator), nameof(IdeoGenerator.GenerateTutorialIdeo))]
	public static class Patch_IdeoGenerator_GenerateTutorialIdeo
	{
		static void Postfix(Ideo __result)
		{
			HarmonyPatches.TryAddFutaStandingPrecept(__result);
		}
	}
}