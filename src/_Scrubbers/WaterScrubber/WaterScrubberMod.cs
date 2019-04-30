using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace WaterScrubber
{
    public class WaterScrubberConfigMod
    {

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class WaterScrubberConfigPatch
        {
            public static LocString NAME = new LocString("Water Scrubber",
                                                         "STRINGS.BUILDINGS.PREFABS." + WaterScrubberConfig.ID.ToUpper() + ".NAME");
            public static LocString DESC =new LocString("This building will help you scrub " + STRINGS.UI.FormatAsLink("water", "WATER") + ".\nTo make water from H2 and O2 all you need is a spark." +
            "\nSo here you have it.\n---------------------\nBuild in a closed room, 'cause it consumes all gases, and stores them. You can empty the building to get the gases.\n---------------------\n", 
                                                        "STRINGS.BUILDINGS.PREFABS." + WaterScrubberConfig.ID.ToUpper() + ".DESC");
            public static LocString EFFECT = new LocString("Water Scrubber is provided to you by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + ".",
                                                        "STRINGS.BUILDINGS.PREFABS." + WaterScrubberConfig.ID.ToUpper() + ".EFFECT");
            private static void Prefix()
            {
                Strings.Add(NAME.key.String, NAME.text);
                Strings.Add(DESC.key.String, DESC.text);
                Strings.Add(EFFECT.key.String, EFFECT.text);

                ModUtil.AddBuildingToPlanScreen("Utilities", WaterScrubberConfig.ID);
            }

         private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(WaterScrubberConfig));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public class WaterScrubberDbPatch
        {
            private static void Prefix()
            {
                List<string> ls = new List<string>(Techs.TECH_GROUPING["AdvancedResearch"]) { WaterScrubberConfig.ID };
                Techs.TECH_GROUPING["AdvancedResearch"] = ls.ToArray();
            }
        }

    }
}
