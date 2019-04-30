using TUNING;
using UnityEngine;

namespace WaterScrubber
{
    public class WaterScrubber : KMonoBehaviour
    {
        public Storage storage;
        public ElementConverter elementConverter;
        public ElementConsumer elementConsumer;
    }
         
    public class WaterScrubberConfig : CeilingLightConfig
    {
      public new const string ID = "WaterScrubber";

            public override BuildingDef CreateBuildingDef()
            {
                string id = "WaterScrubber";
                int width = 1;
                int height = 1;
                string anim = "ceilinglight_kanim";
                int hitpoints = 10;
                float construction_time = 10f;
                float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER1;
                string[] all_METALS = MATERIALS.ANY_BUILDABLE;
                float melting_point = 1000f;
                BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
                EffectorValues none = NOISE_POLLUTION.NONE;
                BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, all_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.NONE, none, 0.2f);
                buildingDef.RequiresPowerInput = true;
                buildingDef.PermittedRotations = PermittedRotations.R360;
                buildingDef.EnergyConsumptionWhenActive = 60f;
                buildingDef.ExhaustKilowattsWhenActive = 0f;
                buildingDef.SelfHeatKilowattsWhenActive = 0f;
                buildingDef.ViewMode = OverlayModes.Light.ID;
                buildingDef.AudioCategory = "Metal";
                return buildingDef;
            }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<WaterScrubber>();
            go.AddOrGet<DropAllWorkable>();

            Storage storage = go.AddOrGet<Storage>();
            storage.capacityKg = 100000f;
            storage.showInUI = true;

            ElementConsumer elementConsumer = go.AddOrGet<ElementConsumer>();
            elementConsumer.configuration = ElementConsumer.Configuration.AllGas;
            elementConsumer.capacityKG = 100000f;
            elementConsumer.consumptionRate = 30f;
            elementConsumer.consumptionRadius = 10;
            elementConsumer.showInStatusPanel = true;
            elementConsumer.sampleCellOffset = new Vector3(0f, 0f, 0f);
            elementConsumer.isRequired = false;
            elementConsumer.storeOnConsume = true;

            ElementDropper elementDropper = go.AddComponent<ElementDropper>();
            elementDropper.emitMass = 30f;
            elementDropper.emitTag = new Tag("Water");
            elementDropper.emitOffset = new Vector3(0f, 1f, 0f);

            float x = 10f;
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[2]
            {
                new ElementConverter.ConsumedElement(new Tag("Oxygen"), 0.888f*x),
                new ElementConverter.ConsumedElement(new Tag("Hydrogen"), 0.112f*x)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[1]
            {
            new ElementConverter.OutputElement(1f*x, SimHashes.Water, 0f, storeOutput:false, 0f, 0f, apply_input_temperature:false, 0f, 0)
            };
        }
    }
}

