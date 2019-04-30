using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace CoalScrubber
{
    public class CoalScrubberConfigMod
    {

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class CoalScrubberConfigPatch
        {
            public static LocString NAME = new LocString("Piped Coal Scrubber",
                                                         "STRINGS.BUILDINGS.PREFABS." + CoalScrubberPipedConfig.ID.ToUpper() + ".NAME");
            public static LocString DESC = new LocString("This building will help you get rid of excess " + STRINGS.UI.FormatAsLink("CO2", "CARBONDIOXIDE") + ". Now with pipes!",
                                                        "STRINGS.BUILDINGS.PREFABS." + CoalScrubberPipedConfig.ID.ToUpper() + ".DESC");
            public static LocString EFFECT = new LocString("Piped Coal Scrubber is provided to you by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + ".",
                                                        "STRINGS.BUILDINGS.PREFABS." + CoalScrubberPipedConfig.ID.ToUpper() + ".EFFECT");

            private static void Prefix()
            {
                Strings.Add(NAME.key.String, NAME.text);
                Strings.Add(DESC.key.String, DESC.text);
                Strings.Add(EFFECT.key.String, EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Oxygen", CoalScrubberPipedConfig.ID);
            }

            private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(CoalScrubberPipedConfig));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public class CoalScrubberPipedDbPatch
        {
            private static void Prefix()
            {
                List<string> ls = new List<string>(Techs.TECH_GROUPING["AdvancedResearch"]){CoalScrubberPipedConfig.ID};
                Techs.TECH_GROUPING["AdvancedResearch"] = ls.ToArray();
            }
        }

    }
}
