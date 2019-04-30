using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace OxyStorage
{
    public class OxyStorageMod
    {

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class OxyStoragePatch
        {
            public static LocString DESC = "This OxyStorage will help you store the "+ STRINGS.UI.FormatAsLink("oxylite", "OXYROCK") +" you produce, nice and sealed.";
            private static void Prefix()
            {                
                Strings.Add("STRINGS.BUILDINGS.PREFABS.MYOXYSTORAGE.NAME", "Sealed OxyStorage");
                Strings.Add("STRINGS.BUILDINGS.PREFABS.MYOXYSTORAGE.DESC", DESC);
                Strings.Add("STRINGS.BUILDINGS.PREFABS.MYOXYSTORAGE.EFFECT", "Sealed OxyStorage is provided to you by " + 
                    STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + ".");

                ModUtil.AddBuildingToPlanScreen("Oxygen", OxyStorageConfig.ID);              
            }

         private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(OxyStorageConfig));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public class OxyStorageDbPatch
        {
            private static void Prefix()
            {
                List<string> ls = new List<string>(Techs.TECH_GROUPING["ImprovedGasPiping"]){OxyStorageConfig.ID};
                Techs.TECH_GROUPING["ImprovedGasPiping"] = ls.ToArray();                
            }
        }

    }
}
