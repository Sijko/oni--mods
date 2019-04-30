using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace NaturalGasScrubber
{
    public class NaturalGasScrubberConfigMod
    {

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class NaturalGasScrubberConfigPatch
        {
            public static LocString NAME = new LocString("Natural Gas Scrubber",
                                                         "STRINGS.BUILDINGS.PREFABS." + NaturalGasScrubberConfig.ID.ToUpper() + ".NAME");
            public static LocString DESC = new LocString("This building will help you get rid of excess " + STRINGS.UI.FormatAsLink("CH4", "METHANE") + ".",
                                                        "STRINGS.BUILDINGS.PREFABS." + NaturalGasScrubberConfig.ID.ToUpper() + ".DESC");
            public static LocString EFFECT = new LocString("Natural Gas Scrubber is provided to you by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + ".",
                                                        "STRINGS.BUILDINGS.PREFABS." + NaturalGasScrubberConfig.ID.ToUpper() + ".EFFECT");

            private static void Prefix()
            {                
                Strings.Add(NAME.key.String, NAME.text);
                Strings.Add(DESC.key.String, DESC.text);
                Strings.Add(EFFECT.key.String, EFFECT.text);

                ModUtil.AddBuildingToPlanScreen("Oxygen", NaturalGasScrubberConfig.ID);
            }

         private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(NaturalGasScrubberConfig));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public class NaturalGasScrubberDbPatch
        {
            private static void Prefix()
            {
                List<string> ls = new List<string>(Techs.TECH_GROUPING["AdvancedResearch"]) { NaturalGasScrubberConfig.ID };
                Techs.TECH_GROUPING["AdvancedResearch"] = ls.ToArray();
            }
        }

    }
}
