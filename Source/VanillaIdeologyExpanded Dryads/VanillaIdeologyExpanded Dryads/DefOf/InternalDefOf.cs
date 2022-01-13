﻿
using RimWorld;
using Verse;

namespace VanillaIdeologyExpanded_Dryads
{
    [DefOf]
    public static class InternalDefOf
    {
       
        public static JobDef VDE_MergeIntoAwakeningCocoon;


        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }
    }
}
