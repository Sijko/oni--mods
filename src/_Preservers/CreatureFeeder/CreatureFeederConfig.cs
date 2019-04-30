using System.Collections.Generic;
using TUNING;
using UnityEngine;

public class MyCreatureFeeder : CreatureFeeder
{ }
public class MyCreatureFeederConfig : IBuildingConfig
{
    public const string ID = "MYCREATUREFEEDER";

    public override BuildingDef CreateBuildingDef()
    {
        string id = "MYCREATUREFEEDER";
        int width = 1;
        int height = 2;
        string anim = "feeder_kanim";
        int hitpoints = 100;
        float construction_time = 120f;
        float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
        string[] raw_METALS = MATERIALS.ANY_BUILDABLE;
        float melting_point = 1600f;
        BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
        EffectorValues none = NOISE_POLLUTION.NONE;
        BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_METALS,
        melting_point, build_location_rule, BUILDINGS.DECOR.PENALTY.TIER2, none, 0.2f);
        buildingDef.AudioCategory = "Metal";
        buildingDef.PermittedRotations = PermittedRotations.R360;
        return buildingDef;
    }

    public override void DoPostConfigureUnderConstruction(GameObject go)
    {
    }

    public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
    {
        List<Storage.StoredItemModifier> mod = new List<Storage.StoredItemModifier>
                { Storage.StoredItemModifier.Hide, Storage.StoredItemModifier.Insulate,Storage.StoredItemModifier.Preserve, Storage.StoredItemModifier.Seal};

        Prioritizable.AddRef(go);
        go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.CreatureFeeder);
        Storage storage = go.AddOrGet<Storage>();
        storage.SetDefaultStoredItemModifiers(mod);
        storage.capacityKg = 1000000f;
        storage.showInUI = true;
        storage.showDescriptor = true;
        storage.allowItemRemoval = false;
        storage.allowSettingOnlyFetchMarkedItems = false;
        go.AddOrGet<StorageLocker>();
        go.AddOrGet<TreeFilterable>();
        go.AddOrGet<MyCreatureFeeder>();
    }

    public override void DoPostConfigureComplete(GameObject go)
    {
        go.AddOrGetDef<StorageController.Def>();
    }

    public override void ConfigurePost(BuildingDef def)
    {
        List<Tag> list = new List<Tag>();
        Tag[] target_species = new Tag[]
        {
            GameTags.Creatures.Species.LightBugSpecies,
            GameTags.Creatures.Species.HatchSpecies,
            GameTags.Creatures.Species.MoleSpecies,
            GameTags.Creatures.Species.PacuSpecies
        };
        foreach (KeyValuePair<Tag, Diet> keyValuePair in DietManager.CollectDiets(target_species))
        {
            list.Add(keyValuePair.Key);
        }
        def.BuildingComplete.GetComponent<Storage>().storageFilters = list;
    }
}