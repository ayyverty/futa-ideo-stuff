# Futa Ideo Stuff

A RimWorld 1.6 mod that adds a **Futanari Supremacy** ideology meme and other random Futa things.

| | |
|---|---|
| **Package ID** | `toast.FutanariSupremacy` |
| **Author** | toasterbath |
| **Game version** | 1.6 (mod version 1.6.1.0) |
| **Requires** | Ideology, RimJobWorld (RJW) |

## Features

### The Futanari Supremacy Meme

Futanari Supremacy is **mutually exclusive with Male Supremacy and Female Supremacy**. It ships custom ideological text for theist, archist and animist origins, plus lesson and founder description variants, and draws from four symbol packs: **Futanism**, **Perfectism**, **Ascensionism** and **Holism**.

### Only Futanari can hold ideology roles

Every ideology role, including the vanilla Leader role, can only be held by a futanari while the meme is active. 

Note that RJW defines futanari anatomically (pawn with both a vagina and a penis), not by the Gender field, so this gate keys off actual genital presence rather than pawn gender.

### Perfect Form

Believers gain pride-based thoughts tied to the meme itself, with no precept required:

| Thought | Who | Effect |
|---|---|---|
| Perfect Form | Futanari believers | **+4** mood |
| Perfect Form | Believers observing a Futanari | **+6** opinion |

### The Ascended Role

Ascended is an optional, futa-only rank of recognition, requiring the meme. You can have as many Ascended as you want. It grants the following bonuses:

- **Social Impact ×1.25**
- **Work Speed Global +0.1**

Roles can be named from a dedicated generator, producing things like *Ascendant*, *Gynarch*, *Phalloborn*, or *Firstborn of the Perfected Body*.

### The Futanari Standing Precept

A new precept, Futanari Standing, with three options:

| Option | Mood (non-futa believers) | Opinion of futanari |
|---|---|---|
| **Hated** | −8 | −15 |
| **Neutral** | — | — |
| **Approved** | +5 | +8 |

Every newly generated ideology is seeded with **Hated** by default. Ideologies that contain the meme are exempt. A player-chosen neutral or approved is never overwritten.

The mood thought only applies while a Futanari is actually in the colony, as a colonist or a slave. Futanari themselves and pawns with the *Futa Lover* trait are exempt from these thoughts entirely — they only ever see the meme's Perfect Form thoughts or the trait's opinion.

### The Futa Lover Trait

Futa Lover makes a pawn fond of Futanari and regard them as ideal partners and friends, granting **+10 opinion** of Futanari regardless of ideology.

### Diplomacy

Futanari Supremacy is well received by its own kind and poorly received elsewhere:

| Situation | Goodwill |
|---|---|
| Futanari Supremacy vs itself | **+10** |
| vs Male Supremacy | **−30** |
| vs Female Supremacy | **−15** |
| vs Individualist | **−20** |
| vs Transhumanist | **−10** |
| Futanari haters vs Futanari Supremacy | **−30** |
| Futanari Supremacy vs Futanari haters | **−30** |

### RJW integration

On a pawn's first sexualization, any Futanari's penises are raised to RJW's **Large** stage. This is a floor, not a set:

- Anything smaller — Micro (0.01), Small (0.20), Average (0.40) — is raised to Large.
- Already Larger (Huge 0.80, Towering 1.01) is left alone.
- Vaginas and breasts are untouched.
- Parts with no initialized size, or whose size is forced by RJW or another mod, are left alone, since something else owns them.

Because this hooks RJW's own first-sexualization guard, it applies at pawn generation and **does not retroactively resize pawns already in a save**.
