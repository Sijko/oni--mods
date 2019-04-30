using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace CritterHolder
{
    public class CritterHolderConfigMod
    {

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class CritterHolderPatch
        {
            public static LocString NAME = new LocString("CritterHolder",
                                                        "STRINGS.BUILDINGS.PREFABS." + CritterHolderConfig.ID.ToUpper() + ".NAME");
            public static LocString DESC = new LocString("This building is a CritterHolder.",
                                                        "STRINGS.BUILDINGS.PREFABS." + CritterHolderConfig.ID.ToUpper() + ".DESC");
            public static LocString EFFECT = new LocString("CritterHolder is provided to you by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + ".",
                                                        "STRINGS.BUILDINGS.PREFABS." + CritterHolderConfig.ID.ToUpper() + ".EFFECT");

            private static void Prefix()
            {
                Strings.Add(NAME.key.String, NAME.text);
                Strings.Add(DESC.key.String, DESC.text);
                Strings.Add(EFFECT.key.String, EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Food", CritterHolderConfig.ID);
            }

         private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(CritterHolderConfig));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public class CritterHolderDbPatch
        {
            private static void Prefix()
            {
                List<string> ls = new List<string>(Techs.TECH_GROUPING["MedicineI"]){CritterHolderConfig.ID};
                Techs.TECH_GROUPING["MedicineI"] = ls.ToArray();                
            }
        }

    }
}
