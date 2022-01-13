using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;
using RimWorld;
using RimWorld.Planet;

namespace VanillaIdeologyExpanded_Dryads
{
	public class JobDriver_MergeIntoAwakeningCocoon : JobDriver
	{
		


		public override bool TryMakePreToilReservations(bool errorOnFailed)
		{
			return true;
		}

		protected override IEnumerable<Toil> MakeNewToils()
		{

			this.FailOnDespawnedOrNull(TargetIndex.A);
			this.FailOnDespawnedOrNull(TargetIndex.B);
			yield return Toils_Goto.GotoThing(TargetIndex.B, PathEndMode.Touch);
			yield return Toils_General.WaitWith(TargetIndex.B, WaitTicks, true, false);
			yield return Toils_General.Do(delegate
			{
				
				this.pawn.DeSpawn();
				Find.WorldPawns.PassToWorld(this.pawn, PawnDiscardDecideMode.Discard);
			});
			yield break;
		}

		private const int WaitTicks = 120;
	}
}
