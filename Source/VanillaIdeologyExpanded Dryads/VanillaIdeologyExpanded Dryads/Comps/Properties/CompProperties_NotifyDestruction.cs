using System;
using System.Collections.Generic;
using System.Linq;

using RimWorld;
using Verse;
using UnityEngine;

using Verse.AI;

namespace VanillaIdeologyExpanded_Dryads
{
    public class CompProperties_NotifyDestruction : CompProperties
    {
       
        public CompProperties_NotifyDestruction()
        {
            this.compClass = typeof(CompNotifyDestruction);
        }
    }
}