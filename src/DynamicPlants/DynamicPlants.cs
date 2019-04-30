using Harmony;
using UnityEngine;
using KorribanDynamics.SithLordsPrevail;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq;
using System;
using TUNING;

namespace KorribanDynamics
{
    namespace SithLordsPrevail
    {
        public class r
        {
            public static float t01_1_1 = DynamicPlantsState.StateManager.State.MealwoodT11+273.15f;
            public static float t01_1_2 = DynamicPlantsState.StateManager.State.MealwoodT12+273.15f;
            public static bool ps01_1 = DynamicPlantsState.StateManager.State.MealwoodPS1;
            public static float p01_1_1 = DynamicPlantsState.StateManager.State.MealwoodP11/1000f;
            public static float p01_1_2 = DynamicPlantsState.StateManager.State.MealwoodP12/1000f;
            public static bool d01_1 = true;
            public static float t02_1_1 = DynamicPlantsState.StateManager.State.MushroomT11+273.15f;
            public static float t02_1_2 = DynamicPlantsState.StateManager.State.MushroomT12+273.15f;
            public static bool ps02_1 = DynamicPlantsState.StateManager.State.MushroomPS1;
            public static float p02_1_1 = DynamicPlantsState.StateManager.State.MushroomP11/1000f;
            public static float p02_1_2 = DynamicPlantsState.StateManager.State.MushroomP12/1000f;
            public static bool d02_1 = true;
            public static float t03_1_1 = DynamicPlantsState.StateManager.State.BristleBlossomT11+273.15f;
            public static float t03_1_2 = DynamicPlantsState.StateManager.State.BristleBlossomT12+273.15f;
            public static bool ps03_1 = DynamicPlantsState.StateManager.State.BristleBlossomPS1;
            public static float p03_1_1 = DynamicPlantsState.StateManager.State.BristleBlossomP11/1000f;
            public static float p03_1_2 = DynamicPlantsState.StateManager.State.BristleBlossomP12/1000f;
            public static bool d03_1 = true;
            public static float t04_1_1 = DynamicPlantsState.StateManager.State.SleetWheatT11+273.15f;
            public static float t04_1_2 = DynamicPlantsState.StateManager.State.SleetWheatT12+273.15f;
            public static bool ps04_1 = DynamicPlantsState.StateManager.State.SleetWheatPS1;
            public static float p04_1_1 = DynamicPlantsState.StateManager.State.SleetWheatP11/1000f;
            public static float p04_1_2 = DynamicPlantsState.StateManager.State.SleetWheatP12/1000f;
            public static bool d04_1 = true;
            public static float t05_1_1 = DynamicPlantsState.StateManager.State.GasGrassT11+273.15f;
            public static float t05_1_2 = DynamicPlantsState.StateManager.State.GasGrassT12+273.15f;
            public static bool ps05_1 = DynamicPlantsState.StateManager.State.GasGrassPS1;
            public static float p05_1_1 = DynamicPlantsState.StateManager.State.GasGrassP11/1000f;
            public static float p05_1_2 = DynamicPlantsState.StateManager.State.GasGrassP12/1000f;
            public static bool d05_1 = true;
            public static float t06_1_1 = DynamicPlantsState.StateManager.State.BalmLilyT11+273.15f;
            public static float t06_1_2 = DynamicPlantsState.StateManager.State.BalmLilyT12+273.15f;
            public static bool ps06_1 = DynamicPlantsState.StateManager.State.BalmLilyPS1;
            public static float p06_1_1 = DynamicPlantsState.StateManager.State.BalmLilyP11/1000f;
            public static float p06_1_2 = DynamicPlantsState.StateManager.State.BalmLilyP12/1000f;
            public static bool d06_1 = true;
            public static float t07_1_1 = DynamicPlantsState.StateManager.State.PinchaPepperT11+273.15f;
            public static float t07_1_2 = DynamicPlantsState.StateManager.State.PinchaPepperT12+273.15f;
            public static bool ps07_1 = DynamicPlantsState.StateManager.State.PinchaPepperPS1;
            public static float p07_1_1 = DynamicPlantsState.StateManager.State.PinchaPepperP11/1000f;
            public static float p07_1_2 = DynamicPlantsState.StateManager.State.PinchaPepperP12/1000f;
            public static bool d07_1 = true;
            public static float t08_1_1 = DynamicPlantsState.StateManager.State.ThimbleReedT11+273.15f;
            public static float t08_1_2 = DynamicPlantsState.StateManager.State.ThimbleReedT12+273.15f;
            public static bool ps08_1 = DynamicPlantsState.StateManager.State.ThimbleReedPS1;
            public static float p08_1_1 = DynamicPlantsState.StateManager.State.ThimbleReedP11/1000f;
            public static float p08_1_2 = DynamicPlantsState.StateManager.State.ThimbleReedP12/1000f;
            public static bool d08_1 = false;
            //Bluff Briar
            public static float zt01_1_1 = DynamicPlantsState.StateManager.State.BluffBriarT11 + 273.15f;
            public static float zt01_1_2 = DynamicPlantsState.StateManager.State.BluffBriarT12 + 273.15f;
            public static bool zps01_1 = DynamicPlantsState.StateManager.State.BluffBriarPS1;
            public static float zp01_1_1 = DynamicPlantsState.StateManager.State.BluffBriarP11 / 1000f;
            public static float zp01_1_2 = DynamicPlantsState.StateManager.State.BluffBriarP12 / 1000f;
            public static bool zd01_1 = true;
            //Buddy Bud        
            public static float zt02_1_1 = DynamicPlantsState.StateManager.State.BuddyBudT11 + 273.15f;
            public static float zt02_1_2 = DynamicPlantsState.StateManager.State.BuddyBudT12 + 273.15f;
            public static bool zps02_1 = DynamicPlantsState.StateManager.State.BuddyBudPS1;
            public static float zp02_1_1 = DynamicPlantsState.StateManager.State.BuddyBudP11 / 1000f;
            public static float zp02_1_2 = DynamicPlantsState.StateManager.State.BuddyBudP12 / 1000f;
            public static bool zd02_1 = true;
            //Mirth Leaf
            public static float zt03_1_1 = DynamicPlantsState.StateManager.State.MirthLeafT11 + 273.15f;
            public static float zt03_1_2 = DynamicPlantsState.StateManager.State.MirthLeafT12 + 273.15f;
            public static bool zps03_1 = DynamicPlantsState.StateManager.State.MirthLeafPS1;
            public static float zp03_1_1 = DynamicPlantsState.StateManager.State.MirthLeafP11 / 1000f;
            public static float zp03_1_2 = DynamicPlantsState.StateManager.State.MirthLeafP12 / 1000f;
            public static bool zd03_1 = true;
            //Jumping Joya 
            public static float zt04_1_1 = DynamicPlantsState.StateManager.State.JumpingJoyaT11 + 273.15f;
            public static float zt04_1_2 = DynamicPlantsState.StateManager.State.JumpingJoyaT12 + 273.15f;
            public static bool zps04_1 = DynamicPlantsState.StateManager.State.JumpingJoyaPS1;
            public static float zp04_1_1 = DynamicPlantsState.StateManager.State.JumpingJoyaP11 / 1000f;
            public static float zp04_1_2 = DynamicPlantsState.StateManager.State.JumpingJoyaP12 / 1000f;
            public static bool zd04_1 = true;

            //texts
            public static string t01 = "BasicPlantFood";
            public static string t02 = MushroomConfig.ID;
            public static string t03 = PrickleFruitConfig.ID;
            public static string t04 = "ColdWheatSeed";
            public static string t05 = "GasGrassHarvested";
            public static string t06 = SwampLilyFlowerConfig.ID;
            public static string t07 = SpiceNutConfig.ID;
            public static string t08 = BasicFabricConfig.ID;

            public static string z01 = null;
            public static string z02 = null;
            public static string z03 = null;
            public static string z04 = null;
        }
        public class e
        {
            public static int GasToEmit1 = DynamicPlantsState.StateManager.State.EmitGas1;
            public static int GasToEmit2 = DynamicPlantsState.StateManager.State.EmitGas2;
            public static int GasToEmit3 = DynamicPlantsState.StateManager.State.EmitGas3;
            public static int GasToEmit4 = DynamicPlantsState.StateManager.State.EmitGas4;
            public static int GasToEmit5 = DynamicPlantsState.StateManager.State.EmitGas5;
            public static int GasToEmit6 = DynamicPlantsState.StateManager.State.EmitGas6;
            public static int GasToEmit7 = DynamicPlantsState.StateManager.State.EmitGas7;
            public static int GasToEmit8 = DynamicPlantsState.StateManager.State.EmitGas8;
            public static int GasToEmit9 = DynamicPlantsState.StateManager.State.EmitGas9;
            public static int GasToEmit10 = DynamicPlantsState.StateManager.State.EmitGas10;
            public static int GasToEmit11 = DynamicPlantsState.StateManager.State.EmitGas11;
            public static int GasToEmit12 = DynamicPlantsState.StateManager.State.EmitGas12;
            public static float QtyToEmit1 = DynamicPlantsState.StateManager.State.EmitGas1Q;
            public static float QtyToEmit2 = DynamicPlantsState.StateManager.State.EmitGas2Q;
            public static float QtyToEmit3 = DynamicPlantsState.StateManager.State.EmitGas3Q;
            public static float QtyToEmit4 = DynamicPlantsState.StateManager.State.EmitGas4Q;
            public static float QtyToEmit5 = DynamicPlantsState.StateManager.State.EmitGas5Q;
            public static float QtyToEmit6 = DynamicPlantsState.StateManager.State.EmitGas6Q;
            public static float QtyToEmit7 = DynamicPlantsState.StateManager.State.EmitGas7Q;
            public static float QtyToEmit8 = DynamicPlantsState.StateManager.State.EmitGas8Q;
            public static float QtyToEmit9 = DynamicPlantsState.StateManager.State.EmitGas9Q;
            public static float QtyToEmit10 = DynamicPlantsState.StateManager.State.EmitGas10Q;
            public static float QtyToEmit11 = DynamicPlantsState.StateManager.State.EmitGas11Q;
            public static float QtyToEmit12 = DynamicPlantsState.StateManager.State.EmitGas12Q;
            public static bool ToEmit = false;
        }
        public class s
        {   /*List<SimHashes> sh = new List<SimHashes> { };sh.Add(SimHashes.Hydrogen);*/
            //DEFAULTS           
           /*1*/ public static SimHashes[] sh0 = new SimHashes[] { };
            //All
           /*2*/ public static SimHashes[] shAll = new SimHashes[] { SimHashes.Oxygen, SimHashes.ContaminatedOxygen, SimHashes.CarbonDioxide, SimHashes.Hydrogen, SimHashes.ChlorineGas, SimHashes.Methane, SimHashes.Steam };
            //All+Water
           /*3*/ public static SimHashes[] shAllW = new SimHashes[] { SimHashes.Oxygen, SimHashes.ContaminatedOxygen, SimHashes.CarbonDioxide, SimHashes.Hydrogen, SimHashes.ChlorineGas, SimHashes.Methane, SimHashes.Steam, SimHashes.DirtyWater, SimHashes.Water };
            //All+Water+Vacuum
           /*4*/ public static SimHashes[] shAllWV = new SimHashes[] { SimHashes.Oxygen, SimHashes.ContaminatedOxygen, SimHashes.CarbonDioxide, SimHashes.Hydrogen, SimHashes.ChlorineGas, SimHashes.Methane, SimHashes.Steam, SimHashes.DirtyWater, SimHashes.Water, SimHashes.Vacuum };

           /*5*/ public static SimHashes[] shNull = null;           

            public static int MealwoodAtm = DynamicPlantsState.StateManager.State.MealwoodA+1;
            public static int MushroomAtm = DynamicPlantsState.StateManager.State.MushroomA+1;
            public static int BristleBlossomAtm = DynamicPlantsState.StateManager.State.BristleBlossomA+1;
            public static int SleetWheatAtm = DynamicPlantsState.StateManager.State.SleetWheatA+1;
            public static int GasGrassAtm = DynamicPlantsState.StateManager.State.GasGrassA+1;
            public static int BalmLilyAtm = DynamicPlantsState.StateManager.State.BalmLilyA+1;
            public static int PinchaPepperAtm = DynamicPlantsState.StateManager.State.PinchaPepperA+1;
            public static int ThimbleReedAtm = DynamicPlantsState.StateManager.State.ThimbleReedA+1;
            public static int BluffBriarAtm = DynamicPlantsState.StateManager.State.BluffBriarA + 1;
            public static int BuddyBudAtm = DynamicPlantsState.StateManager.State.BuddyBudA + 1;
            public static int MirthLeafAtm = DynamicPlantsState.StateManager.State.MirthLeafA + 1;
            public static int JumpingJoyaAtm = DynamicPlantsState.StateManager.State.JumpingJoyaA + 1;

            public static SimHashes[] EmittedGas = new SimHashes[]
            {
                SimHashes.Hydrogen,
                SimHashes.CarbonDioxide,
                SimHashes.Oxygen,
                SimHashes.ContaminatedOxygen, 
                SimHashes.ChlorineGas,
                SimHashes.Methane,
                SimHashes.SourGas,
                SimHashes.Steam                
            };
        }
        public class t
        {
            public static List<Tag> testTag = new List<Tag> { SimHashes.Aerogel.CreateTag(),SimHashes.Algae.CreateTag(),SimHashes.Bitumen.CreateTag(),SimHashes.BleachStone.CreateTag(),SimHashes.Brick.CreateTag(),SimHashes.Carbon.CreateTag(),SimHashes.CarbonDioxide.CreateTag(),SimHashes.CarbonFibre.CreateTag(),SimHashes.CarbonGas.CreateTag(),SimHashes.Cement.CreateTag(),
                SimHashes.CementMix.CreateTag(),SimHashes.Ceramic.CreateTag(),SimHashes.Chlorine.CreateTag(),SimHashes.ChlorineGas.CreateTag(),SimHashes.Clay.CreateTag(),SimHashes.ContaminatedOxygen.CreateTag(),SimHashes.Copper.CreateTag(),SimHashes.CopperGas.CreateTag(),SimHashes.CrudeOil.CreateTag(),
                SimHashes.CrushedIce.CreateTag(),SimHashes.CrushedRock.CreateTag(),SimHashes.Cuprite.CreateTag(),SimHashes.Diamond.CreateTag(),SimHashes.Dirt.CreateTag(),SimHashes.DirtyIce.CreateTag(),SimHashes.DirtyWater.CreateTag(),SimHashes.Electrum.CreateTag(),SimHashes.Fertilizer.CreateTag(),SimHashes.FoolsGold.CreateTag(),
                SimHashes.Fossil.CreateTag(),SimHashes.Fullerene.CreateTag(),SimHashes.Glass.CreateTag(),SimHashes.Gold.CreateTag(),SimHashes.GoldAmalgam.CreateTag(),SimHashes.GoldGas.CreateTag(),SimHashes.Granite.CreateTag(),SimHashes.Helium.CreateTag(),SimHashes.Hydrogen.CreateTag(),SimHashes.Ice.CreateTag(),
                SimHashes.IgneousRock.CreateTag(),SimHashes.Iron.CreateTag(),SimHashes.IronGas.CreateTag(),SimHashes.IronOre.CreateTag(),SimHashes.Isoresin.CreateTag(),SimHashes.Katairite.CreateTag(),SimHashes.Lime.CreateTag(),SimHashes.LiquidCarbonDioxide.CreateTag(),SimHashes.LiquidHelium.CreateTag(),SimHashes.LiquidHydrogen.CreateTag(),
                SimHashes.LiquidMethane.CreateTag(),SimHashes.LiquidOxygen.CreateTag(),SimHashes.LiquidPhosphorus.CreateTag(),SimHashes.LiquidPropane.CreateTag(),SimHashes.LiquidSulfur.CreateTag(),SimHashes.MaficRock.CreateTag(),SimHashes.Magma.CreateTag(),SimHashes.Mercury.CreateTag(),SimHashes.MercuryGas.CreateTag(),SimHashes.Methane.CreateTag(),
                SimHashes.MoltenCarbon.CreateTag(),SimHashes.MoltenCopper.CreateTag(),SimHashes.MoltenGlass.CreateTag(),SimHashes.MoltenGold.CreateTag(),SimHashes.MoltenIron.CreateTag(),SimHashes.MoltenNiobium.CreateTag(),SimHashes.MoltenSteel.CreateTag(),SimHashes.MoltenTungsten.CreateTag(),SimHashes.Naphtha.CreateTag(),SimHashes.Niobium.CreateTag(),
                SimHashes.NiobiumGas.CreateTag(),SimHashes.Obsidian.CreateTag(),SimHashes.OxyRock.CreateTag(),SimHashes.Oxygen.CreateTag(),SimHashes.Petroleum.CreateTag(),SimHashes.PhosphateNodules.CreateTag(),SimHashes.Phosphorite.CreateTag(),SimHashes.Phosphorus.CreateTag(),SimHashes.PhosphorusGas.CreateTag(),SimHashes.Polypropylene.CreateTag(),
                SimHashes.Propane.CreateTag(),SimHashes.Radium.CreateTag(),SimHashes.RefinedCarbon.CreateTag(),SimHashes.Regolith.CreateTag(),SimHashes.RockGas.CreateTag(),SimHashes.Sand.CreateTag(),SimHashes.SandCement.CreateTag(),SimHashes.SandStone.CreateTag(),SimHashes.SedimentaryRock.CreateTag(),
                SimHashes.SlimeMold.CreateTag(),SimHashes.Snow.CreateTag(),SimHashes.SolidCarbonDioxide.CreateTag(),SimHashes.SolidChlorine.CreateTag(),SimHashes.SolidCrudeOil.CreateTag(),SimHashes.SolidHydrogen.CreateTag(),SimHashes.SolidMercury.CreateTag(),SimHashes.SolidMethane.CreateTag(),SimHashes.SolidNaphtha.CreateTag(),SimHashes.SolidOxygen.CreateTag(),
                SimHashes.SolidPetroleum.CreateTag(),SimHashes.SolidPropane.CreateTag(),SimHashes.SolidSuperCoolant.CreateTag(),SimHashes.SolidViscoGel.CreateTag(),SimHashes.SourGas.CreateTag(),SimHashes.Steam.CreateTag(),SimHashes.Steel.CreateTag(),SimHashes.SteelGas.CreateTag(),SimHashes.Sulfur.CreateTag(),SimHashes.SulfurGas.CreateTag(),SimHashes.SuperCoolant.CreateTag(),
                SimHashes.SuperCoolantGas.CreateTag(),SimHashes.SuperInsulator.CreateTag(),SimHashes.TempConductorSolid.CreateTag(),SimHashes.ToxicSand.CreateTag(),SimHashes.Tungsten.CreateTag(),SimHashes.TungstenGas.CreateTag(),SimHashes.ViscoGel.CreateTag(),SimHashes.Water.CreateTag(),SimHashes.Wolframite.CreateTag() };
        }
        public class PlantConfigs
        {
            public static float GlobalEmitFrequency = 1f;
            public static float GlobalMaxEmitPressure = 2f;
            public static List<float> Harv = new List<float>
            { 0f, 1f, 2f, 3f, 4f,5f,6f,7f,7.5f,8f,9f,10f,11f,12f,13f,14f,15f,16f,17f,18f,19f,20f};
            public static int GlobalPlantNumOfCrop1 = DynamicPlantsState.StateManager.State.MealLiceNumOfCrop;
            public static int GlobalPlantNumOfCrop2 = DynamicPlantsState.StateManager.State.MushroomNumOfCrop;
            public static int GlobalPlantNumOfCrop3 = DynamicPlantsState.StateManager.State.BerrieNumOfCrop;
            public static int GlobalPlantNumOfCrop4 = DynamicPlantsState.StateManager.State.ColdWheatNumOfCrop;
            public static int GlobalPlantNumOfCrop5 = DynamicPlantsState.StateManager.State.GasGrassNumOfCrop;
            public static int GlobalPlantNumOfCrop6 = DynamicPlantsState.StateManager.State.LillyNumOfCrop;
            public static int GlobalPlantNumOfCrop7 = DynamicPlantsState.StateManager.State.SpiceNumOfCrop;
            public static int GlobalPlantNumOfCrop8 = DynamicPlantsState.StateManager.State.FiberNumOfCrop;
        }
    }
    namespace Planting
    {        
        //Mealwood
        [HarmonyPatch(typeof(BasicSingleHarvestPlantConfig), "CreatePrefab")]//SimHashes.Oxygen,SimHashes.ContaminatedOxygen,SimHashes.CarbonDioxide
        public static class MealwoodPlanting
        {        
            public static void Postfix(BasicSingleHarvestPlantConfig __instance, ref GameObject __result)
            {
                switch (s.MealwoodAtm)
                {
                    case 1:EntityTemplates.ExtendEntityToBasicPlant(__result, r.t01_1_1-50f, r.t01_1_1, r.t01_1_2, r.t01_1_2+500f, s.sh0, r.ps01_1, r.p01_1_2, r.p01_1_1, r.t01, r.d01_1, false);break;
                    case 2:EntityTemplates.ExtendEntityToBasicPlant(__result, r.t01_1_1-50f, r.t01_1_1, r.t01_1_2, r.t01_1_2+500f, s.shAll, r.ps01_1, r.p01_1_2, r.p01_1_1, r.t01, r.d01_1, false); break;
                    case 3:EntityTemplates.ExtendEntityToBasicPlant(__result, r.t01_1_1-50f, r.t01_1_1, r.t01_1_2, r.t01_1_2+500f, s.shAllW, r.ps01_1, r.p01_1_2, r.p01_1_1, r.t01, r.d01_1, false); break;
                    case 4:EntityTemplates.ExtendEntityToBasicPlant(__result, r.t01_1_1-50f, r.t01_1_1, r.t01_1_2, r.t01_1_2+500f, s.shAllWV, r.ps01_1, r.p01_1_2, r.p01_1_1, r.t01, r.d01_1, false); break;
                }
                EntityTemplates.ExtendPlantToFertilizable(__result, new PlantElementAbsorber.ConsumeInfo[]    {
                    new PlantElementAbsorber.ConsumeInfo
                    {
                        tag = t.testTag[DynamicPlantsState.StateManager.State.IndexMealwoodF],
                        massConsumptionRate = DynamicPlantsState.StateManager.State.ConMealwoodF/1000/600f
                    }});
            }
        }
        //Mushroom
        [HarmonyPatch(typeof(MushroomPlantConfig), "CreatePrefab")]//SimHashes.CarbonDioxide
        public static class MushroomPlanting
        {
            public static void Postfix(MushroomPlantConfig __instance, ref GameObject __result)
            {
                switch (s.MushroomAtm)
                {
                    case 1:EntityTemplates.ExtendEntityToBasicPlant(__result, r.t02_1_1-50f, r.t02_1_1, r.t02_1_2, r.t02_1_2+500f, s.sh0, r.ps02_1, r.p02_1_2, r.p02_1_1, r.t02, r.d02_1, true); break;
                    case 2:EntityTemplates.ExtendEntityToBasicPlant(__result, r.t02_1_1-50f, r.t02_1_1, r.t02_1_2, r.t02_1_2+500f, s.shAll, r.ps02_1, r.p02_1_2, r.p02_1_1, r.t02, r.d02_1, true); break;
                    case 3:EntityTemplates.ExtendEntityToBasicPlant(__result, r.t02_1_1-50f, r.t02_1_1, r.t02_1_2, r.t02_1_2+500f, s.shAllW, r.ps02_1, r.p02_1_2, r.p02_1_1, r.t02, r.d02_1, true); break;
                    case 4:EntityTemplates.ExtendEntityToBasicPlant(__result, r.t02_1_1-50f, r.t02_1_1, r.t02_1_2, r.t02_1_2+500f, s.shAllWV, r.ps02_1, r.p02_1_2, r.p02_1_1, r.t02, r.d02_1, true); break;
                }
                EntityTemplates.ExtendPlantToFertilizable(__result, new PlantElementAbsorber.ConsumeInfo[]    {
                    new PlantElementAbsorber.ConsumeInfo
                    {
                        tag = t.testTag[DynamicPlantsState.StateManager.State.IndexMushroomF],
                        massConsumptionRate = DynamicPlantsState.StateManager.State.ConMushroomF/1000/600f
                    }});
                if (!DynamicPlantsState.StateManager.State.NeedsDark) { UnityEngine.Object.DestroyImmediate(__result.GetComponent<IlluminationVulnerable>()); }
            }
        }
        //Bristle Blossom 
        [HarmonyPatch(typeof(PrickleFlowerConfig), "CreatePrefab")]//SimHashes.Oxygen,SimHashes.ContaminatedOxygen,SimHashes.CarbonDioxide
        public static class BristleBlossomPlanting
        {
            public static void Postfix(PrickleFlowerConfig __instance, ref GameObject __result)
            {
                switch (s.BristleBlossomAtm)
                {
                    case 1:EntityTemplates.ExtendEntityToBasicPlant(__result, r.t03_1_1-50f, r.t03_1_1, r.t03_1_2, r.t03_1_2+500f, s.sh0, r.ps03_1, r.p03_1_2, r.p03_1_1, r.t03, r.d03_1, true); break;
                    case 2:EntityTemplates.ExtendEntityToBasicPlant(__result, r.t03_1_1-50f, r.t03_1_1, r.t03_1_2, r.t03_1_2+500f, s.shAll, r.ps03_1, r.p03_1_2, r.p03_1_1, r.t03, r.d03_1, true); break;
                    case 3:EntityTemplates.ExtendEntityToBasicPlant(__result, r.t03_1_1-50f, r.t03_1_1, r.t03_1_2, r.t03_1_2+500f, s.shAllW, r.ps03_1, r.p03_1_2, r.p03_1_1, r.t03, r.d03_1, true); break;
                    case 4:EntityTemplates.ExtendEntityToBasicPlant(__result, r.t03_1_1-50f, r.t03_1_1, r.t03_1_2, r.t03_1_2+500f, s.shAllWV, r.ps03_1, r.p03_1_2, r.p03_1_1, r.t03, r.d03_1, true); break;
                }
                EntityTemplates.ExtendPlantToIrrigated(__result, new PlantElementAbsorber.ConsumeInfo[]    {
                    new PlantElementAbsorber.ConsumeInfo
                    {
                        tag = t.testTag[DynamicPlantsState.StateManager.State.IndexBristleBlossomI],
                        massConsumptionRate = DynamicPlantsState.StateManager.State.ConBristleBlossomI/1000/600f
                    }});
                if (!DynamicPlantsState.StateManager.State.NeedsLight) { UnityEngine.Object.DestroyImmediate(__result.GetComponent<IlluminationVulnerable>()); }
            }              
        }
        //Sleet Wheat
        [HarmonyPatch(typeof(ColdWheatConfig), "CreatePrefab")]//SimHashes.Oxygen,SimHashes.ContaminatedOxygen,SimHashes.CarbonDioxide
        public static class SleetWheatPlanting
        {
            public static void Postfix(ColdWheatConfig __instance, ref GameObject __result)
            {
                switch (s.SleetWheatAtm)
                {
                    case 1: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t04_1_1-50f, r.t04_1_1, r.t04_1_2, r.t04_1_2+500f, s.sh0, r.ps04_1, r.p04_1_2, r.p04_1_1, r.t04, r.d04_1, true); break;
                    case 2: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t04_1_1-50f, r.t04_1_1, r.t04_1_2, r.t04_1_2+500f, s.shAll, r.ps04_1, r.p04_1_2, r.p04_1_1, r.t04, r.d04_1, true); break;
                    case 3: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t04_1_1-50f, r.t04_1_1, r.t04_1_2, r.t04_1_2+500f, s.shAllW, r.ps04_1, r.p04_1_2, r.p04_1_1, r.t04, r.d04_1, true); break;
                    case 4: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t04_1_1-50f, r.t04_1_1, r.t04_1_2, r.t04_1_2+500f, s.shAllWV, r.ps04_1, r.p04_1_2, r.p04_1_1, r.t04, r.d04_1, true); break;
                }
                EntityTemplates.ExtendPlantToIrrigated(__result, new PlantElementAbsorber.ConsumeInfo[]    {
                    new PlantElementAbsorber.ConsumeInfo
                    {
                        tag = t.testTag[DynamicPlantsState.StateManager.State.IndexSleetWheatI],
                        massConsumptionRate = DynamicPlantsState.StateManager.State.ConSleetWheatI/1000/600f
                    }});
                EntityTemplates.ExtendPlantToFertilizable(__result, new PlantElementAbsorber.ConsumeInfo[]{
                        new PlantElementAbsorber.ConsumeInfo
                        {
                            tag = t.testTag[DynamicPlantsState.StateManager.State.IndexSleetWheatF],
                            massConsumptionRate = DynamicPlantsState.StateManager.State.ConSleetWheatF/1000/600f
                        }});
            }
        }
        //Gas Grass	
        [HarmonyPatch(typeof(GasGrassConfig), "CreatePrefab")]//ANY
        public static class GasGrassPlanting
        {
            public static void Postfix(GasGrassConfig __instance, ref GameObject __result)
            {
                switch (s.GasGrassAtm)
                {
                    case 1: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t05_1_1-50f, r.t05_1_1, r.t05_1_2, r.t05_1_2+500f, s.shNull, r.ps05_1, r.p05_1_2, r.p05_1_1, r.t05, r.d05_1, true); break;
                    case 2: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t05_1_1-50f, r.t05_1_1, r.t05_1_2, r.t05_1_2+500f, s.shAll, r.ps05_1, r.p05_1_2, r.p05_1_1, r.t05, r.d05_1, true); break;
                    case 3: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t05_1_1-50f, r.t05_1_1, r.t05_1_2, r.t05_1_2+500f, s.shAllW, r.ps05_1, r.p05_1_2, r.p05_1_1, r.t05, r.d05_1, true); break;
                    case 4: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t05_1_1-50f, r.t05_1_1, r.t05_1_2, r.t05_1_2+500f, s.shAllWV, r.ps05_1, r.p05_1_2, r.p05_1_1, r.t05, r.d05_1, true); break;
                }
                EntityTemplates.ExtendPlantToIrrigated(__result, new PlantElementAbsorber.ConsumeInfo[]    {
                    new PlantElementAbsorber.ConsumeInfo
                    {
                        tag = t.testTag[DynamicPlantsState.StateManager.State.IndexGasGrassI],
                        massConsumptionRate = DynamicPlantsState.StateManager.State.ConGasGrassI/1000/600f
                    }});
            }
        }
        
        //Balm Lily
        [HarmonyPatch(typeof(SwampLilyConfig), "CreatePrefab")]
        public static class BalmLilyPlanting
        {
            public static void Postfix(GasGrassConfig __instance, ref GameObject __result)
            {
                switch (s.BalmLilyAtm)
                {
                    case 1: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t06_1_1 - 50f, r.t06_1_1, r.t06_1_2, r.t06_1_2 + 500f, s.shNull, r.ps06_1, r.p06_1_2, r.p06_1_1, r.t06, r.d06_1, true); break;
                    case 2: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t06_1_1 - 50f, r.t06_1_1, r.t06_1_2, r.t06_1_2 + 500f, s.shAll, r.ps06_1, r.p06_1_2, r.p06_1_1, r.t06, r.d06_1, true); break;
                    case 3: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t06_1_1 - 50f, r.t06_1_1, r.t06_1_2, r.t06_1_2 + 500f, s.shAllW, r.ps06_1, r.p06_1_2, r.p06_1_1, r.t06, r.d06_1, true); break;
                    case 4: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t06_1_1 - 50f, r.t06_1_1, r.t06_1_2, r.t06_1_2 + 500f, s.shAllWV, r.ps06_1, r.p06_1_2, r.p06_1_1, r.t06, r.d06_1, true); break;
                }
            }

            //static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            //    {
            //        var codes = new List<CodeInstruction>(instructions);
            //        for (int i = 0; i < codes.Count; i++)
            //        {
            //            if ((codes[i].opcode == OpCodes.Ldc_R4) && ((Single)codes[i].operand == 258.15f))
            //            {
            //                codes[i].operand = r.t06_1_1 - 50f;codes[i+2].operand = r.t06_1_1;codes[i+4].operand = r.t06_1_2;codes[i+6].operand = r.t06_1_1 +500f;
            //            }
            //        }
            //        return codes.AsEnumerable();
            //    }
        } 
        
        //Pincha Pepper	
        [HarmonyPatch(typeof(SpiceVineConfig), "CreatePrefab")]//ANY
        public static class PinchaPepperPlanting
        {
                public static void Postfix(SpiceVineConfig __instance, ref GameObject __result)
            {
                switch (s.PinchaPepperAtm)
                    {
                    
                        case 1: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t07_1_1-50f, r.t07_1_1, r.t07_1_2, r.t07_1_2+500f, s.shNull, r.ps07_1, r.p07_1_2, r.p07_1_1, r.t07, r.d07_1, true); break;
                        case 2: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t07_1_1-50f, r.t07_1_1, r.t07_1_2, r.t07_1_2+500f, s.shNull, r.ps07_1, r.p07_1_2, r.p07_1_1, r.t07, r.d07_1, true); break;
                        case 3: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t07_1_1-50f, r.t07_1_1, r.t07_1_2, r.t07_1_2+500f, s.shNull, r.ps07_1, r.p07_1_2, r.p07_1_1, r.t07, r.d07_1, true); break;
                        case 4: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t07_1_1-50f, r.t07_1_1, r.t07_1_2, r.t07_1_2+500f, s.shNull, r.ps07_1, r.p07_1_2, r.p07_1_1, r.t07, r.d07_1, true); break;
                    }
                    EntityTemplates.ExtendPlantToIrrigated(__result, new PlantElementAbsorber.ConsumeInfo[]{
                    new PlantElementAbsorber.ConsumeInfo
                    {
                        tag = t.testTag[DynamicPlantsState.StateManager.State.IndexPinchaPepperI],
                        massConsumptionRate = DynamicPlantsState.StateManager.State.ConPinchaPepperI/1000/600f
                    }});
                    EntityTemplates.ExtendPlantToFertilizable(__result, new PlantElementAbsorber.ConsumeInfo[]{
                        new PlantElementAbsorber.ConsumeInfo
                        {
                            tag = t.testTag[DynamicPlantsState.StateManager.State.IndexPinchaPepperF],
                            massConsumptionRate = DynamicPlantsState.StateManager.State.ConPinchaPepperF/1000/600f
                        }});
                }
        }
        //Thimble Reed	
        [HarmonyPatch(typeof(BasicFabricMaterialPlantConfig), "CreatePrefab")]//SimHashes.Oxygen,SimHashes.ContaminatedOxygen,SimHashes.CarbonDioxide,SimHashes.DirtyWater,SimHashes.Water
        public static class ThimbleReedPlanting
        {
        public static void Postfix(BasicFabricMaterialPlantConfig __instance, ref GameObject __result)
                {
                switch (s.ThimbleReedAtm)
                    {
                        case 1: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t08_1_1-50f, r.t08_1_1, r.t08_1_2, r.t08_1_2+500f, s.sh0, r.ps08_1, r.p08_1_2, r.p08_1_1, r.t08, r.d08_1, true); break;
                        case 2: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t08_1_1-50f, r.t08_1_1, r.t08_1_2, r.t08_1_2+500f, s.shAll, r.ps08_1, r.p08_1_2, r.p08_1_1, r.t08, r.d08_1, true); break;
                        case 3: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t08_1_1-50f, r.t08_1_1, r.t08_1_2, r.t08_1_2+500f, s.shAllW, r.ps08_1, r.p08_1_2, r.p08_1_1, r.t08, r.d08_1, true); break;
                        case 4: EntityTemplates.ExtendEntityToBasicPlant(__result, r.t08_1_1-50f, r.t08_1_1, r.t08_1_2, r.t08_1_2+500f, s.shAllWV, r.ps08_1, r.p08_1_2, r.p08_1_1, r.t08, r.d08_1, true); break;
                    }
                    EntityTemplates.ExtendPlantToIrrigated(__result, new PlantElementAbsorber.ConsumeInfo[]    
                    {
                    new PlantElementAbsorber.ConsumeInfo
                    {
                        tag = t.testTag[DynamicPlantsState.StateManager.State.IndexThimbleReedI],
                        massConsumptionRate = DynamicPlantsState.StateManager.State.ConThimbleReedI/1000/600f
                    }});
                }
        }
        
        //Bluff Briar
        [HarmonyPatch(typeof(PrickleGrassConfig), "CreatePrefab")]
        public class BluffBriarOxygen
        {
            public static void Postfix(PrickleGrassConfig __instance, ref GameObject __result)
            {
                switch (s.BluffBriarAtm)
                {
                    case 1: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt01_1_1 - 50f, r.zt01_1_1, r.zt01_1_2, r.zt01_1_2 + 500f, s.sh0, r.zps01_1, r.zp01_1_2, r.zp01_1_1, r.z01, r.zd01_1, false); break;
                    case 2: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt01_1_1 - 50f, r.zt01_1_1, r.zt01_1_2, r.zt01_1_2 + 500f, s.shAll, r.zps01_1, r.zp01_1_2, r.zp01_1_1, r.z01, r.zd01_1, false); break;
                    case 3: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt01_1_1 - 50f, r.zt01_1_1, r.zt01_1_2, r.zt01_1_2 + 500f, s.shAllW, r.zps01_1, r.zp01_1_2, r.zp01_1_1, r.z01, r.zd01_1, false); break;
                    case 4: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt01_1_1 - 50f, r.zt01_1_1, r.zt01_1_2, r.zt01_1_2 + 500f, s.shAllWV, r.zps01_1, r.zp01_1_2, r.zp01_1_1, r.z01, r.zd01_1, false); break;
                }
            }
        }
        //Buddy Bud        
        [HarmonyPatch(typeof(BulbPlantConfig), "CreatePrefab")]
        public class BuddyBudOxygen
        {
            public static void Postfix(BulbPlantConfig __instance, ref GameObject __result)
            {
                switch (s.BuddyBudAtm)
                {
                    case 1: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt02_1_1 - 50f, r.zt02_1_1, r.zt02_1_2, r.zt02_1_2 + 500f, s.sh0, r.zps02_1, r.zp02_1_2, r.zp02_1_1, r.z02, r.zd02_1, false); break;
                    case 2: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt02_1_1 - 50f, r.zt02_1_1, r.zt02_1_2, r.zt02_1_2 + 500f, s.shAll, r.zps02_1, r.zp02_1_2, r.zp02_1_1, r.z02, r.zd02_1, false); break;
                    case 3: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt02_1_1 - 50f, r.zt02_1_1, r.zt02_1_2, r.zt02_1_2 + 500f, s.shAllW, r.zps02_1, r.zp02_1_2, r.zp02_1_1, r.z02, r.zd02_1, false); break;
                    case 4: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt02_1_1 - 50f, r.zt02_1_1, r.zt02_1_2, r.zt02_1_2 + 500f, s.shAllWV, r.zps02_1, r.zp02_1_2, r.zp02_1_1, r.z02, r.zd02_1, false); break;
                }
            }
        }
        //Mirth Leaf
        [HarmonyPatch(typeof(LeafyPlantConfig), "CreatePrefab")]
        public class MirthLeafOxygen
        {
            public static void Postfix(LeafyPlantConfig __instance, ref GameObject __result)
            {
                switch (s.MirthLeafAtm)
                {
                    case 1: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt03_1_1 - 50f, r.zt03_1_1, r.zt03_1_2, r.zt03_1_2 + 500f, s.sh0, r.zps03_1, r.zp03_1_2, r.zp03_1_1, r.z03, r.zd03_1, false); break;
                    case 2: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt03_1_1 - 50f, r.zt03_1_1, r.zt03_1_2, r.zt03_1_2 + 500f, s.shAll, r.zps03_1, r.zp03_1_2, r.zp03_1_1, r.z03, r.zd03_1, false); break;
                    case 3: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt03_1_1 - 50f, r.zt03_1_1, r.zt03_1_2, r.zt03_1_2 + 500f, s.shAllW, r.zps03_1, r.zp03_1_2, r.zp03_1_1, r.z03, r.zd03_1, false); break;
                    case 4: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt03_1_1 - 50f, r.zt03_1_1, r.zt03_1_2, r.zt03_1_2 + 500f, s.shAllWV, r.zps03_1, r.zp03_1_2, r.zp03_1_1, r.z03, r.zd03_1, false); break;
                }
            }
        }
        //Jumping Joya 
        [HarmonyPatch(typeof(CactusPlantConfig), "CreatePrefab")]
        public class JumpingJoyaOxygen
        {
            public static void Postfix(CactusPlantConfig __instance, ref GameObject __result)
            {
                switch (s.JumpingJoyaAtm)
                {
                    case 1: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt04_1_1 - 50f, r.zt04_1_1, r.zt04_1_2, r.zt04_1_2 + 500f, s.sh0, r.zps04_1, r.zp04_1_2, r.zp04_1_1, r.z04, r.zd04_1, false); break;
                    case 2: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt04_1_1 - 50f, r.zt04_1_1, r.zt04_1_2, r.zt04_1_2 + 500f, s.shAll, r.zps04_1, r.zp04_1_2, r.zp04_1_1, r.z04, r.zd04_1, false); break;
                    case 3: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt04_1_1 - 50f, r.zt04_1_1, r.zt04_1_2, r.zt04_1_2 + 500f, s.shAllW, r.zps04_1, r.zp04_1_2, r.zp04_1_1, r.z04, r.zd04_1, false); break;
                    case 4: EntityTemplates.ExtendEntityToBasicPlant(__result, r.zt04_1_1 - 50f, r.zt04_1_1, r.zt04_1_2, r.zt04_1_2 + 500f, s.shAllWV, r.zps04_1, r.zp04_1_2, r.zp04_1_1, r.z04, r.zd04_1, false); break;
                }
            }
        }
    }
    
    namespace Oxxy
    {
        //Mealwood
        [HarmonyPatch(typeof(BasicSingleHarvestPlantConfig), "CreatePrefab")]
        public static class MealwoodPlanting
        {
            public static void Postfix(BasicSingleHarvestPlantConfig __instance, ref GameObject __result)
            {              
                float tempemit = e.QtyToEmit1 / 1000f;
                if (e.GasToEmit1 == -1) {return;}
                else
                {
                    __result.AddOrGet<ElementEmitter>();
                    __result.AddOrGet<ElementEmitter>().emissionFrequency = PlantConfigs.GlobalEmitFrequency;
                    __result.AddOrGet<ElementEmitter>().emitRange = 1;
                    __result.AddOrGet<ElementEmitter>().maxPressure = PlantConfigs.GlobalMaxEmitPressure;
                    __result.AddOrGet<ElementEmitter>().outputElement = new ElementConverter.OutputElement(tempemit, s.EmittedGas[e.GasToEmit1], outputTemperature: 298.15f, storeOutput: false, outputElementOffsety: 1f);
                    __result.AddOrGet<ElementEmitter>().showDescriptor = true;
                }
            }
        }
        //Mushroom
        [HarmonyPatch(typeof(MushroomPlantConfig), "CreatePrefab")]
        public static class MushroomPlanting
        {
            public static void Postfix(MushroomPlantConfig __instance, ref GameObject __result)
            {
                float tempemit = e.QtyToEmit2 / 1000f;
                if (e.GasToEmit2 == -1) { return; }
                else
                {
                    __result.AddOrGet<ElementEmitter>();
                    __result.AddOrGet<ElementEmitter>().emissionFrequency = PlantConfigs.GlobalEmitFrequency;
                    __result.AddOrGet<ElementEmitter>().emitRange = 1;
                    __result.AddOrGet<ElementEmitter>().maxPressure = PlantConfigs.GlobalMaxEmitPressure;
                    __result.AddOrGet<ElementEmitter>().outputElement = new ElementConverter.OutputElement(tempemit, s.EmittedGas[e.GasToEmit2], outputTemperature: 298.15f, storeOutput: false, outputElementOffsety: 1f);
                    __result.AddOrGet<ElementEmitter>().showDescriptor = true;
                }
            }
        }
        //Bristle Blossom 
        [HarmonyPatch(typeof(PrickleFlowerConfig), "CreatePrefab")]
        public static class BristleBlossomPlanting
        {
            public static void Postfix(PrickleFlowerConfig __instance, ref GameObject __result)
            {
                float tempemit = e.QtyToEmit3 / 1000f;
                if (e.GasToEmit3 == -1) { return; }
                else
                {
                    __result.AddOrGet<ElementEmitter>();
                    __result.AddOrGet<ElementEmitter>().emissionFrequency = PlantConfigs.GlobalEmitFrequency;
                    __result.AddOrGet<ElementEmitter>().emitRange = 1;
                    __result.AddOrGet<ElementEmitter>().maxPressure = PlantConfigs.GlobalMaxEmitPressure;
                    __result.AddOrGet<ElementEmitter>().outputElement = new ElementConverter.OutputElement(tempemit, s.EmittedGas[e.GasToEmit3], outputTemperature: 298.15f, storeOutput: false, outputElementOffsety: 1f);
                    __result.AddOrGet<ElementEmitter>().showDescriptor = true;
                }
            }
        }
        //Sleet Wheat
        [HarmonyPatch(typeof(ColdWheatConfig), "CreatePrefab")]
        public static class SleetWheatPlanting
        {
            public static void Postfix(ColdWheatConfig __instance, ref GameObject __result)
            {
                float tempemit = e.QtyToEmit4 / 1000f;
                if (e.GasToEmit4 == -1) { return; }
                else
                {
                    __result.AddOrGet<ElementEmitter>();
                    __result.AddOrGet<ElementEmitter>().emissionFrequency = PlantConfigs.GlobalEmitFrequency;
                    __result.AddOrGet<ElementEmitter>().emitRange = 1;
                    __result.AddOrGet<ElementEmitter>().maxPressure = PlantConfigs.GlobalMaxEmitPressure;
                    __result.AddOrGet<ElementEmitter>().outputElement = new ElementConverter.OutputElement(tempemit, s.EmittedGas[e.GasToEmit4], outputTemperature: 298.15f, storeOutput: false, outputElementOffsety: 1f);
                    __result.AddOrGet<ElementEmitter>().showDescriptor = true;
                }
            }
        }
        //Gas Grass	
        [HarmonyPatch(typeof(GasGrassConfig), "CreatePrefab")]
        public static class GasGrassPlanting
        {
            public static void Postfix(GasGrassConfig __instance, ref GameObject __result)
            {
                float tempemit = e.QtyToEmit5 / 1000f;
                if (e.GasToEmit5 == -1) { return; }
                else
                {
                    __result.AddOrGet<ElementEmitter>();
                    __result.AddOrGet<ElementEmitter>().emissionFrequency = PlantConfigs.GlobalEmitFrequency;
                    __result.AddOrGet<ElementEmitter>().emitRange = 1;
                    __result.AddOrGet<ElementEmitter>().maxPressure = PlantConfigs.GlobalMaxEmitPressure;
                    __result.AddOrGet<ElementEmitter>().outputElement = new ElementConverter.OutputElement(tempemit, s.EmittedGas[e.GasToEmit5], outputTemperature: 298.15f, storeOutput: false, outputElementOffsety: 1f);
                    __result.AddOrGet<ElementEmitter>().showDescriptor = true;
                }
            }
        }
        //Balm Lily
        [HarmonyPatch(typeof(SwampLilyConfig), "CreatePrefab")]
        public static class BalmLilyPlanting
        {
            public static void Postfix(SwampLilyConfig __instance, ref GameObject __result)
            {
                float tempemit = e.QtyToEmit6 / 1000f;
                if (e.GasToEmit6 == -1) { return; }
                else
                {
                    __result.AddOrGet<ElementEmitter>();
                    __result.AddOrGet<ElementEmitter>().emissionFrequency = PlantConfigs.GlobalEmitFrequency;
                    __result.AddOrGet<ElementEmitter>().emitRange = 1;
                    __result.AddOrGet<ElementEmitter>().maxPressure = PlantConfigs.GlobalMaxEmitPressure;
                    __result.AddOrGet<ElementEmitter>().outputElement = new ElementConverter.OutputElement(tempemit, s.EmittedGas[e.GasToEmit6], outputTemperature: 298.15f, storeOutput: false, outputElementOffsety: 1f);
                    __result.AddOrGet<ElementEmitter>().showDescriptor = true;
                }
            }
        }
        //Pincha Pepper	
        [HarmonyPatch(typeof(SpiceVineConfig), "CreatePrefab")]
        public static class PinchaPepperPlanting
        {
            public static void Postfix(SpiceVineConfig __instance, ref GameObject __result)
            {
                float tempemit = e.QtyToEmit7 / 1000f;
                if (e.GasToEmit7 == -1) { return; }
                else
                {
                    __result.AddOrGet<ElementEmitter>();
                    __result.AddOrGet<ElementEmitter>().emissionFrequency = PlantConfigs.GlobalEmitFrequency;
                    __result.AddOrGet<ElementEmitter>().emitRange = 1;
                    __result.AddOrGet<ElementEmitter>().maxPressure = PlantConfigs.GlobalMaxEmitPressure;
                    __result.AddOrGet<ElementEmitter>().outputElement = new ElementConverter.OutputElement(tempemit, s.EmittedGas[e.GasToEmit7], outputTemperature: 298.15f, storeOutput: false, outputElementOffsety: 1f);
                    __result.AddOrGet<ElementEmitter>().showDescriptor = true;
                }
            }
        }
        //Thimble Reed	
        [HarmonyPatch(typeof(BasicFabricMaterialPlantConfig), "CreatePrefab")]
        public static class ThimbleReedPlanting
        {
            public static void Postfix(BasicFabricMaterialPlantConfig __instance, ref GameObject __result)
            {
                float tempemit = e.QtyToEmit8 / 1000f;
                if (e.GasToEmit8 == -1) { return; }
                else
                {
                    __result.AddOrGet<ElementEmitter>();
                    __result.AddOrGet<ElementEmitter>().emissionFrequency = PlantConfigs.GlobalEmitFrequency;
                    __result.AddOrGet<ElementEmitter>().emitRange = 1;
                    __result.AddOrGet<ElementEmitter>().maxPressure = PlantConfigs.GlobalMaxEmitPressure;
                    __result.AddOrGet<ElementEmitter>().outputElement = new ElementConverter.OutputElement(tempemit, s.EmittedGas[e.GasToEmit8], outputTemperature: 298.15f, storeOutput: false, outputElementOffsety: 1f);
                    __result.AddOrGet<ElementEmitter>().showDescriptor = true;
                }
            }
        }


        //Bluff Briar
        [HarmonyPatch(typeof(PrickleGrassConfig), "CreatePrefab")]
        public class BluffBriarOxygen
        {
            public static void Postfix(PrickleGrassConfig __instance, ref GameObject __result)
            {
                float tempemit = e.QtyToEmit9 / 1000f;
                if (e.GasToEmit9 == -1) { return; }
                else
                {
                    __result.AddOrGet<ElementEmitter>();
                    __result.AddOrGet<ElementEmitter>().emissionFrequency = PlantConfigs.GlobalEmitFrequency;
                    __result.AddOrGet<ElementEmitter>().emitRange = 1;
                    __result.AddOrGet<ElementEmitter>().maxPressure = PlantConfigs.GlobalMaxEmitPressure;
                    __result.AddOrGet<ElementEmitter>().outputElement = new ElementConverter.OutputElement(tempemit, s.EmittedGas[e.GasToEmit9], outputTemperature: 298.15f, storeOutput: false, outputElementOffsety: 1f);
                    __result.AddOrGet<ElementEmitter>().showDescriptor = true;
                }
            }
        }
        //Buddy Bud        
        [HarmonyPatch(typeof(BulbPlantConfig), "CreatePrefab")]
        public class BuddyBudOxygen
        {
            public static void Postfix(BulbPlantConfig __instance, ref GameObject __result)
            {
                float tempemit = e.QtyToEmit10 / 1000f;
                if (e.GasToEmit10 == -1) { return; }
                else
                {
                    __result.AddOrGet<ElementEmitter>();
                    __result.AddOrGet<ElementEmitter>().emissionFrequency = PlantConfigs.GlobalEmitFrequency;
                    __result.AddOrGet<ElementEmitter>().emitRange = 1;
                    __result.AddOrGet<ElementEmitter>().maxPressure = PlantConfigs.GlobalMaxEmitPressure;
                    __result.AddOrGet<ElementEmitter>().outputElement = new ElementConverter.OutputElement(tempemit, s.EmittedGas[e.GasToEmit10], outputTemperature: 298.15f, storeOutput: false, outputElementOffsety: 1f);
                    __result.AddOrGet<ElementEmitter>().showDescriptor = true;
                }
            }
        }
        //Mirth Leaf
        [HarmonyPatch(typeof(LeafyPlantConfig), "CreatePrefab")]
        public class MirthLeafOxygen
        {
            public static void Postfix(LeafyPlantConfig __instance, ref GameObject __result)
            {
                float tempemit = e.QtyToEmit11 / 1000f;
                if (e.GasToEmit11 == -1) { return; }
                else
                {
                    __result.AddOrGet<ElementEmitter>();
                    __result.AddOrGet<ElementEmitter>().emissionFrequency = PlantConfigs.GlobalEmitFrequency;
                    __result.AddOrGet<ElementEmitter>().emitRange = 1;
                    __result.AddOrGet<ElementEmitter>().maxPressure = PlantConfigs.GlobalMaxEmitPressure;
                    __result.AddOrGet<ElementEmitter>().outputElement = new ElementConverter.OutputElement(tempemit, s.EmittedGas[e.GasToEmit11], outputTemperature: 298.15f, storeOutput: false, outputElementOffsety: 1f);
                    __result.AddOrGet<ElementEmitter>().showDescriptor = true;
                }
            }
        }
        //Jumping Joya 
        [HarmonyPatch(typeof(CactusPlantConfig), "CreatePrefab")]
        public class JumpingJoyaOxygen
        {
            public static void Postfix(CactusPlantConfig __instance, ref GameObject __result)
            {
                float tempemit = e.QtyToEmit12 / 1000f;
                if (e.GasToEmit12 == -1) { return; }
                else
                {
                    __result.AddOrGet<ElementEmitter>();
                    __result.AddOrGet<ElementEmitter>().emissionFrequency = PlantConfigs.GlobalEmitFrequency;
                    __result.AddOrGet<ElementEmitter>().emitRange = 1;
                    __result.AddOrGet<ElementEmitter>().maxPressure = PlantConfigs.GlobalMaxEmitPressure;
                    __result.AddOrGet<ElementEmitter>().outputElement = new ElementConverter.OutputElement(tempemit, s.EmittedGas[e.GasToEmit12], outputTemperature: 298.15f, storeOutput: false, outputElementOffsety: 1f);
                    __result.AddOrGet<ElementEmitter>().showDescriptor = true;
                }
            }
        }
    }

    namespace HarvestTime
    {
        [HarmonyPatch(typeof(Db), "Initialize")]
        class TheDBCheats
        {
            private static void Prefix(Db __instance)
            {


                CROPS.CROP_TYPES = new List<Crop.CropVal>
                {
                    new Crop.CropVal("BasicPlantFood", PlantConfigs.Harv[DynamicPlantsState.StateManager.State.MealLiceToHarvestTime]*600f, PlantConfigs.GlobalPlantNumOfCrop1, true),
                    new Crop.CropVal(MushroomConfig.ID, PlantConfigs.Harv[DynamicPlantsState.StateManager.State.MushroomToHarvestTime]*600f, PlantConfigs.GlobalPlantNumOfCrop2, true),
                    new Crop.CropVal(PrickleFruitConfig.ID, PlantConfigs.Harv[DynamicPlantsState.StateManager.State.BerrieToHarvestTime]*600f, PlantConfigs.GlobalPlantNumOfCrop3, true),
                    new Crop.CropVal("ColdWheatSeed", PlantConfigs.Harv[DynamicPlantsState.StateManager.State.ColdWheatToHarvestTime]*600f, PlantConfigs.GlobalPlantNumOfCrop4, true),
                    new Crop.CropVal("GasGrassHarvested", PlantConfigs.Harv[DynamicPlantsState.StateManager.State.GasGrassToHarvestTime]*600f, PlantConfigs.GlobalPlantNumOfCrop5, true),
                    new Crop.CropVal(SwampLilyFlowerConfig.ID,PlantConfigs.Harv[DynamicPlantsState.StateManager.State.LillyToHarvestTime]*600f, PlantConfigs.GlobalPlantNumOfCrop6, true),
                    new Crop.CropVal(SpiceNutConfig.ID, PlantConfigs.Harv[DynamicPlantsState.StateManager.State.SpiceToHarvestTime]*600f, PlantConfigs.GlobalPlantNumOfCrop7, true),
                    new Crop.CropVal(BasicFabricConfig.ID, PlantConfigs.Harv[DynamicPlantsState.StateManager.State.FiberToHarvestTime]*600f, PlantConfigs.GlobalPlantNumOfCrop8, true)
                };
            }
        }
    }
    namespace Temp
    {
    }


}
