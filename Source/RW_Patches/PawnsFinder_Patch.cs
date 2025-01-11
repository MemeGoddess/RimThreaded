using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RimThreaded.RW_Patches
{
    public class PawnsFinder_Patch
    {
        internal static void RunNonDestructivePatches()
        {
            Type original = typeof(PawnsFinder);
            Type patched = typeof(PawnsFinder_Patch);
            RimThreadedHarmony.Transpile(original, patched, nameof(get_AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep));
        }


        public static IEnumerable<CodeInstruction>
            get_AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep(
                IEnumerable<CodeInstruction> instructions, ILGenerator ilGenerator)
        {

            var wrappedInstructions = RimThreadedHarmony.WrapMethodInInstanceLock(instructions, ilGenerator);

            // Want to add a .ToList() call to the return 
            var pawnListField = AccessTools.Field(
                typeof(RimWorld.PawnsFinder),
                nameof(PawnsFinder.allMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep_Result)
            );

            var toListMethod = AccessTools.Method(
                typeof(Enumerable),
                nameof(Enumerable.ToList),
                new[] { typeof(IEnumerable<Pawn>) }
            );

            foreach (var instruction in wrappedInstructions)
            {
                yield return instruction;

                if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == pawnListField)
                    yield return new CodeInstruction(OpCodes.Call, toListMethod);
            }
        }
    }
}
