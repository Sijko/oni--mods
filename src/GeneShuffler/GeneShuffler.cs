using Harmony;
using Klei.AI;

namespace Gene_Shuffler
{
    namespace _DoTheMagic_
    {
        [HarmonyPatch(typeof(GeneShuffler), "ApplyRandomTrait")]
        public class GeneShufflerMod
        {
            public static void Prefix(GeneShuffler __instance, ref Worker worker)
            {
                Trait trait01 = Db.Get().traits.TryGet("Anemic"); worker.GetComponent<Traits>().Remove(trait01);
                Trait trait02 = Db.Get().traits.TryGet("CalorieBurner"); worker.GetComponent<Traits>().Remove(trait02);
                Trait trait03 = Db.Get().traits.TryGet("CantBuild"); worker.GetComponent<Traits>().Remove(trait03);
                Trait trait04 = Db.Get().traits.TryGet("CantCook"); worker.GetComponent<Traits>().Remove(trait04);
                Trait trait05 = Db.Get().traits.TryGet("CantDig"); worker.GetComponent<Traits>().Remove(trait05);
                Trait trait06 = Db.Get().traits.TryGet("CantResearch"); worker.GetComponent<Traits>().Remove(trait06);
                Trait trait07 = Db.Get().traits.TryGet("Claustrophobic"); worker.GetComponent<Traits>().Remove(trait07);
                Trait trait08 = Db.Get().traits.TryGet("Climacophobic"); worker.GetComponent<Traits>().Remove(trait08);
                Trait trait09 = Db.Get().traits.TryGet("Fashionable"); worker.GetComponent<Traits>().Remove(trait09);
                Trait trait10 = Db.Get().traits.TryGet("Hemophobia"); worker.GetComponent<Traits>().Remove(trait10);
                Trait trait11 = Db.Get().traits.TryGet("IrritableBowel"); worker.GetComponent<Traits>().Remove(trait11);
                Trait trait12 = Db.Get().traits.TryGet("MouthBreather"); worker.GetComponent<Traits>().Remove(trait12);
                Trait trait13 = Db.Get().traits.TryGet("Narcolepsy"); worker.GetComponent<Traits>().Remove(trait13);
                Trait trait14 = Db.Get().traits.TryGet("NoodleArms"); worker.GetComponent<Traits>().Remove(trait14);
                Trait trait15 = Db.Get().traits.TryGet("PrefersColder"); worker.GetComponent<Traits>().Remove(trait15);
                Trait trait16 = Db.Get().traits.TryGet("PrefersWarmer"); worker.GetComponent<Traits>().Remove(trait16);
                Trait trait17 = Db.Get().traits.TryGet("ScaredyCat"); worker.GetComponent<Traits>().Remove(trait17);
                Trait trait18 = Db.Get().traits.TryGet("SensitiveFeet"); worker.GetComponent<Traits>().Remove(trait18);
                Trait trait19 = Db.Get().traits.TryGet("SlowLearner"); worker.GetComponent<Traits>().Remove(trait19);
                Trait trait20 = Db.Get().traits.TryGet("SmallBladder"); worker.GetComponent<Traits>().Remove(trait20);
                Trait trait21 = Db.Get().traits.TryGet("Snorer"); worker.GetComponent<Traits>().Remove(trait21);
                Trait trait22 = Db.Get().traits.TryGet("SolitarySleeper"); worker.GetComponent<Traits>().Remove(trait22);
                Trait trait23 = Db.Get().traits.TryGet("WeakImmuneSystem"); worker.GetComponent<Traits>().Remove(trait23);
                Trait trait24 = Db.Get().traits.TryGet("Workaholic"); worker.GetComponent<Traits>().Remove(trait24);

                Trait trait25 = Db.Get().traits.TryGet("Aggressive"); worker.GetComponent<Traits>().Remove(trait25);
                Trait trait26 = Db.Get().traits.TryGet("BingeEater"); worker.GetComponent<Traits>().Remove(trait26);
                Trait trait27 = Db.Get().traits.TryGet("StressVomiter"); worker.GetComponent<Traits>().Remove(trait27);
                Trait trait28 = Db.Get().traits.TryGet("UglyCrier"); worker.GetComponent<Traits>().Remove(trait28);
            }
        }
    }
}
