using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RimWorld;
using Verse;
using UnityEngine;

namespace VanillaIdeologyExpanded_Dryads


{
    class CompProperties_SpawnAwakened : CompProperties
    {
        public CompProperties_SpawnAwakened()
        {
            this.compClass = typeof(CompSpawnAwakened);
        }
        public int ticksToSpawn;
        public PawnKindDef dryadToSpawn;


    }
}
