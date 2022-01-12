using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace VanillaIdeologyExpanded_Dryads
{
    public class CompProperties_PawnMerge : CompProperties
    {
        public int requiredCount;
        public PawnKindDef mergeTo;
        public CompProperties_PawnMerge()
        {
            this.compClass = typeof(CompPawnMerge);
        }
    }

    public class CompPawnMerge : ThingComp
    {
        public CompProperties_PawnMerge Props => base.props as CompProperties_PawnMerge;
        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            var pawns = Find.Selector.SelectedPawns.Where(p => p.def == parent.def).ToList();
            if (pawns.Count >= Props.requiredCount)
            {
                yield return new Command_Action
                {
                    defaultLabel = "TEST",
                    action = () => Log.Message("TEST")
                };
            }
        }
    }
}
