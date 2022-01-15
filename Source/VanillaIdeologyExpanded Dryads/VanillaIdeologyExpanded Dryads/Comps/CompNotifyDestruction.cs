
using Verse;

namespace VanillaIdeologyExpanded_Dryads
{
    class CompNotifyDestruction : ThingComp
    {


        public CompProperties_NotifyDestruction Props
        {
            get
            {
                return (CompProperties_NotifyDestruction)this.props;
            }
        }

      

        public override void PostDeSpawn(Map map)
        {
            NotifyDestructionToComps(map);
        }

        public override void PostDestroy(DestroyMode mode, Map previousMap)
        {
            NotifyDestructionToComps(previousMap);
        }

        public void NotifyDestructionToComps(Map map)
        {
            foreach (Pawn p in map.mapPawns.SpawnedColonyAnimals)
            {
                AnimalBehaviours.CompBuildPeriodically comp = p.TryGetComp<AnimalBehaviours.CompBuildPeriodically>();
                if (comp != null)
                {
                    comp.NotifyBuildingDestroyed(this.parent);
                }
            }

        }
    }
}
