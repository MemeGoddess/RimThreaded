using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Mono.Cecil.Cil;
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
            var instructionsList = instructions.ToList();
            // Want to add a .ToList() call to the return 
            var toListMethod = typeof(Enumerable)
                    .GetMethods(BindingFlags.Static | BindingFlags.Public)
                    .FirstOrDefault(m =>
                        m.Name == "ToList"
                        && m.IsGenericMethod
                        && m.GetParameters().Length == 1
                        && m.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                    )?
                    .MakeGenericMethod(typeof(Pawn));

            for (int i = instructionsList.Count() - 1; i > 0; i--)
            {
                var instruction = instructionsList[i];
                if (instruction.opcode == OpCodes.Ldsfld && (instruction.operand as FieldInfo).Name == nameof(PawnsFinder.allMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep_Result))
                    instructionsList.Insert(i + 1, new CodeInstruction(OpCodes.Call, toListMethod));
            }
            // Why is this call not working and just returning null? O.o
            var wrapped =  RimThreadedHarmony.WrapMethodInInstanceLock(instructionsList, ilGenerator);
            return wrapped;
        }
    }
}
