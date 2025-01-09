using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using HarmonyLib;
using UnityEngine;
using Verse;
using Verse.AI;
using static HarmonyLib.AccessTools;

namespace RimThreaded.RW_Patches
{

    public class Pawn_HealthTracker_Patch
    {
        internal static void RunDestructivePatches()
        {
            Type original = typeof(Pawn_HealthTracker);
            Type patched = typeof(Pawn_HealthTracker_Patch);
            RimThreadedHarmony.Prefix(original, patched, nameof(RemoveHediff));
            RimThreadedHarmony.Prefix(original, patched, nameof(RestorePartRecursiveInt));
            RimThreadedHarmony.Prefix(original, patched, nameof(CheckPredicateAfterAddingHediff));
            RimThreadedHarmony.Prefix(original, patched, nameof(Notify_Resurrected));
            RimThreadedHarmony.Prefix(original, patched, nameof(HealthTick));
            RimThreadedHarmony.Prefix(original, patched, nameof(SetDead)); //optional warning instead of error
            //RimThreadedHarmony.Transpile(original, patched, nameof(CheckForStateChange));
            //RimThreadedHarmony.Prefix(original, patched, nameof(CheckForStateChange));
            MethodInfo checkForStateChange = Method(original, "CheckForStateChange");
            MethodInfo checkForStateChangeMonitorEnterMethod = Method(patched, nameof(CheckForStateChangeMonitorEnter));
            RimThreadedHarmony.harmony.Patch(checkForStateChange, prefix: new HarmonyMethod(checkForStateChangeMonitorEnterMethod, 1000));
            RimThreadedHarmony.nonDestructivePrefixes.Add(checkForStateChangeMonitorEnterMethod);
            RimThreadedHarmony.harmony.Patch(checkForStateChange, finalizer: new HarmonyMethod(Method(patched, nameof(CheckForStateChangeMonitorExit)), -1000));
            MethodInfo postApplyDamage = Method(original, "PostApplyDamage");
            MethodInfo postApplyDamageEnterMethod = Method(patched, nameof(PostApplyDamageEnter));
            RimThreadedHarmony.nonDestructivePrefixes.Add(postApplyDamageEnterMethod);
            RimThreadedHarmony.harmony.Patch(postApplyDamage, prefix: new HarmonyMethod(postApplyDamageEnterMethod, 1000));
            RimThreadedHarmony.harmony.Patch(postApplyDamage, finalizer: new HarmonyMethod(Method(patched, nameof(PostApplyDamageExit)), -1000));
        }
        [ThreadStatic] static bool Pawn_HealthTrackerLockTaken;
        [ThreadStatic] static HediffSet Pawn_HealthTrackerHediffSet;
        [ThreadStatic] static bool Pawn_HealthTrackerLockTaken2;
        [ThreadStatic] static HediffSet Pawn_HealthTrackerHediffSet2;

        public static bool CheckForStateChangeMonitorEnter(Pawn_HealthTracker __instance, DamageInfo? dinfo, Hediff hediff)
        {
            Pawn_HealthTrackerLockTaken = false;
            Pawn_HealthTrackerHediffSet = __instance.hediffSet;
            Monitor.TryEnter(Pawn_HealthTrackerHediffSet, RimThreaded.halfTimeoutMS, ref Pawn_HealthTrackerLockTaken);
            if (Pawn_HealthTrackerLockTaken)
                return true;
            Log.Error("RimThreaded.CheckForStateChange was unable to be obtain lock for Pawn_HealthTracker: " + __instance + " within timeout(MS) : " + RimThreaded.halfTimeoutMS.ToString());
            return false;
        }
        public static void CheckForStateChangeMonitorExit(Pawn_HealthTracker __instance, DamageInfo? dinfo, Hediff hediff)
        {
            if (Pawn_HealthTrackerLockTaken)
                Monitor.Exit(Pawn_HealthTrackerHediffSet);
        }

        public static bool PostApplyDamageEnter(Pawn_HealthTracker __instance, DamageInfo dinfo, float totalDamageDealt)
        {
            Pawn_HealthTrackerLockTaken2 = false;
            Pawn_HealthTrackerHediffSet2 = __instance.hediffSet;
            Monitor.TryEnter(Pawn_HealthTrackerHediffSet2, RimThreaded.halfTimeoutMS, ref Pawn_HealthTrackerLockTaken2);
            if (Pawn_HealthTrackerLockTaken2)
                return true;
            Log.Error("RimThreaded.CheckForStateChange was unable to be obtain lock for Pawn_HealthTracker: " + __instance + " within timeout(MS) : " + RimThreaded.halfTimeoutMS.ToString());
            return false;
        }
        public static void PostApplyDamageExit(Pawn_HealthTracker __instance, DamageInfo dinfo, float totalDamageDealt)
        {
            if (Pawn_HealthTrackerLockTaken2)
                Monitor.Exit(Pawn_HealthTrackerHediffSet2);
        }

        public static bool SetDead(Pawn_HealthTracker __instance)
        {
            if (__instance.Dead)
                Log.Warning(__instance.pawn.ToString() + " set dead while already dead."); //changed
            __instance.healthState = PawnHealthState.Dead;
            return false;
        }

        public static bool RemoveHediff(Pawn_HealthTracker __instance, Hediff hediff)
        {
            if (__instance.hediffSet == null || __instance.hediffSet.hediffs == null)
                return false;
            hediff.PreRemoved();
            lock (__instance.hediffSet)
            {
                List<Hediff> newHediffs = new List<Hediff>(__instance.hediffSet.hediffs);
                newHediffs.Remove(hediff);
                __instance.hediffSet.hediffs = newHediffs;
            }
            hediff.PostRemoved();
            //__instance.Notify_HediffChanged(null); 1.4 changed?
            __instance.Notify_HediffChanged(hediff);

            if(hediff.def.HasDefinedGraphicProperties || hediff.def.forceRenderTreeRecache)
                __instance.pawn.Drawer.renderer.SetAllGraphicsDirty();
            Pawn_HealthTracker.tmpRemovedHediffs.Add(hediff);

            return false;
        }
        public static bool RestorePartRecursiveInt(Pawn_HealthTracker __instance, BodyPartRecord part, Hediff diffException = null)
        {
            lock (__instance.hediffSet)
            {
                List<Hediff> newHediffs = new List<Hediff>(__instance.hediffSet.hediffs); //added
                //List<Hediff> hediffs = __instance.hediffSet.hediffs; //removed
                for (int index = newHediffs.Count - 1; index >= 0; --index)
                {
                    Hediff hediff = newHediffs[index];
                    if (hediff.Part == part && hediff != diffException && !hediff.def.keepOnBodyPartRestoration)
                    {
                        newHediffs.RemoveAt(index);
                        __instance.hediffSet.hediffs = newHediffs; //added
                        hediff.PostRemoved();
                    }
                }
                for (int index = 0; index < part.parts.Count; ++index)
                    __instance.RestorePartRecursiveInt(part.parts[index], diffException);
            }
            return false;
        }
        public static bool CheckPredicateAfterAddingHediff(Pawn_HealthTracker __instance, ref bool __result, Hediff hediff, Func<bool> pred)
        {
            lock (__instance.hediffSet) //added
            {
                List<Hediff> newHediffs = new List<Hediff>(__instance.hediffSet.hediffs); //added
                HashSet<Hediff> missing = __instance.CalculateMissingPartHediffsFromInjury(hediff);
                newHediffs.Add(hediff);
                if (missing != null)
                    newHediffs.AddRange(missing);
                __instance.hediffSet.hediffs = newHediffs;//added
                __instance.hediffSet.DirtyCache();
                int num = pred() ? 1 : 0;
                if (missing != null)
                    newHediffs.RemoveAll(x => missing.Contains(x));
                newHediffs.Remove(hediff);
                __instance.hediffSet.hediffs = newHediffs;//added
                __instance.hediffSet.DirtyCache();
                __result = num != 0;
            }
            return false;
        }
        public static bool Notify_Resurrected(Pawn_HealthTracker __instance, bool restoreMissingParts = true, float gettingScarsChance = 0.0f)
        {
            lock (__instance.hediffSet) //added
            {

                var hediffSet = __instance.hediffSet; //added
                List<Hediff> newHediffs = new List<Hediff>(hediffSet.hediffs); //added

                if ((double)gettingScarsChance > 0.0)
                {
                    for (int index = 0; index < newHediffs.Count; ++index)
                    {
                        if (newHediffs[index] is Hediff_Injury hediff &&
                            !hediffSet.PartOrAnyAncestorHasDirectlyAddedParts(hediff.Part))
                        {
                            HediffComp_GetsPermanent comp = hediff.TryGetComp<HediffComp_GetsPermanent>();
                            if (comp != null && !comp.IsPermanent && Rand.Chance(gettingScarsChance))
                            {
                                comp.IsPermanent = true;
                                hediff.Severity = Mathf.Min(hediff.Severity, (float)Rand.RangeInclusive(2, 6));
                            }
                        }
                    }
                }

                __instance.healthState = PawnHealthState.Mobile;
                newHediffs.RemoveAll(x => x.def.everCurableByItem && x.TryGetComp<HediffComp_Immunizable>() != null);
                newHediffs.RemoveAll(x => x.def.everCurableByItem && x is Hediff_Injury && !x.IsPermanent());
                newHediffs.RemoveAll(x =>
                {
                    if (!x.def.everCurableByItem)
                        return false;
                    return x.IsLethal || x.IsAnyStageLifeThreatening();

                });
                if (!__instance.pawn.RaceProps.IsMechanoid)
                {
                    newHediffs.RemoveAll((Predicate<Hediff>)(x => x.def.everCurableByItem && x is Hediff_Injury && !x.IsPermanent()));
                }
                else
                {
                    // TODO LA tmpMechInjuries might need a newHediffs treatment
                    __instance.tmpMechInjuries.Clear();
                    hediffSet.GetHediffs<Hediff_Injury>(ref __instance.tmpMechInjuries, (Predicate<Hediff_Injury>)(x => x != null && x.def.everCurableByItem && !x.IsPermanent()));
                    if (__instance.tmpMechInjuries.Count > 0)
                    {
                        float num = __instance.tmpMechInjuries.Sum<Hediff_Injury>((Func<Hediff_Injury, float>)(x => x.Severity)) * 0.5f / (float)__instance.tmpMechInjuries.Count;
                        for (int index = 0; index < __instance.tmpMechInjuries.Count; ++index)
                            __instance.tmpMechInjuries[index].Severity -= num;
                        __instance.tmpMechInjuries.Clear();
                    }
                }
                newHediffs.RemoveAll(x => x.def.everCurableByItem && x is Hediff_Injury && x.IsPermanent() && (double)__instance.hediffSet.GetPartHealth(x.Part) <= 0.0);
                __instance.hediffSet = hediffSet; //added
                __instance.hediffSet.hediffs = newHediffs; //added
                if (restoreMissingParts)
                {
                    while (true)
                    {
                        Hediff_MissingPart hediffMissingPart = __instance.hediffSet.GetMissingPartsCommonAncestors()
                            .Where(x => !__instance.hediffSet.PartOrAnyAncestorHasDirectlyAddedParts(x.Part))
                            .FirstOrDefault();
                        if (hediffMissingPart != null)
                            __instance.RestorePart(hediffMissingPart.Part, checkStateChange: false);
                        else
                            break;
                    }
                }

                __instance.hediffSet.DirtyCache();
                if (__instance.ShouldBeDead())
                    __instance.hediffSet.hediffs.RemoveAll(h => !h.def.keepOnBodyPartRestoration);
                __instance.Notify_HediffChanged(null);
            }
            return false;
        }

        public static bool HealthTick(Pawn_HealthTracker __instance)
        {
            Pawn pawn = __instance.pawn; //added
            if (__instance.Dead)
                return false;

            // I'm not using Pawn_HealthTracker.tmpHediffs. That's just asking for multithreading issues...
            var tmpHediffs = __instance.hediffSet.hediffs;
            foreach(var hediff in tmpHediffs)
            {
                // Omitting a check for tmpRemovedHediffs here. It's an empty list that is cleared and then checked if contains the hediff...
                try
                {
                    hediff.Tick();
                    hediff.PostTick();
                }
                catch (Exception ex1)
                {
                    Log.Error("Exception ticking hediff " + hediff.ToStringSafe() + " for pawn " + pawn.ToStringSafe() + ". Removing hediff... Exception: " + ex1);
                    try
                    {
                        __instance.RemoveHediff(hediff);
                    }
                    catch (Exception ex2)
                    {
                        Log.Error("Error while removing hediff: " + ex2);
                    }
                }
                if (__instance.Dead)
                    return false;
            }
            lock (__instance.hediffSet) //added
            {
                List<Hediff> newHediffs = new List<Hediff>(__instance.hediffSet.hediffs); //added
                for (int index = newHediffs.Count - 1; index >= 0; --index) //changed
                {
                    Hediff hediff = newHediffs[index];
                    if (hediff.ShouldRemove)
                    {
                        __instance.RemoveHediff(hediff);
                    }
                }
            }
            if (__instance.Dead)
                return false;
            __instance.immunity.ImmunityHandlerTick();
            if(pawn.Spawned && pawn.Crawling && pawn.MapHeld.reservationManager.IsReservedAndRespected((LocalTargetInfo) (Thing) pawn, pawn))
                __instance.pawn.jobs.EndCurrentJob(JobCondition.InterruptForced);
            if ((pawn.RaceProps.IsFlesh|| pawn.RaceProps.IsAnomalyEntity) && pawn.IsHashIntervalTick(600) && (pawn.needs.food == null || !pawn.needs.food.Starving))
            {
                bool flag = false;
                if (__instance.hediffSet.HasNaturallyHealingInjury())
                {
                    float num = 8f;
                    if (pawn.GetPosture() != PawnPosture.Standing)
                    {
                        num += 4f;
                        Building_Bed buildingBed = pawn.CurrentBed();
                        if (buildingBed != null)
                            num += buildingBed.def.building.bed_healPerDay;
                    }
                    foreach (Hediff hediff in __instance.hediffSet.hediffs)
                    {
                        HediffStage curStage = hediff.CurStage;
                        if (curStage != null && curStage.naturalHealingFactor != -1f)
                            num *= curStage.naturalHealingFactor;
                    }
                    //__instance.hediffSet.GetHediffs<Hediff_Injury>().Where(x => x.CanHealNaturally()).RandomElement().Heal((float)((double)num * (double)pawn.HealthScale * 0.00999999977648258) * pawn.GetStatValue(StatDefOf.InjuryHealingFactor));
                    //1.4
                    __instance.hediffSet.GetHediffs(ref __instance.tmpHediffInjuries, (Hediff_Injury h) => h.CanHealNaturally());
                    __instance.tmpHediffInjuries.RandomElement().Heal(num * pawn.HealthScale * 0.01f * pawn.GetStatValue(StatDefOf.InjuryHealingFactor));

                    flag = true;
                }
                if (__instance.hediffSet.HasTendedAndHealingInjury() && (pawn.needs.food == null || !pawn.needs.food.Starving))
                {
                    //1.4
                    //Hediff_Injury hd = __instance.hediffSet.GetHediffs<Hediff_Injury>().Where(x => x.CanHealFromTending()).RandomElement();
                    //hd.Heal((float)(8.0 * (double)GenMath.LerpDouble(0.0f, 1f, 0.5f, 1.5f, Mathf.Clamp01(hd.TryGetComp<HediffComp_TendDuration>().tendQuality)) * (double)pawn.HealthScale * 0.00999999977648258) * pawn.GetStatValue(StatDefOf.InjuryHealingFactor));
                    //flag2 = true;
                    Need_Food food = pawn.needs.food;
                    if (food == null || !food.Starving)
                    {
                        __instance.hediffSet.GetHediffs(ref __instance.tmpHediffInjuries, (Hediff_Injury h) => h.CanHealFromTending());
                        Hediff_Injury hediff_Injury = __instance.tmpHediffInjuries.RandomElement();
                        float tendQuality = hediff_Injury.TryGetComp<HediffComp_TendDuration>().tendQuality;
                        float num4 = GenMath.LerpDouble(0f, 1f, 0.5f, 1.5f, Mathf.Clamp01(tendQuality));
                        hediff_Injury.Heal(8f * num4 * pawn.HealthScale * 0.01f * pawn.GetStatValue(StatDefOf.InjuryHealingFactor));
                        flag = true;
                    }
                }
                if (flag && !__instance.HasHediffsNeedingTendByPlayer() && !HealthAIUtility.ShouldSeekMedicalRest(pawn) && !__instance.hediffSet.HasTendedAndHealingInjury() && PawnUtility.ShouldSendNotificationAbout(pawn))
                    Messages.Message((string)"MessageFullyHealed".Translate((NamedArgument)pawn.LabelCap, (NamedArgument)pawn), (LookTargets)pawn, MessageTypeDefOf.PositiveEvent);
            }
            if (__instance.CanBleed && __instance.hediffSet.BleedRateTotal >= 0.1f && (pawn.Spawned || pawn.ParentHolder is Pawn_CarryTracker) && pawn.SpawnedOrAnyParentSpawned)
            {
                if (pawn.Crawling && pawn.Spawned)
                {
                    if (!__instance.lastSmearDropPos.HasValue || (double)Vector3.Distance(pawn.DrawPos, __instance.lastSmearDropPos.Value) > (double)Pawn_HealthTracker.BloodFilthDropDistanceRangeFromBleedRate.LerpThroughRange(__instance.hediffSet.BleedRateTotal))
                        __instance.DropBloodSmear();
                }
                else
                {
                    float bleedRate = __instance.hediffSet.BleedRateTotal * pawn.BodySize;
                    if (Rand.Chance(pawn.GetPosture() != PawnPosture.Standing ? bleedRate * 0.0004f : bleedRate * 0.004f))
                        __instance.DropBloodFilth();
                }
            }
            if (!pawn.IsHashIntervalTick(60))
                return false;
            List<HediffGiverSetDef> hediffGiverSets = pawn.RaceProps.hediffGiverSets;
            if (hediffGiverSets != null)
            {
                for (int index1 = 0; index1 < hediffGiverSets.Count; ++index1)
                {
                    List<HediffGiver> hediffGivers = hediffGiverSets[index1].hediffGivers;
                    for (int index2 = 0; index2 < hediffGivers.Count; ++index2)
                    {
                        hediffGivers[index2].OnIntervalPassed(pawn, null);
                        if (pawn.Dead)
                            return false;
                    }
                }
            }
            if (pawn.story == null)
                return false;
            List<Trait> allTraits = pawn.story.traits.allTraits;
            for (int k = 0; k < allTraits.Count; k++)
            {
                if (allTraits[k].Suppressed)
                {
                    continue;
                }
                TraitDegreeData currentData = allTraits[k].CurrentData;
                if (!(currentData.randomDiseaseMtbDays > 0f) || !Rand.MTBEventOccurs(currentData.randomDiseaseMtbDays, 60000f, 60f))
                {
                    continue;
                }
                BiomeDef biome;
                if (pawn.Tile != -1)
                {
                    biome = Find.WorldGrid[pawn.Tile].biome;
                }
                else
                {
                    biome = DefDatabase<BiomeDef>.GetRandom();
                }
                IncidentDef incidentDef = DefDatabase<IncidentDef>.AllDefs.Where((IncidentDef d) => d.category == IncidentCategoryDefOf.DiseaseHuman).RandomElementByWeightWithFallback((IncidentDef d) => biome.CommonalityOfDisease(d));
                if (incidentDef == null)
                {
                    continue;
                }
                string blockedInfo;
                List<Pawn> list = ((IncidentWorker_Disease)incidentDef.Worker).ApplyToPawns(Gen.YieldSingle(pawn), out blockedInfo);
                if (PawnUtility.ShouldSendNotificationAbout(pawn))
                {
                    if (list.Contains(pawn))
                    {
                        Find.LetterStack.ReceiveLetter("LetterLabelTraitDisease".Translate(incidentDef.diseaseIncident.label), "LetterTraitDisease".Translate(pawn.LabelCap, incidentDef.diseaseIncident.label, pawn.Named("PAWN")).AdjustedFor(pawn), LetterDefOf.NegativeEvent, pawn);
                    }
                    else if (!blockedInfo.NullOrEmpty())
                    {
                        Messages.Message(blockedInfo, pawn, MessageTypeDefOf.NeutralEvent);
                    }
                }
            }
            return false;
        }
    }
}