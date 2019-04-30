using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace UniversalCooler
{
    public class UniversalCoolerConfigMod
    {

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class UniversalCoolerPatch
        {
            public static LocString NAME = new LocString("Universal Cooler",
                                            "STRINGS.BUILDINGS.PREFABS." + UniversalCoolerConfig.ID.ToUpper() + ".NAME");
            public static LocString DESC = new LocString("This building will help you " + STRINGS.UI.FormatAsLink("cool", "TEMPERATURE") + " all the items down.",
                                                        "STRINGS.BUILDINGS.PREFABS." + UniversalCoolerConfig.ID.ToUpper() + ".DESC");
            public static LocString EFFECT = new LocString("Universal Cooler is provided to you by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + ".",
                                                        "STRINGS.BUILDINGS.PREFABS." + UniversalCoolerConfig.ID.ToUpper() + ".EFFECT");

            private static void Prefix()
            {
                Strings.Add(NAME.key.String, NAME.text);
                Strings.Add(DESC.key.String, DESC.text);
                Strings.Add(EFFECT.key.String, EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Utilities", UniversalCoolerConfig.ID);
            }

         private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(UniversalCoolerConfig));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public class UniversalCoolerDbPatch
        {
            private static void Prefix()
            {
                List<string> ls = new List<string>(Techs.TECH_GROUPING["HighTempForging"]){UniversalCoolerConfig.ID};
                Techs.TECH_GROUPING["HighTempForging"] = ls.ToArray();                
            }
        }

    }
}
