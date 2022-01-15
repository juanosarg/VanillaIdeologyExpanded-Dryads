
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
            NotifyDestructionToComps();
        }

        public override void PostDestroy(DestroyMode mode, Map previousMap)
        {
            NotifyDestructionToComps();
        }

        public void NotifyDestructionToComps()
        {
            foreach (Pawn p in this.parent.Map.mapPawns.SpawnedColonyAnimals)
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
