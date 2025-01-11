using RimWorld;
using System;
using Verse;
using Verse.AI;

namespace RimThreaded.RW_Patches
{
    public class Pawn_MindState_Patch
    {
        internal static void RunDestructivePatches()
        {
            Type original = typeof(Pawn_MindState);
            Type patched = typeof(Pawn_MindState_Patch);
            RimThreadedHarmony.Prefix(original, patched, "MindStateTick");
        }

        public static bool MindStateTick(Pawn_MindState __instance)
        {
            if (__instance.wantsToTradeWithColony)
                TradeUtility.CheckInteractWithTradersTeachOpportunity(__instance.pawn);
            if (__instance.meleeThreat != null && !__instance.MeleeThreatStillThreat)
                __instance.meleeThreat = null;
            __instance.mentalStateHandler.MentalStateHandlerTick();
            __instance.mentalBreaker.MentalBreakerTick();
            __instance.inspirationHandler.InspirationHandlerTick();
            if (!__instance.pawn.GetPosture().Laying())
                __instance.applyBedThoughtsTick = 0;
            if (__instance.pawn.IsHashIntervalTick(100))
                __instance.anyCloseHostilesRecently = __instance.pawn.Spawned && PawnUtility.EnemiesAreNearby(__instance.pawn, __instance.anyCloseHostilesRecently ? 24 : 18, true);
            if (__instance.WillJoinColonyIfRescued && __instance.AnythingPreventsJoiningColonyIfRescued)
                __instance.WillJoinColonyIfRescued = false;
            if (__instance.pawn.Spawned && __instance.pawn.IsWildMan() && !__instance.WildManEverReachedOutside && __instance.pawn.GetRoom(RegionType.Set_Passable) != null && __instance.pawn.GetRoom(RegionType.Set_Passable).TouchesMapEdge)
                __instance.WildManEverReachedOutside = true;
            if (__instance.pawn.Spawned && __instance.pawn.RaceProps.IsFlesh && __instance.pawn.needs.mood != null && __instance.pawn.IsHashIntervalTick(123))
            {
                TerrainDef terrain = __instance.pawn.Position.GetTerrain(__instance.pawn.Map);
                if (terrain.traversedThought != null)
                    __instance.pawn.needs.mood.thoughts.memories.TryGainMemoryFast(terrain.traversedThought);
                WeatherDef curWeatherLerped = __instance.pawn.Map.weatherManager.CurWeatherLerped;
                if (curWeatherLerped.weatherThought != null)
                {
                    var isRoofed = __instance.pawn.Position.Roofed(__instance.pawn.Map);
                    var singleStage = curWeatherLerped.weatherThought.stages.Count == 1;

                    if(!isRoofed || !singleStage)
                        __instance.pawn.needs.mood.thoughts.memories.TryGainMemoryFast(curWeatherLerped.weatherThought);
                }
                if (__instance.pawn.Position.GasDensity(__instance.pawn.Map, GasType.RotStink) > (byte)0)
                    __instance.lastRotStinkTick = Find.TickManager.TicksGame;
            }

            
            if (__instance.droppedWeapon != null && !__instance.droppedWeapon.Spawned)
                __instance.droppedWeapon = (Thing)null;
            if (GenLocalDate.DayTick((Thing)__instance.pawn) == 0)
                __instance.interactionsToday = 0;
            if (__instance.pawn.IsFighting() && __instance.pawn.CurJob?.def != JobDefOf.Wait_Combat || __instance.pawn.equipment?.Primary != null)
                __instance.lastCombatantTick = Find.TickManager.TicksGame;
            if (!(__instance.enemyTarget is Pawn enemyTarget) || enemyTarget.mindState == null)
                return false;
            enemyTarget.mindState.lastCombatantTick = Find.TickManager.TicksGame;
            //dirty hack for easy speedup - i'm sure this breaks things like pawn conversation interval.
            //if (GenLocalDate.DayTick((Thing)__instance.pawn) != 0)
            //	return;
            __instance.interactionsToday = 0;
            return false;
        }

    }
}