using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace UniversalHeater
{
    public class UniversalHeaterConfigMod
    {

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class UniversalHeaterPatch
        {
            public static LocString NAME = new LocString("Universal Heater",
                                                        "STRINGS.BUILDINGS.PREFABS." + UniversalHeaterConfig.ID.ToUpper() + ".NAME");
            public static LocString DESC = new LocString("This building will help you " + STRINGS.UI.FormatAsLink("heat", "TEMPERATURE") + " all the items up.",
                                                        "STRINGS.BUILDINGS.PREFABS." + UniversalHeaterConfig.ID.ToUpper() + ".DESC");
            public static LocString EFFECT = new LocString("Universal Heater is provided to you by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + ".",
                                                        "STRINGS.BUILDINGS.PREFABS." + UniversalHeaterConfig.ID.ToUpper() + ".EFFECT");

            private static void Prefix()
            {
                Strings.Add(NAME.key.String, NAME.text);
                Strings.Add(DESC.key.String, DESC.text);
                Strings.Add(EFFECT.key.String, EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Utilities",UniversalHeaterConfig.ID);
            }

         private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(UniversalHeaterConfig));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public class UniversalHeaterDbPatch
        {
            private static void Prefix()
            {
                List<string> ls = new List<string>(Techs.TECH_GROUPING["HighTempForging"]){UniversalHeaterConfig.ID};
                Techs.TECH_GROUPING["HighTempForging"] = ls.ToArray();                
            }
        }

    }
}
