# Futa Ideo Stuff

A RimWorld 1.6 mod that adds a **Futanari Supremacy** ideology meme: futanari are the perfected form and should rule above all others.

| | |
|---|---|
| **Package ID** | `toast.FutanariSupremacy` |
| **Author** | toasterbath |
| **Game version** | 1.6 (mod version 1.6.1.0) |
| **Requires** | Ideology, RimJobWorld (RJW) |

## Features

### The meme

`RJWFuta_FutanariSupremacy` sits in vanilla's `GenderSupremacy` group and carries the same exclusion tag, so it is **mutually exclusive with Male Supremacy and Female Supremacy**. It ships custom ideological text for theist, archist and animist origins, plus lesson and founder description variants, and draws from four symbol packs: **Futanism**, **Perfectism**, **Ascensionism** and **Holism**. Futanari Supremacy ideologies also get their own ideo colour, `RJWFuta_DarkPurple`.

### Only futanari can hold ideology roles

A `RJWFuta.RoleRequirement_Futa` role requirement is patched onto vanilla's `PreceptRoleSingleBase` and `PreceptRoleMultiBase`, which every concrete role inherits — so **every** ideology role, including the vanilla Leader role, can only be held by a futanari while the meme is active. The requirement self-disables outside Futanari Supremacy ideologies, so vanilla behaviour is untouched elsewhere.

Note that RJW defines futanari anatomically (a pawn with both a vagina and a penis), not by the `Gender` field, so this gate keys off actual genital presence rather than pawn gender.

### Perfect Form

Believers gain pride-based thoughts tied to the meme itself, with no precept required:

| Thought | Who | Effect |
|---|---|---|
| Perfect Form | futanari believers | **+4** mood |
| Perfect Form | believers observing a futanari | **+6** opinion |

### The Ascended role

`RJWFuta_IdeoRole_Ascended` is an optional, futa-only rank of recognition, requiring the meme. It confers no duty and forbids nothing — just:

- **Social Impact ×1.25**
- **Work Speed Global +0.1**

Roles can be named from a dedicated generator (`NamerRoleAscended`), producing things like *Ascendant*, *Gynarch*, *Phalloborn*, or *Firstborn of the Perfected Body*.

### The futanari standing precept

A new issue, `RJWFuta_FutanariStanding`, with three options:

| Option | Mood (non-futa believers) | Opinion of futanari |
|---|---|---|
| **hated** | −8 | −15 |
| **neutral** | — | — |
| **approved** | +5 | +8 |

Every newly generated ideology is seeded with **hated** by default. Ideologies that contain the meme are exempt and rely on Perfect Form instead. A player-chosen neutral or approved is never overwritten.

The mood thought only applies while a futanari is actually in the colony, as a colonist or a slave. Futanari themselves and pawns with the *futa lover* trait are exempt from these thoughts entirely — they only ever see the meme's Perfect Form thoughts or the trait's opinion.

### The futa lover trait

`RJWFuta_FutaLover` (commonality 1) makes a pawn fond of futanari and regard them as ideal partners and friends, granting **+10 opinion** of futanari regardless of ideology.

### Diplomacy

Futanari Supremacy is well received by its own kind and poorly received elsewhere:

| Situation | Goodwill |
|---|---|
| Futanari supremacy vs itself | **+10** |
| vs male supremacy | **−30** |
| vs female supremacy | **−15** |
| vs individualist | **−20** |
| vs transhumanist | **−10** |
| futanari haters vs futanari supremacy | **−30** |
| futanari supremacy vs futanari haters | **−30** |

The last two use custom goodwill workers, since Ideology ships no worker that compares a precept against a meme. Vanilla's `GoodwillSituationWorker_MemeCompatibility` covers the rest.

### RJW integration

On a pawn's first sexualization, any futanari's penises are raised to RJW's **Large** stage (severity 0.6). This is a floor, not a set:

- Anything smaller — Micro (0.01), Small (0.20), Average (0.40) — is raised to Large.
- Already Larger (Huge 0.80, Towering 1.01) is left alone.
- Vaginas and breasts are untouched.
- Parts with no initialised size, or whose size is forced by RJW or another mod, are left alone, since something else owns them.

Because this hooks RJW's own first-sexualization guard, it applies at pawn generation and **does not retroactively resize pawns already in a save**.

## Notes

There are no mod settings or config toggles; all behaviour is defined in XML or hardcoded.

All player-facing strings except the futanari role-requirement label are hardcoded in XML defs rather than routed through keyed translation files, so the mod is currently English-only. `Languages/English/Keyed/RJWFuta.xml` holds the single keyed string.

## Repository layout

```
About/About.xml              mod metadata
Languages/                   keyed translations
Source/                      C# sources (namespace RJWFuta)
  FutaMeme.cs                meme helper
  FutaPrecept.cs             precept def cache
  FutaTrait.cs               trait helper
  FutaUtil.cs                futanari detection
  FutaPenisSize.cs           RJW size floor
  HarmonyPatches.cs          patch registry + precept injection
  RoleRequirement_Futa.cs    futa-only role gate
  GoodwillSituationWorker_*  precept-vs-meme goodwill
  ThoughtWorker_*            meme, precept and trait thoughts
1.6/Defs/                    meme, precept, role, thought, trait, goodwill defs
1.6/Patches/                 role requirement patch
1.6/Assemblies/RJWFuta.dll   compiled assembly
Textures/UI/                 meme, role and issue icons
```

## Building

Requires the .NET Framework reference assemblies and a local copy of RJW. The csproj references RJW by absolute path, so adjust the `HintPath` in `Source/RJWFuta.csproj` to match your installation before building:

```sh
dotnet build Source/RJWFuta.csproj
```

Output goes straight to `1.6/Assemblies/RJWFuta.dll`.