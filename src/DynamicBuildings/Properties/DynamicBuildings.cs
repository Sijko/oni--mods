using Harmony;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq;
using TUNING;
using KorribanDynamics.JapaneseSchoolGirls;

namespace KorribanDynamics
{
    namespace JapaneseSchoolGirls
    {
        public class SithLordsPrevail
        {
            public static float GlobalCap= DynamicBuildingsState.StateManager.State.LockerCap;
            public static float GlobalConsumeRate = DynamicBuildingsState.StateManager.State.liquidandgas;
            public static byte GlobalRadius = DynamicBuildingsState.StateManager.State.SuckInRadius;
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
    namespace PipeAndCoveyorCapacity
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

        [HarmonyPatch(typeof(ConduitFlow), MethodType.Constructor, new Type[] { typeof(ConduitType), typeof(int), typeof(IUtilityNetworkMgr), typeof(float), typeof(float) })]
        public static class PipesMass
        {
            public static void Prefix(ConduitType conduit_type, int num_cells, IUtilityNetworkMgr network_mgr, ref float max_conduit_mass, float initial_elapsed_time)
            { max_conduit_mass = SithLordsPrevail.GlobalConsumeRate; }
        }

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

        [HarmonyPatch(typeof(LiquidLogicValveConfig), "ConfigureBuildingTemplate")]
        public static class LiquidLogicValveConfigDynamicPatch
        {
            public static void Postfix(LiquidLogicValveConfig __instance, ref GameObject go)
            {
                OperationalValve operationalValve = go.AddOrGet<OperationalValve>();
                operationalValve.maxFlow = SithLordsPrevail.GlobalConsumeRate;
            }
        }

        [HarmonyPatch(typeof(GasLogicValveConfig), "ConfigureBuildingTemplate")]
        public static class GasLogicValveConfigDynamicPatch
        {
            public static void Postfix(GasLogicValveConfig __instance, ref GameObject go)
            {
                OperationalValve operationalValve = go.AddOrGet<OperationalValve>();
                operationalValve.maxFlow = SithLordsPrevail.GlobalConsumeRate;
            }
        }

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

        [HarmonyPatch(typeof(GasPumpConfig), "DoPostConfigureComplete")]
        public static class GasPumpConfigDynamicPatch
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

        [HarmonyPatch(typeof(GasMiniPumpConfig), "DoPostConfigureComplete")]
        public static class GasMiniPumpConfigDynamicPatch
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
    namespace DynamicBuildings
    {
        namespace Generators
        {
            namespace NaturalGas
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
            namespace Hydrogen
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
        
        namespace MediumBattery
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

        [HarmonyPatch(typeof(FuelTank), "MaxCapacity", MethodType.Getter)]
        public static class FuelTankPatch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (int i = 0; i < codes.Count; i++)
                {
                    if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 900f)) { codes[i].operand = 2000f; }
                }
                return codes.AsEnumerable();
            }
        }

        [HarmonyPatch(typeof(LogicWireConfig), "CreateBuildingDef")]
        public class LogicWirePatch
        {
            static void Postfix(LogicWireConfig __instance, ref BuildingDef __result)
            {
                __result.Invincible = true;
            }
        }

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

        [HarmonyPatch(typeof(FirePoleConfig), "ConfigureBuildingTemplate")]
        public static class FirePoleSpeed
        {
            public static void Postfix(FirePoleConfig __instance, ref GameObject go)
            {
                Ladder ladder = go.AddOrGet<Ladder>();
                ladder.upwardsMovementSpeedMultiplier = 10f;
                ladder.downwardsMovementSpeedMultiplier = 10f;
            }
        }

        [HarmonyPatch(typeof(ElectrolyzerConfig), "ConfigureBuildingTemplate")]
        public static class ElectrolyzerPressure
        {
            public static void Postfix(ElectrolyzerConfig __instance, ref GameObject go)
            {
                float MaxPressure = DynamicBuildingsState.StateManager.State.ElectrolyzerMaxPressure;
                float InRate = DynamicBuildingsState.StateManager.State.ElectrolyzerRate;
                float Cap = SithLordsPrevail.GlobalCap;
                float MyHydro = DynamicBuildingsState.StateManager.State.ElectroHydro / 1000f;
                float MyOxy = 1f - MyHydro;

                Electrolyzer electrolyzer = go.AddOrGet<Electrolyzer>();
                electrolyzer.maxMass = MaxPressure;
                ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                conduitConsumer.consumptionRate = InRate;
                Storage storage = go.AddOrGet<Storage>();
                storage.capacityKg = Cap;
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

        [HarmonyPatch(typeof(LiquidFuelTankConfig), "DoPostConfigureComplete")]
        public static class LiquidFuelTankPatch
        {
            static void Postfix(LiquidFuelTankConfig __instance, ref GameObject go)
            {
                float mycapacity = 2000f;
                float rate = SithLordsPrevail.GlobalConsumeRate;

                FuelTank fuelTank = go.AddOrGet<FuelTank>();
                fuelTank.capacityKg = mycapacity;
                ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                conduitConsumer.consumptionRate = rate;
                conduitConsumer.capacityKG = mycapacity;
            }
        }

        [HarmonyPatch(typeof(OxidizerTankConfig), "DoPostConfigureComplete")]
        public static class OxidizerTankPatch
        {
            static void Postfix(OxidizerTankConfig __instance, ref GameObject go)
            {
                float mycapacity = 2700f;

                Storage storage = go.AddOrGet<Storage>();
                storage.capacityKg = mycapacity;
                ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
                manualDeliveryKG.refillMass = mycapacity;
                manualDeliveryKG.capacity = mycapacity;
            }
        }

        [HarmonyPatch(typeof(OxidizerTankLiquidConfig), "DoPostConfigureComplete")]
        public static class OxidizerTankLiquidPatch
        {
            static void Postfix(OxidizerTankLiquidConfig __instance, ref GameObject go)
            {
                float mycapacity = 2700f;
                float rate = SithLordsPrevail.GlobalConsumeRate;

                Storage storage = go.AddOrGet<Storage>();
                storage.capacityKg = mycapacity;
                ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                conduitConsumer.consumptionRate = rate;
                conduitConsumer.capacityKG = mycapacity;
                ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
                manualDeliveryKG.refillMass = mycapacity;
                manualDeliveryKG.capacity = mycapacity;
            }
        }

        [HarmonyPatch(typeof(SteamEngineConfig), "DoPostConfigureComplete")]
        public static class SteamEnginePatch
        {
            static void Postfix(SteamEngineConfig __instance, ref GameObject go)
            {
                float rate = SithLordsPrevail.GlobalConsumeRate;
                float mycapacity = 2000f;

                FuelTank fuelTank = go.AddOrGet<FuelTank>();
                fuelTank.capacityKg = mycapacity;
                ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                conduitConsumer.consumptionRate = rate;
                conduitConsumer.capacityKG = mycapacity;
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

        [HarmonyPatch(typeof(SuitLockerConfig), "CreateBuildingDef")]
        class SuitLockerCreateBuilding
        {
            static void Postfix(SuitLockerConfig __instance, ref BuildingDef __result)
            {
                __result.BaseDecor = 0f;
            }
        }

        [HarmonyPatch(typeof(AirFilterConfig), "ConfigureBuildingTemplate")]
        public static class DeodorizerCapacityAndRatePatch
        {
            static void Postfix(AirFilterConfig __instance, ref GameObject go)
            {
                float mycap = DynamicBuildingsState.StateManager.State.DeodorizerCap;
                float rate = DynamicBuildingsState.StateManager.State.DeodorizerRate;
                float con_rate = SithLordsPrevail.GlobalConsumeRate;

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
            }
        }

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

        [HarmonyPatch(typeof(SolidTransferArm), "OnPrefabInit")]
        public static class SweeperCarryCapacityPatch
        {
            static void Prefix(ref float ___max_carry_weight)
            {
                ___max_carry_weight = DynamicBuildingsState.StateManager.State.STA;
            }
        }

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

        [HarmonyPatch(typeof(GasVentConfig), "ConfigureBuildingTemplate")]
        public static class GasVentConfigPatch
        {
            static void Postfix(GasVentConfig __instance, ref GameObject go)
            {
                Vent vent = go.AddOrGet<Vent>(); vent.overpressureMass = DynamicBuildingsState.StateManager.State.GVOP;
            }
        }

        [HarmonyPatch(typeof(GasVentHighPressureConfig), "ConfigureBuildingTemplate")]
        public static class GasVentHighPressureConfigPatch
        {
            static void Postfix(GasVentHighPressureConfig __instance, ref GameObject go)
            {
                Vent vent = go.AddOrGet<Vent>(); vent.overpressureMass = DynamicBuildingsState.StateManager.State.HPGVOP;
            }
        }

        [HarmonyPatch(typeof(LiquidVentConfig), "ConfigureBuildingTemplate")]
        public static class LiquidVentConfigPatch
        {
            static void Postfix(LiquidVentConfig __instance, ref GameObject go)
            {
                Vent vent = go.AddOrGet<Vent>(); vent.overpressureMass = 2000f;
            }
        }

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
                manualDeliveryKG.capacity = capacity;
                manualDeliveryKG.refillMass = 300f * ratio;
            }
        }

        [HarmonyPatch(typeof(AlgaeDistilleryConfig), "ConfigureBuildingTemplate")]
        public static class AlgaeDistilleryConfigDynamicOutputPatch
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
                __result.MassForTemperatureModification = 0f;
                __result.PermittedRotations = PermittedRotations.R360;
                __result.BuildLocationRule = BuildLocationRule.Anywhere;
                __result.ContinuouslyCheckFoundation = false;
            }
        }

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
                __result.MassForTemperatureModification = 0f;
                __result.PermittedRotations = PermittedRotations.R360;
                __result.BuildLocationRule = BuildLocationRule.Anywhere;
                __result.ContinuouslyCheckFoundation = false;
            }
        }

        [HarmonyPatch(typeof(CompostConfig), "ConfigureBuildingTemplate")]
        public class CompostPatch
        {
            static void Postfix(CompostConfig __instance, ref GameObject go)
            {
                float mycapacity = SithLordsPrevail.GlobalCap;
                float myspeed = 10f;

                Storage storage = go.AddOrGet<Storage>();
                storage.capacityKg = mycapacity;

                ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
                elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
                {new ElementConverter.ConsumedElement(GameTags.Compostable, myspeed)};
                elementConverter.outputElements = new ElementConverter.OutputElement[1]
                {new ElementConverter.OutputElement(myspeed, SimHashes.Dirt, 348.15f, true, 0f, 0.5f, false, 1f, byte.MaxValue)};

                ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
                manualDeliveryKG.capacity = mycapacity;
                manualDeliveryKG.refillMass = 110f;

                go.AddOrGet<DropAllWorkable>();
            }
        }

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
    namespace Dupes
    {
        [HarmonyPatch(typeof(RockCrusherConfig), "ConfigureBuildingTemplate")]
        internal class RockCrusherDupesPatch
        {
            static void Postfix(RockCrusherConfig __instance, ref GameObject go)
            {
                bool RockDupeWork = DynamicBuildingsState.StateManager.State.RockDupe;
                ComplexFabricator complexFabricator = go.AddOrGet<ComplexFabricator>();
                complexFabricator.duplicantOperated = RockDupeWork;
            }
        }
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
    namespace StorageCapacity
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

        [HarmonyPatch(typeof(SolidConduitInboxConfig), "DoPostConfigureComplete")]
        public class SolidConduitInboxConfigCapacityPatch
        {
            static void Postfix(SolidConduitInboxConfig __instance, ref GameObject go)
            {
                Storage storage = go.AddOrGet<Storage>();
                storage.capacityKg = DynamicBuildingsState.StateManager.State.ConLoaderCap;
            }
        }
        [HarmonyPatch(typeof(RationBoxConfig), "ConfigureBuildingTemplate")]
        public class RationBoxConfigCapacityPatch
        {
            static void Postfix(RationBoxConfig __instance, ref GameObject go)
            {
                Storage storage = go.AddOrGet<Storage>();
                storage.capacityKg = SithLordsPrevail.GlobalCap;
            }
        }
        [HarmonyPatch(typeof(CreatureFeederConfig), "ConfigureBuildingTemplate")]
        public class CreatureFeederConfigCapacityPatch
        {
            static void Postfix(CreatureFeederConfig __instance, ref GameObject go)
            {
                Storage storage = go.AddOrGet<Storage>();
                storage.capacityKg = SithLordsPrevail.GlobalCap;
            }
        }
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
    namespace StorageType
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
    }
    namespace BasementNeed
    {
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

        [HarmonyPatch(typeof(GasReservoirConfig), "CreateBuildingDef")]
        public class GasReservoirConfigBasePatch
        {
            static void Postfix(GasReservoirConfig __instance, ref BuildingDef __result)
            {
                __result.BuildLocationRule = BuildLocationRule.Anywhere; __result.ContinuouslyCheckFoundation = DynamicBuildingsState.StateManager.State.GasResBase;
            }
        }

        [HarmonyPatch(typeof(LiquidReservoirConfig), "CreateBuildingDef")]
        public class LiquidReservoirConfigBasePatch
        {
            static void Postfix(LiquidReservoirConfig __instance, ref BuildingDef __result)
            {
                __result.BuildLocationRule = BuildLocationRule.Anywhere; __result.ContinuouslyCheckFoundation = DynamicBuildingsState.StateManager.State.LiqResBase;
            }
        }
    }
    namespace Rotations
    {
        [HarmonyPatch(typeof(AirFilterConfig), "CreateBuildingDef")]public class AirFilterRotations{static void Postfix(AirFilterConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.R360;}
        [HarmonyPatch(typeof(OilRefineryConfig), "CreateBuildingDef")]public static class OilRefineryRotations{public static void Postfix(OilRefineryConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.FlipH;}
        [HarmonyPatch(typeof(OilWellCapConfig), "CreateBuildingDef")]        public static class OilWellCapRotations        {            public static void Postfix(OilWellCapConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.FlipH;        }
        [HarmonyPatch(typeof(LiquidReservoirConfig), "CreateBuildingDef")]        public static class LiquidReservoirConfigRotations        {            public static void Postfix(LiquidReservoirConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.R360;        }
        [HarmonyPatch(typeof(GasReservoirConfig), "CreateBuildingDef")]        public static class GasReservoirConfigRotations        {            public static void Postfix(GasReservoirConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.R360;        }        [HarmonyPatch(typeof(LiquidPumpingStationConfig), "CreateBuildingDef")]        public static class LiquidPumpingStationRotations        {            public static void Postfix(LiquidPumpingStationConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.FlipH;        }
        [HarmonyPatch(typeof(RationBoxConfig), "CreateBuildingDef")]        public static class RationBoxStorageRotations        {            public static void Postfix(RationBoxConfig __instance, ref BuildingDef __result) => __result.PermittedRotations = PermittedRotations.R360;        }
    }
    namespace MyCheats
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

        [HarmonyPatch(typeof(PressureDoorConfig), "CreateBuildingDef")]
        class PressureDoorNoPower
        {
            public static void Postfix(PressureDoorConfig __instance, ref BuildingDef __result)
            {
                __result.RequiresPowerInput = false;
                __result.EnergyConsumptionWhenActive = 0f;
            }
        }
        [HarmonyPatch(typeof(SolidTransferArmConfig), "CreateBuildingDef")]
        class SweeperNoPower
        {
            public static void Postfix(SolidTransferArmConfig __instance, ref BuildingDef __result)
            {
                __result.RequiresPowerInput = DynamicBuildingsState.StateManager.State.SweeperRequiresPowerInput;
                __result.EnergyConsumptionWhenActive = DynamicBuildingsState.StateManager.State.SweeperEnergyConsumption;
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
        [HarmonyPatch(typeof(SuitLockerConfig), "CreateBuildingDef")]
        class SuitLockerNoPower
        {
            public static void Postfix(SuitLockerConfig __instance, ref BuildingDef __result)
            {
                __result.RequiresPowerInput = DynamicBuildingsState.StateManager.State.SuitLockerRequiresPowerInput;
                __result.EnergyConsumptionWhenActive = DynamicBuildingsState.StateManager.State.SuitLockerEnergyConsumption;
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
    namespace Recipes
    { 
        [HarmonyPatch(typeof(CookingStationConfig), "ConfigureRecipes")]
        public static class CookingStationRecipes
        {
            public static void Postfix(CookingStationConfig __instance)
            {
                //frostbun
                ComplexRecipe.RecipeElement[] array1001 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement("ColdWheatSeed", 30f),
                    new ComplexRecipe.RecipeElement("Water", 1f)
                };
                ComplexRecipe.RecipeElement[] array1002 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement("ColdWheatBread", 10f)
                };
                string id1001 = ComplexRecipeManager.MakeRecipeID("CookingStation", array1001, array1002);
                SpiceBreadConfig.recipe = new ComplexRecipe(id1001, array1001, array1002)
                {
                    time = 0f,
                    description = "Make 10 Frost Buns in one time",
                    useResultAsDescription = true,
                    fabricators = new List<Tag>
                    {
                        "CookingStation"
                    },
                    sortOrder = 1
                };

                //omelette
                ComplexRecipe.RecipeElement[] array1003 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement("RawEgg", 10f),
                    new ComplexRecipe.RecipeElement("Water", 1f)
                };
                ComplexRecipe.RecipeElement[] array1004 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement("CookedEgg", 10f)
                };
                string id1002 = ComplexRecipeManager.MakeRecipeID("CookingStation", array1003, array1004);
                CookedEggConfig.recipe = new ComplexRecipe(id1002, array1003, array1004)
                {
                    time = 0f,
                    description = "Make 10 Omelettes in one time",
                    useResultAsDescription = true,
                    fabricators = new List<Tag>
                    {
                        "CookingStation"
                    },
                    sortOrder = 1
                };
                // Gristle Berry
                ComplexRecipe.RecipeElement[] array1005 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(PrickleFruitConfig.ID, 10f),
                    new ComplexRecipe.RecipeElement("Water", 1f)
                };
                ComplexRecipe.RecipeElement[] array1006 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement("GrilledPrickleFruit", 10f)
                };
                string id1003 = ComplexRecipeManager.MakeRecipeID("CookingStation", array1005, array1006);
                GrilledPrickleFruitConfig.recipe = new ComplexRecipe(id1003, array1005, array1006)
                {
                    time = 0f,
                    description = "Make 10 Gristle Berries in one time",
                    useResultAsDescription = true,
                    fabricators = new List<Tag>
                    {
                        "CookingStation"
                    },
                    sortOrder = 1
                };

                // Fried Mushroom
                ComplexRecipe.RecipeElement[] array1007 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(MushroomConfig.ID, 10f),
                    new ComplexRecipe.RecipeElement("Water", 1f)
                };
                ComplexRecipe.RecipeElement[] array1008 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement("FriedMushroom", 10f)
                };
                string id1004 = ComplexRecipeManager.MakeRecipeID("CookingStation", array1007, array1008);
                FriedMushroomConfig.recipe = new ComplexRecipe(id1004, array1007, array1008)
                {
                    time = 0f,
                    description = "Make 10 Fried Mushrooms in one time",
                    useResultAsDescription = true,
                    fabricators = new List<Tag>
                    {
                        "CookingStation"
                    },
                    sortOrder = 1
                };

                // Barbeque
                ComplexRecipe.RecipeElement[] array1009 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement("Meat", 20f),
                    new ComplexRecipe.RecipeElement(SpiceNutConfig.ID, 10f),
                    new ComplexRecipe.RecipeElement("Water", 1f)
                };
                ComplexRecipe.RecipeElement[] array1010 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement("CookedMeat", 10f)
                };
                string id1005 = ComplexRecipeManager.MakeRecipeID("CookingStation", array1009, array1010);
                CookedMeatConfig.recipe = new ComplexRecipe(id1005, array1009, array1010)
                {
                    time = 0f,
                    description = "Make 10 Barbeques in one time",
                    useResultAsDescription = true,
                    fabricators = new List<Tag>
                    {
                        "CookingStation"
                    },
                    sortOrder = 1
                };

                // Pickled Meal
                ComplexRecipe.RecipeElement[] array1011 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement("BasicPlantFood", 30f),
                    new ComplexRecipe.RecipeElement("Water", 1f)
                };
                ComplexRecipe.RecipeElement[] array1012 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement("PickledMeal", 10f)
                };
                string id1006 = ComplexRecipeManager.MakeRecipeID("CookingStation", array1011, array1012);
                PickledMealConfig.recipe = new ComplexRecipe(id1006, array1011, array1012)
                {
                    time = 0f,
                    description = "Make 10 Pickled Meals in one time",
                    useResultAsDescription = true,
                    fabricators = new List<Tag>
                    {
                        "CookingStation"
                    },
                    sortOrder = 1
                };
            }
        }
      
        [HarmonyPatch(typeof(KilnConfig), "ConfigureBuildingTemplate")]
        public static class KilnMod
        {
            public static void Postfix()
            {
                Tag tag1 = ElementLoader.FindElementByHash(SimHashes.Clay).tag;
                Tag tag2 = ElementLoader.FindElementByHash(SimHashes.Carbon).tag;
                Tag tag3 = ElementLoader.FindElementByHash(SimHashes.Ceramic).tag;
                Tag tag4 = ElementLoader.FindElementByHash(SimHashes.Sand).tag;
                string stag1 = tag1.ToString();
                string stag2 = tag2.ToString();
                string stag3 = tag3.ToString();
                string stag4 = tag4.ToString();

                ComplexRecipe.RecipeElement[] ingredients1 = new ComplexRecipe.RecipeElement[3]
                {
                    new ComplexRecipe.RecipeElement(tag1, 1000f),
                    new ComplexRecipe.RecipeElement(tag2, 250f),
                    new ComplexRecipe.RecipeElement(tag4, 100f)

                };
                ComplexRecipe.RecipeElement[] results1 = new ComplexRecipe.RecipeElement[2]
                {
                    new ComplexRecipe.RecipeElement(tag3, 1000f),
                    new ComplexRecipe.RecipeElement(tag4, 100f)
                };

                string str1 = ComplexRecipeManager.MakeRecipeID("Kiln", ingredients1, results1);

                new ComplexRecipe(str1, ingredients1, results1)
                {
                    time = 0f,
                    useResultAsDescription = true,
                    displayInputAndOutput = true,
                    description = string.Format("Produces {0} from {1} and {2}, with {3} as catalyst, which magically makes the chemical reaction instant.", stag3, stag1, stag2, stag4)
                }.fabricators = new List<Tag>() { TagManager.Create("Kiln") };

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
    namespace Archeology
    {
        [HarmonyPatch(typeof(RockCrusherConfig), "ConfigureBuildingTemplate")]
        internal class RockCrusherArcheologyPatch
        {
            static void Postfix(RockCrusherConfig __instance, ref GameObject go)
            {
                Tag tag1 = ElementLoader.FindElementByHash(SimHashes.Fossil).tag;
                Tag tag2 = ElementLoader.FindElementByHash(SimHashes.Algae).tag;
                string stag1 = tag1.ToString();
                string stag2 = tag2.ToString();

                Tag tag01_3 = ElementLoader.FindElementByHash(SimHashes.Phosphorite).tag;
                Tag tag02_3 = ElementLoader.FindElementByHash(SimHashes.Polypropylene).tag;
                Tag tag03_3 = ElementLoader.FindElementByHash(SimHashes.CrudeOil).tag;
                Tag tag04_3 = ElementLoader.FindElementByHash(SimHashes.OxyRock).tag;
                Tag tag05_3 = ElementLoader.FindElementByHash(SimHashes.Magma).tag;
                Tag tag06_3 = ElementLoader.FindElementByHash(SimHashes.Carbon).tag;
                Tag tag07_3 = ElementLoader.FindElementByHash(SimHashes.IronOre).tag;
                Tag tag08_3 = ElementLoader.FindElementByHash(SimHashes.Diamond).tag;
                Tag tag09_3 = ElementLoader.FindElementByHash(SimHashes.Lime).tag;
                Tag tag10_3 = PrickleFruitConfig.ID.ToTag();
                Tag tag11_3 = ElementLoader.FindElementByHash(SimHashes.Katairite).tag;
                Tag tag12_3 = SpiceBreadConfig.ID.ToTag();
                Tag tag13_3 = CookedMeatConfig.ID.ToTag();
                Tag tag14_3 = MushroomConfig.ID.ToTag();
                Tag tag15_3 = GrilledPrickleFruitConfig.ID.ToTag();
                Tag tag16_3 = SpiceNutConfig.ID.ToTag();
                Tag tag17_3 = ElementLoader.FindElementByHash(SimHashes.ToxicSand).tag;
                Tag tag18_3 = ElementLoader.FindElementByHash(SimHashes.ToxicSand).tag;
                Tag tag19_3 = ElementLoader.FindElementByHash(SimHashes.ToxicSand).tag;
                Tag tag20_3 = ElementLoader.FindElementByHash(SimHashes.SlimeMold).tag;
                Tag tag21_3 = ElementLoader.FindElementByHash(SimHashes.SlimeMold).tag;
                Tag tag22_3 = ElementLoader.FindElementByHash(SimHashes.BleachStone).tag;
                Tag tag23_3 = ElementLoader.FindElementByHash(SimHashes.OxyRock).tag;

                Tag tag01_4 = DreckoConfig.EGG_ID.ToTag();
                Tag tag02_4 = DreckoPlasticConfig.EGG_ID.ToTag();
                Tag tag03_4 = OilFloaterConfig.EGG_ID.ToTag();
                Tag tag04_4 = OilFloaterDecorConfig.EGG_ID.ToTag();
                Tag tag05_4 = OilFloaterHighTempConfig.EGG_ID.ToTag();
                Tag tag06_4 = HatchConfig.EGG_ID.ToTag();
                Tag tag07_4 = HatchHardConfig.EGG_ID.ToTag();
                Tag tag08_4 = HatchMetalConfig.EGG_ID.ToTag();
                Tag tag09_4 = HatchVeggieConfig.EGG_ID.ToTag();
                Tag tag10_4 = LightBugConfig.EGG_ID.ToTag();
                Tag tag11_4 = LightBugBlackConfig.EGG_ID.ToTag();
                Tag tag12_4 = LightBugBlueConfig.EGG_ID.ToTag();
                Tag tag13_4 = LightBugCrystalConfig.EGG_ID.ToTag();
                Tag tag14_4 = LightBugOrangeConfig.EGG_ID.ToTag();
                Tag tag15_4 = LightBugPinkConfig.EGG_ID.ToTag();
                Tag tag16_4 = LightBugPurpleConfig.EGG_ID.ToTag();
                Tag tag17_4 = PacuConfig.EGG_ID.ToTag();
                Tag tag18_4 = PacuCleanerConfig.EGG_ID.ToTag();
                Tag tag19_4 = PacuTropicalConfig.EGG_ID.ToTag();
                Tag tag20_4 = PuftConfig.EGG_ID.ToTag();
                Tag tag21_4 = PuftAlphaConfig.EGG_ID.ToTag();
                Tag tag22_4 = PuftBleachstoneConfig.EGG_ID.ToTag();
                Tag tag23_4 = PuftOxyliteConfig.EGG_ID.ToTag();

                string stag01_4 = STRINGS.CREATURES.SPECIES.DRECKO.EGG_NAME;
                string stag02_4 = STRINGS.CREATURES.SPECIES.DRECKO.VARIANT_PLASTIC.EGG_NAME;
                string stag03_4 = STRINGS.CREATURES.SPECIES.OILFLOATER.EGG_NAME;
                string stag04_4 = STRINGS.CREATURES.SPECIES.OILFLOATER.VARIANT_DECOR.EGG_NAME;
                string stag05_4 = STRINGS.CREATURES.SPECIES.OILFLOATER.VARIANT_HIGHTEMP.EGG_NAME;
                string stag06_4 = STRINGS.CREATURES.SPECIES.HATCH.EGG_NAME;
                string stag07_4 = STRINGS.CREATURES.SPECIES.HATCH.VARIANT_HARD.EGG_NAME;
                string stag08_4 = STRINGS.CREATURES.SPECIES.HATCH.VARIANT_METAL.EGG_NAME;
                string stag09_4 = STRINGS.CREATURES.SPECIES.HATCH.VARIANT_VEGGIE.EGG_NAME;
                string stag10_4 = STRINGS.CREATURES.SPECIES.LIGHTBUG.EGG_NAME;
                string stag11_4 = STRINGS.CREATURES.SPECIES.LIGHTBUG.VARIANT_BLACK.EGG_NAME;
                string stag12_4 = STRINGS.CREATURES.SPECIES.LIGHTBUG.VARIANT_BLUE.EGG_NAME;
                string stag13_4 = STRINGS.CREATURES.SPECIES.LIGHTBUG.VARIANT_CRYSTAL.EGG_NAME;
                string stag14_4 = STRINGS.CREATURES.SPECIES.LIGHTBUG.VARIANT_ORANGE.EGG_NAME;
                string stag15_4 = STRINGS.CREATURES.SPECIES.LIGHTBUG.VARIANT_PINK.EGG_NAME;
                string stag16_4 = STRINGS.CREATURES.SPECIES.LIGHTBUG.VARIANT_PURPLE.EGG_NAME;
                string stag17_4 = STRINGS.CREATURES.SPECIES.PACU.EGG_NAME;
                string stag18_4 = STRINGS.CREATURES.SPECIES.PACU.VARIANT_CLEANER.EGG_NAME;
                string stag19_4 = STRINGS.CREATURES.SPECIES.PACU.VARIANT_TROPICAL.EGG_NAME;
                string stag20_4 = STRINGS.CREATURES.SPECIES.PUFT.EGG_NAME;
                string stag21_4 = STRINGS.CREATURES.SPECIES.PUFT.VARIANT_ALPHA.EGG_NAME;
                string stag22_4 = STRINGS.CREATURES.SPECIES.PUFT.VARIANT_BLEACHSTONE.EGG_NAME;
                string stag23_4 = STRINGS.CREATURES.SPECIES.PUFT.VARIANT_OXYLITE.EGG_NAME;

                string stag01_3 = STRINGS.ELEMENTS.PHOSPHORITE.NAME;//Phosphorite 
                string stag02_3 = STRINGS.ELEMENTS.POLYPROPYLENE.NAME;//Polypropylene
                string stag03_3 = STRINGS.ELEMENTS.CRUDEOIL.NAME;//CrudeOil 
                string stag04_3 = STRINGS.ELEMENTS.OXYROCK.NAME;//OxyRock 
                string stag05_3 = STRINGS.ELEMENTS.MAGMA.NAME;//Magma 
                string stag06_3 = STRINGS.ELEMENTS.CARBON.NAME;//Carbon 
                string stag07_3 = STRINGS.ELEMENTS.IRONORE.NAME;//IronOre 
                string stag08_3 = STRINGS.ELEMENTS.DIAMOND.NAME;//Diamond 
                string stag09_3 = STRINGS.ELEMENTS.LIME.NAME;//Lime 
                string stag10_3 = STRINGS.ITEMS.FOOD.PRICKLEFRUIT.NAME;//PrickleFruitConfig 
                string stag11_3 = STRINGS.ELEMENTS.KATAIRITE.NAME;//Katairite 
                string stag12_3 = STRINGS.ITEMS.FOOD.SPICEBREAD.NAME;//SpiceBreadConfig 
                string stag13_3 = STRINGS.ITEMS.FOOD.COOKEDMEAT.NAME;//CookedMeatConfig 
                string stag14_3 = STRINGS.ITEMS.FOOD.MUSHROOM.NAME;//MushroomConfig 
                string stag15_3 = STRINGS.ITEMS.FOOD.GRILLEDPRICKLEFRUIT.NAME;//GrilledPrickleFruitConfig 
                string stag16_3 = STRINGS.ITEMS.FOOD.SPICENUT.NAME;//SpiceNutConfig 
                string stag17_3 = STRINGS.ELEMENTS.TOXICSAND.NAME;//ToxicSand 
                string stag18_3 = STRINGS.ELEMENTS.TOXICSAND.NAME;//ToxicSand 
                string stag19_3 = STRINGS.ELEMENTS.TOXICSAND.NAME;//ToxicSand 
                string stag20_3 = STRINGS.ELEMENTS.SLIMEMOLD.NAME;//SlimeMold 
                string stag21_3 = STRINGS.ELEMENTS.SLIMEMOLD.NAME;//SlimeMold 
                string stag22_3 = STRINGS.ELEMENTS.BLEACHSTONE.NAME;//BleachStone
                string stag23_3 = STRINGS.ELEMENTS.OXYROCK.NAME;//OxyRock

                ComplexRecipe complexRecipe01; ComplexRecipe complexRecipe02; ComplexRecipe complexRecipe03; ComplexRecipe complexRecipe04; ComplexRecipe complexRecipe05; ComplexRecipe complexRecipe06; ComplexRecipe complexRecipe07; ComplexRecipe complexRecipe08;
                ComplexRecipe complexRecipe09; ComplexRecipe complexRecipe10; ComplexRecipe complexRecipe11; ComplexRecipe complexRecipe12; ComplexRecipe complexRecipe13; ComplexRecipe complexRecipe14; ComplexRecipe complexRecipe15; ComplexRecipe complexRecipe16;
                ComplexRecipe complexRecipe17; ComplexRecipe complexRecipe18; ComplexRecipe complexRecipe19; ComplexRecipe complexRecipe20; ComplexRecipe complexRecipe21; ComplexRecipe complexRecipe22; ComplexRecipe complexRecipe23;

                ComplexRecipe.RecipeElement[] ingredients01_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag01_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients02_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag02_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients03_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag03_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients04_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag04_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients05_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag05_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients06_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag06_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients07_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag07_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients08_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag08_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients09_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag09_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients10_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag10_3, 10f) };
                ComplexRecipe.RecipeElement[] ingredients11_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag11_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients12_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag12_3, 10f) };
                ComplexRecipe.RecipeElement[] ingredients13_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag13_3, 10f) };
                ComplexRecipe.RecipeElement[] ingredients14_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag14_3, 10f) };
                ComplexRecipe.RecipeElement[] ingredients15_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag15_3, 10f) };
                ComplexRecipe.RecipeElement[] ingredients16_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag16_3, 10f) };
                ComplexRecipe.RecipeElement[] ingredients17_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag17_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients18_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag18_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients19_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag19_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients20_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag20_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients21_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag21_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients22_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag22_3, 1000f) };
                ComplexRecipe.RecipeElement[] ingredients23_1 = new ComplexRecipe.RecipeElement[3] { new ComplexRecipe.RecipeElement(tag1, 1000f), new ComplexRecipe.RecipeElement(tag2, 1000f), new ComplexRecipe.RecipeElement(tag23_3, 1000f) };
                ComplexRecipe.RecipeElement[] results01_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag01_4, 1f) };
                ComplexRecipe.RecipeElement[] results02_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag02_4, 1f) };
                ComplexRecipe.RecipeElement[] results03_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag03_4, 1f) };
                ComplexRecipe.RecipeElement[] results04_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag04_4, 1f) };
                ComplexRecipe.RecipeElement[] results05_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag05_4, 1f) };
                ComplexRecipe.RecipeElement[] results06_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag06_4, 1f) };
                ComplexRecipe.RecipeElement[] results07_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag07_4, 1f) };
                ComplexRecipe.RecipeElement[] results08_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag08_4, 1f) };
                ComplexRecipe.RecipeElement[] results09_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag09_4, 1f) };
                ComplexRecipe.RecipeElement[] results10_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag10_4, 1f) };
                ComplexRecipe.RecipeElement[] results11_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag11_4, 1f) };
                ComplexRecipe.RecipeElement[] results12_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag12_4, 1f) };
                ComplexRecipe.RecipeElement[] results13_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag13_4, 1f) };
                ComplexRecipe.RecipeElement[] results14_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag14_4, 1f) };
                ComplexRecipe.RecipeElement[] results15_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag15_4, 1f) };
                ComplexRecipe.RecipeElement[] results16_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag16_4, 1f) };
                ComplexRecipe.RecipeElement[] results17_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag17_4, 1f) };
                ComplexRecipe.RecipeElement[] results18_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag18_4, 1f) };
                ComplexRecipe.RecipeElement[] results19_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag19_4, 1f) };
                ComplexRecipe.RecipeElement[] results20_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag20_4, 1f) };
                ComplexRecipe.RecipeElement[] results21_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag21_4, 1f) };
                ComplexRecipe.RecipeElement[] results22_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag22_4, 1f) };
                ComplexRecipe.RecipeElement[] results23_1 = new ComplexRecipe.RecipeElement[1] { new ComplexRecipe.RecipeElement(tag23_4, 1f) };

                string str01_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients01_1, results01_1);
                string str02_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients02_1, results02_1);
                string str03_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients03_1, results03_1);
                string str04_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients04_1, results04_1);
                string str05_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients05_1, results05_1);
                string str06_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients06_1, results06_1);
                string str07_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients07_1, results07_1);
                string str08_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients08_1, results08_1);
                string str09_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients09_1, results09_1);
                string str10_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients10_1, results10_1);
                string str11_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients11_1, results11_1);
                string str12_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients12_1, results12_1);
                string str13_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients13_1, results13_1);
                string str14_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients14_1, results14_1);
                string str15_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients15_1, results15_1);
                string str16_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients16_1, results16_1);
                string str17_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients17_1, results17_1);
                string str18_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients18_1, results18_1);
                string str19_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients19_1, results19_1);
                string str20_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients20_1, results20_1);
                string str21_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients21_1, results21_1);
                string str22_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients22_1, results22_1);
                string str23_1 = ComplexRecipeManager.MakeRecipeID("RockCrusher", ingredients23_1, results23_1);

                complexRecipe01 = new ComplexRecipe(str01_1, ingredients01_1, results01_1);
                complexRecipe02 = new ComplexRecipe(str02_1, ingredients02_1, results02_1);
                complexRecipe03 = new ComplexRecipe(str03_1, ingredients03_1, results03_1);
                complexRecipe04 = new ComplexRecipe(str04_1, ingredients04_1, results04_1);
                complexRecipe05 = new ComplexRecipe(str05_1, ingredients05_1, results05_1);
                complexRecipe06 = new ComplexRecipe(str06_1, ingredients06_1, results06_1);
                complexRecipe07 = new ComplexRecipe(str07_1, ingredients07_1, results07_1);
                complexRecipe08 = new ComplexRecipe(str08_1, ingredients08_1, results08_1);
                complexRecipe09 = new ComplexRecipe(str09_1, ingredients09_1, results09_1);
                complexRecipe10 = new ComplexRecipe(str10_1, ingredients10_1, results10_1);
                complexRecipe11 = new ComplexRecipe(str11_1, ingredients11_1, results11_1);
                complexRecipe12 = new ComplexRecipe(str12_1, ingredients12_1, results12_1);
                complexRecipe13 = new ComplexRecipe(str13_1, ingredients13_1, results13_1);
                complexRecipe14 = new ComplexRecipe(str14_1, ingredients14_1, results14_1);
                complexRecipe15 = new ComplexRecipe(str15_1, ingredients15_1, results15_1);
                complexRecipe16 = new ComplexRecipe(str16_1, ingredients16_1, results16_1);
                complexRecipe17 = new ComplexRecipe(str17_1, ingredients17_1, results17_1);
                complexRecipe18 = new ComplexRecipe(str18_1, ingredients18_1, results18_1);
                complexRecipe19 = new ComplexRecipe(str19_1, ingredients19_1, results19_1);
                complexRecipe20 = new ComplexRecipe(str20_1, ingredients20_1, results20_1);
                complexRecipe21 = new ComplexRecipe(str21_1, ingredients21_1, results21_1);
                complexRecipe22 = new ComplexRecipe(str22_1, ingredients22_1, results22_1);
                complexRecipe23 = new ComplexRecipe(str23_1, ingredients23_1, results23_1);

                complexRecipe01.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag01_4, stag1, stag2, stag01_3);
                complexRecipe02.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag02_4, stag1, stag2, stag02_3);
                complexRecipe03.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag03_4, stag1, stag2, stag03_3);
                complexRecipe04.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag04_4, stag1, stag2, stag04_3);
                complexRecipe05.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag05_4, stag1, stag2, stag05_3);
                complexRecipe06.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag06_4, stag1, stag2, stag06_3);
                complexRecipe07.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag07_4, stag1, stag2, stag07_3);
                complexRecipe08.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag08_4, stag1, stag2, stag08_3);
                complexRecipe09.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag09_4, stag1, stag2, stag09_3);
                complexRecipe10.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag10_4, stag1, stag2, stag10_3);
                complexRecipe11.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag11_4, stag1, stag2, stag11_3);
                complexRecipe12.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag12_4, stag1, stag2, stag12_3);
                complexRecipe13.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag13_4, stag1, stag2, stag13_3);
                complexRecipe14.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag14_4, stag1, stag2, stag14_3);
                complexRecipe15.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag15_4, stag1, stag2, stag15_3);
                complexRecipe16.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag16_4, stag1, stag2, stag16_3);
                complexRecipe17.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag17_4, stag1, stag2, stag17_3);
                complexRecipe18.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag18_4, stag1, stag2, stag18_3);
                complexRecipe19.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag19_4, stag1, stag2, stag19_3);
                complexRecipe20.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag20_4, stag1, stag2, stag20_3);
                complexRecipe21.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag21_4, stag1, stag2, stag21_3);
                complexRecipe22.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag22_4, stag1, stag2, stag22_3);
                complexRecipe23.description = string.Format("Produces {0} from {1}, {2} and {3}.\n Provided by " + STRINGS.UI.FormatAsLink("Korriban Dynamics", "KORRIBANDYNAMICS") + " Archaeology Dept.", stag23_4, stag1, stag2, stag23_3);

                complexRecipe01.time = 0f; complexRecipe02.time = 0f; complexRecipe03.time = 0f; complexRecipe04.time = 0f; complexRecipe05.time = 0f; complexRecipe06.time = 0f; complexRecipe07.time = 0f;
                complexRecipe08.time = 0f; complexRecipe09.time = 0f; complexRecipe10.time = 0f; complexRecipe11.time = 0f; complexRecipe12.time = 0f; complexRecipe13.time = 0f; complexRecipe14.time = 0f;
                complexRecipe15.time = 0f; complexRecipe16.time = 0f; complexRecipe17.time = 0f; complexRecipe18.time = 0f; complexRecipe19.time = 0f; complexRecipe20.time = 0f; complexRecipe21.time = 0f;
                complexRecipe22.time = 0f; complexRecipe23.time = 0f;

                complexRecipe01.useResultAsDescription = true; complexRecipe02.useResultAsDescription = true; complexRecipe03.useResultAsDescription = true; complexRecipe04.useResultAsDescription = true; complexRecipe05.useResultAsDescription = true;
                complexRecipe06.useResultAsDescription = true; complexRecipe07.useResultAsDescription = true; complexRecipe08.useResultAsDescription = true; complexRecipe09.useResultAsDescription = true; complexRecipe10.useResultAsDescription = true;
                complexRecipe11.useResultAsDescription = true; complexRecipe12.useResultAsDescription = true; complexRecipe13.useResultAsDescription = true; complexRecipe14.useResultAsDescription = true; complexRecipe15.useResultAsDescription = true;
                complexRecipe16.useResultAsDescription = true; complexRecipe17.useResultAsDescription = true; complexRecipe18.useResultAsDescription = true; complexRecipe19.useResultAsDescription = true; complexRecipe20.useResultAsDescription = true;
                complexRecipe21.useResultAsDescription = true; complexRecipe22.useResultAsDescription = true; complexRecipe23.useResultAsDescription = true;

                complexRecipe01.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe02.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe03.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe04.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe05.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe06.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe07.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe08.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe09.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe10.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe11.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe12.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe13.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe14.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe15.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe16.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe17.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe18.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe19.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe20.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe21.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe22.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
                complexRecipe23.fabricators = new List<Tag>() { TagManager.Create("RockCrusher") };
            }
        }
    }
    namespace EmitMass
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

        [HarmonyPatch(typeof(AlgaeDistilleryConfig), "ConfigureBuildingTemplate")]
        public static class AlgaeDistilleryemitMassPatch
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
    }
    namespace DatabaseTinkers
    {
        [HarmonyPatch(typeof(Db), "Initialize")]
        class TheDBCheats
        {
            private static void Prefix(Db __instance)
            {
                BUILDINGS.ROCKETRY_MASS_KG.COMMAND_MODULE_MASS = new float[1] { 1f };
                BUILDINGS.ROCKETRY_MASS_KG.OXIDIZER_TANK_OXIDIZER_MASS = new float[1] { 1f };
                BUILDINGS.ROCKETRY_MASS_KG.FUEL_TANK_DRY_MASS = new float[1] { 1f };
                BUILDINGS.ROCKETRY_MASS_KG.FUEL_TANK_WET_MASS = new float[1] { 1f };
                BUILDINGS.ROCKETRY_MASS_KG.ENGINE_MASS_LARGE = new float[1] { 1f };
                BUILDINGS.ROCKETRY_MASS_KG.ENGINE_MASS_SMALL = new float[1] { 1f };
                ROLES.PASSIVE_EXPERIENCE_SCALE = 1f;
            }
        }

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

    }
    namespace AddHardiness
    {
        [HarmonyPatch(typeof(MaterialSelector), "SetEffects")]
        internal class AddHardinessSTRINGS
        {
            public static void Postfix(MaterialSelector __instance, ref Tag element)
            {
                if (element == "BasicFabric") return;
                List <Descriptor> materialDescriptors = GameUtil.GetMaterialDescriptors(element);
                Element myelement = ElementLoader.FindElementByName(element.ToString());
                if (materialDescriptors.Count > 0)
                {
                    Descriptor item = default;

                    item.SetupDescriptor(
                        STRINGS.UI.FormatAsLink("  Hardness", "HARDNESS") + " of " + myelement.name + " is : " + myelement.hardness.ToString(),"Element's hardness. Data provided by Korriban Dynamics.",Descriptor.DescriptorType.Effect);materialDescriptors.Insert(0, item);
                    item.SetupDescriptor(
                        STRINGS.UI.FormatAsLink("  Meltdown temperature", "HIGHTEMP") + " of " + myelement.name +
                        " is : ~" + (myelement.highTemp-273.15f).ToString(), "Element's meltdown temperature. Data provided by Korriban Dynamics.", Descriptor.DescriptorType.Effect);materialDescriptors.Insert(0, item);
                    item.SetupDescriptor(
                        STRINGS.UI.FormatAsLink("  Heat capacity", "SPECIFICHEATCAPACITY") + " of " + myelement.name + " is : " + myelement.specificHeatCapacity.ToString(), "Element's heat capacity. Data provided by Korriban Dynamics.", Descriptor.DescriptorType.Effect); materialDescriptors.Insert(0, item);
                    item.SetupDescriptor(
                        STRINGS.UI.FormatAsLink("  Thermal conductivity", "THERMALCONDUCTIVITY") + " of " + myelement.name + " is : " + myelement.thermalConductivity.ToString(), "Element's thermal conductivity. Data provided by Korriban Dynamics.", Descriptor.DescriptorType.Effect); materialDescriptors.Insert(0, item);


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

}
