using RimWorld;
using Verse;

namespace RJWFuta
{
	/// <summary>
	/// Requires the pawn to be futanari. Self-disabling: when the pawn's
	/// ideology does not contain the futanari supremacy meme this requirement
	/// reports no label and is always met, so vanilla roles behave normally.
	/// </summary>
	public class RoleRequirement_Futa : RoleRequirement
	{
		public override string GetLabel(Precept_Role role)
		{
			if (!FutaMeme.IsActive(role?.ideo))
			{
				return "";
			}

			return FutaMeme.LabelKey.Translate();
		}

		public override bool Met(Pawn p, Precept_Role role)
		{
			if (!FutaMeme.IsActive(role?.ideo))
			{
				return true;
			}

			return FutaUtil.IsFuta(p);
		}
	}
}
