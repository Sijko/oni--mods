using ONI_Common.Json;

class DynamicBuildingsState
{
    //ExhaustKilowattsWhenActive === HeatsUpAir
   //SelfHeatKilowattsWhenActive === HeatsUpSelf

    public float liquidandgas { get; set; } = 10f;
    public float Solid { get; set; } = 20f;
    public float STA { get; set; } = 1000f;
    public float SlimeConsumeKGsPerSecond { get; set; } = 1f;
    public byte SuckInRadius { get; set; } = 2;
    public float GVOP { get; set; } = 2f;
    public float HPGVOP { get; set; } = 10f;
    public bool Fudge { get; set; } = true;
    public float GasRes { get; set; } = 150f;
    public float LiqRes { get; set; } = 5000f;
    public bool RockDupe { get; set; } = true;
    public bool GlassDupe { get; set; } = true;
    public float LockerCap { get; set; } = 20000f;
    public float ConLoaderCap { get; set; } = 1000f;
    public float ConUnloaderCap { get; set; } = 100f;
    public bool LockerBase { get; set; } = true;
    public bool BatteryMedBase { get; set; } = true;
    public bool GasResBase { get; set; } = true;
    public bool LiqResBase { get; set; } = true;
    public float Thermos { get; set; } = -14f;
    public float MedBatCap { get; set; } = 40f;
    public float ColdBreezeToTile { get; set; } = 0f;
    public bool DupeNoWantSleep { get; set; } = true;
    public bool DupeNoWantPee { get; set; } = true;
    public bool MopMax { get; set; } = true;

    public bool SuitLockerRequiresPowerInput { get; set; } = true;
    public bool SweeperRequiresPowerInput { get; set; } = true;
    public bool BatteryMediumLoosesEnergy { get; set; } = true;
    public float CoalGeneratorWattage { get; set; } = 600f;
    public bool CoalGeneratorHeatsUpAir { get; set; } = true;
    public bool PolymerizerHeatsUpAir { get; set; } = true;
    public bool PolymerizerHeatsUpSelf { get; set; } = true;
    public float SuitLockerEnergyConsumption { get; set; } = 120f;
    public float SweeperEnergyConsumption { get; set; } = 120f;
    public float DeodorizerCap { get; set; } = 320f;
    public float RefineryWaterCapacity { get; set; } = 800f;
    public float RefineryWaterForOneRecipe { get; set; } = 400f;
    public float ElectrolyzerMaxPressure { get; set; } = 1.8f;
    public float ElectrolyzerRate { get; set; } = 1f;
    public float DeodorizerRate { get; set; } = 1f;
    public float WheezTemp { get; set; } = -5f;
    public float WheezMin { get; set; } = -60f;
    public float WheezMax { get; set; } = 95f;
    public float ElectroHydro { get; set; } = 112f;
    public bool CoolingCheat { get; set; } = false;
    public float RocketStorageCap { get; set; } = 1000f;
    public int PlanetTierDistance { get; set; } = 5;
    public bool AutoSave { get; set; } = true;
    public bool LightFloor { get; set; } = false;
    public bool LightAir { get; set; } = false;
    public bool LightLiquid { get; set; } = false;

    public static BaseStateManager<DynamicBuildingsState> StateManager= new BaseStateManager<DynamicBuildingsState>("DynamicBuildings");
    }

