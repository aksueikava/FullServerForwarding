using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Exiled.API.Features;
using HarmonyLib;

namespace FullServerForwarding.Patches
{
    [HarmonyPatch(typeof(CustomNetworkManager), "CreateMatch")]
    public static class CreateMatchPatch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var newInstructions = instructions.ToList();
            newInstructions.InsertRange(37, new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldc_I4_1),
                new CodeInstruction(OpCodes.Add)
            });
            foreach (var instruction in newInstructions)
                yield return instruction;
        }
    }
}