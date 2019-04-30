using System;
using System.Collections.Generic;
using Database;
using Harmony;

public class MyCreatureFeederMod
{

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class MyCreatureFeederConfigPatch
    {
        public static LocString NAME = new LocString("Preserving Creature Feeder",
                                                     "STRINGS.BUILDINGS.PREFABS." + MyCreatureFeederConfig.ID.ToUpper() + ".NAME");
        public static LocString DESC = new LocString("This Creature Feeder will help you preserve the " + STRINGS.UI.FormatAsLink("food", "FOOD") + " you made for your critters.",
                                                    "STRINGS.BUILDINGS.PREFABS." + MyCreatureFeederConfig.ID.ToUpper() + ".DESC");
        public static LocString EFFECT = new LocString("Preserving Creature Feeder is provided to you by " +STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + ".",
                                                    "STRINGS.BUILDINGS.PREFABS." + MyCreatureFeederConfig.ID.ToUpper() + ".EFFECT");

            private static void Prefix()
            {                
            Strings.Add(NAME.key.String, NAME.text);
            Strings.Add(DESC.key.String, DESC.text);
            Strings.Add(EFFECT.key.String, EFFECT.text);
            ModUtil.AddBuildingToPlanScreen("Food", MyCreatureFeederConfig.ID);
        }

         private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(MyCreatureFeederConfig));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public class MyCreatureFeederDbPatch
    {
            private static void Prefix()
            {
            List<string> ls = new List<string>(Techs.TECH_GROUPING["MedicineI"]){MyCreatureFeederConfig.ID};
            Techs.TECH_GROUPING["MedicineI"] = ls.ToArray();                
            }
        }

    }
