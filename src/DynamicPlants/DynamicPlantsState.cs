using ONI_Common.Json;

class DynamicPlantsState
{
    public float MealwoodT11 { get; set; } = 10f;
    public float MealwoodT12 { get; set; } = 30f;
    public bool MealwoodPS1 { get; set; } = true;
    public float MealwoodP11 { get; set; } = 150f;
    public float MealwoodP12 { get; set; } = 0f;

    public float MushroomT11 { get; set; } = 5f;
    public float MushroomT12 { get; set; } = 35f;
    public bool MushroomPS1 { get; set; } = true;
    public float MushroomP11 { get; set; } = 150f;
    public float MushroomP12 { get; set; } = 0f;

    public float BristleBlossomT11 { get; set; } = 5f;
    public float BristleBlossomT12 { get; set; } = 30f;
    public bool BristleBlossomPS1 { get; set; } = true;
    public float BristleBlossomP11 { get; set; } = 150f;
    public float BristleBlossomP12 { get; set; } = 0f;

    public float SleetWheatT11 { get; set; } = -55f;
    public float SleetWheatT12 { get; set; } = 5f;
    public bool SleetWheatPS1 { get; set; } = true;
    public float SleetWheatP11 { get; set; } = 150f;
    public float SleetWheatP12 { get; set; } = 0f;

    public float GasGrassT11 { get; set; } = 7f;
    public float GasGrassT12 { get; set; } = 75f;
    public bool GasGrassPS1 { get; set; } = true;
    public float GasGrassP11 { get; set; } = 150f;
    public float GasGrassP12 { get; set; } = 0f;

    public float BalmLilyT11 { get; set; } = 35f;
    public float BalmLilyT12 { get; set; } = 85f;
    public bool BalmLilyPS1 { get; set; } = true;
    public float BalmLilyP11 { get; set; } = 150f;
    public float BalmLilyP12 { get; set; } = 0f;

    public float PinchaPepperT11 { get; set; } = 35f;
    public float PinchaPepperT12 { get; set; } = 85f;
    public bool PinchaPepperPS1 { get; set; } = true;
    public float PinchaPepperP11 { get; set; } = 150f;
    public float PinchaPepperP12 { get; set; } = 0f;

    public float ThimbleReedT11 { get; set; } = 22f;
    public float ThimbleReedT12 { get; set; } = 37f;
    public bool ThimbleReedPS1 { get; set; } = false;
    public float ThimbleReedP11 { get; set; } = 150f;
    public float ThimbleReedP12 { get; set; } = 0f;
    //-----------------
    public float BluffBriarT11 { get; set; } = 10f;
    public float BluffBriarT12 { get; set; } = 30f;
    public bool BluffBriarPS1 { get; set; } = true;
    public float BluffBriarP11 { get; set; } = 150f;
    public float BluffBriarP12 { get; set; } = 0f;

    public float BuddyBudT11 { get; set; } = 20f;
    public float BuddyBudT12 { get; set; } = 40f;
    public bool BuddyBudPS1 { get; set; } = true;
    public float BuddyBudP11 { get; set; } = 150f;
    public float BuddyBudP12 { get; set; } = 0f;

    public float MirthLeafT11 { get; set; } = 20f;
    public float MirthLeafT12 { get; set; } = 50f;
    public bool MirthLeafPS1 { get; set; } = true;
    public float MirthLeafP11 { get; set; } = 150f;
    public float MirthLeafP12 { get; set; } = 0f;

    public float JumpingJoyaT11 { get; set; } = 0f;
    public float JumpingJoyaT12 { get; set; } = 100f;
    public bool JumpingJoyaPS1 { get; set; } = false;
    public float JumpingJoyaP11 { get; set; } = 150f;
    public float JumpingJoyaP12 { get; set; } = 0f;
    //-----------------------

    public byte MealwoodA { get; set; } = 0;
    public byte MushroomA { get; set; } = 0;
    public byte BristleBlossomA { get; set; } = 0;
    public byte SleetWheatA { get; set; } = 0;
    public byte GasGrassA { get; set; } = 0;
    public byte BalmLilyA { get; set; } = 0;
    public byte PinchaPepperA { get; set; } = 0;
    public byte ThimbleReedA { get; set; } = 0;

    public byte BluffBriarA { get; set; } = 0;
    public byte BuddyBudA { get; set; } = 0;
    public byte MirthLeafA { get; set; } = 0;
    public byte JumpingJoyaA { get; set; } = 0;

    public int IndexBristleBlossomI { get; set; } = 116;
    public int IndexSleetWheatI { get; set; } = 116;
    public int IndexGasGrassI { get; set; } = 12;
    public int IndexPinchaPepperI { get; set; } = 25;
    public int IndexThimbleReedI { get; set; } = 25;
    public float ConBristleBlossomI { get; set; } = 20000f;
    public float ConSleetWheatI { get; set; } = 20000f;
    public float ConGasGrassI { get; set; } = 500f;
    public float ConPinchaPepperI { get; set; } = 35000f;
    public float ConThimbleReedI { get; set; } = 160000f;

    public int IndexMealwoodF { get; set; } = 23;
    public int IndexMushroomF { get; set; } = 88;
    public int IndexSleetWheatF { get; set; } = 23;
    public int IndexPinchaPepperF { get; set; } = 75;
    public float ConMealwoodF { get; set; } = 10000f;
    public float ConMushroomF { get; set; } = 4000f;
    public float ConSleetWheatF { get; set; } = 5000f;
    public float ConPinchaPepperF { get; set; } = 1000f;

    public bool NeedsLight { get; set; } = true;
    public bool NeedsDark { get; set; } = true;

    public int EmitGas1 { get; set; } = 1;
    public int EmitGas2 { get; set; } = 1;
    public int EmitGas3 { get; set; } = 1;
    public int EmitGas4 { get; set; } = 1;
    public int EmitGas5 { get; set; } = 1;
    public int EmitGas6 { get; set; } = 1;
    public int EmitGas7 { get; set; } = 1;
    public int EmitGas8 { get; set; } = 1;
    public int EmitGas9 { get; set; } = 1;
    public int EmitGas10 { get; set; } = 1;
    public int EmitGas11 { get; set; } = 1;
    public int EmitGas12 { get; set; } = 1;

    public float EmitGas1Q { get; set; } = 0.01f;
    public float EmitGas2Q { get; set; } = 0.01f;
    public float EmitGas3Q { get; set; } = 0.01f;
    public float EmitGas4Q { get; set; } = 0.01f;
    public float EmitGas5Q { get; set; } = 0.01f;
    public float EmitGas6Q { get; set; } = 0.01f;
    public float EmitGas7Q { get; set; } = 0.01f;
    public float EmitGas8Q { get; set; } = 0.01f;
    public float EmitGas9Q { get; set; } = 0.01f;
    public float EmitGas10Q { get; set; } = 0.01f;
    public float EmitGas11Q { get; set; } = 0.01f;
    public float EmitGas12Q { get; set; } = 0.01f;

    public int MealLiceToHarvestTime { get; set; } = 4;
    public int MushroomToHarvestTime { get; set; } = 9;
    public int BerrieToHarvestTime { get; set; } = 7;
    public int ColdWheatToHarvestTime { get; set; } = 20;
    public int GasGrassToHarvestTime { get; set; } = 5;
    public int LillyToHarvestTime { get; set; } = 14;
    public int SpiceToHarvestTime { get; set; } = 10;
    public int FiberToHarvestTime { get; set; } = 3;
          
    public int MealLiceNumOfCrop { get; set; } = 1;
    public int MushroomNumOfCrop { get; set; } = 1;
    public int BerrieNumOfCrop { get; set; } = 1;
    public int ColdWheatNumOfCrop { get; set; } = 18;
    public int GasGrassNumOfCrop { get; set; } = 2;
    public int LillyNumOfCrop { get; set; } = 1;
    public int SpiceNumOfCrop { get; set; } = 4;
    public int FiberNumOfCrop { get; set; } = 1;


    public static BaseStateManager<DynamicPlantsState> StateManager= new BaseStateManager<DynamicPlantsState>("DynamicPlants");
    }

