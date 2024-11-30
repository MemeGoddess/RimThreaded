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
                        ClassName = "RimWorld.IdeoManager",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "activeRitualsTmp" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.LordJob_Ritual",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "totalPresenceTmp" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.LordToil_Ritual",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "reservedThings" },
                            new ThreadStaticDetail { FieldName = "cachedDuties" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.AI.AttackTargetFinder",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpTargets" },
                            new ThreadStaticDetail { FieldName = "availableShootingTargets" },
                            new ThreadStaticDetail { FieldName = "tmpTargetScores" },
                            new ThreadStaticDetail { FieldName = "tmpCanShootAtTarget" },
                            new ThreadStaticDetail { FieldName = "tempDestList" },
                            new ThreadStaticDetail { FieldName = "tempSourceList" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.PortraitsCache",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "toRemove" },
                            new ThreadStaticDetail { FieldName = "toSetDirty" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.PawnBioAndNameGenerator",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpNames" },
                            new ThreadStaticDetail { FieldName = "usedNamesTmp" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.JobDriver_RopeToDestination",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpRopees" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.AI.AttackTargetsCache",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpTargets" },
                            new ThreadStaticDetail { FieldName = "tmpToUpdate" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.AutoSlaughterManager",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpAnimals" },
                            new ThreadStaticDetail { FieldName = "tmpAnimalsMale" },
                            new ThreadStaticDetail { FieldName = "tmpAnimalsMaleYoung" },
                            new ThreadStaticDetail { FieldName = "tmpAnimalsFemale" },
                            new ThreadStaticDetail { FieldName = "tmpAnimalsFemaleYoung" },
                            new ThreadStaticDetail { FieldName = "tmpAnimalsPregnant" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.BeautyUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tempCountedThings" },
                            new ThreadStaticDetail { FieldName = "beautyRelevantCells" },
                            new ThreadStaticDetail { FieldName = "visibleRooms" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Planet.CaravanInventoryUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "inventoryItems" },
                            new ThreadStaticDetail { FieldName = "inventoryToMove" },
                            new ThreadStaticDetail { FieldName = "tmpApparel" },
                            new ThreadStaticDetail { FieldName = "tmpEquipment" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Planet.Caravan_BedsTracker",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpUsableBeds" },
                            new ThreadStaticDetail { FieldName = "tmpPawnLabels" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.CellFinder",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "workingCells" },
                            new ThreadStaticDetail { FieldName = "workingRegions" },
                            new ThreadStaticDetail { FieldName = "workingListX" },
                            new ThreadStaticDetail { FieldName = "workingListZ" },
                            new ThreadStaticDetail { FieldName = "mapEdgeCells" },
                            new ThreadStaticDetail { FieldName = "mapEdgeCellsSize" },
                            new ThreadStaticDetail
                            {
                                FieldName = "mapSingleEdgeCells",
                                PatchedClassName = "RimThreaded.RW_Patches.CellFinder_Patch", SelfInitialized = true
                            },
                            new ThreadStaticDetail { FieldName = "mapSingleEdgeCellsSize" },
                            new ThreadStaticDetail { FieldName = "tmpDistances" },
                            new ThreadStaticDetail { FieldName = "tmpParents" },
                            new ThreadStaticDetail { FieldName = "tmpCells" },
                            new ThreadStaticDetail { FieldName = "tmpUniqueWipedThings" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.DamageWorker",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "thingsToAffect" },
                            new ThreadStaticDetail { FieldName = "openCells" },
                            new ThreadStaticDetail { FieldName = "adjWallCells" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Fire",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "flammableList" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.FloatMenuMakerMap",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpPawns" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.FoodUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "filtered" },
                            new ThreadStaticDetail { FieldName = "tmpPredatorCandidates" },
                            new ThreadStaticDetail { FieldName = "ingestThoughts" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.GenAdjFast",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "resultList" },
                            new ThreadStaticDetail { FieldName = "working" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.GenAdj",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "validCells" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.GenLeaving",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpCellsCandidates" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.GenRadial",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpCells" },
                            new ThreadStaticDetail { FieldName = "working" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.GenTemperature",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "neighRooms" },
                            new ThreadStaticDetail
                            {
                                FieldName = "beqRooms",
                                PatchedClassName = "RimThreaded.RW_Patches.GenTemperature_Patch", SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.GenText",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpSbForCapitalizedSentences" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.GrammarResolverSimpleStringExtensions",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "argsLabels" },
                            new ThreadStaticDetail { FieldName = "argsObjects" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.GrammarResolverSimple",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpResultBuffer" },
                            new ThreadStaticDetail { FieldName = "tmpSymbolBuffer" },
                            new ThreadStaticDetail { FieldName = "tmpSymbolBuffer_objectLabel" },
                            new ThreadStaticDetail { FieldName = "tmpSymbolBuffer_subSymbol" },
                            new ThreadStaticDetail { FieldName = "tmpSymbolBuffer_args" },
                            new ThreadStaticDetail { FieldName = "tmpArgsLabels" },
                            new ThreadStaticDetail { FieldName = "tmpArgsObjects" },
                            new ThreadStaticDetail { FieldName = "tmpArg" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.AI.HaulAIUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "candidates" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.ImmunityHandler",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpNeededImmunitiesNow" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.InfestationCellFinder",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "regionsDistanceToUnroofed" },
                            new ThreadStaticDetail { FieldName = "tmpColonyBuildingsLocs" },
                            new ThreadStaticDetail { FieldName = "tmpDistanceResult" },
                            new ThreadStaticDetail { FieldName = "distToColonyBuilding" },
                            new ThreadStaticDetail { FieldName = "closedAreaSize" },
                            new ThreadStaticDetail { FieldName = "tmpCachedInfestationChanceCellColors" },
                            new ThreadStaticDetail { FieldName = "tempUnroofedRegions" },
                            new ThreadStaticDetail { FieldName = "locationCandidates" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.JobGiver_AnimalFlee",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpThings" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.JobGiver_ConfigurableHostilityResponse",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpThreats" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.JobGiver_OptimizeApparel",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "neededWarmth" },
                            new ThreadStaticDetail { FieldName = "debugSb" },
                            new ThreadStaticDetail { FieldName = "wornApparelScores" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.LanguageWordInfo",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpLowercase" },
                            new ThreadStaticDetail { FieldName = "lookupTables" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.MapPawns",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "allPawnsResult" },
                            new ThreadStaticDetail { FieldName = "allPawnsUnspawnedResult" },
                            new ThreadStaticDetail { FieldName = "prisonersOfColonyResult" },
                            new ThreadStaticDetail { FieldName = "freeColonistsAndPrisonersResult" },
                            new ThreadStaticDetail { FieldName = "tmpThings" },
                            new ThreadStaticDetail { FieldName = "freeColonistsAndPrisonersSpawnedResult" },
                            new ThreadStaticDetail { FieldName = "spawnedPawnsWithAnyHediffResult" },
                            new ThreadStaticDetail { FieldName = "spawnedHungryPawnsResult" },
                            new ThreadStaticDetail { FieldName = "spawnedDownedPawnsResult" },
                            new ThreadStaticDetail { FieldName = "spawnedPawnsWhoShouldHaveSurgeryDoneNowResult" },
                            new ThreadStaticDetail { FieldName = "spawnedPawnsWhoShouldHaveInventoryUnloadedResult" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Medicine",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tendableHediffsInTendPriorityOrder" },
                            new ThreadStaticDetail { FieldName = "tmpHediffs" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.AI.PathFinder",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = "openList", PatchedClassName = "RimThreaded.RW_Patches.PathFinder_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = "statusOpenValue",
                                PatchedClassName = "RimThreaded.RW_Patches.PathFinder_Patch", SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = "statusClosedValue",
                                PatchedClassName = "RimThreaded.RW_Patches.PathFinder_Patch", SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = "disallowedCornerIndices",
                                PatchedClassName = "RimThreaded.RW_Patches.PathFinder_Patch", SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = "calcGrid", PatchedClassName = "RimThreaded.RW_Patches.PathFinder_Patch",
                                SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.PawnDiedOrDownedThoughtsUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpIndividualThoughtsToAdd" },
                            new ThreadStaticDetail { FieldName = "tmpAllColonistsThoughts" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.PawnsFinder",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "allMapsWorldAndTemporary_AliveOrDead_Result" },
                            new ThreadStaticDetail { FieldName = "allMapsWorldAndTemporary_Alive_Result" },
                            new ThreadStaticDetail { FieldName = "allMapsAndWorld_Alive_Result" },
                            new ThreadStaticDetail { FieldName = "allMaps_Result" },
                            new ThreadStaticDetail { FieldName = "allMaps_Spawned_Result" },
                            new ThreadStaticDetail { FieldName = "all_AliveOrDead_Result" },
                            new ThreadStaticDetail { FieldName = "temporary_Result" },
                            new ThreadStaticDetail { FieldName = "temporary_Alive_Result" },
                            new ThreadStaticDetail { FieldName = "temporary_Dead_Result" },
                            new ThreadStaticDetail
                                { FieldName = "allMapsCaravansAndTravelingTransportPods_Alive_Result" },
                            new ThreadStaticDetail { FieldName = "allCaravansAndTravelingTransportPods_Alive_Result" },
                            new ThreadStaticDetail
                                { FieldName = "allCaravansAndTravelingTransportPods_AliveOrDead_Result" },
                            new ThreadStaticDetail
                                { FieldName = "allMapsCaravansAndTravelingTransportPods_Alive_Colonists_Result" },
                            new ThreadStaticDetail
                                { FieldName = "allMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_Result" },
                            new ThreadStaticDetail
                            {
                                FieldName =
                                    "allMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoLodgers_Result"
                            },
                            new ThreadStaticDetail
                            {
                                FieldName =
                                    "allMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep_Result"
                            },
                            new ThreadStaticDetail
                                { FieldName = "allMapsCaravansAndTravelingTransportPods_Alive_OfPlayerFaction_Result" },
                            new ThreadStaticDetail
                            {
                                FieldName =
                                    "allMapsCaravansAndTravelingTransportPods_Alive_OfPlayerFaction_NoCryptosleep_Result"
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = "allMapsCaravansAndTravelingTransportPods_Alive_PrisonersOfColony_Result"
                            },
                            new ThreadStaticDetail
                            {
                                FieldName =
                                    "allMapsCaravansAndTravelingTransportPods_Alive_FreeColonistsAndPrisoners_Result"
                            },
                            new ThreadStaticDetail
                            {
                                FieldName =
                                    "allMapsCaravansAndTravelingTransportPods_Alive_FreeColonistsAndPrisoners_NoCryptosleep_Result"
                            },
                            new ThreadStaticDetail { FieldName = "allMaps_PrisonersOfColonySpawned_Result" },
                            new ThreadStaticDetail { FieldName = "allMaps_PrisonersOfColony_Result" },
                            new ThreadStaticDetail { FieldName = "allMaps_FreeColonists_Result" },
                            new ThreadStaticDetail { FieldName = "allMaps_FreeColonistsSpawned_Result" },
                            new ThreadStaticDetail { FieldName = "allMaps_FreeColonistsAndPrisonersSpawned_Result" },
                            new ThreadStaticDetail { FieldName = "allMaps_FreeColonistsAndPrisoners_Result" },
                            new ThreadStaticDetail { FieldName = "allMaps_SpawnedPawnsInFaction_Result" },
                            new ThreadStaticDetail { FieldName = "homeMaps_FreeColonistsSpawned_Result" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Pawn_InteractionsTracker",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "workingList" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Pawn_MeleeVerbs",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "meleeVerbs" },
                            new ThreadStaticDetail { FieldName = "verbsToAdd" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Pawn_WorkSettings",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "wtsByPrio" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.Projectile",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "checkedCells" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.QuestUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpExtraFactions" },
                            new ThreadStaticDetail { FieldName = "tmpQuestParts" },
                            new ThreadStaticDetail { FieldName = "tmpQuestWorkDisabled" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.Rand",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpRange" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.RCellFinder",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "regions" },
                            new ThreadStaticDetail { FieldName = "tmpBuildings" },
                            new ThreadStaticDetail { FieldName = "tmpSpotThings" },
                            new ThreadStaticDetail { FieldName = "tmpSpotsToAvoid" },
                            new ThreadStaticDetail { FieldName = "tmpEdgeCells" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.RegionAndRoomUpdater",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpVisitedDistricts" },
                            new ThreadStaticDetail { FieldName = "tmpDistrictStack" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.AI.RegionCostCalculator",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpPathableNeighborIndices" },
                            new ThreadStaticDetail { FieldName = "tmpDistances" },
                            new ThreadStaticDetail { FieldName = "tmpCellIndices" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.RegionListersUpdater",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpRegions" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.RegionMaker",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpProcessedThings" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.RegionTraverser",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = "NumWorkers",
                                PatchedClassName = "RimThreaded.RW_Patches.RegionTraverser_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = "freeWorkers",
                                PatchedClassName = "RimThreaded.RW_Patches.RegionTraverser_Patch",
                                SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.Room",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "uniqueContainedThingsSet" },
                            new ThreadStaticDetail { FieldName = "uniqueContainedThings" },
                            new ThreadStaticDetail { FieldName = "uniqueContainedThingsOfDef" },
                            new ThreadStaticDetail { FieldName = "fields" },
                            new ThreadStaticDetail { FieldName = "tmpRegions" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.Sound.SustainerManager",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = "playingPerDef",
                                PatchedClassName = "RimThreaded.RW_Patches.SustainerManager_Patch",
                                SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.TendUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpHediffsToTend" },
                            new ThreadStaticDetail { FieldName = "tmpHediffs" },
                            new ThreadStaticDetail { FieldName = "tmpHediffsWithTendPriority" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.AI.ThinkNode_PrioritySorter",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "workingNodes" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.ThoughtHandler",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpThoughts" },
                            new ThreadStaticDetail { FieldName = "tmpTotalMoodOffsetThoughts" },
                            new ThreadStaticDetail { FieldName = "tmpSocialThoughts" },
                            new ThreadStaticDetail { FieldName = "tmpTotalOpinionOffsetThoughts" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Toils_Ingest",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "spotSearchList" },
                            new ThreadStaticDetail
                            {
                                FieldName = "cardinals", PatchedClassName = "RimThreaded.RW_Patches.Toils_Ingest_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = "diagonals", PatchedClassName = "RimThreaded.RW_Patches.Toils_Ingest_Patch",
                                SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.Verb",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tempLeanShootSources" },
                            new ThreadStaticDetail { FieldName = "tempDestList" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.AI.WanderUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "gatherSpots" },
                            new ThreadStaticDetail { FieldName = "candidateCells" },
                            new ThreadStaticDetail { FieldName = "candidateBuildingsInRandomOrder" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.WealthWatcher",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpThings" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.WildPlantSpawner",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "nearbyClusters" },
                            new ThreadStaticDetail { FieldName = "nearbyClustersList" },
                            new ThreadStaticDetail { FieldName = "distanceSqToNearbyClusters" },
                            new ThreadStaticDetail { FieldName = "tmpPossiblePlantsWithWeight" },
                            new ThreadStaticDetail { FieldName = "tmpPossiblePlants" },
                            new ThreadStaticDetail { FieldName = "allCavePlants" },
                            new ThreadStaticDetail { FieldName = "tmpPlantDefsLowerOrder" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.WorkGiver_Grower",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = "wantedPlantDef",
                                PatchedClassName = "RimThreaded.RW_Patches.WorkGiver_Grower_Patch"
                            }
                        }
                    },
                    new ClassReplacement { ClassName = "RimWorld.WorkGiver_InteractAnimal" },
                    new ClassReplacement
                    {
                        ClassName = "Verse.WorldFloodFiller",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "openSet" },
                            new ThreadStaticDetail { FieldName = "traversalDistance" },
                            new ThreadStaticDetail { FieldName = "visited" },
                            new ThreadStaticDetail { FieldName = "working" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Planet.WorldGrid",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpNeighbors" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Planet.World",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = "tmpNaturalRockDefs",
                                PatchedClassName = "RimThreaded.RW_Patches.World_Patch", SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = "tmpOceanDirs", PatchedClassName = "RimThreaded.RW_Patches.World_Patch",
                                SelfInitialized = true
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = "tmpNeighbors", PatchedClassName = "RimThreaded.RW_Patches.World_Patch",
                                SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.ShipLandingBeaconUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpShipLandingAreas" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.DropCellFinder",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpColonyBuildings" },
                            new ThreadStaticDetail { FieldName = "tmpShipLandingAreas" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.Grammar.GrammarResolver",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "rules" },
                            new ThreadStaticDetail { FieldName = "rulePool" },
                            new ThreadStaticDetail { FieldName = "loopCount" },
                            new ThreadStaticDetail { FieldName = "logSbTrace" },
                            new ThreadStaticDetail { FieldName = "logSbMid" },
                            new ThreadStaticDetail { FieldName = "logSbRules" },
                            new ThreadStaticDetail { FieldName = "tmpSortedRuleList" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.ShipUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "closedSet" },
                            new ThreadStaticDetail { FieldName = "openSet" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.ThingSetMaker",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "thingsBeingGeneratedNow" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.ColoredText",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "resultBuffer" },
                            new ThreadStaticDetail { FieldName = "tagBuffer" },
                            new ThreadStaticDetail { FieldName = "argBuffer" },
                            new ThreadStaticDetail { FieldName = "cache" },
                            new ThreadStaticDetail { FieldName = "capStage" },
                            new ThreadStaticDetail
                            {
                                FieldName = "ColonistCountRegex",
                                PatchedClassName = "RimThreaded.RW_Patches.ColoredText_Patch", SelfInitialized = true
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Pawn_ApparelTracker",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = "tmpApparel",
                                PatchedClassName = "RimThreaded.RW_Patches.Pawn_ApparelTracker_Patch"
                            },
                            new ThreadStaticDetail { FieldName = "tmpApparelList" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.RoomStatWorker_Beauty",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "countedThings" },
                            new ThreadStaticDetail { FieldName = "countedAdjCells" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.SpouseRelationUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpSpouses" },
                            new ThreadStaticDetail { FieldName = "tmpLoveRelations" },
                            new ThreadStaticDetail { FieldName = "tmpStack" },
                            new ThreadStaticDetail { FieldName = "tmpDivorcedPawnNames" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.LovePartnerRelationUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpExistingLovePartners" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.BuildingsDamageSectionLayerUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "availableOverlays" },
                            new ThreadStaticDetail { FieldName = "overlaysWorkingList" },
                            new ThreadStaticDetail { FieldName = "overlays" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.IdeoUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpCheckRooms" },
                            new ThreadStaticDetail { FieldName = "tmpTreeSightings" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Need_RoomSize",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tempScanRooms" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Planet.TileFinder",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpTiles" },
                            new ThreadStaticDetail { FieldName = "tmpPlayerTiles" }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "SpeakUp.GrammarResolver_RandomPossiblyResolvableEntry", IgnoreMissing = true,
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "CurrentRules" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.ThingOwnerUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail
                            {
                                FieldName = "tmpStack",
                                PatchedClassName = "RimThreaded.RW_Patches.ThingOwnerUtility_Patch"
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = "tmpHolders",
                                PatchedClassName = "RimThreaded.RW_Patches.ThingOwnerUtility_Patch"
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = "tmpThings",
                                PatchedClassName = "RimThreaded.RW_Patches.ThingOwnerUtility_Patch"
                            },
                            new ThreadStaticDetail
                            {
                                FieldName = "tmpMapChildHolders",
                                PatchedClassName = "RimThreaded.RW_Patches.ThingOwnerUtility_Patch"
                            }
                        }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Building_Bed",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpOrderedInteractionCells" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.Trait",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpDisabledWorktypes" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.GuestUtility",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpDisabledWorkTypes" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.RoomRoleWorker_Barracks",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpBeds" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "RimWorld.RoomRoleWorker_Bedroom",
                        ThreadStatics = new List<ThreadStaticDetail>
                            { new ThreadStaticDetail { FieldName = "tmpBeds" } }
                    },
                    new ClassReplacement
                    {
                        ClassName = "Verse.HediffSet",
                        ThreadStatics = new List<ThreadStaticDetail>
                        {
                            new ThreadStaticDetail { FieldName = "tmpHediffVerbs" },
                            new ThreadStaticDetail { FieldName = "tmpInjuredParts" },
                            new ThreadStaticDetail { FieldName = "tmpNaturallyHealingInjuredParts" }
                        }
                    }
                }
            };
        }
    }

}
