using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace UltraLight
{
    public class UltraLightConfigMod
    {

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class UltraLightPatch
        {
            public static LocString NAME = new LocString("Ultra Light",
                                                        "STRINGS.BUILDINGS.PREFABS." + UltraLightConfig.ID.ToUpper() + ".NAME");
            public static LocString DESC = new LocString("This building is a Ultra Light. Zis is a graet soorce of ligt!!1111",
                                                        "STRINGS.BUILDINGS.PREFABS." + UltraLightConfig.ID.ToUpper() + ".DESC");
            public static LocString EFFECT = new LocString("Ultra Light is provided to you by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + ".",
                                                        "STRINGS.BUILDINGS.PREFABS." + UltraLightConfig.ID.ToUpper() + ".EFFECT");

            private static void Prefix()
            {
                Strings.Add(NAME.key.String, NAME.text);
                Strings.Add(DESC.key.String, DESC.text);
                Strings.Add(EFFECT.key.String, EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Rocketry", UltraLightConfig.ID);
            }

         private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(UltraLightConfig));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public class UltraLightDbPatch
        {
            private static void Prefix()
            {
                List<string> ls = new List<string>(Techs.TECH_GROUPING["BasicRocketry"]){UltraLightConfig.ID};
                Techs.TECH_GROUPING["BasicRocketry"] = ls.ToArray();                
            }
        }

    }
}
