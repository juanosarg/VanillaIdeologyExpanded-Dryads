using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;
using UnityEngine;
using Verse.AI;
using RimWorld.Planet;

namespace VanillaIdeologyExpanded_Dryads
{
   

    public class CompPawnMerge : ThingComp, AnimalBehaviours.PawnGizmoProvider
    {
        public CompProperties_PawnMerge Props => base.props as CompProperties_PawnMerge;

        
        public IEnumerable<Gizmo> GetGizmos()
        {
          
            var pawns = Find.Selector.SelectedPawns.Where(p => p.def == parent.def).ToList();
            if (pawns.Count == Props.requiredCount)
            {
               
                yield return new Command_Action
                {
                    defaultLabel = Props.gizmoLabel.Translate(),
                    defaultDesc = Props.gizmoDesc.Translate(),
                    icon = ContentFinder<Texture2D>.Get(Props.gizmoImage, true),
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
            for (int i= 0; i< pawns.Count; i++)
            {

                List<Thing> connectedThings = pawns[i].connections.ConnectedThings;
                for (int num = connectedThings.Count - 1; num >= 0; num--)
                {
                    connectedThings[num].TryGetComp<CompTreeConnection>()?.RemoveDryad(pawns[i]);
                    
                }
              
                if (i == 0 && pawns[0]!=null) {
                    IntVec3 pos = pawns[i].Position;
                    Map map = pawns[i].Map;
                    if (map != null) {
                                         
                      
                        pawns[i].DeSpawn();
                        Find.WorldPawns.PassToWorld(pawns[i], PawnDiscardDecideMode.Discard);
                        podthing = GenSpawn.Spawn(ThingMaker.MakeThing(Props.podToBuild, null), pos, map, WipeMode.Vanish);
                    }
                    

                } else if (podthing!=null) {

                    pawns[i].jobs.StopAll();
                    Job job = JobMaker.MakeJob(InternalDefOf.VDE_MergeIntoAwakeningCocoon, pawns[i], podthing);
                    pawns[i].jobs.StartJob(job);
                }

            
            }
        }
    }

   
}
