using ONI_Common.Json;

namespace CheetyCreety
{
    class CheetyCreetyState
    {     
     /*1*/    public float DreckoAge1 { get; set; } = 2000f;
     /*2*/    public float DreckoAge2 { get; set; } = 2000f;
     /*3*/    public float MooAge { get; set; } = 2000f;
     /*4*/    public float SlicksterAge1 { get; set; } = 2000f;
     /*5*/    public float SlicksterAge2 { get; set; } = 2000f;
     /*6*/    public float SlicksterAge3 { get; set; } = 2000f;
     /*7*/    public float HatchAge1 { get; set; } = 2000f;
     /*8*/    public float HatchAge2 { get; set; } = 2000f;
     /*9*/    public float HatchAge3 { get; set; } = 2000f;
     /*10*/   public float HatchAge4 { get; set; } = 2000f;
     /*11*/   public float PufftAge1 { get; set; } = 2000f;
     /*12*/   public float PufftAge2 { get; set; } = 2000f;
     /*13*/   public float PufftAge3 { get; set; } = 2000f;
     /*14*/   public float PufftAge4 { get; set; } = 2000f;
     /*15*/   public float PacuAge { get; set; } = 2000f;
     /*16*/   public float LightBugAge1 { get; set; } = 2000f;
     /*17*/   public float LightBugAge2 { get; set; } = 2000f;
     /*18*/   public float LightBugAge3 { get; set; } = 2000f;
     /*19*/   public float LightBugAge4 { get; set; } = 2000f;
     /*20*/   public float LightBugAge5 { get; set; } = 2000f;
     /*21*/   public float LightBugAge6 { get; set; } = 2000f;
     /*22*/   public float LightBugAge7 { get; set; } = 2000f;

     /*1*/   public float DreckoRep1 { get; set; } = 10f;
     /*2*/   public float DreckoRep2 { get; set; } = 10f;
     /*3*/   public float SlicksterRep1 { get; set; } = 10f;
     /*4*/   public float SlicksterRep2 { get; set; } = 10f;
     /*5*/   public float SlicksterRep3 { get; set; } = 10f;
     /*6*/   public float HatchRep1 { get; set; } = 10f;
     /*7*/   public float HatchRep2 { get; set; } = 10f;
     /*8*/   public float HatchRep3 { get; set; } = 10f;
     /*9*/   public float HatchRep4 { get; set; } = 10f;
     /*10*/  public float PufftRep1 { get; set; } = 10f;
     /*11*/  public float PufftRep2 { get; set; } = 10f;
     /*12*/  public float PufftRep3 { get; set; } = 10f;
     /*13*/  public float PufftRep4 { get; set; } = 10f;
     /*14*/  public float PacuRep1 { get; set; } = 10f;
     /*15*/  public float PacuRep2 { get; set; } = 10f;
     /*16*/  public float PacuRep3 { get; set; } = 10f;
     /*17*/  public float LightBugRep1 { get; set; } = 10f;
     /*18*/  public float LightBugRep2 { get; set; } = 10f;
     /*19*/  public float LightBugRep3 { get; set; } = 10f;
     /*20*/  public float LightBugRep4 { get; set; } = 10f;
     /*21*/  public float LightBugRep5 { get; set; } = 10f;
     /*22*/  public float LightBugRep6 { get; set; } = 10f;
     /*23*/  public float LightBugRep7 { get; set; } = 10f;

        public float ShoveVoleAge { get; set; } = 2000f;
        public float ShoveVoleRep { get; set; } = 10f;
        public int GasIndex { get; set; } = 1;
        public int RatePercent { get; set; } = 0;
        public int Grooming { get; set; } = 1;

        public float Set_GlobalHatchMetal_kgPerDay { get; set; } = 140f;
        public float Set_GlobalHatchVeggie_kgPerDay { get; set; } = 140f;
        public float Set_GlobalHatchHard_kgPerDay { get; set; } = 140f;
        public float Set_GlobalHatch_kgPerDay { get; set; } = 140f;
        public float Set_GlobalMole_KgPerDay { get; set; } = 140f;
        public float Set_GlobalRegolith_KgPerDay { get; set; } = 140f;


        public static BaseStateManager<CheetyCreetyState> StateManager = new BaseStateManager<CheetyCreetyState>("CheetyCreety");
        
    }
}
