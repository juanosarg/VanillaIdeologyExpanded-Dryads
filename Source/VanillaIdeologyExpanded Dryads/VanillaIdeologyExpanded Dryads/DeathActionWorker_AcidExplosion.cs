
using RimWorld;
using Verse;

namespace VanillaIdeologyExpanded_Dryads
{
    public class DeathActionWorker_AcidExplosion : DeathActionWorker
    {



        public override void PawnDied(Corpse corpse)
        {
           



            GenExplosion.DoExplosion(corpse.Position, corpse.Map, 2.9f, InternalDefOf.VDE_AcidSpit, corpse.InnerPawn, 10, -1, InternalDefOf.VDE_GooPop, null, null, null, ThingDefOf.Filth_Slime, 1f, 1, false, null, 0f, 1);
        }


    }
}
