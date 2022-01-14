
using RimWorld;
using Verse;

namespace VanillaIdeologyExpanded_Dryads
{
    [DefOf]
    public static class InternalDefOf
    {
       
        public static JobDef VDE_MergeIntoAwakeningCocoon;
        public static DamageDef VDE_AcidSpit;
        public static SoundDef VDE_GooPop;


        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }
    }
}
