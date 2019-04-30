using Harmony;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq;
using TUNING;
using KorribanDynamics.JapaneseSchoolGirls;
using UnityEngine;
using System.Reflection;

namespace KorribanDynamics
{
    namespace JapaneseSchoolGirls
    {
        public class SithLordsPrevail
        {
            public static float GlobalCap = DynamicBuildingsState.StateManager.State.LockerCap;
            public static float GlobalConsumeRate = DynamicBuildingsState.StateManager.State.liquidandgas;
            public static byte GlobalRadius = DynamicBuildingsState.StateManager.State.SuckInRadius;
            public static float GlobalRocketCap = DynamicBuildingsState.StateManager.State.RocketStorageCap;
            public static int MyDistance = DynamicBuildingsState.StateManager.State.PlanetTierDistance;
            public static bool AllShit = false;
        }

    }

    namespace DynamicBuildings
    {
        namespace Base_Changes
        {
            namespace Ladders
            {
                namespace Ladder_
                {
                }
                namespace Plastic_Ladder { }
                namespace Fire_Pole
                {
                    [HarmonyPatch(typeof(FirePoleConfig), "ConfigureBuildingTemplate")]
                    public static class FirePoleSpeed
                    {
                        public static void Postfix(FirePoleConfig __instance, ref GameObject go)
                        {
                            Ladder ladder = go.AddOrGet<Ladder>();
                            ladder.upwardsMovementSpeedMultiplier = 15f;
                            ladder.downwardsMovementSpeedMultiplier = 15f;
                        }
                    }
                }
            }
            namespace Tiles
            {
                namespace Tile{}
                namespace Mesh_Tile{}
                namespace Insulation_Tile
                {
                    [HarmonyPatch(typeof(InsulationTileConfig), "CreateBuildingDef")]
                    public static class InsulationTile_Mass
                    {
                        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                        {
                            var codes = new List<CodeInstruction>(instructions);
                            FieldInfo fieldInfoF1 = AccessTools.Field(typeof(BUILDINGS.CONSTRUCTION_MASS_KG), nameof(BUILDINGS.CONSTRUCTION_MASS_KG.TIER4));
                            FieldInfo fieldInfoF2 = AccessTools.Field(typeof(BUILDINGS.CONSTRUCTION_MASS_KG), nameof(BUILDINGS.CONSTRUCTION_MASS_KG.TIER_TINY));
                            for (int i = 0; i < codes.Count; i++)
                            {
                                CodeInstruction instruction = codes[index: i];
                                if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1)
                                {
                                    if (DynamicBuildingsState.StateManager.State.LightFloor) { instruction.operand = fieldInfoF2; } else { instruction.operand = fieldInfoF1; }
                                }
                            }
                            return codes.AsEnumerable();
                        }
                    }                    
                }
                namespace Plastic_Tile { }
                namespace Metal_Tile { }
                namespace Glass_Tile { }
                namespace Bunker_Tile
                {
                    [HarmonyPatch(typeof(BunkerTileConfig), "CreateBuildingDef")]
                    public static class BunkerTile_HP
                    {
                        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                        {
                            var codes = new List<CodeInstruction>(instructions);                            
                            for (int i = 0; i < codes.Count; i++)
                            {
                                CodeInstruction instruction = codes[index: i];
                                if (instruction.opcode == OpCodes.Ldc_I4 && (int)instruction.operand == 1000)
                                {
                                    instruction.operand = 999999;
                                }
                            }
                            return codes.AsEnumerable();
                        }
                    }

                }
                namespace Carpeted_Tile { }
            }
            namespace Doors
            {
                namespace Pneumatic_Door { }
                namespace Manual_Airlock { }
                namespace Mechanized_Airlock
                {
                    [HarmonyPatch(typeof(PressureDoorConfig), "CreateBuildingDef")]
                    class PressureDoorNoPower
                    {
                        public static void Postfix(PressureDoorConfig __instance, ref BuildingDef __result)
                        {
                            __result.RequiresPowerInput = false;
                            __result.EnergyConsumptionWhenActive = 0f;
                        }
                    }
                }
                namespace Bunker_Door
                {
                    //QOL2 - mod unfriendly
                }
            }
            namespace Storages
            {
                namespace Storage_Locker
                {
                    [HarmonyPatch(typeof(StorageLockerConfig), "ConfigureBuildingTemplate")]
                    public class StorageLockerConfigCapacityPatch
                    {
                        static void Postfix(StorageLockerConfig __instance, ref GameObject go)
                        {
                            Storage storage = go.AddOrGet<Storage>();
                            storage.capacityKg = SithLordsPrevail.GlobalCap;
                        }
                    }
                    [HarmonyPatch(typeof(StorageLockerConfig), "CreateBuildingDef")]
                    public class StorageLockerConfigBasePatch
                    {
                        static void Postfix(StorageLockerConfig __instance, ref BuildingDef __result)
                        {
                            __result.PermittedRotations = PermittedRotations.R360;
                            __result.BuildLocationRule = BuildLocationRule.Anywhere;
                            __result.ContinuouslyCheckFoundation = DynamicBuildingsState.StateManager.State.LockerBase;
                        }
                    }
                }
                namespace Smart_Storage_Locker { }
                namespace Liquid_Reservoir
                {
                    [HarmonyPatch(typeof(LiquidReservoirConfig), "ConfigureBuildingTemplate")]
                    public static class LiquidReservoirConfigRotationsPatch
                    {
                        public static void Postfix(LiquidReservoirConfig __instance, ref GameObject go)
                        {
                            Storage storage = BuildingTemplates.CreateDefaultStorage(go);
                            storage.capacityKg = DynamicBuildingsState.StateManager.State.LiqRes;
                            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                            conduitConsumer.capacityKG = storage.capacityKg;
                        }
                    }
                    [HarmonyPatch(typeof(LiquidReservoirConfig), "CreateBuildingDef")]
                    public class LiquidReservoirConfigBasePatch
                    {
                        static void Postfix(LiquidReservoirConfig __instance, ref BuildingDef __result)
                        {
                            __result.PermittedRotations = PermittedRotations.R360;
                            __result.BuildLocationRule = BuildLocationRule.Anywhere; 
                            __result.ContinuouslyCheckFoundation = DynamicBuildingsState.StateManager.State.LiqResBase;
                        }
                    }
                }
                namespace Gas_Reservoir
                {
                    [HarmonyPatch(typeof(GasReservoirConfig), "ConfigureBuildingTemplate")]
                    public static class GasReservoirConfigRotationsPatch
                    {
                        public static void Postfix(GasReservoirConfig __instance, ref GameObject go)
                        {
                            Storage storage = BuildingTemplates.CreateDefaultStorage(go);
                            storage.capacityKg = DynamicBuildingsState.StateManager.State.GasRes;
                            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                            conduitConsumer.capacityKG = storage.capacityKg;
                        }
                    }
                    [HarmonyPatch(typeof(GasReservoirConfig), "CreateBuildingDef")]
                    public class GasReservoirConfigBasePatch
                    {
                        static void Postfix(GasReservoirConfig __instance, ref BuildingDef __result)
                        {
                            __result.PermittedRotations = PermittedRotations.R360;
                            __result.BuildLocationRule = BuildLocationRule.Anywhere;
                            __result.ContinuouslyCheckFoundation = DynamicBuildingsState.StateManager.State.GasResBase;
                        }
                    }
                }
            }
            namespace Transit
            {
                namespace Transit_Tube { }
                namespace Transit_Tube_Access
                {
                    [HarmonyPatch(typeof(TravelTubeEntranceConfig), "ConfigureBuildingTemplate")]
                    public static class TravelTubeEntranceConfigPatch
                    {
                        static void Postfix(TravelTubeEntranceConfig __instance, ref GameObject go)
                        {
                            TravelTubeEntrance travelTubeEntrance = go.AddOrGet<TravelTubeEntrance>();
                            travelTubeEntrance.joulesPerLaunch = 10f;
                            travelTubeEntrance.jouleCapacity = 10000f;
                        }
                    }
                }
                namespace Transit_Tube_Crossing { }
            }
        }
        namespace Oxygen_Changes
        {
            namespace Oxygen_Diffuser { }
            namespace Algae_Terrarium { }
            namespace Deodorizer
            {
                [HarmonyPatch(typeof(AirFilterConfig), "ConfigureBuildingTemplate")]
                public static class AirFilteremitMassPatch
                {
                    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                    {
                        float gimmeclay = 1000f;
                        var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++)
                        {
                            if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 10f))
                            {
                                {
                                    codes[i].operand = gimmeclay;
                                }
                            }
                        }
                        return codes.AsEnumerable();
                    }
                }
                [HarmonyPatch(typeof(AirFilterConfig), "CreateBuildingDef")]
                public class AirFilterRotations { static void Postfix(AirFilterConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.R360; }

                [HarmonyPatch(typeof(AirFilterConfig), "ConfigureBuildingTemplate")]
                public static class DeodorizerCapacityAndRatePatch
                {
                    static void Postfix(AirFilterConfig __instance, ref GameObject go)
                    {
                        float mycap = DynamicBuildingsState.StateManager.State.DeodorizerCap;
                        float rate = DynamicBuildingsState.StateManager.State.DeodorizerRate;
                        float con_rate = SithLordsPrevail.GlobalConsumeRate*10;

                        ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
                        elementConverter.consumedElements = new ElementConverter.ConsumedElement[2]
                        {
                    new ElementConverter.ConsumedElement(new Tag("Filter"), 0.15f*rate),
                    new ElementConverter.ConsumedElement(new Tag("ContaminatedOxygen"), 0.1f*rate)
                        };
                        elementConverter.outputElements = new ElementConverter.OutputElement[2]
                        {
                    new ElementConverter.OutputElement(0.1f*rate, SimHashes.Clay, outputTemperature:0f, storeOutput: true, 0f, 0.5f, apply_input_temperature: false, 0.25f, byte.MaxValue),
                    new ElementConverter.OutputElement(0.15f*rate, SimHashes.Oxygen, 0f, storeOutput: false, 0f, 0f, apply_input_temperature: false, 0.75f, byte.MaxValue)
                        };

                        Storage storage = BuildingTemplates.CreateDefaultStorage(go);
                        storage.capacityKg = mycap;

                        ElementConsumer elementConsumer = go.AddOrGet<ElementConsumer>();
                        elementConsumer.capacityKG = mycap;
                        elementConsumer.consumptionRate = con_rate;

                        ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
                        manualDeliveryKG.capacity = mycap;
                        manualDeliveryKG.refillMass = 100f;

                        go.AddOrGet<DropAllWorkable>();
                    }
                }
            }
            namespace Carbon_Skimmer { }
            namespace Electrolyzer_
            {
                [HarmonyPatch(typeof(ElectrolyzerConfig), "ConfigureBuildingTemplate")]
                public static class ElectrolyzerPressure
                {
                    public static void Postfix(ElectrolyzerConfig __instance, ref GameObject go)
                    {
                        float MaxPressure = DynamicBuildingsState.StateManager.State.ElectrolyzerMaxPressure;
                        float InRate = DynamicBuildingsState.StateManager.State.ElectrolyzerRate;
                        float MyHydro = DynamicBuildingsState.StateManager.State.ElectroHydro / 1000f;
                        float MyOxy = 1f - MyHydro;

                        Electrolyzer electrolyzer = go.AddOrGet<Electrolyzer>();
                        electrolyzer.maxMass = MaxPressure;
                        ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                        conduitConsumer.consumptionRate = InRate;
                        Storage storage = go.AddOrGet<Storage>();
                        storage.capacityKg = 10000f;
                        ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
                        elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
                        {
                    new ElementConverter.ConsumedElement(new Tag("Water"), InRate)
                        };
                        elementConverter.outputElements = new ElementConverter.OutputElement[2]
                        {
                    new ElementConverter.OutputElement(InRate*MyOxy, SimHashes.Oxygen, 343.15f, false, 0f, 1f, false, 1f, byte.MinValue),
                    new ElementConverter.OutputElement(InRate*MyHydro, SimHashes.Hydrogen, 343.15f, false, 0f, 1f, false, 1f, byte.MinValue)
                        };
                    }
                }
            }
        }
        namespace Power_Changes
        {
            namespace Generators
            {
                namespace Manual_Generator { }
                namespace Coal_Generator
                {
                    namespace CoalGenerator
                    {
                        [HarmonyPatch(typeof(GeneratorConfig), "CreateBuildingDef")]
                        public class GeneratorConfigCoal
                        {
                            static void Postfix(GeneratorConfig __instance, ref BuildingDef __result)
                            {
                                bool HeatAir = DynamicBuildingsState.StateManager.State.CoalGeneratorHeatsUpAir;
                                __result.GeneratorWattageRating = DynamicBuildingsState.StateManager.State.CoalGeneratorWattage;
                                if (HeatAir == false) { __result.ExhaustKilowattsWhenActive = 0f; } else { __result.ExhaustKilowattsWhenActive = 8f; }
                            }
                        }
                    }
                }
                namespace Hydrogen_Generator
                {
                    [HarmonyPatch(typeof(HydrogenGeneratorConfig), "CreateBuildingDef")]
                    public class HydrogenGeneratorElectricityRate
                    {
                        static void Postfix(HydrogenGeneratorConfig __instance, ref BuildingDef __result)
                        {
                            float MyConsume = SithLordsPrevail.GlobalConsumeRate;
                            __result.GeneratorWattageRating = 800f * MyConsume;
                            __result.GeneratorBaseCapacity = 200f + __result.GeneratorWattageRating;
                        }
                    }
                    [HarmonyPatch(typeof(HydrogenGeneratorConfig), "DoPostConfigureComplete")]
                    public class HydrogenGeneratorGasRate
                    {
                        static void Postfix(HydrogenGeneratorConfig __instance, ref GameObject go)
                        {
                            float MyCap = SithLordsPrevail.GlobalCap;
                            float MyConsume = SithLordsPrevail.GlobalConsumeRate;

                            go.AddOrGet<Storage>().capacityKg = MyCap;
                            go.AddOrGet<ConduitConsumer>().consumptionRate = MyConsume;
                            go.AddOrGet<ConduitConsumer>().capacityKG = MyCap;

                            go.AddOrGet<EnergyGenerator>().formula = EnergyGenerator.CreateSimpleFormula(SimHashes.Hydrogen, 0.1f * MyConsume, 2f * MyConsume, SimHashes.Void, 0f, true);
                        }
                    }
                }
                namespace Natural_Gas_Generator
                {
                    [HarmonyPatch(typeof(MethaneGeneratorConfig), "CreateBuildingDef")]
                    public class NaturalGeneratorElectricityRate
                    {
                        static void Postfix(MethaneGeneratorConfig __instance, ref BuildingDef __result)
                        {
                            float MyConsume = SithLordsPrevail.GlobalConsumeRate;
                            __result.GeneratorWattageRating = 800f * MyConsume;
                            __result.GeneratorBaseCapacity = 200f + __result.GeneratorWattageRating;
                        }
                    }
                    [HarmonyPatch(typeof(MethaneGeneratorConfig), "DoPostConfigureComplete")]
                    public class NaturalGeneratorGasRate
                    {
                        static void Postfix(MethaneGeneratorConfig __instance, ref GameObject go)
                        {
                            float MyCap = SithLordsPrevail.GlobalCap;
                            float MyConsume = SithLordsPrevail.GlobalConsumeRate;

                            go.AddOrGet<Storage>().capacityKg = MyCap;
                            go.AddOrGet<ConduitConsumer>().consumptionRate = MyConsume;
                            go.AddOrGet<ConduitConsumer>().capacityKG = MyCap;

                            go.AddOrGet<EnergyGenerator>().formula = new EnergyGenerator.Formula
                            {
                                inputs = new EnergyGenerator.InputItem[]
                                {
                            new EnergyGenerator.InputItem(GameTagExtensions.Create(SimHashes.Methane), 0.09f*MyConsume, MyCap)
                                },
                                outputs = new EnergyGenerator.OutputItem[]
                                {
                            new EnergyGenerator.OutputItem(SimHashes.DirtyWater, 0.0675f*MyConsume, false, new CellOffset(1, 1), 0f),
                            new EnergyGenerator.OutputItem(SimHashes.CarbonDioxide, 0.0225f*MyConsume, true, new CellOffset(0, 2), 383.15f)
                                }
                            };
                        }
                    }
                }
                namespace Petroleum_Generator { }
                namespace Steam_Turbine { }
                namespace Solar_Panel { }
            }
            namespace Wires
            {
                namespace Wire { }
                namespace Wire_Bridge { }
                namespace Heavi_Watt_Wire { }
                namespace Heavi_Watt_Joint_Plate { }
                namespace Conductive_Wire { }
                namespace Conductive_Wire_Bridge { }
                namespace Heavi_Conductive_Wire { }
                namespace Heavi_Conductive_Joint_Plate { }
            }
            namespace Batteries
            {
                namespace Tiny_Battery { }
                namespace Medium_Battery
                {
                    [HarmonyPatch(typeof(BatteryMediumConfig), "DoPostConfigureComplete")]
                    public class BatteryMediumLostJoules
                    {
                        static void Postfix(BatteryMediumConfig __instance, ref GameObject go)
                        {
                            float TotalCap = DynamicBuildingsState.StateManager.State.MedBatCap * 1000f;
                            bool Looser = DynamicBuildingsState.StateManager.State.BatteryMediumLoosesEnergy;
                            Battery battery = go.AddOrGet<Battery>();
                            battery.capacity = TotalCap;
                            if (Looser == false) { battery.joulesLostPerSecond = 0f; } else { battery.joulesLostPerSecond = TotalCap * 0.05f / 600f; }
                        }
                    }

                    [HarmonyPatch(typeof(BatteryMediumConfig), "ConfigureBuildingTemplate")]
                    public class BatteryMediumConfigBasePatch2
                    {
                        private static void Postfix(BatteryMediumConfig __instance, ref Tag prefab_tag)
                        {
                            bool flag = !DynamicBuildingsState.StateManager.State.BatteryMedBase;
                            if (flag)
                            {
                                BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
                            }
                        }
                    }
                }
                namespace Smart_Battery { }
            }
            namespace Transformers
            {
                namespace Small_Power_Transformer { }
                namespace Power_Transformer { }
            }
            namespace Power_Switches
            {
                namespace Power_Switch { }
                namespace Power_Shutoff { }
            }
        }
        namespace Food_Changes
        {
            namespace Cooking
            {
                namespace Microbe_Musher { }
                namespace Electric_Grill {}
            }
            namespace Farming
            {
                namespace Planter_Box { }
                namespace Farm_Tile { }
                namespace Hydroponic_Farm { }
            }
            namespace Critters
            {
                namespace Critter_Drop_Off { }
                namespace Fish_Release { }
                namespace Critter_Feeder
                {
                    [HarmonyPatch(typeof(CreatureFeederConfig), "ConfigureBuildingTemplate")]
                    public class CreatureFeederConfigCapacityPatch
                    {
                        static void Postfix(CreatureFeederConfig __instance, ref GameObject go)
                        {
                            Storage storage = go.AddOrGet<Storage>();
                            storage.capacityKg = SithLordsPrevail.GlobalCap;
                        }
                    }
                }
                namespace Fish_Feeder { }
                namespace Incubator { }
                namespace Egg_Cracker { }
                namespace Critter_Trap { }
                namespace Fish_Trap { }
                namespace Critter_Lure { }
            }
            namespace Food_Storage
            {
                namespace Ration_Box
                {
                    [HarmonyPatch(typeof(RationBoxConfig), "CreateBuildingDef")] public static class RationBoxStorageRotations { public static void Postfix(RationBoxConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.R360; }
                    [HarmonyPatch(typeof(RationBoxConfig), "ConfigureBuildingTemplate")]
                    public class RationBoxConfigCapacityPatch
                    {
                        static void Postfix(RationBoxConfig __instance, ref GameObject go)
                        {
                            Storage storage = go.AddOrGet<Storage>();
                            storage.capacityKg = SithLordsPrevail.GlobalCap;
                        }
                    }
                }
                namespace Refrigerator { }
            }
        }
        namespace Plumbing_Changes
        {
            namespace Bathroom_Stuff
            {
                namespace Outhouse_ { }
                namespace Lavatory_ { }
                namespace Shower_
                {
                    [HarmonyPatch(typeof(ShowerConfig), "ConfigureBuildingTemplate")]
                    public class ShowerConfigPatch
                    {
                        static void Postfix(ShowerConfig __instance, ref GameObject go)
                        {
                            go.AddOrGet<Shower>().workTime = 0f;
                            go.AddOrGet<ConduitConsumer>().capacityKG = 500f;
                            go.AddOrGet<Storage>().capacityKg = 1000f;
                        }
                    }
                }
            }
            namespace Liquid_Pumping
            {
                namespace Pitcher_Pump
                {
                    [HarmonyPatch(typeof(LiquidPumpingStationConfig), "CreateBuildingDef")] public static class LiquidPumpingStationRotations { public static void Postfix(LiquidPumpingStationConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.FlipH; }
                }
                namespace Bottle_Emptier
                {
                    [HarmonyPatch(typeof(BottleEmptierConfig), "ConfigureBuildingTemplate")]
                    public class BottleEmptierPatch
                    {
                        static void Postfix(BottleEmptierConfig __instance, ref GameObject go)
                        {
                            float mycapacity = SithLordsPrevail.GlobalCap;
                            Storage storage = go.AddOrGet<Storage>();
                            storage.capacityKg = mycapacity;
                            go.AddOrGet<BottleEmptier>().emptyRate = 100f;
                        }
                    }
                }
                namespace Liquid_Pump
                {
                    [HarmonyPatch(typeof(LiquidPumpConfig), "DoPostConfigureComplete")]
                    public static class LiquidPumpConfigDynamicPatch
                    {
                        public static void Postfix(LiquidPumpConfig __instance, ref GameObject go)
                        {
                            float ratio = SithLordsPrevail.GlobalConsumeRate;
                            byte radius = SithLordsPrevail.GlobalRadius;
                            float cap = SithLordsPrevail.GlobalCap;
                            Storage storage = go.AddOrGet<Storage>();
                            storage.capacityKg = cap;
                            ElementConsumer elementConsumer = go.AddOrGet<ElementConsumer>();
                            elementConsumer.consumptionRate = ratio;
                            elementConsumer.consumptionRadius = radius;
                            elementConsumer.capacityKG = cap;
                        }
                    }
                }
                namespace Mini_Liquid_Pump
                {
                    [HarmonyPatch(typeof(LiquidMiniPumpConfig), "DoPostConfigureComplete")]
                    public static class LiquidMiniPumpConfigDynamicPatch
                    {
                        public static void Postfix(LiquidMiniPumpConfig __instance, ref GameObject go)
                        {
                            float ratio = SithLordsPrevail.GlobalConsumeRate;
                            byte radius = SithLordsPrevail.GlobalRadius;
                            float cap = SithLordsPrevail.GlobalCap;
                            Storage storage = go.AddOrGet<Storage>();
                            storage.capacityKg = cap;
                            ElementConsumer elementConsumer = go.AddOrGet<ElementConsumer>();
                            elementConsumer.consumptionRate = ratio;
                            elementConsumer.consumptionRadius = radius;
                            elementConsumer.capacityKG = cap;
                        }
                    }
                }
            }
            namespace Liquid_Pipes
            {
                namespace Liquid_Pipe { }
                namespace Insulated_Liquid_Pipe
                {
                    [HarmonyPatch(typeof(InsulatedLiquidConduitConfig), "CreateBuildingDef")]
                    public static class SteamEngine_Mass
                    {
                        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                        {
                            var codes = new List<CodeInstruction>(instructions);
                            FieldInfo fieldInfoF1 = AccessTools.Field(typeof(BUILDINGS.CONSTRUCTION_MASS_KG), nameof(BUILDINGS.CONSTRUCTION_MASS_KG.TIER4));
                            FieldInfo fieldInfoF2 = AccessTools.Field(typeof(BUILDINGS.CONSTRUCTION_MASS_KG), nameof(BUILDINGS.CONSTRUCTION_MASS_KG.TIER0));
                            for (int i = 0; i < codes.Count; i++)
                            {
                                CodeInstruction instruction = codes[index: i];
                                if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1)
                                {
                                    if (DynamicBuildingsState.StateManager.State.LightLiquid) { instruction.operand = fieldInfoF2; } else { instruction.operand = fieldInfoF1; }
                                }
                            }
                            return codes.AsEnumerable();
                        }
                    }
                }
                namespace Radiant_Liquid_Pipe { }
                namespace Liquid_Bridge { }
            }
            namespace Vents_Filters_and_Valves
            {
                namespace Liquid_Vent
                {
                    [HarmonyPatch(typeof(LiquidVentConfig), "ConfigureBuildingTemplate")]
                    public static class LiquidVentConfigPatch
                    {
                        static void Postfix(LiquidVentConfig __instance, ref GameObject go)
                        {
                            Vent vent = go.AddOrGet<Vent>(); vent.overpressureMass = 2000f;
                        }
                    }
                }
                namespace Liquid_Filter
                {

                }
                namespace Liquid_Valve
                {
                    [HarmonyPatch(typeof(LiquidValveConfig), "ConfigureBuildingTemplate")]
                    public static class LiquidValveConfigDynamicPatch
                    {
                        public static void Postfix(LiquidLogicValveConfig __instance, ref GameObject go)
                        {
                            float max = SithLordsPrevail.GlobalConsumeRate;
                            ValveBase valveBase = go.AddOrGet<ValveBase>();
                            valveBase.maxFlow = max;
                            valveBase.animFlowRanges = new ValveBase.AnimRangeInfo[3]
                            {
                    new ValveBase.AnimRangeInfo(max*0.25f, "lo"),
                    new ValveBase.AnimRangeInfo(max/2, "med"),
                    new ValveBase.AnimRangeInfo(max*0.75f, "hi")
                            };
                        }
                    }
                }
                namespace Liquid_Shutoff
                {
                    [HarmonyPatch(typeof(LiquidLogicValveConfig), "ConfigureBuildingTemplate")]
                    public static class LiquidLogicValveConfigDynamicPatch
                    {
                        public static void Postfix(LiquidLogicValveConfig __instance, ref GameObject go)
                        {
                            OperationalValve operationalValve = go.AddOrGet<OperationalValve>();
                            operationalValve.maxFlow = SithLordsPrevail.GlobalConsumeRate;
                        }
                    }
                }
            }
            namespace Sensors
            {
                namespace Liquid_Pipe_Element_Sensor { }
                namespace Liquid_Pipe_Germ_Sensor { }
                namespace Liquid_Pipe_Thermo_Sensor { }
            }
        }
        namespace Ventilation_Changes
        {
            namespace Gas_Pumping
            {
                namespace Gas_Pump
                {
                    [HarmonyPatch(typeof(GasPumpConfig), "DoPostConfigureComplete")]
                    public static class GasPump_DynamicPatch
                    {
                        public static void Postfix(GasPumpConfig __instance, ref GameObject go)
                        {
                            float ratio = SithLordsPrevail.GlobalConsumeRate;
                            byte radius = SithLordsPrevail.GlobalRadius;
                            float cap = SithLordsPrevail.GlobalCap;
                            Storage storage = go.AddOrGet<Storage>();
                            storage.capacityKg = cap;
                            ElementConsumer elementConsumer = go.AddOrGet<ElementConsumer>();
                            elementConsumer.consumptionRate = ratio;
                            elementConsumer.consumptionRadius = radius;
                            elementConsumer.capacityKG = cap;
                        }
                    }
                }
                namespace Mini_Gas_Pump
                {
                    [HarmonyPatch(typeof(GasMiniPumpConfig), "DoPostConfigureComplete")]
                    public static class GasMiniPump_DynamicPatch
                    {
                        public static void Postfix(GasMiniPumpConfig __instance, ref GameObject go)
                        {
                            float ratio = SithLordsPrevail.GlobalConsumeRate;
                            byte radius = SithLordsPrevail.GlobalRadius;
                            float cap = SithLordsPrevail.GlobalCap;
                            Storage storage = go.AddOrGet<Storage>();
                            storage.capacityKg = cap;
                            ElementConsumer elementConsumer = go.AddOrGet<ElementConsumer>();
                            elementConsumer.consumptionRate = ratio;
                            elementConsumer.consumptionRadius = radius;
                            elementConsumer.capacityKG = cap;
                        }
                    }
                }
                namespace Canister_Filler { }
                namespace Canister_Emptier
                {
                    [HarmonyPatch(typeof(BottleEmptierGasConfig), "ConfigureBuildingTemplate")]
                    public class BottleEmptierGasPatch
                    {
                        static void Postfix(BottleEmptierGasConfig __instance, ref GameObject go)
                        {
                            float mycapacity = SithLordsPrevail.GlobalCap;
                            Storage storage = go.AddOrGet<Storage>();
                            storage.capacityKg = mycapacity;
                            go.AddOrGet<BottleEmptier>().emptyRate = 100f;
                        }
                    }
                }
            }
            namespace Gas_Pipes
            {
                namespace Gas_Pipe { }
                namespace Insulated_Gas_Pipe
                {
                    [HarmonyPatch(typeof(InsulatedGasConduitConfig), "CreateBuildingDef")]
                    public static class SteamEngine_Mass
                    {
                        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                        {
                            var codes = new List<CodeInstruction>(instructions);
                            FieldInfo fieldInfoF1 = AccessTools.Field(typeof(BUILDINGS.CONSTRUCTION_MASS_KG), nameof(BUILDINGS.CONSTRUCTION_MASS_KG.TIER4));
                            FieldInfo fieldInfoF2 = AccessTools.Field(typeof(BUILDINGS.CONSTRUCTION_MASS_KG), nameof(BUILDINGS.CONSTRUCTION_MASS_KG.TIER0));
                            for (int i = 0; i < codes.Count; i++)
                            {
                                CodeInstruction instruction = codes[index: i];
                                if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1)
                                {
                                    if (DynamicBuildingsState.StateManager.State.LightAir) { instruction.operand = fieldInfoF2; } else { instruction.operand = fieldInfoF1; }
                                }
                            }
                            return codes.AsEnumerable();
                        }
                    }
                }
                namespace Radiant_Gas_Pipe { }
                namespace Gas_Bridge { }
            }
            namespace Vents_Filters_and_Valves
            {
                namespace Gas_Vent
                {
                    [HarmonyPatch(typeof(GasVentConfig), "ConfigureBuildingTemplate")]
                    public static class GasVentConfigPatch
                    {
                        static void Postfix(GasVentConfig __instance, ref GameObject go)
                        {
                            Vent vent = go.AddOrGet<Vent>(); vent.overpressureMass = DynamicBuildingsState.StateManager.State.GVOP;
                        }
                    }
                }
                namespace High_Pressure_Gas_Vent
                {
                    [HarmonyPatch(typeof(GasVentHighPressureConfig), "ConfigureBuildingTemplate")]
                    public static class GasVentHighPressureConfigPatch
                    {
                        static void Postfix(GasVentHighPressureConfig __instance, ref GameObject go)
                        {
                            Vent vent = go.AddOrGet<Vent>(); vent.overpressureMass = DynamicBuildingsState.StateManager.State.HPGVOP;
                        }
                    }
                }
                namespace Gas_Filter { }
                namespace Gas_Valve
                {
                    [HarmonyPatch(typeof(GasValveConfig), "ConfigureBuildingTemplate")]
                    public static class GasValveDynamicPatch
                    {
                        public static void Postfix(GasLogicValveConfig __instance, ref GameObject go)
                        {
                            float max = SithLordsPrevail.GlobalConsumeRate;
                            ValveBase valveBase = go.AddOrGet<ValveBase>();
                            valveBase.maxFlow = max;
                            valveBase.animFlowRanges = new ValveBase.AnimRangeInfo[3]
                            {
                    new ValveBase.AnimRangeInfo(max*0.25f, "lo"),
                    new ValveBase.AnimRangeInfo(max/2, "med"),
                    new ValveBase.AnimRangeInfo(max*0.75f, "hi")
                            };
                        }
                    }
                }
                namespace Gas_Shutoff
                {
                    [HarmonyPatch(typeof(GasLogicValveConfig), "ConfigureBuildingTemplate")]
                    public static class GasLogicValveConfigDynamicPatch
                    {
                        public static void Postfix(GasLogicValveConfig __instance, ref GameObject go)
                        {
                            OperationalValve operationalValve = go.AddOrGet<OperationalValve>();
                            operationalValve.maxFlow = SithLordsPrevail.GlobalConsumeRate;
                        }
                    }
                }
            }
            namespace Sensors
            {
                namespace Gas_Pipe_Element_Sensor { }
                namespace Gas_Pipe_Germ_Sensor { }
                namespace Gas_Pipe_Thermo_Sensor { }
            }
        }
        namespace Refinement_Changes
        {
            namespace Compost
            {
                [HarmonyPatch(typeof(CompostConfig), "ConfigureBuildingTemplate")]
                public static class CompostemitMassPatch
                {
                    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                    {
                        float gimmedirt = 1000f;
                        var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++)
                        {
                            if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 10f))
                            {
                                {
                                    codes[i].operand = gimmedirt;
                                }
                            }
                        }
                        return codes.AsEnumerable();
                    }
                }
                [HarmonyPatch(typeof(CompostConfig), "ConfigureBuildingTemplate")]
                public class CompostPatch
                {
                    static void Postfix(CompostConfig __instance, ref GameObject go)
                    {
                        float mycapacity = SithLordsPrevail.GlobalCap;
                        float myspeed = 100f;

                        Storage storage = go.AddOrGet<Storage>();
                        storage.capacityKg = mycapacity;

                        ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
                        elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
                        {new ElementConverter.ConsumedElement(GameTags.Compostable, myspeed)};
                        elementConverter.outputElements = new ElementConverter.OutputElement[1]
                        {new ElementConverter.OutputElement(myspeed, SimHashes.Dirt, 348.15f, true, 0f, 0.5f, false, 1f,byte.MaxValue)};

                        ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
                        manualDeliveryKG.capacity = mycapacity;
                        manualDeliveryKG.refillMass = 10000f;

                        go.AddOrGet<DropAllWorkable>();
                    }
                }
            }
            namespace Water_Sieve
            {
                [HarmonyPatch(typeof(WaterPurifierConfig), "ConfigureBuildingTemplate")]
                public static class WaterPurifieremitMassPatch
                {
                    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                    {
                        float gimmePollutedDirt = 1000f;
                        var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++)
                        {
                            if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 10f))
                            {
                                {
                                    codes[i].operand = gimmePollutedDirt;
                                }
                            }
                        }
                        return codes.AsEnumerable();
                    }
                }
                [HarmonyPatch(typeof(WaterPurifierConfig), "ConfigureBuildingTemplate")]
                public static class WaterPurifierDynamicOutputPatch
                {
                    public static void Postfix(WaterPurifierConfig __instance, ref GameObject go)
                    {
                        float ratio = SithLordsPrevail.GlobalConsumeRate / 10f;
                        float consume = SithLordsPrevail.GlobalConsumeRate;
                        float capacity = SithLordsPrevail.GlobalCap;

                        Storage storage = BuildingTemplates.CreateDefaultStorage(go);
                        storage.capacityKg = capacity;

                        ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
                        elementConverter.consumedElements = new ElementConverter.ConsumedElement[2]
                        {
                    new ElementConverter.ConsumedElement(new Tag("Filter"), ratio),
                    new ElementConverter.ConsumedElement(new Tag("DirtyWater"), 5f* ratio)
                        };
                        elementConverter.outputElements = new ElementConverter.OutputElement[2]
                        {
                    new ElementConverter.OutputElement(5f* ratio, SimHashes.Water, 313.15f, true, 0f, 0.5f, false, 0.75f, byte.MaxValue),
                    new ElementConverter.OutputElement(0.2f* ratio, SimHashes.ToxicSand, 313.15f, true, 0f, 0.5f, false, 0.25f, byte.MaxValue)
                        };

                        ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                        conduitConsumer.consumptionRate = consume;
                        conduitConsumer.capacityKG = capacity;

                        ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
                        manualDeliveryKG.capacity = 5000f;
                        manualDeliveryKG.refillMass = 300f * ratio;
                    }
                }
            }
            namespace Fertilizer_Synthesizer { }
            namespace Algae_Distiller
            {
                [HarmonyPatch(typeof(AlgaeDistilleryConfig), "ConfigureBuildingTemplate")]
                public static class AlgaeDistillery_EmitMassPatch
                {
                    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                    {
                        float gimmealga = 1000f;
                        var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++)
                        {
                            if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 30f))
                            {
                                {
                                    codes[i].operand = gimmealga;
                                }
                            }
                        }
                        return codes.AsEnumerable();
                    }
                }
                [HarmonyPatch(typeof(AlgaeDistilleryConfig), "ConfigureBuildingTemplate")]
                public static class AlgaeDistillery_DynamicOutputPatch
                {
                    public static void Postfix(AlgaeDistilleryConfig __instance, ref GameObject go)
                    {
                        float ratio = DynamicBuildingsState.StateManager.State.SlimeConsumeKGsPerSecond / 0.6f;
                        float cap = SithLordsPrevail.GlobalCap;

                        ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
                        manualDeliveryKG.refillMass = 120f * ratio;
                        manualDeliveryKG.capacity = cap;

                        ElementConverter elementConverter = go.AddOrGet<ElementConverter>();

                        var newConsumedElements = new[] { new ElementConverter.ConsumedElement(SimHashes.SlimeMold.CreateTag(), 0.6f * ratio) };

                        var newOutputElements = new[]
                        {
                    new ElementConverter.OutputElement(0.2f*ratio, SimHashes.Algae, 303.15f, true, 0f, 1f, false, 0f, 0),
                    new ElementConverter.OutputElement(0.4f*ratio, SimHashes.DirtyWater, 303.15f, true, 0f, 0.5f, false, 0f, 0)
                };

                        elementConverter.outputElements = newOutputElements;
                        elementConverter.consumedElements = newConsumedElements;

                        go.AddOrGet<DropAllWorkable>();
                    }
                }
            }
            namespace Rock_Granulator
            {
                [HarmonyPatch(typeof(RockCrusherConfig), "ConfigureBuildingTemplate")]
                internal class RockCrusherArcheologyPatch
                {
                    static void Postfix(RockCrusherConfig __instance, ref GameObject go)
                    {
                        bool RockDupeWork = DynamicBuildingsState.StateManager.State.RockDupe;
                        ComplexFabricator complexFabricator = go.AddOrGet<ComplexFabricator>();
                        complexFabricator.duplicantOperated = RockDupeWork;
                    }
                }
            }
            namespace Kiln{}
            namespace Metal_Refinery
            {
                [HarmonyPatch(typeof(MetalRefineryConfig), "ConfigureBuildingTemplate")]
                class MetalRefineryMegaPatch
                {
                    static void Postfix(MetalRefineryConfig __instance, ref GameObject go)
                    {
                        float TotalCap = DynamicBuildingsState.StateManager.State.RefineryWaterCapacity;
                        float RecipeDose = DynamicBuildingsState.StateManager.State.RefineryWaterForOneRecipe;
                        bool DoTheFudge = DynamicBuildingsState.StateManager.State.Fudge;

                        LiquidCooledRefinery liquidCooledRefinery = go.AddOrGet<LiquidCooledRefinery>();
                        liquidCooledRefinery.minCoolantMass = RecipeDose;
                        liquidCooledRefinery.buildStorage.capacityKg = TotalCap;
                        liquidCooledRefinery.inStorage.capacityKg = TotalCap;
                        liquidCooledRefinery.outStorage.capacityKg = TotalCap;
                        liquidCooledRefinery.thermalFudge = DoTheFudge ? 0.8f : 0f;

                        ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                        conduitConsumer.capacityKG = TotalCap;
                    }
                }
            }
            namespace Glass_Forge
            {
                [HarmonyPatch(typeof(GlassForgeConfig), "ConfigureBuildingTemplate")]
                internal class GlassForgeDupesPatch
                {
                    static void Postfix(GlassForgeConfig __instance, ref GameObject go)
                    {
                        bool GlassDupeWork = DynamicBuildingsState.StateManager.State.GlassDupe;
                        GlassForge glassForge = go.AddOrGet<GlassForge>();
                        glassForge.duplicantOperated = GlassDupeWork;
                    }
                }
            }
            namespace Oil_Refinery
            {
                [HarmonyPatch(typeof(OilRefineryConfig), "ConfigureBuildingTemplate")]
                public static class OilRefineryDynamicOutputPatch
                {
                    public static void Postfix(OilRefineryConfig __instance, ref GameObject go)
                    {
                        float consume = SithLordsPrevail.GlobalConsumeRate;
                        float ratio = SithLordsPrevail.GlobalConsumeRate / 10f;
                        float cap = SithLordsPrevail.GlobalCap;

                        OilRefinery oilRefinery = go.AddOrGet<OilRefinery>();
                        oilRefinery.overpressureMass = DynamicBuildingsState.StateManager.State.HPGVOP;

                        ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                        conduitConsumer.consumptionRate = consume;
                        conduitConsumer.capacityKG = cap;
                        ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
                        var newConsumedElements = new[]
                        {
                            new ElementConverter.ConsumedElement(SimHashes.CrudeOil.CreateTag(), 10*ratio)
                        };
                        var newOutputElements = new[]
                        {
                            new ElementConverter.OutputElement(5*ratio, SimHashes.Petroleum, 348.15f, true, 0f, 1f, false, 0f, 0),
                            new ElementConverter.OutputElement(0.09f*ratio, SimHashes.Methane, 348.15f, false, 0f, 1f, false, 0f, 0)
                        };

                        elementConverter.outputElements = newOutputElements;
                        elementConverter.consumedElements = newConsumedElements;
                    }
                }
                [HarmonyPatch(typeof(OilRefineryConfig), "CreateBuildingDef")] public static class OilRefineryRotations { public static void Postfix(OilRefineryConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.FlipH; }
            }
            namespace Polymer_Press
            {
                [HarmonyPatch(typeof(PolymerizerConfig), "ConfigureBuildingTemplate")]
                public static class PolymerizeremitMassPatch
                {
                    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                    {
                        float gimmeplastic = 1000f;
                        var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++)
                        {
                            if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 30f))
                            {
                                {
                                    codes[i].operand = gimmeplastic;
                                }
                            }
                        }
                        return codes.AsEnumerable();
                    }
                }
                [HarmonyPatch(typeof(PolymerizerConfig), "CreateBuildingDef")]
                class PolymerizerNoHeat
                {
                    public static void Postfix(PolymerizerConfig __instance, ref BuildingDef __result)
                    {
                        bool HeatAir = DynamicBuildingsState.StateManager.State.PolymerizerHeatsUpAir;
                        bool HeatSelf = DynamicBuildingsState.StateManager.State.PolymerizerHeatsUpSelf;
                        if (HeatAir == false) { __result.ExhaustKilowattsWhenActive = 0f; } else { __result.ExhaustKilowattsWhenActive = 0.5f; }
                        if (HeatSelf == false) { __result.SelfHeatKilowattsWhenActive = 0f; } else { __result.SelfHeatKilowattsWhenActive = 32f; }
                    }
                }
                [HarmonyPatch(typeof(PolymerizerConfig), "ConfigureBuildingTemplate")]
                public static class PolymerizerConfigDynamicOutputPatch
                {
                    public static void Postfix(PolymerizerConfig __instance, ref GameObject go)
                    {
                        float ratio = SithLordsPrevail.GlobalConsumeRate / 0.8f;
                        float consume = SithLordsPrevail.GlobalConsumeRate;
                        float capacity = SithLordsPrevail.GlobalCap;

                        ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                        conduitConsumer.consumptionRate = consume;
                        conduitConsumer.capacityKG = capacity;
                        ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
                        var newConsumedElements = new[] { new ElementConverter.ConsumedElement(GameTagExtensions.Create(SimHashes.Petroleum), 0.8f * ratio) };
                        var newOutputElements = new[]
                        {
                            new ElementConverter.OutputElement(0.5f*ratio, SimHashes.Polypropylene, 348.15f, true, 0f, 0.5f, false, 1f, byte.MaxValue, 0),
                            new ElementConverter.OutputElement(0.0084f*ratio, SimHashes.Steam, 473.15f, true, 0f, 0.5f, false, 1f, byte.MaxValue, 0),
                            new ElementConverter.OutputElement(0.0084f*ratio, SimHashes.CarbonDioxide, 423.15f, true, 0f, 0.5f, false, 1f, byte.MaxValue, 0)
                        };
                        elementConverter.consumedElements = newConsumedElements;
                        elementConverter.outputElements = newOutputElements;
                    }
                }
            }
            namespace Oxylite_Refinery
            {
                [HarmonyPatch(typeof(OxyliteRefineryConfig), "ConfigureBuildingTemplate")]
                public static class OxyliteRefineryemitMassPatch
                {
                    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                    {
                        float gimmeoxy = 1000f;
                        var codes = new List<CodeInstruction>(instructions); for (int i = 0; i < codes.Count; i++)
                        {
                            if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 10f))
                            {
                                {
                                    codes[i].operand = gimmeoxy;
                                }
                            }
                        }
                        return codes.AsEnumerable();
                    }
                }
                [HarmonyPatch(typeof(OxyliteRefineryConfig), "ConfigureBuildingTemplate")]
                public static class OxyliteRefineryConfigPatch
                {
                    static void Postfix(OxyliteRefineryConfig __instance, ref GameObject go)
                    {
                        float mycap = SithLordsPrevail.GlobalCap;
                        float ratio = SithLordsPrevail.GlobalConsumeRate;

                        Storage storage = BuildingTemplates.CreateDefaultStorage(go);
                        storage.capacityKg = mycap;

                        ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                        conduitConsumer.consumptionRate = 1.2f * ratio;
                        conduitConsumer.capacityKG = mycap;

                        ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
                        manualDeliveryKG.refillMass = 1.80000007f * ratio;
                        manualDeliveryKG.capacity = 7.20000029f * ratio;

                        ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
                        elementConverter.consumedElements = new ElementConverter.ConsumedElement[2]
                        {new ElementConverter.ConsumedElement(SimHashes.Oxygen.CreateTag(), 0.6f* ratio),new ElementConverter.ConsumedElement(SimHashes.Gold.CreateTag(), 0.003f* ratio)};
                        elementConverter.outputElements = new ElementConverter.OutputElement[1]
                        {new ElementConverter.OutputElement(0.6f* ratio, SimHashes.OxyRock, 303.15f, true, 0f, 0.5f, false, 1f, byte.MaxValue)};
                    }
                }
            }
            namespace Molecular_Forge
            {
                [HarmonyPatch(typeof(SupermaterialRefineryConfig), "ConfigureBuildingTemplate")]
                public static class SupermaterialRefineryStorage
                {
                    public static void Postfix(SupermaterialRefineryConfig __instance, ref GameObject go)
                    {
                        List<Storage.StoredItemModifier> mod = new List<Storage.StoredItemModifier>
                { Storage.StoredItemModifier.Hide, Storage.StoredItemModifier.Insulate,Storage.StoredItemModifier.Preserve, Storage.StoredItemModifier.Seal};
                        go.AddOrGet<ComplexFabricator>().inStorage.SetDefaultStoredItemModifiers(mod);
                        go.AddOrGet<ComplexFabricator>().buildStorage.SetDefaultStoredItemModifiers(mod);
                        go.AddOrGet<ComplexFabricator>().outStorage.SetDefaultStoredItemModifiers(mod);
                    }
                }
                [HarmonyPatch(typeof(SupermaterialRefineryConfig), "ConfigureBuildingTemplate")]
                public static class SupermaterialRefineryCarbonMod
                {
                    public static void Postfix()
                    {
                        Tag tag1 = SimHashes.Regolith.CreateTag();
                        Tag tag2 = SimHashes.Water.CreateTag();
                        Tag tag3 = SimHashes.IgneousRock.CreateTag();
                        Tag tag4 = SimHashes.Carbon.CreateTag();
                        string stag1 = ElementLoader.FindElementByHash(SimHashes.Regolith).name;
                        string stag2 = ElementLoader.FindElementByHash(SimHashes.Water).name;
                        string stag3 = ElementLoader.FindElementByHash(SimHashes.IgneousRock).name;
                        string stag4 = ElementLoader.FindElementByHash(SimHashes.Carbon).name;

                        ComplexRecipe.RecipeElement[] ingredients1 = new ComplexRecipe.RecipeElement[3]
                        {
                        new ComplexRecipe.RecipeElement(tag1, 1100f),
                        new ComplexRecipe.RecipeElement(tag2, 200f),
                        new ComplexRecipe.RecipeElement(tag3, 1100f)
                        };
                        ComplexRecipe.RecipeElement[] results1 = new ComplexRecipe.RecipeElement[1]
                        {
                    new ComplexRecipe.RecipeElement(tag4, 2000f)
                        };

                        string str1 = ComplexRecipeManager.MakeRecipeID("SupermaterialRefinery", ingredients1, results1);

                        new ComplexRecipe(str1, ingredients1, results1)
                        {
                            time = 0f,
                            useResultAsDescription = true,
                            displayInputAndOutput = true,
                            description = string.Format("Wash out with {3} those trails of {0} from a {1} + {2} mixture.\nRecipe discovered by Korriban Dynamics Alchemy Dept.", stag4, stag1, stag3, stag2)
                        }.fabricators = new List<Tag>() { TagManager.Create("SupermaterialRefinery") };

                    }
                }
                [HarmonyPatch(typeof(SupermaterialRefineryConfig), "ConfigureBuildingTemplate")]
                public static class SupermaterialRefinerySlimeMoldMod
                {
                    public static void Postfix()
                    {
                        Tag tag1 = SimHashes.Regolith.CreateTag();
                        Tag tag2 = SimHashes.Dirt.CreateTag();
                        Tag tag3 = SimHashes.DirtyWater.CreateTag();
                        Tag tag4 = SimHashes.Fossil.CreateTag();
                        Tag tag5 = SimHashes.SlimeMold.CreateTag();

                        string stag1 = ElementLoader.FindElementByHash(SimHashes.Regolith).name;
                        string stag2 = ElementLoader.FindElementByHash(SimHashes.Dirt).name;
                        string stag3 = ElementLoader.FindElementByHash(SimHashes.DirtyWater).name;
                        string stag4 = ElementLoader.FindElementByHash(SimHashes.Fossil).name;
                        string stag5 = ElementLoader.FindElementByHash(SimHashes.SlimeMold).name;

                        ComplexRecipe.RecipeElement[] ingredients1 = new ComplexRecipe.RecipeElement[4]
                        {
                    new ComplexRecipe.RecipeElement(tag1, 800f),
                    new ComplexRecipe.RecipeElement(tag2, 500f),
                    new ComplexRecipe.RecipeElement(tag3, 200f),
                    new ComplexRecipe.RecipeElement(tag4, 300f)

                        };
                        ComplexRecipe.RecipeElement[] results1 = new ComplexRecipe.RecipeElement[1]
                        {
                    new ComplexRecipe.RecipeElement(tag5, 1000f)
                        };

                        string str1 = ComplexRecipeManager.MakeRecipeID("SupermaterialRefinery", ingredients1, results1);

                        new ComplexRecipe(str1, ingredients1, results1)
                        {
                            time = 0f,
                            useResultAsDescription = true,
                            displayInputAndOutput = true,
                            description = string.Format("Wash out some {0} from {1} with {3}, adding some {2} and {4} for flavor.\nRecipe discovered by Korriban Dynamics Alchemy Dept.", /*0*/stag5, /*1*/stag1, /*2*/stag2, /*3*/stag3, /*4*/stag4)
                        }.fabricators = new List<Tag>() { TagManager.Create("SupermaterialRefinery") };
                    }
                }
                [HarmonyPatch(typeof(SupermaterialRefineryConfig), "ConfigureBuildingTemplate")]
                public static class SupermaterialRefineryDirtMod
                {
                    public static void Postfix()
                    {
                        Tag tag1 = SimHashes.Regolith.CreateTag();
                        Tag tag2 = SimHashes.Water.CreateTag();
                        Tag tag3 = SwampLilyFlowerConfig.ID.ToTag();
                        Tag tag4 = SimHashes.Dirt.CreateTag();

                        string stag1 = ElementLoader.FindElementByHash(SimHashes.Regolith).name;
                        string stag2 = ElementLoader.FindElementByHash(SimHashes.Water).name;
                        string stag3 = STRINGS.ITEMS.INGREDIENTS.SWAMPLILYFLOWER.NAME;
                        string stag4 = ElementLoader.FindElementByHash(SimHashes.Dirt).name;

                        ComplexRecipe.RecipeElement[] ingredients1 = new ComplexRecipe.RecipeElement[3]
                        {
                    new ComplexRecipe.RecipeElement(tag1, 1000f),
                    new ComplexRecipe.RecipeElement(tag2, 50f),
                    new ComplexRecipe.RecipeElement(tag3, 100f)

                        };
                        ComplexRecipe.RecipeElement[] results1 = new ComplexRecipe.RecipeElement[1]
                        {
                    new ComplexRecipe.RecipeElement(tag4, 300f)
                        };

                        string str1 = ComplexRecipeManager.MakeRecipeID("SupermaterialRefinery", ingredients1, results1);

                        new ComplexRecipe(str1, ingredients1, results1)
                        {
                            time = 0f,
                            useResultAsDescription = true,
                            displayInputAndOutput = true,
                            description = string.Format("I had a dream last night. We all were in a swamp lilly garden, watering the plants, when a metorite hit us.\nSuddenly, there was only dirt everywhere." +
                            "\nLet's mix some {0} with {2} and pour some {1} into it. Let's hope we'll have some {3} then.\nRecipe discovered by Korriban Dynamics Alchemy Dept.",
                            /*0-Regolith*/stag1, /*1-Water*/stag2, /*2-Lily*/stag3, /*3-Dirt*/stag4)
                        }.fabricators = new List<Tag>() { TagManager.Create("SupermaterialRefinery") };
                    }
                }
            }
        }
        namespace Medicine_Changes
        {
            namespace Wash_Basin { }
            namespace Sink { }
            namespace Hand_Sanitizer { }
            namespace Apothecary { }
            namespace Med_Bed { }
            namespace Pharma_Chamber { }
            namespace Massage_Table { }
            namespace Tasteful_Memorial { }
        }
        namespace Furniture_Changes
        {
            namespace Bedroom
            {
                namespace Cot { }
                namespace Comfy_Bed { }
            }
            namespace Lights
            {
                namespace Lamp { }
                namespace Ceiling_Light
                {
                    [HarmonyPatch(typeof(CeilingLightConfig), "CreateBuildingDef")]
                    public class CeilingLightPatch
                    {
                        static void Postfix(CeilingLightConfig __instance, ref BuildingDef __result)
                        {
                            __result.PermittedRotations = PermittedRotations.R360;
                            __result.SelfHeatKilowattsWhenActive = 0f;
                            __result.ExhaustKilowattsWhenActive = 0f;
                            __result.RequiresPowerInput = false;
                        }
                    }
                }
            }
            namespace Pots
            {
                namespace Flower_Pot { }
                namespace Wall_Pot { }
                namespace Hanging_Pot { }
                namespace Aero_Pot { }
            }
            namespace Pleasure
            {
                namespace Mess_Table { }
                namespace Water_Cooler { }
                namespace Jukebot { }
                namespace Arcade_Cabinet { }
                namespace Espresso_Machine { }
            }
            namespace Statues_and_Paintings
            {
                namespace Ice_Sculpture{ }
                namespace _Sculpture_
                {
                    [HarmonyPatch(typeof(SculptureConfig), "CreateBuildingDef")]
                    public class SculptureRotations
                    {
                        static void Postfix(SculptureConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.R360;
                    }
                }
                namespace Small_Sculpture_
                {
                    [HarmonyPatch(typeof(SmallSculptureConfig), "CreateBuildingDef")]
                    public class SmallSculptureRotations
                    {
                        static void Postfix(SmallSculptureConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.R360;
                    }
                }                
                namespace Marble_Sculpture
                {
                    [HarmonyPatch(typeof(MarbleSculptureConfig), "CreateBuildingDef")]
                    public class MarbleSculptureRotations
                    {
                        static void Postfix(MarbleSculptureConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.R360;
                    }
                }
                namespace Metal_Sculpture
                {
                    [HarmonyPatch(typeof(MetalSculptureConfig), "CreateBuildingDef")]
                    public class MetalSculptureRotations
                    {
                        static void Postfix(MetalSculptureConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.R360;
                    }
                }
                namespace Crown_Moulding { }
                namespace Corner_Moulding { }
                namespace Blank_Canvas { }
                namespace Landscape_Canvas { }
                namespace Portrait_Canvas { }
                namespace Pedestal { }
            }
        }
        namespace Stations_Changes
        {
            namespace Research_Station { }
            namespace Super_Computer { }
            namespace Virtual_Planetarium { }
            namespace Telescope_
            {
                //QOL2 - mod unfriendly
            }
            namespace Power_Control_Station { }
            namespace Farm_Station { }
            namespace Grooming_Station { }
            namespace Shearing_Station { }
            namespace Jobs_Board { }
            namespace Textile_Loom { }
            namespace Exosuit_Forge { }
            namespace Suits
            {
                namespace Exosuit_Checkpoint { }
                namespace Exosuit_Dock
                {
                    [HarmonyPatch(typeof(SuitLockerConfig), "CreateBuildingDef")]
                    class SuitLockerNoPower
                    {
                        public static void Postfix(SuitLockerConfig __instance, ref BuildingDef __result)
                        {
                            __result.RequiresPowerInput = DynamicBuildingsState.StateManager.State.SuitLockerRequiresPowerInput;
                            __result.EnergyConsumptionWhenActive = DynamicBuildingsState.StateManager.State.SuitLockerEnergyConsumption;
                           // __result.BaseDecor = 0f;
                        }
                    }

                    [HarmonyPatch(typeof(SuitLockerConfig), "ConfigureBuildingTemplate")]
                    class SuitLockerConsumptionRate
                    {
                        public static void Postfix(SuitLockerConfig __instance, ref GameObject go)
                        {
                            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                            conduitConsumer.consumptionRate = SithLordsPrevail.GlobalConsumeRate;
                            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Store;
                            go.AddOrGet<DropAllWorkable>();
                        }
                    }
                }
                namespace Jet_Suit_Checkpoint { }
                namespace Jet_Suit_Dock { }
            }
            namespace Space_Cadet_Centrifuge { }
        }
        namespace Utilities_Changes
        {
            namespace Cooling
            {
                namespace Hydrofan { }
                namespace Thermo_Regulator
                {
                    [HarmonyPatch(typeof(AirConditionerConfig), "ConfigureBuildingTemplate")]
                    public class AirConditionerConfigPatch
                    {
                        static void Postfix(AirConditionerConfig __instance, ref GameObject go)
                        {
                            AirConditioner airConditioner = go.AddOrGet<AirConditioner>();
                            airConditioner.temperatureDelta = DynamicBuildingsState.StateManager.State.Thermos;
                            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                            conduitConsumer.consumptionRate = SithLordsPrevail.GlobalConsumeRate;
                        }
                    }

                    [HarmonyPatch(typeof(AirConditionerConfig), "CreateBuildingDef")]
                    public class AirConditionerConfigPatch2
                    {
                        static void Postfix(AirConditionerConfig __instance, ref BuildingDef __result)
                        {
                            if (!DynamicBuildingsState.StateManager.State.CoolingCheat) { __result.MassForTemperatureModification = 0f; }
                            __result.PermittedRotations = PermittedRotations.R360;
                            __result.BuildLocationRule = BuildLocationRule.Anywhere;
                            __result.ContinuouslyCheckFoundation = false;
                        }
                    }

                }
                namespace Thermo_Aquatuner
                {
                    [HarmonyPatch(typeof(LiquidConditionerConfig), "ConfigureBuildingTemplate")]
                    public class LiquidConditionerConfigPatch
                    {
                        static void Postfix(LiquidConditionerConfig __instance, ref GameObject go)
                        {
                            AirConditioner airConditioner = go.AddOrGet<AirConditioner>();
                            airConditioner.temperatureDelta = DynamicBuildingsState.StateManager.State.Thermos;
                            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                            conduitConsumer.consumptionRate = SithLordsPrevail.GlobalConsumeRate;
                        }
                    }

                    [HarmonyPatch(typeof(LiquidConditionerConfig), "CreateBuildingDef")]
                    public class LiquidConditionerConfigPatch2
                    {
                        static void Postfix(LiquidConditionerConfig __instance, ref BuildingDef __result)
                        {
                            if (!DynamicBuildingsState.StateManager.State.CoolingCheat) { __result.MassForTemperatureModification = 0f; }
                            __result.PermittedRotations = PermittedRotations.R360;
                            __result.BuildLocationRule = BuildLocationRule.Anywhere;
                            __result.ContinuouslyCheckFoundation = false;
                        }
                    }
                }
                namespace Tempshift_Plate { }
                namespace Ice__Machine___
                {
                    [HarmonyPatch(typeof(IceMachineConfig), "ConfigureBuildingTemplate")]
                    public class IceMachineConfig1
                    {
                        static void Postfix(IceMachineConfig __instance, ref GameObject go)
                        {
                            Storage storage = go.AddOrGet<Storage>();
                            storage.SetDefaultStoredItemModifiers(Storage.StandardInsulatedStorage);
                            storage.showInUI = true;
                            storage.capacityKg = 10000f;
                            Storage storage2 = go.AddComponent<Storage>();
                            storage2.SetDefaultStoredItemModifiers(Storage.StandardInsulatedStorage);
                            storage2.showInUI = true;
                            storage2.capacityKg = 10000f;
                            ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
                            manualDeliveryKG.capacity = 10000f;
                        }
                    }

                    [HarmonyPatch(typeof(IceMachineConfig), "CreateBuildingDef")]
                    public class IceMachine2
                    {
                        static void Postfix(IceMachineConfig __instance, ref BuildingDef __result)
                        {
                            __result.PermittedRotations = PermittedRotations.R360;
                        }
                    }
                }
            }
            namespace Heating
            {
                namespace Space_Heater { }
                namespace Liquid_Tepidizer { }
            }
            namespace Ore_Scrubber { }
            namespace Oil_Well
            {
                [HarmonyPatch(typeof(OilWellCapConfig), "ConfigureBuildingTemplate")]
                public static class OilWellCapConfigPatch
                {
                    static void Postfix(OilWellCapConfig __instance, ref GameObject go)
                    {
                        float mycap = SithLordsPrevail.GlobalCap;
                        float ratio = SithLordsPrevail.GlobalConsumeRate;

                        Storage storage = BuildingTemplates.CreateDefaultStorage(go);
                        storage.capacityKg = mycap;

                        ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                        conduitConsumer.consumptionRate = ratio;
                        conduitConsumer.capacityKG = 10f * ratio;

                        ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
                        elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
                        {
                    new ElementConverter.ConsumedElement(new Tag("Water"), ratio)
                        };
                        elementConverter.outputElements = new ElementConverter.OutputElement[1]
                        {
                    new ElementConverter.OutputElement(3.33333325f*ratio, SimHashes.CrudeOil, 363.15f, false, 2f, 1.5f, false, 0f, byte.MaxValue)
                        };
                        OilWellCap oilWellCap = go.AddOrGet<OilWellCap>();
                        oilWellCap.addGasRate = 0.0333333351f * ratio;
                        oilWellCap.maxGasPressure = 80.00001f * ratio;
                        oilWellCap.releaseGasRate = 0.444444478f * ratio;
                    }
                }
                [HarmonyPatch(typeof(OilWellCapConfig), "CreateBuildingDef")] public static class OilWellCapRotations { public static void Postfix(OilWellCapConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.FlipH; }
            }
            namespace Drywall { }
        }
        namespace Automation_Changes
        {
            namespace Automation_Wire
            {
                [HarmonyPatch(typeof(LogicWireConfig), "CreateBuildingDef")]
                public class LogicWirePatch
                {
                    static void Postfix(LogicWireConfig __instance, ref BuildingDef __result)
                    {
                        __result.Invincible = true;
                    }
                }
            }
            namespace Automation_Wire_Bridge { }
            namespace LOGIC
            {
                namespace AND_Gate { }
                namespace OR_Gate { }
                namespace XOR_Gate { }
                namespace NOT_Gate { }
                namespace BUFFER_Gate { }
                namespace FILTER_Gate { }
                namespace Memory_Toggle { }
            }
            namespace Automation_Sensors
            {
                namespace Atmo_Sensor { }
                namespace Hydro_Sensor { }
                namespace Thermo_Sensor { }
                namespace Clock_Sensor { }
                namespace Germ_Sensor { }
                namespace Gaseous_Element_Sensor { }
                namespace Critter_Sensor { }
                namespace Weight_Plate { }
                namespace Duplicant_Checkpoint { }
                namespace Space_Scanner { }
            }
            namespace Signal_Switch { }
        }
        namespace Shipping_Changes
        {
            namespace Auto_Sweeper
            {
                [HarmonyPatch(typeof(SolidTransferArmConfig), "CreateBuildingDef")]
                class SweeperNoPower
                {
                    public static void Postfix(SolidTransferArmConfig __instance, ref BuildingDef __result)
                    {
                        __result.RequiresPowerInput = DynamicBuildingsState.StateManager.State.SweeperRequiresPowerInput;
                        __result.EnergyConsumptionWhenActive = DynamicBuildingsState.StateManager.State.SweeperEnergyConsumption;
                    }
                }
                [HarmonyPatch(typeof(SolidTransferArm), "OnPrefabInit")]
                public static class SweeperCarryCapacityPatch
                {
                    static void Prefix(ref float ___max_carry_weight)
                    {
                        ___max_carry_weight = DynamicBuildingsState.StateManager.State.STA;
                    }
                }
            }
            namespace Conveyor_Rail
            {
                [HarmonyPatch(typeof(SolidConduitDispenser), "ConduitUpdate")]
                public static class MotherfuckingBitchAssFaggotNigger
                {
                    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                    {

                        var codes = new List<CodeInstruction>(instructions);
                        for (int i = 0; i < codes.Count; i++)
                        {
                            if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 20f))
                            {
                                {
                                    codes[i].operand = (Single)DynamicBuildingsState.StateManager.State.Solid;
                                }
                            }
                        }

                        return codes.AsEnumerable();
                    }
                }
                [HarmonyPatch(typeof(SolidConduitConfig), "CreateBuildingDef")]
                public static class SolidConduitPatch
                {
                    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                    {

                        var codes = new List<CodeInstruction>(instructions);
                        for (int i = 0; i < codes.Count; i++)
                        {
                            if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 1600f))
                            {
                                {
                                    codes[i].operand = 9000f;
                                }
                            }
                        }

                        return codes.AsEnumerable();
                    }
                }
            }
            namespace Conveyor_Loader
            {
                [HarmonyPatch(typeof(SolidConduitInboxConfig), "DoPostConfigureComplete")]
                public class SolidConduitInboxConfigCapacityPatch
                {
                    static void Postfix(SolidConduitInboxConfig __instance, ref GameObject go)
                    {
                        Storage storage = go.AddOrGet<Storage>();
                        storage.capacityKg = DynamicBuildingsState.StateManager.State.ConLoaderCap;
                    }
                }
            }
            namespace Conveyor_Receptacle
            {
                [HarmonyPatch(typeof(SolidConduitOutboxConfig), "ConfigureBuildingTemplate")]
                public class SolidConduitOutboxConfigCapacityPatch
                {
                    static void Postfix(SolidConduitOutboxConfig __instance, ref GameObject go)
                    {
                        Storage storage = BuildingTemplates.CreateDefaultStorage(go);
                        storage.capacityKg = DynamicBuildingsState.StateManager.State.ConUnloaderCap;
                        go.AddOrGet<SolidConduitConsumer>().capacityKG = DynamicBuildingsState.StateManager.State.ConUnloaderCap;
                    }
                }
            }
            namespace Conveyor_Bridge { }
            namespace Robo_Miner
            {
            //    [HarmonyPatch(typeof(AutoMinerConfig), "CreateBuildingDef")]
            //    public class AutoMinerConfig_Entomb
            //    {
            //        static void Postfix(AutoMinerConfig __instance, ref BuildingDef __result)
            //        {
            //            __result.Entombable = false;
            //        }
            //    }
            //    [HarmonyPatch(typeof(AutoMinerConfig), "DoPostConfigureComplete")]
            //    public class AutoMinerConfig_Distance
            //    {
            //        static void Postfix(AutoMinerConfig __instance, ref GameObject go)
            //        {
            //            AutoMiner autoMiner = go.AddOrGet<AutoMiner>();
            //            autoMiner.x = -17;
            //            autoMiner.y = 0;
            //            autoMiner.width = 36;
            //            autoMiner.height = 100;
            //        }
            //    }
            //    [HarmonyPatch(typeof(AutoMinerConfig), "AddVisualizer")]
            //    public class AutoMinerConfig_DistanceVisual
            //    {
            //        static void Postfix(AutoMinerConfig __instance, ref GameObject prefab)
            //        {
            //            StationaryChoreRangeVisualizer stationaryChoreRangeVisualizer = prefab.AddOrGet<StationaryChoreRangeVisualizer>();
            //            stationaryChoreRangeVisualizer.x = -17;
            //            stationaryChoreRangeVisualizer.y = 0;
            //            stationaryChoreRangeVisualizer.width = 36;
            //            stationaryChoreRangeVisualizer.height = 100;
            //        }
            //    }
            }
        }
        namespace Rocketry_Changes
        {
            namespace Fuel_and_Fueltanks
            {
                namespace Fuel_Tank
                {
                    [HarmonyPatch(typeof(FuelTank), "MaxCapacity", MethodType.Getter)]
                    public static class FuelTankPatch
                    {
                        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                        {
                            var codes = new List<CodeInstruction>(instructions);
                            for (int i = 0; i < codes.Count; i++)
                            {
                                if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 900f)) { codes[i].operand = 3000f; }
                            }
                            return codes.AsEnumerable();
                        }
                    }
                }
                namespace Solid_Fuel_Thruster { }
                namespace Liquid_Fuel_Tank
                {
                    [HarmonyPatch(typeof(LiquidFuelTankConfig), "DoPostConfigureComplete")]
                    public static class LiquidFuelTankPatch
                    {
                        static void Postfix(LiquidFuelTankConfig __instance, ref GameObject go)
                        {
                            float mycapacity = 3000f;
                            float rate = SithLordsPrevail.GlobalConsumeRate;

                            FuelTank fuelTank = go.AddOrGet<FuelTank>();
                            fuelTank.capacityKg = mycapacity;
                            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                            conduitConsumer.consumptionRate = rate;
                            conduitConsumer.capacityKG = mycapacity;
                        }
                    }
                }
                namespace Solid_Oxidizer_Tank
                {
                    [HarmonyPatch(typeof(OxidizerTankConfig), "DoPostConfigureComplete")]
                    public static class OxidizerTankPatch
                    {
                        static void Postfix(OxidizerTankConfig __instance, ref GameObject go)
                        {
                            float mycapacity = 3000f;

                            Storage storage = go.AddOrGet<Storage>();
                            storage.capacityKg = mycapacity;
                            ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
                            manualDeliveryKG.refillMass = mycapacity;
                            manualDeliveryKG.capacity = mycapacity;
                        }
                    }
                }
                namespace Liquid_Oxidizer_Tank
                {
                    [HarmonyPatch(typeof(OxidizerTankLiquidConfig), "DoPostConfigureComplete")]
                    public static class OxidizerTankLiquidPatch
                    {
                        static void Postfix(OxidizerTankLiquidConfig __instance, ref GameObject go)
                        {
                            float mycapacity = 3000f;
                            float rate = SithLordsPrevail.GlobalConsumeRate;

                            Storage storage = go.AddOrGet<Storage>();
                            storage.capacityKg = mycapacity;
                            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                            conduitConsumer.consumptionRate = rate;
                            conduitConsumer.capacityKG = mycapacity;
                        }
                    }
                }
            }
            namespace Steam_Engine
            {
                [HarmonyPatch(typeof(SteamEngineConfig), "CreateBuildingDef")]
                public static class SteamEngine_Mass
                {
                    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                    {
                        var codes = new List<CodeInstruction>(instructions);
                        FieldInfo fieldInfoF1 = AccessTools.Field(typeof(BUILDINGS.CONSTRUCTION_MASS_KG), nameof(BUILDINGS.CONSTRUCTION_MASS_KG.TIER7));
                        FieldInfo fieldInfoF2 = AccessTools.Field(typeof(BUILDINGS.CONSTRUCTION_MASS_KG), nameof(BUILDINGS.CONSTRUCTION_MASS_KG.TIER_TINY));
                        for (int i = 0; i < codes.Count; i++)
                        {
                            CodeInstruction instruction = codes[index: i];
                            if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1)
                            {
                                instruction.operand = fieldInfoF2;
                            }
                        }
                        return codes.AsEnumerable();
                    }
                }
                [HarmonyPatch(typeof(SteamEngineConfig), "DoPostConfigureComplete")]
                public static class SteamEnginePatch1
                {
                    static void Prefix(SteamEngineConfig __instance, ref GameObject go)
                    {
                        float rate = SithLordsPrevail.GlobalConsumeRate;
                        float mycapacity = 3000f;

                        FuelTank fuelTank = go.AddOrGet<FuelTank>();
                        fuelTank.capacityKg = mycapacity;
                        ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                        conduitConsumer.consumptionRate = rate;
                        conduitConsumer.capacityKG = mycapacity;
                    }
                    static void Postfix(SteamEngineConfig __instance, ref GameObject go)
                    {
                        float rate = SithLordsPrevail.GlobalConsumeRate;
                        float mycapacity = 3000f;

                        FuelTank fuelTank = go.AddOrGet<FuelTank>();
                        fuelTank.capacityKg = mycapacity;
                        ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                        conduitConsumer.consumptionRate = rate;
                        conduitConsumer.capacityKG = mycapacity;
                    }
                }
            }
            namespace Gantry { }
            namespace Petroleum_Engine { }
            namespace Cargo_Bay
            {
                [HarmonyPatch(typeof(CargoBayConfig), "DoPostConfigureComplete")]
                public class CargoBayStorage
                {
                    static void Postfix(CargoBayConfig __instance, ref GameObject go)
                    {
                        CargoBay cargoBay = go.AddOrGet<CargoBay>();
                        cargoBay.storage = go.AddOrGet<Storage>();
                        cargoBay.storageType = CargoBay.CargoType.solids;
                        cargoBay.storage.capacityKg = SithLordsPrevail.GlobalRocketCap; 
                        cargoBay.storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
                    }
                }
            }
            namespace Gas_Cargo_Bay
            {
                [HarmonyPatch(typeof(GasCargoBayConfig), "DoPostConfigureComplete")]
                public class Liquid_Cargo_Bay_Storage
                {
                    static void Postfix(GasCargoBayConfig __instance, ref GameObject go)
                    {
                        CargoBay cargoBay = go.AddOrGet<CargoBay>();
                        cargoBay.storage = go.AddOrGet<Storage>();
                        cargoBay.storageType = CargoBay.CargoType.gasses;
                        cargoBay.storage.capacityKg = SithLordsPrevail.GlobalRocketCap;
                        cargoBay.storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
                    }
                }
            }
            namespace Liquid_Cargo_Bay
            {
                [HarmonyPatch(typeof(LiquidCargoBayConfig), "DoPostConfigureComplete")]
                public class Liquid_Cargo_Bay_Storage
                {
                    static void Postfix(LiquidCargoBayConfig __instance, ref GameObject go)
                    {
                        CargoBay cargoBay = go.AddOrGet<CargoBay>();
                        cargoBay.storage = go.AddOrGet<Storage>();
                        cargoBay.storageType = CargoBay.CargoType.liquids;
                        cargoBay.storage.capacityKg = SithLordsPrevail.GlobalRocketCap;
                        cargoBay.storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
                    }
                }
            }
            namespace Command_Capsule { }
            namespace Sight_Seeing_Module { }
            namespace Research_Module { }
            namespace Biological_Cargo_Bay
            {
                [HarmonyPatch(typeof(SpecialCargoBayConfig), "DoPostConfigureComplete")]
                public class Biological_Cargo_Bay_Storage
                {
                    static void Postfix(SpecialCargoBayConfig __instance, ref GameObject go)
                    {
                        CargoBay cargoBay = go.AddOrGet<CargoBay>();
                        cargoBay.storage = go.AddOrGet<Storage>();
                        cargoBay.storageType = CargoBay.CargoType.entities;
                        cargoBay.storage.capacityKg = SithLordsPrevail.GlobalRocketCap/10f;
                    }
                }
            }
            namespace Hydrogen_Engine { }
        }
    }

    namespace UI_and_QOL_mods
    {
        namespace ColdBreather_
        {
            [HarmonyPatch(typeof(ColdBreatherConfig), "CreatePrefab")]
                public static class ColdBreatherConfigDynamicPatch
                {
                    public static void Postfix(ColdBreatherConfig __instance, ref GameObject __result)
                    {
                        float tiledelta = DynamicBuildingsState.StateManager.State.ColdBreezeToTile;
                        float delta = DynamicBuildingsState.StateManager.State.WheezTemp;
                        float Wmin = DynamicBuildingsState.StateManager.State.WheezMin + 273.15f;
                        float Wmax = DynamicBuildingsState.StateManager.State.WheezMax + 273.15f;

                        TemperatureVulnerable temperatureVulnerable = __result.AddOrGet<TemperatureVulnerable>();
                        //temperatureVulnerable.Configure(213.15f, 183.15f, 368.15f, 463.15f); (-60,-90,95,190)
                        temperatureVulnerable.Configure(Wmin, Wmin - 20f, Wmax, Wmax + 100);

                        ColdBreather coldBreather = __result.AddOrGet<ColdBreather>();
                        coldBreather.deltaEmitTemperature = delta;
                        coldBreather.emitOffsetCell = new Vector3(0f, tiledelta);

                        ElementConsumer elementConsumer = __result.AddOrGet<ElementConsumer>();
                        elementConsumer.capacityKG = 20f;
                        elementConsumer.consumptionRate = 5f;
                        elementConsumer.consumptionRadius = 3;

                    }

                }
            }
        namespace UI
        {
            [HarmonyPatch(typeof(PlanScreen), MethodType.Constructor)]
                public static class PlanScreenMOAR
                {
                    public static void Postfix(PlanScreen __instance)
                    {
                        AccessTools.Field(typeof(PlanScreen), "buildGrid_maxRowsBeforeScroll").SetValue(__instance, 8);
                    }
                }
            }
        namespace LiquidAndGasPipesCapacity
        {
            [HarmonyPatch(typeof(ConduitFlow), MethodType.Constructor, new Type[] { typeof(ConduitType), typeof(int), typeof(IUtilityNetworkMgr), typeof(float), typeof(float) })]
                public static class PipesMass
                {
                    public static void Prefix(ConduitType conduit_type, int num_cells, IUtilityNetworkMgr network_mgr, ref float max_conduit_mass, float initial_elapsed_time)
                    { max_conduit_mass = SithLordsPrevail.GlobalConsumeRate; }
                }
            }
        namespace Meteors
        {
            [HarmonyPatch(typeof(SeasonManager), MethodType.Constructor)]
                public static class MeteorFrequency
                {
                    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                    {
                        var codes = new List<CodeInstruction>(instructions);
                        for (int i = 0; i < codes.Count; i++)
                        {
                            if (codes[i].opcode == OpCodes.Ldc_I4_4)
                            {
                                codes[i].opcode = OpCodes.Ldc_I4;
                                codes[i].operand = 50;

                            }
                        }
                        return codes.AsEnumerable();
                    }
                }
            }
        namespace MinionsOfTheVoid
        {
            [HarmonyPatch(typeof(MinionConfig), "CreatePrefab")]
                public static class StaminaPatch
                {
                    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                    {
                        var codes = new List<CodeInstruction>(instructions);
                        for (int i = 0; i < codes.Count; i++)
                        {
                            if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == -0.116666667f))
                            {
                                if (DynamicBuildingsState.StateManager.State.DupeNoWantSleep) { codes[i].operand = 0f; } else { codes[i].operand = -0.116666667f; }
                            }
                        }
                        return codes.AsEnumerable();
                    }
                }

                [HarmonyPatch(typeof(MinionConfig), "CreatePrefab")]
                public static class BladderPatch
                {
                    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                    {
                        var codes = new List<CodeInstruction>(instructions);
                        for (int i = 0; i < codes.Count; i++)
                        {
                            if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 0.166666672f))
                            {
                                if (DynamicBuildingsState.StateManager.State.DupeNoWantPee) { codes[i].operand = 0f; } else { codes[i].operand = 0.166666672f; }
                            }
                        }
                        return codes.AsEnumerable();
                    }
                }

            }
        namespace Mopper
        {
            [HarmonyPatch(typeof(MopTool), MethodType.Constructor)]
                class MopToolPatch
                {
                    public static void Prefix(ref float ___maxMopAmt)
                    {
                        bool MopMeMax = DynamicBuildingsState.StateManager.State.MopMax;
                        ___maxMopAmt = MopMeMax ? 9999f : 150f;
                    }
                }
            }
        namespace DatabaseTinkers
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
                class TheDBCheats
                {
                    private static void Prefix(Db __instance)
                    {
                     BUILDINGS.ROCKETRY_MASS_KG.COMMAND_MODULE_MASS = new float[] {1f };
                     BUILDINGS.ROCKETRY_MASS_KG.OXIDIZER_TANK_OXIDIZER_MASS = new float[] { 1f };
                     BUILDINGS.ROCKETRY_MASS_KG.FUEL_TANK_DRY_MASS = new float[] { 1f };
                     BUILDINGS.ROCKETRY_MASS_KG.FUEL_TANK_WET_MASS = new float[] {1f };
                     BUILDINGS.ROCKETRY_MASS_KG.ENGINE_MASS_LARGE = new float[] { 1f };
                     BUILDINGS.ROCKETRY_MASS_KG.ENGINE_MASS_SMALL = new float[] { 1f };
                     BUILDINGS.ROCKETRY_MASS_KG.CARGO_MASS= new float[] { 1f,1f };
                     ROLES.PASSIVE_EXPERIENCE_SCALE = 1f;
                     ROCKETRY.CARGO_CONTAINER_MASS.PAYLOAD_MASS = 1f;
                     ROCKETRY.CARGO_CONTAINER_MASS.STATIC_MASS = 1f;
                     CREATURES.SPACE_REQUIREMENTS.TIER2 = 1;
                     CREATURES.SPACE_REQUIREMENTS.TIER3 = 1;
                     CREATURES.SPACE_REQUIREMENTS.TIER4 = 1;
                    DUPLICANTSTATS.MAX_TRAITS = 6;
                    switch (SithLordsPrevail.MyDistance)
                    {
                        case 0:ROCKETRY.MISSION_DURATION_SCALE =1f;break;
                        case 1:ROCKETRY.MISSION_DURATION_SCALE =60f; break;
                        case 2: ROCKETRY.MISSION_DURATION_SCALE = 300f; break;
                        case 3: ROCKETRY.MISSION_DURATION_SCALE = 600f; break;
                        case 4: ROCKETRY.MISSION_DURATION_SCALE = 1200f; break;
                        case 5: ROCKETRY.MISSION_DURATION_SCALE = 1800f; break;
                        case 6: ROCKETRY.MISSION_DURATION_SCALE = 2400f; break;
                        case 7: ROCKETRY.MISSION_DURATION_SCALE = 3000f; break;
                        case 8: ROCKETRY.MISSION_DURATION_SCALE = 3600f; break;
                        case 9: ROCKETRY.MISSION_DURATION_SCALE = 4200f; break;
                        case 10: ROCKETRY.MISSION_DURATION_SCALE =4800f; break;
                        case 11: ROCKETRY.MISSION_DURATION_SCALE =5400f; break;
                        case 12: ROCKETRY.MISSION_DURATION_SCALE =6000f; break;
                    }
                }
            }
/*
                [HarmonyPatch(typeof(ElementLoader), "LoadUserElementData")]
                public static class StoreThatSolidGasesYouBitch
                {
                    public static void Postfix()
                    {
                        Element SolidCarbonDioxide = ElementLoader.FindElementByHash(SimHashes.SolidCarbonDioxide);
                        Element SolidChlorine = ElementLoader.FindElementByHash(SimHashes.SolidChlorine);
                        Element SolidHydrogen = ElementLoader.FindElementByHash(SimHashes.SolidHydrogen);
                        Element SolidOxygen = ElementLoader.FindElementByHash(SimHashes.SolidOxygen);
                        Element SolidPropane = ElementLoader.FindElementByHash(SimHashes.SolidPropane);

                        SolidCarbonDioxide.materialCategory = "ConsumableOre";
                        SolidCarbonDioxide.oreTags = CreateTags(SolidCarbonDioxide.materialCategory, new[] { "ConsumableOre" });
                        GameTags.SolidElements.Add(SolidCarbonDioxide.tag);

                        SolidChlorine.materialCategory = "ConsumableOre";
                        SolidChlorine.oreTags = CreateTags(SolidChlorine.materialCategory, new[] { "ConsumableOre" });
                        GameTags.SolidElements.Add(SolidChlorine.tag);

                        SolidHydrogen.materialCategory = "ConsumableOre";
                        SolidHydrogen.oreTags = CreateTags(SolidHydrogen.materialCategory, new[] { "ConsumableOre" });
                        GameTags.SolidElements.Add(SolidHydrogen.tag);

                        SolidOxygen.materialCategory = "ConsumableOre";
                        SolidOxygen.oreTags = CreateTags(SolidOxygen.materialCategory, new[] { "ConsumableOre" });
                        GameTags.SolidElements.Add(SolidOxygen.tag);

                        SolidPropane.materialCategory = "ConsumableOre";
                        SolidPropane.oreTags = CreateTags(SolidPropane.materialCategory, new[] { "ConsumableOre" });
                        GameTags.SolidElements.Add(SolidPropane.tag);
                    }
                    public static Tag[] CreateTags(Tag materialCategory, string[] tags)
                    {
                        List<Tag> tagList = new List<Tag>();
                        if (tags != null)
                        {
                            foreach (string tag_string in tags)
                            {
                                if (!string.IsNullOrEmpty(tag_string))
                                    tagList.Add(TagManager.Create(tag_string));
                            }
                        }

                        tagList.Add(TagManager.Create(Element.State.Solid.ToString()));

                        if (materialCategory.IsValid && !tagList.Contains(materialCategory))
                            tagList.Add(materialCategory);

                        return tagList.ToArray();
                    }

                }
*/
            }
        namespace AddHardiness
        {
            [HarmonyPatch(typeof(MaterialSelector), "SetEffects")]
                internal class AddHardinessSTRINGS
                {
                    public static void Postfix(MaterialSelector __instance, ref Tag element)
                    {
                        if (element == "BasicFabric") return;
                        List<Descriptor> materialDescriptors = GameUtil.GetMaterialDescriptors(element);
                        Element myelement = ElementLoader.FindElementByName(element.ToString());
                        if (materialDescriptors.Count > 0)
                        {
                            Descriptor item = default;

                            item.SetupDescriptor(
                                STRINGS.UI.FormatAsLink("   Hardness", "HARDNESS") + " : " + myelement.hardness.ToString(), "Element's hardness. Data provided by Korriban Dynamics.", Descriptor.DescriptorType.Effect); materialDescriptors.Insert(0, item);
                            item.SetupDescriptor(
                                STRINGS.UI.FormatAsLink("   Meltdown T", "HIGHTEMP") + " : ~" + (myelement.highTemp - 273.15f).ToString("0.00") + "°C", "Element's meltdown temperature. Data provided by Korriban Dynamics.", Descriptor.DescriptorType.Effect); materialDescriptors.Insert(0, item);
                            item.SetupDescriptor(
                                STRINGS.UI.FormatAsLink("   Heat capacity", "SPECIFICHEATCAPACITY") + " : " + myelement.specificHeatCapacity.ToString("0.00"), "Element's heat capacity. Data provided by Korriban Dynamics.", Descriptor.DescriptorType.Effect); materialDescriptors.Insert(0, item);
                            item.SetupDescriptor(
                                STRINGS.UI.FormatAsLink("   Thermal conductivity", "THERMALCONDUCTIVITY") + " : " + myelement.thermalConductivity.ToString("0.00"), "Element's thermal conductivity. Data provided by Korriban Dynamics.", Descriptor.DescriptorType.Effect); materialDescriptors.Insert(0, item);


                            __instance.MaterialEffectsPane.gameObject.SetActive(true);
                            __instance.MaterialEffectsPane.SetDescriptors(materialDescriptors);
                        }
                        else
                        {
                            __instance.MaterialEffectsPane.gameObject.SetActive(false);
                        }
                    }
                }
            }
        namespace NoPingForYouKurwa
        {
            public class NoAutoSave
            {
                [HarmonyPatch(typeof(GameClock),"DoAutoSave")]
                public static class AutoSave_ornot
                {
                    public static bool Prefix()
                    {
                        bool AS = DynamicBuildingsState.StateManager.State.AutoSave;
                        return AS ? true : false;
                    }
                }
            }
        }
        namespace AllBuildable
        {
            public class temptemptemp
            {     //if (SithLordsPrevail.AllShit) { return; }
                [HarmonyPatch(typeof(AdvancedResearchCenterConfig), "CreateBuildingDef")] public static class AdvancedResearchCenterConfig_Material {static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(AirConditionerConfig), "CreateBuildingDef")] public static class AirConditionerConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(AirFilterConfig), "CreateBuildingDef")] public static class AirFilterConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(AlgaeDistilleryConfig), "CreateBuildingDef")] public static class AlgaeDistilleryConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(ApothecaryConfig), "CreateBuildingDef")] public static class ApothecaryConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(ArcadeMachineConfig), "CreateBuildingDef")] public static class ArcadeMachineConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(AstronautTrainingCenterConfig), "CreateBuildingDef")] public static class AstronautTrainingCenterConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(AutoMinerConfig), "CreateBuildingDef")] public static class AutoMinerConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(BedConfig), "CreateBuildingDef")] public static class BedConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(BottleEmptierConfig), "CreateBuildingDef")] public static class BottleEmptierConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(BottleEmptierGasConfig), "CreateBuildingDef")] public static class BottleEmptierGasConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(CO2ScrubberConfig), "CreateBuildingDef")] public static class CO2ScrubberConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(CeilingLightConfig), "CreateBuildingDef")] public static class CeilingLightConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(CheckpointConfig), "CreateBuildingDef")] public static class CheckpointConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(ClothingFabricatorConfig), "CreateBuildingDef")] public static class ClothingFabricatorConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(CometDetectorConfig), "CreateBuildingDef")] public static class CometDetectorConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(CompostConfig), "CreateBuildingDef")] public static class CompostConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(TravelTubeConfig), "CreateBuildingDef")] public static class TravelTubeConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.PLASTICS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(TravelTubeEntranceConfig), "CreateBuildingDef")] public static class TravelTubeEntranceConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(TravelTubeWallBridgeConfig), "CreateBuildingDef")] public static class TravelTubeWallBridgeConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.PLASTICS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(CookingStationConfig), "CreateBuildingDef")] public static class CookingStationConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(CosmicResearchCenterConfig), "CreateBuildingDef")] public static class CosmicResearchCenterConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(CreatureDeliveryPointConfig), "CreateBuildingDef")] public static class CreatureDeliveryPointConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(CreatureFeederConfig), "CreateBuildingDef")] public static class CreatureFeederConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(DiningTableConfig), "CreateBuildingDef")] public static class DiningTableConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(EggCrackerConfig), "CreateBuildingDef")] public static class EggCrackerConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(EggIncubatorConfig), "CreateBuildingDef")] public static class EggIncubatorConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(ElectrolyzerConfig), "CreateBuildingDef")] public static class ElectrolyzerConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(EspressoMachineConfig), "CreateBuildingDef")] public static class EspressoMachineConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(ExteriorWallConfig), "CreateBuildingDef")] public static class ExteriorWallConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(FarmStationConfig), "CreateBuildingDef")] public static class FarmStationConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(FertilizerMakerConfig), "CreateBuildingDef")] public static class FertilizerMakerConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(FirePoleConfig), "CreateBuildingDef")] public static class FirePoleConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(SolidConduitBridgeConfig), "CreateBuildingDef")] public static class SolidConduitBridgeConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                [HarmonyPatch(typeof(SolidConduitConfig), "CreateBuildingDef")] public static class SolidConduitConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                [HarmonyPatch(typeof(SolidConduitInboxConfig), "CreateBuildingDef")] public static class SolidConduitInboxConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                [HarmonyPatch(typeof(SolidConduitOutboxConfig), "CreateBuildingDef")] public static class SolidConduitOutboxConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                [HarmonyPatch(typeof(SolidTransferArmConfig), "CreateBuildingDef")] public static class SolidTransferArmConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                [HarmonyPatch(typeof(WireBridgeConfig), "CreateBuildingDef")] public static class WireBridgeConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(WireBridgeHighWattageConfig), "CreateBuildingDef")] public static class WireBridgeHighWattageConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(WireRefinedBridgeConfig), "CreateBuildingDef")] public static class WireRefinedBridgeConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(WireRefinedBridgeHighWattageConfig), "CreateBuildingDef")] public static class WireRefinedBridgeHighWattageConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(FishDeliveryPointConfig), "CreateBuildingDef")] public static class FishDeliveryPointConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(FishFeederConfig), "CreateBuildingDef")] public static class FishFeederConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(FloorLampConfig), "CreateBuildingDef")] public static class FloorLampConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(FloorSwitchConfig), "CreateBuildingDef")] public static class FloorSwitchConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(FlowerVaseConfig), "CreateBuildingDef")] public static class FlowerVaseConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(FlowerVaseHangingConfig), "CreateBuildingDef")] public static class FlowerVaseHangingConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(FlowerVaseHangingFancyConfig), "CreateBuildingDef")] public static class FlowerVaseHangingFancyConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.TRANSPARENTS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(FlowerVaseWallConfig), "CreateBuildingDef")] public static class FlowerVaseWallConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(FlushToiletConfig), "CreateBuildingDef")] public static class FlushToiletConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(GasBottlerConfig), "CreateBuildingDef")] public static class GasBottlerConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(GasConduitBridgeConfig), "CreateBuildingDef")] public static class GasConduitBridgeConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(GasConduitConfig), "CreateBuildingDef")] public static class GasConduitConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(GasFilterConfig), "CreateBuildingDef")] public static class GasFilterConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(GasLogicValveConfig), "CreateBuildingDef")] public static class GasLogicValveConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(GasPermeableMembraneConfig), "CreateBuildingDef")] public static class GasPermeableMembraneConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(GasPumpConfig), "CreateBuildingDef")] public static class GasPumpConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(GasReservoirConfig), "CreateBuildingDef")] public static class GasReservoirConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(GasValveConfig), "CreateBuildingDef")] public static class GasValveConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(GasVentConfig), "CreateBuildingDef")] public static class GasVentConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                [HarmonyPatch(typeof(GeneratorConfig), "CreateBuildingDef")] public static class GeneratorConfig_Material { static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); } }
                   [HarmonyPatch(typeof(GenericFabricatorConfig), "CreateBuildingDef")] public static class GenericFabricatorConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(GlassForgeConfig), "CreateBuildingDef")] public static class GlassForgeConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(GraveConfig), "CreateBuildingDef")] public static class GraveConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(HydrogenGeneratorConfig), "CreateBuildingDef")] public static class HydrogenGeneratorConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(HydroponicFarmConfig), "CreateBuildingDef")] public static class HydroponicFarmConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(InsulatedGasConduitConfig), "CreateBuildingDef")] public static class InsulatedGasConduitConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(InsulatedLiquidConduitConfig), "CreateBuildingDef")] public static class InsulatedLiquidConduitConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.PLUMBABLE)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(InsulationTileConfig), "CreateBuildingDef")] public static class InsulationTileConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(ItemPedestalConfig), "CreateBuildingDef")] public static class ItemPedestalConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(JetSuitLockerConfig), "CreateBuildingDef")] public static class JetSuitLockerConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(JetSuitMarkerConfig), "CreateBuildingDef")] public static class JetSuitMarkerConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(KilnConfig), "CreateBuildingDef")] public static class KilnConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LadderConfig), "CreateBuildingDef")] public static class LadderConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LiquidConditionerConfig), "CreateBuildingDef")] public static class LiquidConditionerConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LiquidConduitBridgeConfig), "CreateBuildingDef")] public static class LiquidConduitBridgeConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LiquidConduitConfig), "CreateBuildingDef")] public static class LiquidConduitConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.PLUMBABLE)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LiquidFilterConfig), "CreateBuildingDef")] public static class LiquidFilterConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LiquidHeaterConfig), "CreateBuildingDef")] public static class LiquidHeaterConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LiquidLogicValveConfig), "CreateBuildingDef")] public static class LiquidLogicValveConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LiquidPumpConfig), "CreateBuildingDef")] public static class LiquidPumpConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LiquidPumpingStationConfig), "CreateBuildingDef")] public static class LiquidPumpingStationConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                  [HarmonyPatch(typeof(LiquidReservoirConfig), "CreateBuildingDef")] public static class LiquidReservoirConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LiquidValveConfig), "CreateBuildingDef")] public static class LiquidValveConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LiquidVentConfig), "CreateBuildingDef")] public static class LiquidVentConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LogicSwitchConfig), "CreateBuildingDef")] public static class LogicSwitchConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LogicWireBridgeConfig), "CreateBuildingDef")] public static class LogicWireBridgeConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(LogicWireConfig), "CreateBuildingDef")] public static class LogicWireConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(MachineShopConfig), "CreateBuildingDef")] public static class MachineShopConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(ManualGeneratorConfig), "CreateBuildingDef")] public static class ManualGeneratorConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(MassageTableConfig), "CreateBuildingDef")] public static class MassageTableConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(MedicalCotConfig), "CreateBuildingDef")] public static class MedicalCotConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(MeshTileConfig), "CreateBuildingDef")] public static class MeshTileConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(MetalRefineryConfig), "CreateBuildingDef")] public static class MetalRefineryConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(MetalTileConfig), "CreateBuildingDef")] public static class MetalTileConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(MethaneGeneratorConfig), "CreateBuildingDef")] public static class MethaneGeneratorConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(MicrobeMusherConfig), "CreateBuildingDef")] public static class MicrobeMusherConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(MineralDeoxidizerConfig), "CreateBuildingDef")] public static class MineralDeoxidizerConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(OilRefineryConfig), "CreateBuildingDef")] public static class OilRefineryConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(OilWellCapConfig), "CreateBuildingDef")] public static class OilWellCapConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(OuthouseConfig), "CreateBuildingDef")] public static class OuthouseConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(PhonoboxConfig), "CreateBuildingDef")] public static class PhonoboxConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(PolymerizerConfig), "CreateBuildingDef")] public static class PolymerizerConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(PowerControlStationConfig), "CreateBuildingDef")] public static class PowerControlStationConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(PowerTransformerConfig), "CreateBuildingDef")] public static class PowerTransformerConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(PowerTransformerSmallConfig), "CreateBuildingDef")] public static class PowerTransformerSmallConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(RanchStationConfig), "CreateBuildingDef")] public static class RanchStationConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(RationBoxConfig), "CreateBuildingDef")] public static class RationBoxConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(RefrigeratorConfig), "CreateBuildingDef")] public static class RefrigeratorConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(ResearchCenterConfig), "CreateBuildingDef")] public static class ResearchCenterConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(RockCrusherConfig), "CreateBuildingDef")] public static class RockCrusherConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(RoleStationConfig), "CreateBuildingDef")] public static class RoleStationConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(ShearingStationConfig), "CreateBuildingDef")] public static class ShearingStationConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(ShowerConfig), "CreateBuildingDef")] public static class ShowerConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(SpaceHeaterConfig), "CreateBuildingDef")] public static class SpaceHeaterConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(StorageLockerConfig), "CreateBuildingDef")] public static class StorageLockerConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(StorageLockerSmartConfig), "CreateBuildingDef")] public static class StorageLockerSmartConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(SuitFabricatorConfig), "CreateBuildingDef")] public static class SuitFabricatorConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(SuitLockerConfig), "CreateBuildingDef")] public static class SuitLockerConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(SuitMarkerConfig), "CreateBuildingDef")] public static class SuitMarkerConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.REFINED_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(SupermaterialRefineryConfig), "CreateBuildingDef")] public static class SupermaterialRefineryConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(SwitchConfig), "CreateBuildingDef")] public static class SwitchConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(TemperatureControlledSwitchConfig), "CreateBuildingDef")] public static class TemperatureControlledSwitchConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(TileConfig), "CreateBuildingDef")] public static class TileConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(WashBasinConfig), "CreateBuildingDef")] public static class WashBasinConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(WashSinkConfig), "CreateBuildingDef")] public static class WashSinkConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(WaterCoolerConfig), "CreateBuildingDef")] public static class WaterCoolerConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.RAW_MINERALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
                   [HarmonyPatch(typeof(WaterPurifierConfig), "CreateBuildingDef")] public static class WaterPurifierConfig_Material{static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) { var codes = new List<CodeInstruction>(instructions); FieldInfo fieldInfoF1 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ALL_METALS)); FieldInfo fieldInfoF2 = AccessTools.Field(typeof(MATERIALS), nameof(MATERIALS.ANY_BUILDABLE)); for (int i = 0; i < codes.Count; i++) { CodeInstruction instruction = codes[index: i]; if (instruction.opcode == OpCodes.Ldsfld && instruction.operand == fieldInfoF1) { instruction.operand = fieldInfoF2; } } return codes.AsEnumerable(); }}
            }
        }
    }

    namespace _Testing_
    {

    }

    namespace TEMP
    {
        /*
           [HarmonyPatch(typeof(______________), "______________")]
           public class ________________
           {
               public static void Postfix(____________ __instance, ref _______ _________)
               {

               }
           }
        */
    }
    
    /*[HarmonyPatch(typeof(SupermaterialRefineryConfig), "ConfigureBuildingTemplate")]
            public static class SupermaterialRefineryAtmoMod
            {
                public static void Postfix()
                {
                    Tag tag1 = SimHashes.Dirt.CreateTag();
                    Tag tag2 = AtmoSuitConfig.ID;
                    string stag1 = ElementLoader.FindElementByHash(SimHashes.Dirt).name;
                    string stag2 = "Fabric";
                    ComplexRecipe.RecipeElement[] ingredients1 = new ComplexRecipe.RecipeElement[1]
                    {
                    new ComplexRecipe.RecipeElement(tag1, 100f)
                    };
                    ComplexRecipe.RecipeElement[] results1 = new ComplexRecipe.RecipeElement[1]
                    {
                    new ComplexRecipe.RecipeElement(tag2, 1f)
                    };

                    string str1 = ComplexRecipeManager.MakeRecipeID("SupermaterialRefinery", ingredients1, results1);

                    new ComplexRecipe(str1, ingredients1, results1)
                    {
                        time = 0f,
                        useResultAsDescription = true,
                        displayInputAndOutput = true,
                        description = string.Format("Make {0} from {1} ", stag2, stag1)
                    }.fabricators = new List<Tag>() { TagManager.Create("SupermaterialRefinery") };

                }
            }*/
}
