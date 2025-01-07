using RimWorld;
using System;
using System.Collections.Generic;
using Verse;
using static RimWorld.BeautyUtility;

namespace RimThreaded.RW_Patches
{
    class BeautyUtility_Patch
    {
        internal static void RunDestructivePatches()
        {
            Type original = typeof(BeautyUtility);
            Type patched = typeof(BeautyUtility_Patch);
            RimThreadedHarmony.Prefix(original, patched, nameof(CellBeauty));
        }
        public static bool CellBeauty(ref float __result, IntVec3 c, Map map, HashSet<Thing> countedThings = null)
        {
            float num = 0.0f;
            float num2 = 0.0f;
            bool flag = false;
            if (map == null) //added
            {
                __result = 0f;
                return false;
            }
            TerrainGrid terrainGrid = map.terrainGrid;
            if (terrainGrid == null) //added
            {
                __result = 0f;
                return false;
            }
            TerrainDef terrainDef = terrainGrid.TerrainAt(c);
            ThingGrid thingGrid = map.thingGrid;
            if (thingGrid == null) //added
            {
                __result = 0f;
                return false;
            }
            bool outside = c.GetRoom(map)?.PsychologicallyOutdoors ?? true;
            bool roofed = map.roofGrid.Roofed(c);
            List<Thing> thingList = thingGrid.ThingsListAt(c); //changed
            for (int index = 0; index < thingList.Count; ++index)
            {
                Thing thing = thingList[index];
                if (!BeautyRelevant(thing.def.category))
                    continue;
                if (countedThings == null)
                    continue;
                if (countedThings.Contains(thing))
                    continue;
                countedThings.Add(thing);
                SlotGroup slotGroup = thing.GetSlotGroup();
                if (slotGroup != null && slotGroup.parent != thing && slotGroup.parent.IgnoreStoredThingsBeauty)
                    continue;
                //float beauty = ((outside && thing.def.StatBaseDefined(StatDefOf.BeautyOutdoors)) ? thing.GetStatValue(StatDefOf.BeautyOutdoors) : thing.GetStatValue(StatDefOf.Beauty));
                float beauty = thing.GetBeauty(outside);
                if (thing.def.filth != null && !roofed)
                {
                    beauty *= 0.3f;
                }
                if (thing.def.Fillage == FillCategory.Full)
                {
                    flag = true;
                    num2 += beauty;
                }
                else
                {
                    num += beauty;
                }              
            }
            if (flag)
            {
                __result = num2;
                return false;
            }
            if (ModsConfig.BiotechActive && !terrainDef.BuildableByPlayer && c.IsPolluted(map))
            {
                num += -1f;
            }
            if (outside && terrainDef.StatBaseDefined(StatDefOf.BeautyOutdoors))
            {
                __result = num + terrainDef.GetStatValueAbstract(StatDefOf.BeautyOutdoors);
                return false;
            }
            __result = num + terrainDef.GetStatValueAbstract(StatDefOf.Beauty);
            return false;
        }
    }
}
