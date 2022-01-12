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
            Log.Message("Animal detected");
            var pawns = Find.Selector.SelectedPawns.Where(p => p.def == parent.def).ToList();
            if (pawns.Count >= Props.requiredCount)
            {
                Log.Message("Count detected");
                yield return new Command_Action
                {
                    defaultLabel = "TEST",
                    action = delegate
                    {
                        SetDryadAwakenPod(pawns);
                    }
            };
            }
        }
        public void SetDryadAwakenPod(List<Pawn> pawns)
        {
            Thing podthing=null;
            for (int i= 0; i< pawns.Count; i++) {
                if (i == 0) {
                    IntVec3 pos = pawns[i].Position;
                    Map map = pawns[i].Map;
                    pawns[i].Destroy();
                    podthing = GenSpawn.Spawn(ThingMaker.MakeThing(InternalDefOf.VDE_AwakeningCocoon, null), pos, map, WipeMode.Vanish);

                } else {

                    JobMaker.MakeJob(InternalDefOf.VDE_MergeIntoAwakeningCocoon, pawns[i], podthing);
                }
            
            }
        }
    }

   
}
