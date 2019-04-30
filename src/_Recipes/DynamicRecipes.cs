using Harmony;
using System.Collections.Generic;
using UnityEngine;

namespace KorribanDynamics
{
    namespace DynamicRecipes
    {
        namespace Refinement_Changes
        {
            namespace Molecular_Forge
            {
                [HarmonyPatch(typeof(SupermaterialRefineryConfig), "ConfigureBuildingTemplate")]
                public static class SupermaterialRefinerySlimeMoldMod
                {
                    public static void Postfix()
                    {
                        //------Recharger
                        Tag tag1_01 = SimHashes.Regolith.CreateTag();
                        Tag tag2_01 = SimHashes.Katairite.CreateTag();
                        Tag tag3_01 = SimHashes.Steel.CreateTag();
                        Tag tag4_01 = SimHashes.Sulfur.CreateTag();
                        Tag tag5_01 = SimHashes.Gold.CreateTag();
                        Tag tag6_01 = ResearchDatabankConfig.ID;
                        Tag tag7_01 = GeneShufflerRechargeConfig.ID;

                        ComplexRecipe.RecipeElement[] ingredients_01 = new ComplexRecipe.RecipeElement[]
                        {
                            new ComplexRecipe.RecipeElement(tag1_01, 10000f),
                            new ComplexRecipe.RecipeElement(tag2_01, 1000f),
                            new ComplexRecipe.RecipeElement(tag3_01, 2000f),
                            new ComplexRecipe.RecipeElement(tag4_01, 100f),
                            new ComplexRecipe.RecipeElement(tag5_01, 5000f),
                            new ComplexRecipe.RecipeElement(tag6_01, 101f)
                        };
                        ComplexRecipe.RecipeElement[] results_01 = new ComplexRecipe.RecipeElement[]
                        {
                            new ComplexRecipe.RecipeElement(tag7_01, 1f)
                        };

                        string str_01 = ComplexRecipeManager.MakeRecipeID("SupermaterialRefinery", ingredients_01, results_01);

                        new ComplexRecipe(str_01, ingredients_01, results_01)
                        {
                            time = 600f,
                            useResultAsDescription = true,
                            displayInputAndOutput = true,
                            description = "Let's make that bloody recharger!!!!.\nRecipe stolen from Korriban Dynamics Alchemy Dept."
                        }.fabricators = new List<Tag>() { TagManager.Create("SupermaterialRefinery") };

                        //------Abyssalite --> Wolframite
                        Tag tag1_02 = SimHashes.Katairite.CreateTag(); 
                        Tag tag2_02 = SimHashes.Glass.CreateTag(); 
                        Tag tag3_02 = ResearchDatabankConfig.ID;
                        Tag tag4_02 = SimHashes.Niobium.CreateTag();
                        Tag tag5_02 = SimHashes.Wolframite.CreateTag();

                        ComplexRecipe.RecipeElement[] ingredients_02 = new ComplexRecipe.RecipeElement[]
                        {
                            new ComplexRecipe.RecipeElement(tag1_02, 1000f),
                            new ComplexRecipe.RecipeElement(tag2_02, 500f),
                            new ComplexRecipe.RecipeElement(tag3_02, 50f),
                            new ComplexRecipe.RecipeElement(tag4_02, 10f)
                        };
                        ComplexRecipe.RecipeElement[] results_02 = new ComplexRecipe.RecipeElement[]
                        {
                            new ComplexRecipe.RecipeElement(tag5_02, 1000f)
                        };

                        string str_02 = ComplexRecipeManager.MakeRecipeID("SupermaterialRefinery", ingredients_02, results_02);

                        new ComplexRecipe(str_02, ingredients_02, results_02)
                        {
                            time = 0f,
                            useResultAsDescription = true,
                            displayInputAndOutput = true,
                            description = "Let's convert some wolframite!!!!.\n (с) Dimfire."
                        }.fabricators = new List<Tag>() { TagManager.Create("SupermaterialRefinery") };

                        //------Morb
                        Tag tag1_03 = SimHashes.DirtyWater.CreateTag();
                        Tag tag2_03 = SimHashes.Dirt.CreateTag();
                        Tag tag3_03 = GlomConfig.ID;

                        ComplexRecipe.RecipeElement[] ingredients_03 = new ComplexRecipe.RecipeElement[]
                        {
                            new ComplexRecipe.RecipeElement(tag1_03, 1000f),
                            new ComplexRecipe.RecipeElement(tag2_03, 1000f)
                        };
                        ComplexRecipe.RecipeElement[] results_03 = new ComplexRecipe.RecipeElement[]
                        {
                            new ComplexRecipe.RecipeElement(tag3_03, 1f)
                        };

                        string str_03 = ComplexRecipeManager.MakeRecipeID("SupermaterialRefinery", ingredients_03, results_03);

                        new ComplexRecipe(str_03, ingredients_03, results_03)
                        {
                            time = 0f,
                            useResultAsDescription = true,
                            displayInputAndOutput = true,
                            description = "Let's morf some morbs.\nRecipe provided by Korriban Dynamics Biological Dept."
                        }.fabricators = new List<Tag>() { TagManager.Create("SupermaterialRefinery") };

                        //------Steel 1
                        Tag tag1_04 = SimHashes.Iron.CreateTag();
                        Tag tag2_04 = SimHashes.RefinedCarbon.CreateTag();
                        Tag tag3_04 = EggShellConfig.ID;
                        Tag tag4_04 = SimHashes.Sand.CreateTag();
                        Tag tag5_04 = SimHashes.Steel.CreateTag();

                        ComplexRecipe.RecipeElement[] ingredients_04 = new ComplexRecipe.RecipeElement[]
                        {
                            new ComplexRecipe.RecipeElement(tag1_04, 700f),
                            new ComplexRecipe.RecipeElement(tag2_04, 200f),
                            new ComplexRecipe.RecipeElement(tag3_04, 100f),
                            new ComplexRecipe.RecipeElement(tag4_04, 300f)
                        };
                        ComplexRecipe.RecipeElement[] results_04 = new ComplexRecipe.RecipeElement[]
                        {
                            new ComplexRecipe.RecipeElement(tag5_04, 1000f)
                        };

                        string str_04 = ComplexRecipeManager.MakeRecipeID("SupermaterialRefinery", ingredients_04, results_04);

                        new ComplexRecipe(str_04, ingredients_04, results_04)
                        {
                            time = 0f,
                            useResultAsDescription = true,
                            displayInputAndOutput = true,
                            description = "Let's make that steel quickly!!!!.\nRecipe from Korriban Dynamics Alchemy Dept."
                        }.fabricators = new List<Tag>() { TagManager.Create("SupermaterialRefinery") };

                        //------Steel 2
                        Tag tag1_05 = SimHashes.Iron.CreateTag();
                        Tag tag2_05 = SimHashes.RefinedCarbon.CreateTag();
                        Tag tag3_05 = SimHashes.Lime.CreateTag();
                        Tag tag4_05 = SimHashes.Sand.CreateTag();
                        Tag tag5_05 = SimHashes.Steel.CreateTag();

                        ComplexRecipe.RecipeElement[] ingredients_05 = new ComplexRecipe.RecipeElement[]
                        {
                            new ComplexRecipe.RecipeElement(tag1_05, 700f),
                            new ComplexRecipe.RecipeElement(tag2_05, 200f),
                            new ComplexRecipe.RecipeElement(tag3_05, 100f),
                            new ComplexRecipe.RecipeElement(tag4_05, 300f)
                        };
                        ComplexRecipe.RecipeElement[] results_05 = new ComplexRecipe.RecipeElement[]
                        {
                            new ComplexRecipe.RecipeElement(tag5_05, 1000f)
                        };

                        string str_05 = ComplexRecipeManager.MakeRecipeID("SupermaterialRefinery", ingredients_05, results_05);

                        new ComplexRecipe(str_05, ingredients_05, results_05)
                        {
                            time = 0f,
                            useResultAsDescription = true,
                            displayInputAndOutput = true,
                            description = "Let's make that steel quickly!!!!.\nRecipe from Korriban Dynamics Alchemy Dept."
                        }.fabricators = new List<Tag>() { TagManager.Create("SupermaterialRefinery") };
                    }
                }               
            }
            namespace Kiln
            {
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



                        Tag tag21 = ElementLoader.FindElementByHash(SimHashes.Carbon).tag;
                        Tag tag22 = ElementLoader.FindElementByHash(SimHashes.Sand).tag;
                        Tag tag23 = ElementLoader.FindElementByHash(SimHashes.RefinedCarbon).tag;
                        string stag21 = tag21.ToString();
                        string stag22 = tag22.ToString();
                        string stag23 = tag23.ToString();

                        ComplexRecipe.RecipeElement[] ingredients21 = new ComplexRecipe.RecipeElement[]
                        {
                            new ComplexRecipe.RecipeElement(tag21, 1000f),
                            new ComplexRecipe.RecipeElement(tag22, 250f),

                        };
                        ComplexRecipe.RecipeElement[] results21 = new ComplexRecipe.RecipeElement[]
                        {
                            new ComplexRecipe.RecipeElement(tag23, 1000f)
                        };

                        string str21 = ComplexRecipeManager.MakeRecipeID("Kiln", ingredients21, results21);

                        new ComplexRecipe(str21, ingredients21, results21)
                        {
                            time = 0f,
                            useResultAsDescription = true,
                            displayInputAndOutput = true,
                            description = string.Format("Produces {0} from {1} with {2} as catalyst, which magically makes the chemical reaction instant.", stag3, stag1, stag2)
                        }.fabricators = new List<Tag>() { TagManager.Create("Kiln") };

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
            namespace Electric_Grill
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
