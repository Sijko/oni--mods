using Harmony;
using UnityEngine;

namespace KorribanDynamics
{
    namespace BunkerDoors
    {
        [HarmonyPatch(typeof(BunkerDoorConfig), "CreateBuildingDef")]
        public static class BunkerDoorPatch
        {
            static void Postfix(BunkerDoorConfig __instance, ref BuildingDef __result)
            {
                __result.PermittedRotations = PermittedRotations.R360;
            }
        }
        [HarmonyPatch(typeof(BunkerDoorConfig), "DoPostConfigureComplete")]
        public static class BunkerDoorPatch2
        {
            static void Postfix(BunkerDoorConfig __instance, ref GameObject go)
            {
                Door door = go.AddOrGet<Door>();
                door.unpoweredAnimSpeed = 10f;
                door.poweredAnimSpeed = 10f;
            }
        }
    }
}
