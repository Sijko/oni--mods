using TUNING;
using UnityEngine;

namespace CoalScrubber
{
    public class CoalScrubberConfig : IBuildingConfig
	{
        public const string ID = "COALSCRUBBER";

		public override BuildingDef CreateBuildingDef()
		{
            string id = "COALSCRUBBER";
            int wd = 1;
            int hg = 1;
            string ani = "co2filter_kanim";
            int hp = 100;
            float const_time = 30f;
            float[] MyTier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] MyMaterial = MATERIALS.ANY_BUILDABLE;
            float melt_pt = 1600f;
            BuildLocationRule build_loc_rule = BuildLocationRule.OnFloor;
            EffectorValues NoiseTier = NOISE_POLLUTION.NOISY.TIER0;
            EffectorValues MyDecor = BUILDINGS.DECOR.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, wd, hg, ani, hp, const_time, MyTier, MyMaterial, melt_pt, build_loc_rule, MyDecor, NoiseTier);
            buildingDef.Overheatable = false;
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 666f;
            buildingDef.ExhaustKilowattsWhenActive = 0.5f;
            buildingDef.SelfHeatKilowattsWhenActive = 0f;
            buildingDef.PermittedRotations = PermittedRotations.R360;
            buildingDef.UtilityInputOffset = new CellOffset(0, 1);
            buildingDef.UtilityOutputOffset = new CellOffset(0, 0);
            buildingDef.Floodable = false;
            buildingDef.Entombable = true;
            buildingDef.ViewMode = OverlayModes.Oxygen.ID;
            buildingDef.AudioCategory = "Metal";
            return buildingDef;            
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            go.AddOrGet<DropAllWorkable>();
            Prioritizable.AddRef(go);

            Storage storage = BuildingTemplates.CreateDefaultStorage(go);
            storage.showInUI = true;
            storage.capacityKg = 20000f;
            storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);

            ElementConsumer elementConsumer = go.AddOrGet<ElementConsumer>();
            elementConsumer.elementToConsume = SimHashes.CarbonDioxide;
            elementConsumer.consumptionRate = 1000f;
            elementConsumer.consumptionRadius = 10;
            elementConsumer.showInStatusPanel = true;
            elementConsumer.sampleCellOffset = new Vector3(0f, 0f, 0f);
            elementConsumer.isRequired = false;
            elementConsumer.storeOnConsume = true;
            elementConsumer.showDescriptor = false;

            ElementDropper elementDropper = go.AddComponent<ElementDropper>();
            elementDropper.emitMass = 100f;
            elementDropper.emitTag = new Tag("Carbon");
            elementDropper.emitOffset = new Vector3(0f, 0f, 0f);

            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
                new ElementConverter.ConsumedElement(new Tag("Filter"), 0.1f),
                new ElementConverter.ConsumedElement(new Tag("CarbonDioxide"), 1.0f)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
            new ElementConverter.OutputElement(0.27f, SimHashes.Carbon, 0f, true, 0f, 0.5f, false, 0f, byte.MinValue),
            new ElementConverter.OutputElement(0.73f, SimHashes.Oxygen, 0f, false, 0f, 0f, false, 0f, byte.MinValue)
            };

            ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
            manualDeliveryKG.SetStorage(storage);
            manualDeliveryKG.requestedItemTag = new Tag("Filter");
            manualDeliveryKG.capacity = 100f;
            manualDeliveryKG.refillMass = 1f;
            manualDeliveryKG.choreTypeIDHash = Db.Get().ChoreTypes.FetchCritical.IdHash;

            CoalScrubber coalScrubber = go.AddOrGet<CoalScrubber>();
            coalScrubber.filterTag = new Tag("Filter");

            go.AddOrGet<KBatchedAnimController>().randomiseLoopedOffset = true;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<ActiveController.Def>();           
        }
    }
}

