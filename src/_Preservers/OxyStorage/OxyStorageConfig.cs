using TUNING;
using UnityEngine;
using System.Collections.Generic;

namespace OxyStorage
{
    public class OxyStorage : RationBox
    { }
    public class OxyStorageConfig : IBuildingConfig
    {
        public const string ID = "MYOXYSTORAGE";

        public override BuildingDef CreateBuildingDef()
        {
            string id = "MYOXYSTORAGE";
            int width = 2;
            int height = 2;
            string anim = "rationbox_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
            string[] raw_MINERALS = MATERIALS.ANY_BUILDABLE;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_MINERALS, melting_point, build_location_rule, BUILDINGS.DECOR.BONUS.TIER0, none, 0.2f);
            buildingDef.Overheatable = false;
            buildingDef.Floodable = false;
            buildingDef.AudioCategory = "Metal";
            buildingDef.PermittedRotations = PermittedRotations.R360;
            SoundEventVolumeCache.instance.AddVolume("rationbox_kanim", "RationBox_open", NOISE_POLLUTION.NOISY.TIER1);
            SoundEventVolumeCache.instance.AddVolume("rationbox_kanim", "RationBox_close", NOISE_POLLUTION.NOISY.TIER1);
            return buildingDef;
        }
        
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            List<Storage.StoredItemModifier> mod = new List<Storage.StoredItemModifier>
                { Storage.StoredItemModifier.Hide, Storage.StoredItemModifier.Insulate,Storage.StoredItemModifier.Preserve, Storage.StoredItemModifier.Seal};
            List<Tag> OXY = new List<Tag> { GameTags.ConsumableOre};
            Prioritizable.AddRef(go);
            Storage storage = go.AddOrGet<Storage>();
            storage.SetDefaultStoredItemModifiers(mod);
            storage.capacityKg = 1000000f;
            storage.showInUI = true;
            storage.showDescriptor = true;
            storage.storageFilters = OXY;
            storage.allowItemRemoval = true;
            storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
            storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
            go.AddOrGet<TreeFilterable>();
            go.AddOrGet<OxyStorage>();
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<StorageController.Def>();
        }
    }
}

