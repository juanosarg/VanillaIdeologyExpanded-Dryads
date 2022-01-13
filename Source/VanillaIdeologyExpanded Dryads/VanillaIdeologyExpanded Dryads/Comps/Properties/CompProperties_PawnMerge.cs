using System;
using System.Collections.Generic;
using System.Linq;

using RimWorld;
using Verse;
using UnityEngine;

using Verse.AI;

namespace VanillaIdeologyExpanded_Dryads
{
    public class CompProperties_PawnMerge : CompProperties
    {
        public int requiredCount;
        public ThingDef podToBuild;
        public string gizmoImage;
        public string gizmoLabel;
        public string gizmoDesc;
        public CompProperties_PawnMerge()
        {
            this.compClass = typeof(CompPawnMerge);
        }
    }
}