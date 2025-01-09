using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace RimThreaded.RW_Patches
{
    public class PawnsFinder_Patch
    {
        private static readonly object _lockObject = new object();
        internal static void RunNonDestructivePatches()
        {
            Type original = typeof(PawnsFinder);
            Type patched = typeof(PawnsFinder_Patch);
            RimThreadedHarmony.Prefix(original, patched, "get_" + nameof(PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep));
        }

        // TODO LA Make this non destructive again.
        public static bool get_AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep(MethodBase __originalMethod, ref List<Pawn> __result)
        {
            lock (_lockObject)
            {
                try
                {
                    PawnsFinder.allMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep_Result.Clear();
                    List<Pawn> transportPodsAlive = PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive;
                    for (int index = 0; index < transportPodsAlive.Count; ++index)
                    {
                        if (transportPodsAlive[index].IsFreeColonist && !transportPodsAlive[index].InCryptosleep)
                            PawnsFinder.allMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep_Result.Add(transportPodsAlive[index]);
                    }
                    __result = PawnsFinder.allMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep_Result;
                }
                catch(Exception e)
                {
                    Debugger.Break();
                }
            }
            return false;
        }
    }
}
