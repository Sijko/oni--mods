using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using UnityEngine;
using IAmHungry;
using System.Reflection;
using TUNING;
using NewRanching.NewRanchingDietUtils;
using KSerialization;
using Boa;
using Klei.AI;

namespace Boa
{
    public class XaBka
    {
        public static float  Globalminpoopsize = 100f;
        public static float  GlobalHatchMetal_kgPerDay = CheetyCreety.CheetyCreetyState.StateManager.State.Set_GlobalHatchMetal_kgPerDay;
        public static float  GlobalHatchMetal_calPerDay = HatchTuning.STANDARD_CALORIES_PER_CYCLE;
        public static float  GlobalHatchVeggie_kgPerDay = CheetyCreety.CheetyCreetyState.StateManager.State.Set_GlobalHatchVeggie_kgPerDay;
        public static float  GlobalHatchVeggie_calPerDay = HatchTuning.STANDARD_CALORIES_PER_CYCLE;
        public static float  GlobalHatchHard_kgPerDay = CheetyCreety.CheetyCreetyState.StateManager.State.Set_GlobalHatchHard_kgPerDay;
        public static float  GlobalHatchHard_calPerDay = HatchTuning.STANDARD_CALORIES_PER_CYCLE;
        public static float  GlobalHatch_kgPerDay = CheetyCreety.CheetyCreetyState.StateManager.State.Set_GlobalHatch_kgPerDay;
        public static float  GlobalHatch_calPerDay = HatchTuning.STANDARD_CALORIES_PER_CYCLE;
        public static float  GlobalMole_KgPerDay = CheetyCreety.CheetyCreetyState.StateManager.State.Set_GlobalMole_KgPerDay;
        public static float  GlobalMole_CalPerDay = MoleTuning.STANDARD_CALORIES_PER_CYCLE;
        public static float  GlobalRegolith_KgPerDay = CheetyCreety.CheetyCreetyState.StateManager.State.Set_GlobalRegolith_KgPerDay;
    }
}
namespace CheetyCreetyBase
{
    namespace Drecko
    {
        namespace HitlerLives
        {
            [HarmonyPatch(typeof(DreckoConfig), "CreateDrecko")] public static class InBaseDAntarctic { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 150f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.DreckoAge1; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(DreckoPlasticConfig), "CreateDrecko")] public static class InPlasticAntarctic { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 150f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.DreckoAge2; } } } return codes.AsEnumerable(); } }
        }
        namespace SpreadTheDoom
        {
            [HarmonyPatch(typeof(DreckoConfig), "CreatePrefab")] public static class LetsSpreadBaseD { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 90f) && ((Single)codes[i + 2].operand == 30f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.DreckoRep1; codes[i + 2].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(DreckoPlasticConfig), "CreatePrefab")] public static class LetsSpreadPlastic { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 90f) && ((Single)codes[i + 2].operand == 30f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.DreckoRep2; codes[i + 2].operand = 1f; } } } return codes.AsEnumerable(); } }
        }
    }
    namespace Moo
    {
        namespace HitlerLives
        {
            [HarmonyPatch(typeof(MooConfig), "CreateMoo")] public static class ThereIsNoCowLevel { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 75f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.MooAge; } } } return codes.AsEnumerable(); } }
        }
    }
    namespace Slickster
    {
        namespace HitlerLives
        {
            [HarmonyPatch(typeof(OilFloaterConfig), "CreateOilFloater")] public static class InAntarcticBaseO { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 100f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.SlicksterAge1; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(OilFloaterDecorConfig), "CreateOilFloater")] public static class InAntarcticDecor { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 150f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.SlicksterAge2; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(OilFloaterHighTempConfig), "CreateOilFloater")] public static class InAntarcticHigh { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 100f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.SlicksterAge3; } } } return codes.AsEnumerable(); } }
        }
        namespace SpreadTheDoom
        {
            [HarmonyPatch(typeof(OilFloaterConfig), "CreatePrefab")] public static class LetsSpreadBaseO { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 60.0000038f) && ((Single)codes[i + 1].operand == 20f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.SlicksterRep1; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(OilFloaterDecorConfig), "CreatePrefab")] public static class LetsSpreadDecor { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 90f) && ((Single)codes[i + 1].operand == 30f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.SlicksterRep2; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(OilFloaterHighTempConfig), "CreatePrefab")] public static class LetsSpreadHigh { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 60.0000038f) && ((Single)codes[i + 1].operand == 20f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.SlicksterRep3; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
        }


    }
    namespace Hatch
    {
        namespace HitlerLives
        {
            [HarmonyPatch(typeof(HatchConfig), "CreateHatch")] public static class InBaseAntarctic { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 100f) && (codes[i + 1].opcode == OpCodes.Ldarg_1)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.HatchAge1; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(HatchHardConfig), "CreateHatch")] public static class InHardAntarctic { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 100f) && (codes[i + 1].opcode == OpCodes.Ldarg_1)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.HatchAge2; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(HatchMetalConfig), "CreateHatch")] public static class InMetalAntarctic { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 100f) && (codes[i + 1].opcode == OpCodes.Ldarg_1)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.HatchAge3; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(HatchVeggieConfig), "CreateHatch")] public static class InVeggieAntarctic { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 100f) && (codes[i + 1].opcode == OpCodes.Ldarg_1)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.HatchAge4; } } } return codes.AsEnumerable(); } }
        }
        namespace SpreadTheDoom
        {
            [HarmonyPatch(typeof(HatchConfig), "CreatePrefab")] public static class LetsSpreadBase { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 60.0000038f) && ((Single)codes[i + 1].operand == 20f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.HatchRep1; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(HatchHardConfig), "CreatePrefab")] public static class LetsSpreadHard { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 60.0000038f) && ((Single)codes[i + 1].operand == 20f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.HatchRep2; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(HatchMetalConfig), "CreatePrefab")] public static class LetsSpreadMetal { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 60.0000038f) && ((Single)codes[i + 1].operand == 20f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.HatchRep3; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(HatchVeggieConfig), "CreatePrefab")] public static class LetsSpreadVeggie { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 60.0000038f) && ((Single)codes[i + 1].operand == 20f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.HatchRep4; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
        }
    }
    namespace Pufft
    {
        namespace HitlerLives
        {
            [HarmonyPatch(typeof(PuftConfig), "CreatePuft")] public static class InBasePfAntarctic { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 75f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.PufftAge1; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(PuftAlphaConfig), "CreatePuftAlpha")] public static class InAntarcticAlpha { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 75f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.PufftAge2; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(PuftBleachstoneConfig), "CreatePuftBleachstone")] public static class InAntarcticBleach { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 75f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.PufftAge3; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(PuftOxyliteConfig), "CreatePuftOxylite")] public static class InAntarcticOxylite { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 75f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.PufftAge4; } } } return codes.AsEnumerable(); } }
        }
        namespace SpreadTheDoom
        {
            [HarmonyPatch(typeof(PuftConfig), "CreatePrefab")] public static class LetsSpreadBasePf { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 45f) && ((Single)codes[i + 1].operand == 15f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.PufftRep1; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(PuftAlphaConfig), "CreatePrefab")] public static class LetsSpreadAlpha { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 45f) && ((Single)codes[i + 1].operand == 15f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.PufftRep2; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(PuftBleachstoneConfig), "CreatePrefab")] public static class LetsSpreadBleach { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 45f) && ((Single)codes[i + 1].operand == 15f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.PufftRep3; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(PuftOxyliteConfig), "CreatePrefab")] public static class LetsSpreadOxylite { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 45f) && ((Single)codes[i + 1].operand == 15f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.PufftRep4; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
        }
    }
    namespace Pacu
    {
        namespace HitlerLives
        {
            [HarmonyPatch(typeof(BasePacuConfig), "CreatePrefab")]
            public static class InBasePAntarctic
            {
                static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                {
                    var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++)
                    {
                        if ((codes[i].opcode == OpCodes.Ldc_R4) && (codes[i + 7].opcode == OpCodes.Ldloc_0))
                        { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.PacuAge; } }
                    }
                    return codes.AsEnumerable();
                }
            }
        }

        namespace SpreadTheDoom
        {
            [HarmonyPatch(typeof(PacuConfig), "CreatePrefab")] public static class LetsSpreadPBase { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 15.000001f) && ((Single)codes[i + 1].operand == 5f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.PacuRep1; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(PacuCleanerConfig), "CreatePrefab")] public static class LetsSpreadCleaner { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 15.000001f) && ((Single)codes[i + 1].operand == 5f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.PacuRep2; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(PacuTropicalConfig), "CreatePrefab")] public static class LetsSpreadTropical { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 15.000001f) && ((Single)codes[i + 1].operand == 5f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.PacuRep3; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
        }
    }
    namespace LightBug
    {
        namespace HitlerLives
        {
            [HarmonyPatch(typeof(LightBugConfig), "CreateLightBug")] public static class InAntarctic0 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 25f) && (codes[i + 1].opcode == OpCodes.Ldarg_1)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugAge1; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(LightBugBlueConfig), "CreateLightBug")] public static class InAntarctic1 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 25f) && (codes[i + 1].opcode == OpCodes.Ldarg_1)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugAge2; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(LightBugOrangeConfig), "CreateLightBug")] public static class InAntarctic2 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 25f) && (codes[i + 1].opcode == OpCodes.Ldarg_1)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugAge3; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(LightBugPinkConfig), "CreateLightBug")] public static class InAntarctic3 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 25f) && (codes[i + 1].opcode == OpCodes.Ldarg_1)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugAge4; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(LightBugPurpleConfig), "CreateLightBug")] public static class InAntarctic4 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 25f) && (codes[i + 1].opcode == OpCodes.Ldarg_1)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugAge5; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(LightBugCrystalConfig), "CreateLightBug")] public static class InAntarctic5 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 75f) && (codes[i + 1].opcode == OpCodes.Ldarg_1)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugAge6; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(LightBugBlackConfig), "CreateLightBug")] public static class InAntarctic6 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 75f) && (codes[i + 1].opcode == OpCodes.Ldarg_1)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugAge7; } } } return codes.AsEnumerable(); } }
        }
        namespace SpreadTheDoom
        {
            [HarmonyPatch(typeof(LightBugConfig), "CreatePrefab")] public static class LetsSpread0 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 15.000001f) && ((Single)codes[i + 1].operand == 5f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugRep1; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(LightBugBlueConfig), "CreatePrefab")] public static class LetsSpread1 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 15.000001f) && ((Single)codes[i + 1].operand == 5f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugRep2; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(LightBugOrangeConfig), "CreatePrefab")] public static class LetsSpread2 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 15.000001f) && ((Single)codes[i + 1].operand == 5f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugRep3; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(LightBugPinkConfig), "CreatePrefab")] public static class LetsSpread3 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 15.000001f) && ((Single)codes[i + 1].operand == 5f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugRep4; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(LightBugPurpleConfig), "CreatePrefab")] public static class LetsSpread4 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 15.000001f) && ((Single)codes[i + 1].operand == 5f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugRep5; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(LightBugCrystalConfig), "CreatePrefab")] public static class LetsSpread5 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 45f) && ((Single)codes[i + 1].operand == 15f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugRep6; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
            [HarmonyPatch(typeof(LightBugBlackConfig), "CreatePrefab")] public static class LetsSpread6 { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 45f) && ((Single)codes[i + 1].operand == 15f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.LightBugRep7; codes[i + 1].operand = 1f; } } } return codes.AsEnumerable(); } }
        }
    }
    namespace Glom
    {
        [HarmonyPatch(typeof(GlomConfig), "CreatePrefab")]
        public class MorbGas
        {
            public static void Postfix(ref GlomConfig __instance, ref GameObject __result)
            {
                float _out = 25f; int myrate = CheetyCreety.CheetyCreetyState.StateManager.State.RatePercent;
                switch (myrate) { case 0: _out = 25f; break; case 1: _out = 50f; break; case 2: _out = 75f; break; case 3: _out = 100f; break; }
                ElementDropperMonitor.Def def = __result.AddOrGetDef<ElementDropperMonitor.Def>();
                def.dirtyEmitElement = t.testTag[CheetyCreety.CheetyCreetyState.StateManager.State.GasIndex];
                def.dirtyProbabilityPercent = _out;
                def.dirtyMassPerDirty = 0.5f;//mass to produce
                def.dirtyCellToTargetMass = 5f;//maxpressure?
            }
        }        
    }
    namespace Mole
    {
        namespace HitlerLives
        {
            [HarmonyPatch(typeof(MoleConfig), "CreateMole")] public static class ThereIsNoCowLevel { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 100f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.ShoveVoleAge; } } } return codes.AsEnumerable(); } }
        }
        namespace SpreadTheDoom
        {
            [HarmonyPatch(typeof(MoleConfig), "CreatePrefab")] public static class LetsSpreadBaseD { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 60.0000038f) && ((Single)codes[i + 2].operand == 20f)) { { codes[i].operand = CheetyCreety.CheetyCreetyState.StateManager.State.ShoveVoleRep; codes[i + 2].operand = 1f; } } } return codes.AsEnumerable(); } }
        }
    }
}

namespace NewRanching
{
    namespace NewRanchingDietUtils
    {
        public class DietUtils
        {
            public static void AddToDiet(List<Diet.Info> dietInfos, HashSet<Tag> consumedTags, Tag poopTag, float dailyCalories,
                float dailyKilograms, float conversionRate = 1.0f, string diseaseId = "", float diseasePerKg = 0.0f)
            {
                dietInfos.Add(String.IsNullOrEmpty(diseaseId)
                    ? new Diet.Info(consumedTags, poopTag, dailyCalories / dailyKilograms, conversionRate)
                    : new Diet.Info(consumedTags, poopTag, dailyCalories / dailyKilograms, conversionRate, diseaseId, diseasePerKg));
            }

            public static void AddToDiet(List<Diet.Info> dietInfos, Tag consumedTag, Tag poopTag, float dailyCalories,
                float dailyKilograms, float conversionRate = 1.0f, string diseaseId = "", float diseasePerKg = 0.0f)
            {
                AddToDiet(dietInfos, new HashSet<Tag>((IEnumerable<Tag>)new Tag[] { consumedTag }), poopTag, dailyCalories, dailyKilograms, conversionRate, diseaseId, diseasePerKg);
            }

            public static void AddToDiet(List<Diet.Info> dietInfos, EdiblesManager.FoodInfo foodInfo, Tag poopTag, float dailyCalories,
                float howManyKgOfPoopForDailyCalories = 0f, string diseaseId = "", float diseasePerKg = 0.0f)
            {
                var caloriesInKgOfFood = foodInfo.CaloriesPerUnit;
                var kgOfFoodToSatisfyCalories = dailyCalories / caloriesInKgOfFood;

                var conversionRatio = 1f / (kgOfFoodToSatisfyCalories / howManyKgOfPoopForDailyCalories);

                if (String.IsNullOrEmpty(diseaseId))
                {
                    dietInfos.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[] { new Tag(foodInfo.Id) }), poopTag, caloriesInKgOfFood, conversionRatio));
                }
                else
                {
                    dietInfos.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[] { new Tag(foodInfo.Id) }), poopTag, caloriesInKgOfFood, conversionRatio, diseaseId, diseasePerKg));
                }
            }

            public static GameObject SetupPooplessDiet(GameObject prefab, List<Diet.Info> diet_infos)
            {
                Diet diet = new Diet(diet_infos.ToArray());
                prefab.AddOrGetDef<CreatureCalorieMonitor.Def>().diet = diet;
                prefab.AddOrGetDef<SolidConsumerMonitor.Def>().diet = diet;
                return prefab;
            }

            public static GameObject SetupDiet(GameObject prefab, List<Diet.Info> diet_infos, float referenceCaloriesPerKg, float minPoopSizeInKg)
            {
                Diet diet = new Diet(diet_infos.ToArray());
                CreatureCalorieMonitor.Def def = prefab.AddOrGetDef<CreatureCalorieMonitor.Def>();
                def.diet = diet;
                def.minPoopSizeInCalories = referenceCaloriesPerKg * minPoopSizeInKg;
                prefab.AddOrGetDef<SolidConsumerMonitor.Def>().diet = diet;
                return prefab;
            }

            public static List<Diet.Info> CreateFoodDiet(Tag poopTag, float calPerDay, float poopKgPerDay)
            {
                List<Diet.Info> dietList = new List<Diet.Info>();
                foreach (EdiblesManager.FoodInfo foodType in TUNING.FOOD.FOOD_TYPES_LIST)
                {
                    if (foodType.CaloriesPerUnit > 0.0)
                        DietUtils.AddToDiet(dietList, foodType, poopTag, calPerDay, poopKgPerDay);
                }

                return dietList;
            }
        }
    }
    namespace NewRanching.Hatches
    {        
        public class Hatches
        {
            [HarmonyPatch(typeof(HatchMetalConfig), "CreateHatch")]
            public class HatchMetal_Patch
            {
                private static void Postfix(ref GameObject __result)
                {
                    var dietList = new List<Diet.Info>();
                    dietList.AddRange(BaseHatchConfig.MetalDiet(GameTags.Metal, XaBka.GlobalHatchMetal_calPerDay / XaBka.GlobalHatchMetal_kgPerDay, 1f, null, 0.0f));
                    DietUtils.AddToDiet(dietList, SimHashes.Carbon.CreateTag(), SimHashes.Diamond.CreateTag(), XaBka.GlobalHatchMetal_calPerDay, XaBka.GlobalHatchMetal_kgPerDay, 0.1f);

                    __result = DietUtils.SetupDiet(__result, dietList, XaBka.GlobalHatchMetal_calPerDay / XaBka.GlobalHatchMetal_kgPerDay, XaBka.Globalminpoopsize);
                }
            }

            [HarmonyPatch(typeof(HatchVeggieConfig), "CreateHatch")]
            public class HatchVeggie_Patch
            {
                private static void Postfix(ref GameObject __result)
                {
                    var dietList = new List<Diet.Info>();                    
                    dietList.AddRange(BaseHatchConfig.VeggieDiet(SimHashes.Dirt.CreateTag(), XaBka.GlobalHatchVeggie_calPerDay / XaBka.GlobalHatchVeggie_kgPerDay, 1f, null, 0.0f));
                    dietList.AddRange(DietUtils.CreateFoodDiet(SimHashes.Dirt.CreateTag(), XaBka.GlobalHatchVeggie_calPerDay, XaBka.GlobalHatchVeggie_kgPerDay));

                    __result = DietUtils.SetupDiet(__result, dietList,  XaBka.GlobalHatchVeggie_calPerDay / XaBka.GlobalHatchVeggie_kgPerDay, XaBka.Globalminpoopsize);
                }
            }

            [HarmonyPatch(typeof(HatchHardConfig), "CreateHatch")]
            public class HatchHard_Patch
            {
                private static void Postfix(ref GameObject __result)
                {
                    var dietList = new List<Diet.Info>();
                    dietList.AddRange(BaseHatchConfig.HardRockDiet(SimHashes.Carbon.CreateTag(),  XaBka.GlobalHatchHard_calPerDay /  XaBka.GlobalHatchHard_kgPerDay, 1f, null, 0.0f));

                    DietUtils.AddToDiet(dietList, SimHashes.Copper.CreateTag(), SimHashes.Cuprite.CreateTag(),  XaBka.GlobalHatchHard_calPerDay,  XaBka.GlobalHatchHard_kgPerDay, 1f);
                    DietUtils.AddToDiet(dietList, SimHashes.Gold.CreateTag(), SimHashes.GoldAmalgam.CreateTag(),  XaBka.GlobalHatchHard_calPerDay,  XaBka.GlobalHatchHard_kgPerDay, 1f);
                    DietUtils.AddToDiet(dietList, SimHashes.Iron.CreateTag(), SimHashes.IronOre.CreateTag(),  XaBka.GlobalHatchHard_calPerDay,  XaBka.GlobalHatchHard_kgPerDay, 1f);
                    DietUtils.AddToDiet(dietList, SimHashes.Tungsten.CreateTag(), SimHashes.Wolframite.CreateTag(),  XaBka.GlobalHatchHard_calPerDay,  XaBka.GlobalHatchHard_kgPerDay, 1f);

                    __result = DietUtils.SetupDiet(__result, dietList,  XaBka.GlobalHatchHard_calPerDay /  XaBka.GlobalHatchHard_kgPerDay,  XaBka.Globalminpoopsize);
                }
            }

            [HarmonyPatch(typeof(HatchConfig), "CreateHatch")]
            public class Hatch_Patch
            {
                private static void Postfix(ref GameObject __result)
                {
                    var dietList = new List<Diet.Info>();
                    dietList.AddRange(BaseHatchConfig.BasicRockDiet(SimHashes.Carbon.CreateTag(),  XaBka.GlobalHatch_calPerDay /  XaBka.GlobalHatch_kgPerDay, 1f, null, 0.0f));
                    dietList.AddRange(DietUtils.CreateFoodDiet(SimHashes.Carbon.CreateTag(),  XaBka.GlobalHatch_calPerDay,  XaBka.GlobalHatch_kgPerDay * 1f));
                    DietUtils.AddToDiet(dietList, SimHashes.Regolith.CreateTag(), SimHashes.Carbon.CreateTag(),  XaBka.GlobalHatch_calPerDay,  XaBka.GlobalRegolith_KgPerDay);

                    __result = DietUtils.SetupDiet(__result, dietList,  XaBka.GlobalHatch_calPerDay /  XaBka.GlobalHatch_kgPerDay,  XaBka.Globalminpoopsize);
                }
            }

            [HarmonyPatch(typeof(MoleConfig), "CreateMole")]
            public class Mole_Patch
            {
                private static void Postfix(ref GameObject __result)
                {
                    var dietList = new List<Diet.Info>();
                    dietList.AddRange(DietUtils.CreateFoodDiet(SimHashes.Dirt.CreateTag(), XaBka.GlobalMole_CalPerDay, XaBka.GlobalMole_KgPerDay * 1f));
                    DietUtils.AddToDiet(dietList, SimHashes.Regolith.CreateTag(), SimHashes.Dirt.CreateTag(), XaBka.GlobalMole_CalPerDay, XaBka.GlobalRegolith_KgPerDay);

                    __result = DietUtils.SetupDiet(__result, dietList, XaBka.GlobalMole_CalPerDay / XaBka.GlobalMole_KgPerDay,  XaBka.Globalminpoopsize);
                }
            }
        }
    }
    public class OutOfLiquidMonitor : KMonoBehaviour, ISim1000ms
    {
        [Serialize]
        [SerializeField]
        private float timeToSuffocate;

        [Serialize]
        private bool suffocated;
        private bool suffocating;

        protected const float MaxSuffocateTime = 50f;
        protected const float RegenRate = 5f;
        protected const float CellLiquidThreshold = 0.35f;

        protected override void OnPrefabInit()
        {
            base.OnPrefabInit();
            this.timeToSuffocate = 15f;
        }

        protected override void OnSpawn()
        {
            base.OnSpawn();
            this.CheckDryingOut();
        }

        private void CheckDryingOut()
        {
            if (this.suffocated || this.GetComponent<KPrefabID>().HasTag(GameTags.Trapped))
                return;

            if (!IsInWater(Grid.PosToCell(this.gameObject.transform.GetPosition())))
            {
                if (!this.suffocating)
                {
                    this.suffocating = true;
                    this.Trigger((int)GameHashes.DryingOut);
                }

                if ((double)this.timeToSuffocate > 0.0)
                    return;

                DeathMonitor.Instance smi = this.GetSMI<DeathMonitor.Instance>();
                if (smi != null)
                    smi.Kill(Db.Get().Deaths.Suffocation);

                this.Trigger((int)GameHashes.DriedOut);
                this.suffocated = true;
            }
            else
            {
                if (!this.suffocating)
                    return;

                this.suffocating = false;
                this.Trigger((int)GameHashes.EnteredWetArea, (object)null);
            }
        }

        public bool Suffocating => this.suffocating;

        private static bool IsInWater(int cell)
        {
            return Grid.IsSubstantialLiquid(cell, CellLiquidThreshold) || Grid.IsSubstantialLiquid(Grid.CellBelow(cell), 0.5f);
        }

        public void Sim1000ms(float dt)
        {
            this.CheckDryingOut();

            if (this.suffocating)
            {
                if (this.suffocated)
                    return;

                this.timeToSuffocate -= dt;

                if ((double)this.timeToSuffocate > 0.0)
                    return;

                this.CheckDryingOut();
            }
            else
            {
                this.timeToSuffocate += dt * RegenRate;
                this.timeToSuffocate = Mathf.Clamp(this.timeToSuffocate, 0.0f, MaxSuffocateTime);
            }
        }
    }
    [HarmonyPatch(typeof(Manager), "GetType", new[] { typeof(string) })]
    public static class OutOfLiquidMonitorSerializationPatch
    {
        public static void Postfix(string type_name, ref Type __result)
        {
            if (type_name == "RanchingRebalanced.Pacu.OutOfLiquidMonitor")
            {
                __result = typeof(OutOfLiquidMonitor);
            }
        }
    }
    namespace NewRanching.Pacu
    {
        public class Pacus
        {
            [HarmonyPatch(typeof(BasePacuConfig), "CreatePrefab")]
            public class BasePacuConfigCreatePrefab
            {
                private static void Prefix()
                {
                    PacuTuning.STANDARD_CALORIES_PER_CYCLE = 1000000f;
                }

                private static void Postfix(ref GameObject __result)
                {
                    __result.AddOrGet<OutOfLiquidMonitor>();
                }
            }

            [HarmonyPatch(typeof(PacuConfig), "CreatePacu")]
            public class PacuConfigCreatePacu
            {
                private static void Postfix(ref GameObject __result)
                {
                    float algaeKgPerDay = 50f;
                    float kgPerDay = 150f;
                    float calPerDay = PacuTuning.STANDARD_CALORIES_PER_CYCLE;

                    var dietList = new List<Diet.Info>();
                    DietUtils.AddToDiet(dietList, SimHashes.Algae.CreateTag(), SimHashes.ToxicSand.CreateTag(), calPerDay, algaeKgPerDay, 0.75f);
                    DietUtils.AddToDiet(dietList, SimHashes.Phosphorite.CreateTag(), SimHashes.ToxicSand.CreateTag(), calPerDay, kgPerDay, 0.5f);
                    DietUtils.AddToDiet(dietList, SimHashes.Fertilizer.CreateTag(), SimHashes.ToxicSand.CreateTag(), calPerDay, kgPerDay, 0.5f);

                    __result = DietUtils.SetupDiet(__result, dietList, calPerDay / kgPerDay, 25f);
                }
            }

            [HarmonyPatch(typeof(PacuCleanerConfig), "CreatePacu")]
            public class PacuCleanerConfigCreatePacu
            {
                private static void Postfix(ref GameObject __result)
                {
                    float algaeKgPerDay = 50f;
                    float calPerDay = PacuTuning.STANDARD_CALORIES_PER_CYCLE;

                    var dietList = new List<Diet.Info>();
                    DietUtils.AddToDiet(dietList, SimHashes.Algae.CreateTag(), SimHashes.ToxicSand.CreateTag(), calPerDay, algaeKgPerDay, 0.75f);

                    __result = DietUtils.SetupDiet(__result, dietList, calPerDay / algaeKgPerDay, 25f);
                }
            }

            [HarmonyPatch(typeof(PacuTropicalConfig), "CreatePacu")]
            public class PacuTropicalConfigCreatePacu
            {
                private static void Postfix(ref GameObject __result, bool is_baby)
                {
                    float algaeKgPerDay = 50f;
                    float kgPerDay = 150f;
                    float calPerDay = PacuTuning.STANDARD_CALORIES_PER_CYCLE;

                    var dietList = new List<Diet.Info>();
                    DietUtils.AddToDiet(dietList, SimHashes.Algae.CreateTag(), SimHashes.ToxicSand.CreateTag(), calPerDay, algaeKgPerDay, 0.75f);
                    DietUtils.AddToDiet(dietList, SimHashes.SlimeMold.CreateTag(), SimHashes.Algae.CreateTag(), calPerDay, kgPerDay, 0.33f);
                    DietUtils.AddToDiet(dietList, FOOD.FOOD_TYPES.MEAT, SimHashes.ToxicSand.CreateTag(), calPerDay, kgPerDay);
                    DietUtils.AddToDiet(dietList, FOOD.FOOD_TYPES.COOKEDMEAT, SimHashes.ToxicSand.CreateTag(), calPerDay, kgPerDay);

                    __result = DietUtils.SetupDiet(__result, dietList, calPerDay / kgPerDay, 25f);

                    if (is_baby) return;

                    __result.AddComponent<Storage>().capacityKg = 10f;
                    ElementConsumer elementConsumer = __result.AddOrGet<PassiveElementConsumer>();
                    elementConsumer.elementToConsume = SimHashes.Water;
                    elementConsumer.consumptionRate = 0.2f;
                    elementConsumer.capacityKG = 10f;
                    elementConsumer.consumptionRadius = 3;
                    elementConsumer.showInStatusPanel = true;
                    elementConsumer.sampleCellOffset = new Vector3(0.0f, 0.0f, 0.0f);
                    elementConsumer.isRequired = false;
                    elementConsumer.storeOnConsume = true;
                    elementConsumer.showDescriptor = false;
                    __result.AddOrGet<UpdateElementConsumerPosition>();
                    BubbleSpawner bubbleSpawner = __result.AddComponent<BubbleSpawner>();
                    bubbleSpawner.element = SimHashes.DirtyWater;
                    bubbleSpawner.emitMass = 2f;
                    bubbleSpawner.emitVariance = 0.5f;
                    bubbleSpawner.initialVelocity = new Vector2f(0, 1);
                    ElementConverter elementConverter = __result.AddOrGet<ElementConverter>();
                    elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
                    {
                    new ElementConverter.ConsumedElement(SimHashes.Water.CreateTag(), 0.2f)
                    };
                    elementConverter.outputElements = new ElementConverter.OutputElement[1]
                    {
                    new ElementConverter.OutputElement(0.2f, SimHashes.DirtyWater, 0.0f, true, 0.0f, 0.5f, true)
                    };
                }
            }

            [HarmonyPatch(typeof(PacuTropicalConfig), "OnSpawn")]
            public class PacuTropicalConfigOnSpawn
            {
                private static void Postfix(ref GameObject inst)
                {
                    ElementConsumer component = inst.GetComponent<ElementConsumer>();
                    if (component != null) component.EnableConsumption(true);
                }
            }
        }
    }
}

namespace IAmHungry
{
    public class t
    {
        public static List<SimHashes> testTag = new List<SimHashes> { SimHashes.Oxygen, SimHashes.ContaminatedOxygen, SimHashes.CarbonDioxide, SimHashes.Hydrogen,
                                                                      SimHashes.ChlorineGas, SimHashes.Methane, SimHashes.Steam };
    }
}
namespace LessGrooming
{
    public class Grooming
    {
        [HarmonyPatch(typeof(ModifierSet), "LoadEffects")]
        public class GroomingPatch
        {
            private static void Postfix(ref ModifierSet __instance)
            {
                __instance.effects.Get("Ranched").duration = 600f*CheetyCreety.CheetyCreetyState.StateManager.State.Grooming;
            }
        }
    }
}
namespace NoOvercrowd
{
    [HarmonyPatch(typeof(OvercrowdingMonitor),"InitializeStates")]
    public static class NoSociopaths
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            for (int i = 0; i < codes.Count; i++)
            {
                if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == -1f))
                {
                    {
                        codes[i].operand = 1f;
                    }
                }
                if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == -5f))
                {
                    {
                        codes[i].operand = 0f;
                    }
                }
            }
            return codes.AsEnumerable();
        }
    }
}
namespace HappyTame
{
    [HarmonyPatch(typeof(EntityTemplates),"ExtendEntityToWildCreature")]
    public static class ILikeGrooming
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            for (int i = 0; i < codes.Count; i++)
            {
                if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == -1f))
                {
                    {
                        codes[i].operand = 2f;
                    }
                }
            }
            return codes.AsEnumerable();
        }
    }
}
namespace QuickTaming
{
    [HarmonyPatch(typeof(ModifierSet), "LoadEffects")]
    public static class QuickTaming
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            for (int i = 0; i < codes.Count; i++)
            {
                if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == -0.09166667f))
                {
                    {
                        codes[i].operand = -5f;
                    }
                }
            }
            return codes.AsEnumerable();
        }
    }
}
namespace StomachSizeAndPoopRate
{
    namespace Slickster
    {
        //[HarmonyPatch(typeof(MinionVitalsPanel.AttributeLine), "TryUpdate")]
        //public class Reveal_Attribute
        //{
        //    public static void Prefix(ref bool __result, ref Attributes attributes)
        //    {
        //        foreach (AttributeInstance attributeInstance in attributes)
        //        {
        //            attributeInstance.hide = false;
        //        }
        //        __result = true;
        //    }
        //}

        //[HarmonyPatch(typeof(MinionVitalsPanel.AmountLine), "TryUpdate")]
        //public class Reveal_Amount
        //{
        //    public static void Prefix(ref bool __result, ref Amounts amounts)
        //    {
        //        foreach (AmountInstance amountInstance in amounts)
        //        {
        //            amountInstance.hide = false;
        //        }
        //        __result = true;
        //    }
        //}

        [HarmonyPatch(typeof(OilFloaterTuning), MethodType.Constructor)]
            public class SlicksterStomachSize
        {
            private static void Prefix()
            {
                AccessTools.Field(typeof(OilFloaterTuning), "STANDARD_CALORIES_PER_CYCLE").SetValue(OilFloaterTuning.STANDARD_CALORIES_PER_CYCLE, 800000f);
                AccessTools.Field(typeof(OilFloaterTuning), "PEN_SIZE_PER_CREATURE").SetValue(OilFloaterTuning.PEN_SIZE_PER_CREATURE, 1);
            }
        }

        //[HarmonyPatch(typeof(OilFloaterConfig), "CreateOilFloater")]
        //public static class SlicksterMass
        //{
        //    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        //    {
        //        var codes = new List<CodeInstruction>(instructions);

        //        for (int i = 0; i < codes.Count; i++)
        //        {
        //            if (codes[i].opcode == OpCodes.Ldc_I4 && (int)codes[i].operand == -1412059381)
        //            {
        //                codes[i + 2].opcode = OpCodes.Ldc_R4;
        //                codes[i + 2].operand = 100f;
        //            }
        //        }
        //        return codes.AsEnumerable();
        //    }
        //}

        [HarmonyPatch(typeof(OilFloaterConfig), "CreateOilFloater")]
        public static class SlicksterPoopMass
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                FieldInfo fieldInfoF1 = AccessTools.Field(typeof(CREATURES.CONVERSION_EFFICIENCY), nameof(CREATURES.CONVERSION_EFFICIENCY.NORMAL));

                for (int i = 0; i < codes.Count; i++)
                {
                    CodeInstruction instruction = codes[index: i];
                    if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1)
                    {
                        instruction.opcode = OpCodes.Ldc_R4;
                        instruction.operand = 1f;
                    }
                }
                return codes.AsEnumerable();
            }
        }
        [HarmonyPatch(typeof(OilFloaterHighTempConfig), "CreateOilFloater")]
        public static class MoltenSlicksterPoopMass
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                FieldInfo fieldInfoF1 = AccessTools.Field(typeof(CREATURES.CONVERSION_EFFICIENCY), nameof(CREATURES.CONVERSION_EFFICIENCY.NORMAL));

                for (int i = 0; i < codes.Count; i++)
                {
                    CodeInstruction instruction = codes[index: i];
                    if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1)
                    {
                        instruction.opcode = OpCodes.Ldc_R4;
                        instruction.operand = 1f;
                    }
                }
                return codes.AsEnumerable();
            }
        }
    }

    namespace Hatch
    {
        [HarmonyPatch(typeof(HatchTuning), MethodType.Constructor)]
        public class HatchStomachSize
        {
            private static void Prefix()
            {
                AccessTools.Field(typeof(HatchTuning), "STANDARD_CALORIES_PER_CYCLE").SetValue(HatchTuning.STANDARD_CALORIES_PER_CYCLE, 10000f);
                AccessTools.Field(typeof(HatchTuning), "PEN_SIZE_PER_CREATURE").SetValue(HatchTuning.PEN_SIZE_PER_CREATURE, 1);
            }
        }
    }
}
namespace SurviveAndBodyTemperature
{
    namespace BodyTemperature
    {
        [HarmonyPatch(typeof(BaseOilFloaterConfig), "BaseOilFloater")]
        public static class SlicksterBodyTemperature
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (int i = 0; i < codes.Count; i++)
                {
                    if (
                        ((codes[i].opcode == OpCodes.Ldc_I4) && ((int)codes[i].operand == 976099455))
                        )
                    {
                        codes[i + 2].opcode = OpCodes.Ldc_R4;
                        codes[i + 2].operand = 348.15f;
                    }
                }
                return codes.AsEnumerable();
            }
        }
        [HarmonyPatch(typeof(BasePacuConfig), "CreatePrefab")]
        public static class PacuBodyTemperature
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (int i = 0; i < codes.Count; i++)
                {
                    if (
                        ((codes[i].opcode == OpCodes.Ldc_I4) && ((int)codes[i].operand == 976099455))
                        )
                    {
                        codes[i + 2].opcode = OpCodes.Ldc_R4;
                        codes[i + 2].operand = 293.15f;
                    }
                }
                return codes.AsEnumerable();
            }
        }
        [HarmonyPatch(typeof(BaseDreckoConfig), "BaseDrecko")]
        public static class DreckoBodyTemperature
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (int i = 0; i < codes.Count; i++)
                {
                    if (
                        ((codes[i].opcode == OpCodes.Ldc_I4) && ((int)codes[i].operand == 976099455))
                        )
                    {
                        codes[i + 2].opcode = OpCodes.Ldc_R4;
                        codes[i + 2].operand = 293.15f;
                    }
                }
                return codes.AsEnumerable();
            }
        }
    }
    namespace SurviveTemperature
    {
        [HarmonyPatch(typeof(OilFloaterConfig), "CreateOilFloater")]
        public static class SlicksterTemperature
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (int i = 0; i < codes.Count; i++)
                {
                    if (
                        ((codes[i].opcode == OpCodes.Ldc_R4) && ((float)codes[i].operand == 323.15f) && ((float)codes[i + 1].operand == 413.15f))
                        )
                    {
                        codes[i].operand = 50f;
                        codes[i + 1].operand = 5000f;
                    }
                }
                return codes.AsEnumerable();
            }
        }
        [HarmonyPatch(typeof(OilFloaterDecorConfig), "CreateOilFloater")]
        public static class SlicksterDecorTemperature
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (int i = 0; i < codes.Count; i++)
                {
                    if (
                        ((codes[i].opcode == OpCodes.Ldc_R4) && ((float)codes[i].operand == 283.15f) && ((float)codes[i + 1].operand == 343.15f))
                        )
                    {
                        codes[i].operand = 50f;
                        codes[i + 1].operand = 5000f;
                    }
                }
                return codes.AsEnumerable();
            }
        }
        [HarmonyPatch(typeof(OilFloaterHighTempConfig), "CreateOilFloater")]
        public static class SlicksterHTTemperature
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (int i = 0; i < codes.Count; i++)
                {
                    if (
                        ((codes[i].opcode == OpCodes.Ldc_R4) && ((float)codes[i].operand == 363.15f) && ((float)codes[i + 1].operand == 523.15f))
                        )
                    {
                        codes[i].operand = 50f;
                        codes[i + 1].operand = 5000f;
                    }
                }
                return codes.AsEnumerable();
            }
        }
        [HarmonyPatch(typeof(GlomConfig), "CreatePrefab")]
        public static class MorbTemperature
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (int i = 0; i < codes.Count; i++)
                {
                    if ((codes[i].opcode == OpCodes.Ldc_I4_0) && (codes[i + 1].opcode == OpCodes.Ldc_I4_1) && (codes[i + 2].opcode == OpCodes.Ldc_I4_1))
                    {
                        codes[i + 1].opcode = OpCodes.Ldc_I4_0;
                        codes[i + 2].opcode = OpCodes.Ldc_I4_0;
                        codes[i + 3].operand = 50f;
                        codes[i + 4].operand = 500f;
                        codes[i + 5].operand = 10f;
                        codes[i + 6].operand = 600f;
                    }
                }
                return codes.AsEnumerable();
            }
        }
        [HarmonyPatch(typeof(DreckoConfig), "CreateDrecko")] public static class DreckoTemperature { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if (((codes[i].opcode == OpCodes.Ldc_R4) && ((float)codes[i].operand == 308.15f) && ((float)codes[i + 1].operand == 363.15f))) { codes[i].operand = 50f; codes[i + 1].operand = 5000f; } } return codes.AsEnumerable(); } }
        [HarmonyPatch(typeof(DreckoPlasticConfig), "CreateDrecko")] public static class DreckoPlasticTemperature { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if (((codes[i].opcode == OpCodes.Ldc_R4) && ((float)codes[i].operand == 298.15f) && ((float)codes[i + 1].operand == 333.15f))) { codes[i].operand = 50f; codes[i + 1].operand = 5000f; } } return codes.AsEnumerable(); } }
        [HarmonyPatch(typeof(BaseLightBugConfig), "BaseLightBug")]
        public static class BaseLightBugTemperature
        {

            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                FieldInfo fieldInfoF1 = AccessTools.Field(typeof(CREATURES.TEMPERATURE), nameof(CREATURES.TEMPERATURE.FREEZING_1));
                FieldInfo fieldInfoF2 = AccessTools.Field(typeof(CREATURES.TEMPERATURE), nameof(CREATURES.TEMPERATURE.FREEZING_2));
                FieldInfo fieldInfoH1 = AccessTools.Field(typeof(CREATURES.TEMPERATURE), nameof(CREATURES.TEMPERATURE.HOT_1));
                FieldInfo fieldInfoH2 = AccessTools.Field(typeof(CREATURES.TEMPERATURE), nameof(CREATURES.TEMPERATURE.HOT_2));

                for (int i = 0; i < codes.Count; i++)
                {
                    CodeInstruction instruction = codes[index: i];
                    if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1)
                    {
                        instruction.opcode = OpCodes.Ldc_R4;
                        instruction.operand = 50f;
                    }
                    if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF2)
                    {
                        instruction.opcode = OpCodes.Ldc_R4;
                        instruction.operand = 50f;
                    }
                    if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoH1)
                    {
                        instruction.opcode = OpCodes.Ldc_R4;
                        instruction.operand = 5000f;
                    }
                    if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoH2)
                    {
                        instruction.opcode = OpCodes.Ldc_R4;
                        instruction.operand = 5000f;
                    }
                }
                return codes.AsEnumerable();
            }
        }
        [HarmonyPatch(typeof(BaseMoleConfig), "BaseMole")] public static class MoleTemperature { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if (((codes[i].opcode == OpCodes.Ldc_R4) && ((float)codes[i].operand == 123.149994f) && ((float)codes[i + 1].operand == 673.15f))) { codes[i].operand = 50f; codes[i + 1].operand = 5000f; codes[i + 2].operand = 50f; codes[i + 3].operand = 5000f; } } return codes.AsEnumerable(); } }
        [HarmonyPatch(typeof(BaseMooConfig), "BaseMoo")] public static class MooTemperature { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if (((codes[i].opcode == OpCodes.Ldc_R4) && ((float)codes[i].operand == 123.149994f) && ((float)codes[i + 1].operand == 423.15f))) { codes[i].operand = 50f; codes[i + 1].operand = 5000f; codes[i + 2].operand = 50f; codes[i + 3].operand = 5000f; } } return codes.AsEnumerable(); } }
        [HarmonyPatch(typeof(BasePuftConfig), "BasePuft")] public static class PuftTemperature { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if (((codes[i].opcode == OpCodes.Ldc_R4) && ((float)codes[i].operand == 302f) && ((float)codes[i + 1].operand == 318f))) { codes[i].operand = 50f; codes[i + 1].operand = 5000f; codes[i + 2].operand = 50f; codes[i + 3].operand = 5000f; } } return codes.AsEnumerable(); } }
        [HarmonyPatch(typeof(BaseHatchConfig), "BaseHatch")] public static class HatchTemperature { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if (((codes[i].opcode == OpCodes.Ldc_R4) && ((float)codes[i].operand == 283.15f) && ((float)codes[i + 1].operand == 293.15f))) { codes[i].operand = 50f; codes[i + 1].operand = 5000f; codes[i + 2].operand = 50f; codes[i + 3].operand = 5000f; } } return codes.AsEnumerable(); } }
        [HarmonyPatch(typeof(PacuCleanerConfig), "CreatePacu")] public static class PacuCleanerTemperature { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if (((codes[i].opcode == OpCodes.Ldc_R4) && ((float)codes[i].operand == 243.15f) && ((float)codes[i + 1].operand == 278.15f))) { codes[i].operand = 50f; codes[i + 1].operand = 5000f; } } return codes.AsEnumerable(); } }
        [HarmonyPatch(typeof(PacuConfig), "CreatePacu")] public static class PacuTemperature { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if (((codes[i].opcode == OpCodes.Ldc_R4) && ((float)codes[i].operand == 273.15f) && ((float)codes[i + 1].operand == 333.15f))) { codes[i].operand = 50f; codes[i + 1].operand = 5000f; } } return codes.AsEnumerable(); } }
        [HarmonyPatch(typeof(PacuTropicalConfig), "CreatePacu")] public static class PacuTropicalConfigemperature { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++) { if (((codes[i].opcode == OpCodes.Ldc_R4) && ((float)codes[i].operand == 303.15f) && ((float)codes[i + 1].operand == 353.15f))) { codes[i].operand = 50f; codes[i + 1].operand = 5000f; } } return codes.AsEnumerable(); } }

    }
}

namespace AAATest
{    // TODOconf
    //[HarmonyPatch(typeof(OilFloaterConfig), "CreateOilFloater")]
    //public static class SlicksterEnhale
    //{
    //    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    //    {
    //            var codes = new List<CodeInstruction>(instructions);
    //            for (int i = 0; i < codes.Count; i++)
    //            {
    //            if ((codes[i].opcode == OpCodes.Ldc_I4) && ((int)codes[i].operand == 1960575215))
    //            { codes[i].operand = -1528777920; }
    //            }
    //            return codes.AsEnumerable();
    //    }
    //}
}
