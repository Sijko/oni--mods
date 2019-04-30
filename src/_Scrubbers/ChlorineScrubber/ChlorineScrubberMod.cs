using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace ChlorineScrubber
{
    public class ChlorineScrubberConfigMod
    {

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class ChlorineScrubberConfigPatch
        {
            public static LocString NAME = new LocString("Chlorine Scrubber",
                                                         "STRINGS.BUILDINGS.PREFABS." + ChlorineScrubberConfig.ID.ToUpper() + ".NAME");
            public static LocString DESC = new LocString("This building will help you get rid of excess " + STRINGS.UI.FormatAsLink("CL", "CHLORINEGAS") + ".",
                                                        "STRINGS.BUILDINGS.PREFABS." + ChlorineScrubberConfig.ID.ToUpper() + ".DESC");
            public static LocString EFFECT = new LocString("Chlorine Scrubber is provided to you by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + ".",
                                                        "STRINGS.BUILDINGS.PREFABS." + ChlorineScrubberConfig.ID.ToUpper() + ".EFFECT");

            private static void Prefix()
            {                
                Strings.Add(NAME.key.String, NAME.text);
                Strings.Add(DESC.key.String, DESC.text);
                Strings.Add(EFFECT.key.String, EFFECT.text);

                ModUtil.AddBuildingToPlanScreen("Oxygen", ChlorineScrubberConfig.ID);
            }

         private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(ChlorineScrubberConfig));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public class ChlorineScrubberDbPatch
        {
            private static void Prefix()
            {
                List<string> ls = new List<string>(Techs.TECH_GROUPING["AdvancedResearch"]) { ChlorineScrubberConfig.ID };
                Techs.TECH_GROUPING["AdvancedResearch"] = ls.ToArray();
            }
        }

    }
}
