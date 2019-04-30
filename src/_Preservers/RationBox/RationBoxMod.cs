using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace MyRationBox1
{
    public class MyRationBoxMod
    {

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class MyRationBoxPatch
        {
            public static LocString NAME = new LocString("Preserving Ration Box",
                                                        "STRINGS.BUILDINGS.PREFABS." + MyRationBoxConfig.ID.ToUpper() + ".NAME");
            public static LocString DESC = new LocString("This Ration Box will help you preserve your " + STRINGS.UI.FormatAsLink("food", "FOOD") + ".",
                                                        "STRINGS.BUILDINGS.PREFABS." + MyRationBoxConfig.ID.ToUpper() + ".DESC");
            public static LocString EFFECT = new LocString("Preserving Ration Box is provided to you by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + ".",
                                                        "STRINGS.BUILDINGS.PREFABS." + MyRationBoxConfig.ID.ToUpper() + ".EFFECT");
            private static void Prefix()
            {                Strings.Add(NAME.key.String, NAME.text);
                Strings.Add(DESC.key.String, DESC.text);
                Strings.Add(EFFECT.key.String, EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Food", MyRationBoxConfig.ID);              
            }

         private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(MyRationBoxConfig));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public class MyRationBoxDbPatch
        {
            private static void Prefix()
            {
                List<string> ls = new List<string>(Techs.TECH_GROUPING["MedicineI"]){ MyRationBoxConfig.ID};
                Techs.TECH_GROUPING["MedicineI"] = ls.ToArray();                
            }
        }

    }
}
