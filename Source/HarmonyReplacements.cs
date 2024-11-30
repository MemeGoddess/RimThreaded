using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RimThreaded.RimThreadedHarmony;

namespace RimThreaded
{
    public static class HarmonyReplacements
    {
        public static RimThreadedHarmony.Replacements GetReplacements()
        {
            return new RimThreadedHarmony.Replacements()
            {
                ClassReplacements = new List<ClassReplacement>
                {
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.IdeoManager).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.IdeoManager.activeRitualsTmp) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.LordJob_Ritual).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.LordJob_Ritual.totalPresenceTmp) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.LordToil_Ritual).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.LordToil_Ritual.reservedThings) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.LordToil_Ritual.cachedDuties) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.AI.AttackTargetFinder).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.AI.AttackTargetFinder.tmpTargets) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.AI.AttackTargetFinder.availableShootingTargets) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.AI.AttackTargetFinder.tmpTargetScores) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.AI.AttackTargetFinder.tmpCanShootAtTarget) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.AI.AttackTargetFinder.tempDestList) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.AI.AttackTargetFinder.tempSourceList) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.PortraitsCache).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.PortraitsCache.toRemove) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.PortraitsCache.toSetDirty) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.PawnBioAndNameGenerator).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.PawnBioAndNameGenerator.tmpNames) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.PawnBioAndNameGenerator.usedNamesTmp) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.JobDriver_RopeToDestination).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.JobDriver_RopeToDestination.tmpRopees) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.AI.AttackTargetsCache).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.AI.AttackTargetsCache.tmpTargets) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.AI.AttackTargetsCache.tmpToUpdate) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.AutoSlaughterManager).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.AutoSlaughterManager.tmpAnimals) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.AutoSlaughterManager.tmpAnimalsMale) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.AutoSlaughterManager.tmpAnimalsMaleYoung) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.AutoSlaughterManager.tmpAnimalsFemale) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.AutoSlaughterManager.tmpAnimalsFemaleYoung) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.AutoSlaughterManager.tmpAnimalsPregnant) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.BeautyUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.BeautyUtility.tempCountedThings) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.BeautyUtility.beautyRelevantCells) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.BeautyUtility.visibleRooms) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Planet.CaravanInventoryUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.Planet.CaravanInventoryUtility.inventoryItems) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.Planet.CaravanInventoryUtility.inventoryToMove) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.Planet.CaravanInventoryUtility.tmpApparel) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.Planet.CaravanInventoryUtility.tmpEquipment) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Planet.Caravan_BedsTracker).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.Planet.Caravan_BedsTracker.tmpUsableBeds) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.Planet.Caravan_BedsTracker.tmpPawnLabels) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.CellFinder).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.CellFinder.workingCells) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.CellFinder.workingRegions) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.CellFinder.workingListX) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.CellFinder.workingListZ) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.CellFinder.mapEdgeCells) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.CellFinder.mapEdgeCellsSize) },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.CellFinder.mapSingleEdgeCells),
                                PatchedClassName = "RimThreaded.RW_Patches.CellFinder_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail { FieldName = nameof(Verse.CellFinder.mapSingleEdgeCellsSize) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.CellFinder.tmpDistances) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.CellFinder.tmpParents) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.CellFinder.tmpCells) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.CellFinder.tmpUniqueWipedThings) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.DamageWorker).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.DamageWorker.thingsToAffect) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.DamageWorker.openCells) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.DamageWorker.adjWallCells) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Fire).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.Fire.flammableList) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.FloatMenuMakerMap).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.FloatMenuMakerMap.tmpPawns) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.FoodUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.FoodUtility.filtered) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.FoodUtility.tmpPredatorCandidates) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.FoodUtility.ingestThoughts) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.GenAdjFast).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.GenAdjFast.resultList) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.GenAdjFast.working) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.GenAdj).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(Verse.GenAdj.validCells) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.GenLeaving).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.GenLeaving.tmpCellsCandidates) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.GenRadial).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.GenRadial.tmpCells) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.GenRadial.working) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.GenTemperature).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.GenTemperature.neighRooms) },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.GenTemperature.beqRooms),
                                PatchedClassName = "RimThreaded.RW_Patches.GenTemperature_Patch",
                                SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.GenText).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.GenText.tmpSbForCapitalizedSentences) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.GrammarResolverSimpleStringExtensions).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.GrammarResolverSimpleStringExtensions.argsLabels) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.GrammarResolverSimpleStringExtensions.argsObjects) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.GrammarResolverSimple).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.GrammarResolverSimple.tmpResultBuffer) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.GrammarResolverSimple.tmpSymbolBuffer) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.GrammarResolverSimple.tmpSymbolBuffer_objectLabel) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.GrammarResolverSimple.tmpSymbolBuffer_subSymbol) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.GrammarResolverSimple.tmpSymbolBuffer_args) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.GrammarResolverSimple.tmpArgsLabels) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.GrammarResolverSimple.tmpArgsObjects) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.GrammarResolverSimple.tmpArg) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.AI.HaulAIUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(Verse.AI.HaulAIUtility.candidates) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.ImmunityHandler).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.ImmunityHandler.tmpNeededImmunitiesNow) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.InfestationCellFinder).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.InfestationCellFinder.regionsDistanceToUnroofed) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.InfestationCellFinder.closedAreaSize) },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.InfestationCellFinder.tmpCachedInfestationChanceCellColors)
                            },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.InfestationCellFinder.tempUnroofedRegions) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.InfestationCellFinder.locationCandidates) }
                        }
                    },
                    new ClassReplacement()
                    {
                        ClassName = typeof(RimWorld.CellFinderUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>()
                        {
                            new ThreadStaticDetail() { FieldName = nameof(RimWorld.CellFinderUtility.tmpColonyBuildingsLocs) },
                            new ThreadStaticDetail() { FieldName = nameof(RimWorld.CellFinderUtility.tmpDistanceResult) },
                            new ThreadStaticDetail() { FieldName = nameof(RimWorld.CellFinderUtility.distToColonyBuilding) },
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.FleeUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.FleeUtility.tmpThings) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.JobGiver_ConfigurableHostilityResponse).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.JobGiver_ConfigurableHostilityResponse.tmpThreats) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.JobGiver_OptimizeApparel).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.JobGiver_OptimizeApparel.neededWarmth) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.JobGiver_OptimizeApparel.debugSb) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.JobGiver_OptimizeApparel.wornApparelScores) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.LanguageWordInfo).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.LanguageWordInfo.tmpLowercase) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.LanguageWordInfo.lookupTables) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.MapPawns).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.MapPawns.allPawnsResult) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.MapPawns.allPawnsUnspawnedResult) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.MapPawns.prisonersOfColonyResult) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.MapPawns.freeColonistsAndPrisonersResult) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.MapPawns.tmpThings) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.MapPawns.freeColonistsAndPrisonersSpawnedResult) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.MapPawns.spawnedPawnsWithAnyHediffResult) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.MapPawns.spawnedHungryPawnsResult) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.MapPawns.spawnedDownedPawnsResult) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.MapPawns.spawnedPawnsWhoShouldHaveSurgeryDoneNowResult) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.MapPawns.spawnedPawnsWhoShouldHaveInventoryUnloadedResult) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Medicine).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.Medicine.tendableHediffsInTendPriorityOrder) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.Medicine.tmpHediffs) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.AI.PathFinder).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.AI.PathFinder.openList),
                                PatchedClassName = "RimThreaded.RW_Patches.PathFinder_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.AI.PathFinder.statusOpenValue),
                                PatchedClassName = "RimThreaded.RW_Patches.PathFinder_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.AI.PathFinder.statusClosedValue),
                                PatchedClassName = "RimThreaded.RW_Patches.PathFinder_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.AI.PathFinder.disallowedCornerIndices),
                                PatchedClassName = "RimThreaded.RW_Patches.PathFinder_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.AI.PathFinder.calcGrid),
                                PatchedClassName = "RimThreaded.RW_Patches.PathFinder_Patch",
                                SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.PawnDiedOrDownedThoughtsUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnDiedOrDownedThoughtsUtility.tmpIndividualThoughtsToAdd)
                            },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.PawnDiedOrDownedThoughtsUtility.tmpAllColonistsThoughts) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.PawnsFinder).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder.allMapsWorldAndTemporary_AliveOrDead_Result)
                            },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.PawnsFinder.allMapsWorldAndTemporary_Alive_Result) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.PawnsFinder.allMapsAndWorld_Alive_Result) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.PawnsFinder.allMaps_Result) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.PawnsFinder.allMaps_Spawned_Result) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.PawnsFinder.all_AliveOrDead_Result) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.PawnsFinder.temporary_Result) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.PawnsFinder.temporary_Alive_Result) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.PawnsFinder.temporary_Dead_Result) },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder
                                    .allMapsCaravansAndTravelingTransportPods_Alive_Result)
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder
                                    .allCaravansAndTravelingTransportPods_Alive_Result)
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder
                                    .allCaravansAndTravelingTransportPods_AliveOrDead_Result)
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder
                                    .allMapsCaravansAndTravelingTransportPods_Alive_Colonists_Result)
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder
                                    .allMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_Result)
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder
                                    .allMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoLodgers_Result)
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder
                                    .allMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep_Result)
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder
                                    .allMapsCaravansAndTravelingTransportPods_Alive_OfPlayerFaction_Result)
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder
                                    .allMapsCaravansAndTravelingTransportPods_Alive_OfPlayerFaction_NoCryptosleep_Result)
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder
                                    .allMapsCaravansAndTravelingTransportPods_Alive_PrisonersOfColony_Result)
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder
                                    .allMapsCaravansAndTravelingTransportPods_Alive_FreeColonistsAndPrisoners_Result)
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder
                                    .allMapsCaravansAndTravelingTransportPods_Alive_FreeColonistsAndPrisoners_NoCryptosleep_Result)
                            },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.PawnsFinder.allMaps_PrisonersOfColonySpawned_Result) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.PawnsFinder.allMaps_PrisonersOfColony_Result) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.PawnsFinder.allMaps_FreeColonists_Result) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.PawnsFinder.allMaps_FreeColonistsSpawned_Result) },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.PawnsFinder.allMaps_FreeColonistsAndPrisonersSpawned_Result)
                            },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.PawnsFinder.allMaps_FreeColonistsAndPrisoners_Result) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.PawnsFinder.allMaps_SpawnedPawnsInFaction_Result) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.PawnsFinder.homeMaps_FreeColonistsSpawned_Result) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Pawn_InteractionsTracker).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.Pawn_InteractionsTracker.workingList) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Pawn_MeleeVerbs).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.Pawn_MeleeVerbs.meleeVerbs) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.Pawn_MeleeVerbs.verbsToAdd) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Pawn_WorkSettings).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.Pawn_WorkSettings.wtsByPrio) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.Projectile).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(Verse.Projectile.checkedCells) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.QuestUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.QuestUtility.tmpExtraFactions) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.QuestUtility.tmpQuestParts) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.QuestUtility.tmpQuestWorkDisabled) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.Rand).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(Verse.Rand.tmpRange) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.RCellFinder).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.RCellFinder.regions) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.RCellFinder.tmpBuildings) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.RCellFinder.tmpSpotThings) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.RCellFinder.tmpSpotsToAvoid) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.RCellFinder.tmpEdgeCells) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.RegionAndRoomUpdater).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.RegionAndRoomUpdater.tmpVisitedDistricts) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.RegionAndRoomUpdater.tmpDistrictStack) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.AI.RegionCostCalculator).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.AI.RegionCostCalculator.tmpPathableNeighborIndices) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.AI.RegionCostCalculator.tmpDistances) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.AI.RegionCostCalculator.tmpCellIndices) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.RegionListersUpdater).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(Verse.RegionListersUpdater.tmpRegions) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.RegionMaker).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(Verse.RegionMaker.tmpProcessedThings) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.RegionTraverser).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.RegionTraverser.NumWorkers),
                                PatchedClassName = "RimThreaded.RW_Patches.RegionTraverser_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.RegionTraverser.freeWorkers),
                                PatchedClassName = "RimThreaded.RW_Patches.RegionTraverser_Patch",
                                SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.Room).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.Room.uniqueContainedThingsSet) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.Room.uniqueContainedThings) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.Room.uniqueContainedThingsOfDef) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.Room.fields) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.Room.tmpRegions) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.Sound.SustainerManager).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.Sound.SustainerManager.playingPerDef),
                                PatchedClassName = "RimThreaded.RW_Patches.SustainerManager_Patch",
                                SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.TendUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.TendUtility.tmpHediffsToTend) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.TendUtility.tmpHediffs) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.TendUtility.tmpHediffsWithTendPriority) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.AI.ThinkNode_PrioritySorter).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.AI.ThinkNode_PrioritySorter.workingNodes) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.ThoughtHandler).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.ThoughtHandler.tmpThoughts) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.ThoughtHandler.tmpTotalMoodOffsetThoughts) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.ThoughtHandler.tmpSocialThoughts) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.ThoughtHandler.tmpTotalOpinionOffsetThoughts) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Toils_Ingest).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.Toils_Ingest.spotSearchList) },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.Toils_Ingest.cardinals),
                                PatchedClassName = "RimThreaded.RW_Patches.Toils_Ingest_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.Toils_Ingest.diagonals),
                                PatchedClassName = "RimThreaded.RW_Patches.Toils_Ingest_Patch",
                                SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.Verb).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.Verb.tempLeanShootSources) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.Verb.tempDestList) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.AI.WanderUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.AI.WanderUtility.gatherSpots) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.AI.WanderUtility.candidateCells) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.AI.WanderUtility.candidateBuildingsInRandomOrder) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.WealthWatcher).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.WealthWatcher.tmpThings) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.WildPlantSpawner).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.WildPlantSpawner.nearbyClusters) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.WildPlantSpawner.nearbyClustersList) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.WildPlantSpawner.distanceSqToNearbyClusters) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.WildPlantSpawner.tmpPossiblePlantsWithWeight) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.WildPlantSpawner.tmpPossiblePlants) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.WildPlantSpawner.allCavePlants) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.WildPlantSpawner.tmpPlantDefsLowerOrder) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.WorkGiver_Grower).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.WorkGiver_Grower.wantedPlantDef),
                                PatchedClassName = "RimThreaded.RW_Patches.WorkGiver_Grower_Patch"
                            }
                        }
                    },
                    new ClassReplacement { ClassName = typeof(RimWorld.WorkGiver_InteractAnimal).FullName },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.WorldFloodFiller).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.WorldFloodFiller.openSet) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.WorldFloodFiller.traversalDistance) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.WorldFloodFiller.visited) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.WorldFloodFiller.working) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Planet.WorldGrid).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.Planet.WorldGrid.tmpNeighbors) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Planet.World).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.Planet.World.tmpNaturalRockDefs),
                                PatchedClassName = "RimThreaded.RW_Patches.World_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.Planet.World.tmpOceanDirs),
                                PatchedClassName = "RimThreaded.RW_Patches.World_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.Planet.World.tmpNeighbors),
                                PatchedClassName = "RimThreaded.RW_Patches.World_Patch",
                                SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.ShipLandingBeaconUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.ShipLandingBeaconUtility.tmpShipLandingAreas) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.DropCellFinder).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.DropCellFinder.tmpColonyBuildings) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.DropCellFinder.tmpShipLandingAreas) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.Grammar.GrammarResolver).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.Grammar.GrammarResolver.rules) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.Grammar.GrammarResolver.rulePool) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.Grammar.GrammarResolver.loopCount) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.Grammar.GrammarResolver.logSbTrace) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.Grammar.GrammarResolver.logSbMid) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.Grammar.GrammarResolver.logSbRules) },
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.ShipUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.ShipUtility.closedSet) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.ShipUtility.openSet) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.ThingSetMaker).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.ThingSetMaker.thingsBeingGeneratedNow) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.ColoredText).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.ColoredText.resultBuffer) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.ColoredText.tagBuffer) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.ColoredText.argBuffer) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.ColoredText.cache) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.ColoredText.capStage) },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.ColoredText.ColonistCountRegex),
                                PatchedClassName = "RimThreaded.RW_Patches.ColoredText_Patch",
                                SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Pawn_ApparelTracker).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(RimWorld.Pawn_ApparelTracker.tmpApparel),
                                PatchedClassName = "RimThreaded.RW_Patches.Pawn_ApparelTracker_Patch"
                            },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.Pawn_ApparelTracker.tmpApparelList) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.RoomStatWorker_Beauty).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.RoomStatWorker_Beauty.countedThings) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.RoomStatWorker_Beauty.countedAdjCells) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.SpouseRelationUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.SpouseRelationUtility.tmpSpouses) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.SpouseRelationUtility.tmpLoveRelations) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.SpouseRelationUtility.tmpStack) },
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.SpouseRelationUtility.tmpDivorcedPawnNames) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.LovePartnerRelationUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.LovePartnerRelationUtility.tmpExistingLovePartners) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.BuildingsDamageSectionLayerUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.BuildingsDamageSectionLayerUtility.availableOverlays) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.BuildingsDamageSectionLayerUtility.overlaysWorkingList) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.BuildingsDamageSectionLayerUtility.overlays) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.IdeoUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.IdeoUtility.tmpCheckRooms) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.IdeoUtility.tmpTreeSightings) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Need_RoomSize).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.Need_RoomSize.tempScanRooms) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Planet.TileFinder).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.Planet.TileFinder.tmpTiles) },
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.Planet.TileFinder.tmpPlayerTiles) }
                        }
                    },
                    new ClassReplacement
                    {
                        // Is mod, can't reference it the same way
                        ClassName = "SpeakUp.GrammarResolver_RandomPossiblyResolvableEntry",
                        IgnoreMissing = true,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = "CurrentRules"
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.ThingOwnerUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.ThingOwnerUtility.tmpStack),
                                PatchedClassName = "RimThreaded.RW_Patches.ThingOwnerUtility_Patch"
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.ThingOwnerUtility.tmpHolders),
                                PatchedClassName = "RimThreaded.RW_Patches.ThingOwnerUtility_Patch"
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.ThingOwnerUtility.tmpThings),
                                PatchedClassName = "RimThreaded.RW_Patches.ThingOwnerUtility_Patch"
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = nameof(Verse.ThingOwnerUtility.tmpMapChildHolders),
                                PatchedClassName = "RimThreaded.RW_Patches.ThingOwnerUtility_Patch"
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Building_Bed).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                                { FieldName = nameof(RimWorld.Building_Bed.tmpOrderedInteractionCells) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.Trait).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.Trait.tmpDisabledWorktypes) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.GuestUtility).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(RimWorld.GuestUtility.tmpDisabledWorkTypes) }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.RoomRoleWorker_Barracks).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.RoomRoleWorker_Barracks.tmpBeds) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(RimWorld.RoomRoleWorker_Bedroom).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = nameof(RimWorld.RoomRoleWorker_Bedroom.tmpBeds) } }
                    },
                    new ClassReplacement
                    {
                        ClassName = typeof(Verse.HediffSet).FullName,
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = nameof(Verse.HediffSet.tmpHediffVerbs) },
                            new ThreadStaticDetail { FieldName = nameof(Verse.HediffSet.tmpInjuredParts) },
                            new ThreadStaticDetail
                                { FieldName = nameof(Verse.HediffSet.tmpNaturallyHealingInjuredParts) }
                        }
                    }

                }
            };
        }
    }

}
