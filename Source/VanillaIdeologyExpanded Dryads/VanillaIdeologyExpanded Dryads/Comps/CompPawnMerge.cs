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

    public class CompPawnMerge : ThingComp, AnimalBehaviours.PawnGizmoProvider
    {
        public CompProperties_PawnMerge Props => base.props as CompProperties_PawnMerge;

        
        public IEnumerable<Gizmo> GetGizmos()
        {
          
            var pawns = Find.Selector.SelectedPawns.Where(p => p.def == parent.def).ToList();
            if (pawns.Count >= Props.requiredCount)
            {
               
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
                if (i == 0 && pawns[0]!=null) {
                    IntVec3 pos = pawns[i].Position;
                    Map map = pawns[i].Map;
                    if (map != null) {
                        pawns[i].Destroy();
                        podthing = GenSpawn.Spawn(ThingMaker.MakeThing(InternalDefOf.VDE_AwakeningCocoon, null), pos, map, WipeMode.Vanish);
                    }
                    

                } else {

                    JobMaker.MakeJob(InternalDefOf.VDE_MergeIntoAwakeningCocoon, pawns[i], podthing);
                }
            
            }
        }
    }

   
}
