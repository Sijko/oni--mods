﻿using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace NaturalGasScrubber
{
    public class NaturalGasScrubberConfig : IBuildingConfig
	{
        public const string ID = "NaturalGasScrubber";

		public override BuildingDef CreateBuildingDef()
		{
            string id = "NaturalGasScrubber";
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
            buildingDef.ExhaustKilowattsWhenActive = 1f;
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

            List<Storage.StoredItemModifier> mod = new List<Storage.StoredItemModifier>
                { Storage.StoredItemModifier.Hide, Storage.StoredItemModifier.Insulate,Storage.StoredItemModifier.Preserve, Storage.StoredItemModifier.Seal};

            Storage storage = BuildingTemplates.CreateDefaultStorage(go);
            storage.SetDefaultStoredItemModifiers(mod);
            storage.showInUI = true;
            storage.capacityKg = 20000f;
            storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);

            ElementConsumer elementConsumer = go.AddOrGet<ElementConsumer>();
            elementConsumer.elementToConsume = SimHashes.Methane;
            elementConsumer.consumptionRate = 1000f;
            elementConsumer.consumptionRadius = 10;
            elementConsumer.showInStatusPanel = true;
            elementConsumer.sampleCellOffset = new Vector3(0f, 0f, 0f);
            elementConsumer.isRequired = false;
            elementConsumer.storeOnConsume = true;
            elementConsumer.showDescriptor = false;

            ElementDropper elementDropper = go.AddComponent<ElementDropper>();
            elementDropper.emitMass = 100f;
            elementDropper.emitTag = new Tag("SolidMethane");
            elementDropper.emitOffset = new Vector3(0f, 0f, 0f);

            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
                new ElementConverter.ConsumedElement(new Tag("Ice"), 1f),
                new ElementConverter.ConsumedElement(new Tag("Methane"), 1.0f)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
            new ElementConverter.OutputElement(1.0f, SimHashes.SolidMethane, 50.15f, storeOutput:true, 0f, 0f, apply_input_temperature:false, diseaseWeight:0f, addedDiseaseIdx:byte.MinValue)
            };

            ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
            manualDeliveryKG.SetStorage(storage);
            manualDeliveryKG.requestedItemTag = new Tag("Ice");
            manualDeliveryKG.capacity = 1000f;
            manualDeliveryKG.refillMass = 10f;
            manualDeliveryKG.choreTypeIDHash = Db.Get().ChoreTypes.FetchCritical.IdHash;

            NaturalGasScrubber NaturalGasScrubber = go.AddOrGet<NaturalGasScrubber>();
            NaturalGasScrubber.filterTag = new Tag("Ice");

            go.AddOrGet<KBatchedAnimController>().randomiseLoopedOffset = true;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<ActiveController.Def>();           
        }
    }
}

