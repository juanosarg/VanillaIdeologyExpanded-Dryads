using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RimWorld;
using Verse;
using Verse.Sound;
using UnityEngine;
using Verse.AI.Group;

namespace VanillaIdeologyExpanded_Dryads
{
	class CompSpawnAwakened : ThingComp
	{
		
		int tickCounter;

		private CompProperties_SpawnAwakened Props
		{
			get
			{
				return (CompProperties_SpawnAwakened)this.props;
			}
		}

		public override void Initialize(CompProperties props)
		{
			base.Initialize(props);	
			tickCounter= Props.ticksToSpawn;
		}

		public override string CompInspectStringExtra()
		{
			return "VDE_TicksToSpawn".Translate(tickCounter.ToStringTicksToPeriod());
			
		}

		public override void CompTick()
		{
			base.CompTick();
			tickCounter--;

            if (tickCounter <= 0) {
				tickCounter = Props.ticksToSpawn;
				if (this.parent.Map != null)
				{
					DoSpawn();
					
				}

			}
			
		}

		public void DoSpawn()
        {
			IntVec3 vec3 = this.parent.Position.RandomAdjacentCell8Way();
			Pawn p = PawnGenerator.GeneratePawn(Props.dryadToSpawn, Faction.OfPlayer);
			GenSpawn.Spawn(p, vec3, this.parent.Map);
			FilthMaker.TryMakeFilth(this.parent.Position, this.parent.Map, ThingDefOf.Filth_Slime, 1);
			this.parent.Destroy();

		}

		public override IEnumerable<Gizmo> CompGetGizmosExtra()
		{
			if (Prefs.DevMode)
			{
				Command_Action command_Action = new Command_Action();
				command_Action.defaultLabel = "DEBUG: Spawn dryad";
				command_Action.icon = TexCommand.DesirePower;
				command_Action.action = delegate
				{
					
					DoSpawn();
				};
				yield return command_Action;
			}
		}


		public override void PostExposeData()
		{
			base.PostExposeData();		
			Scribe_Values.Look<int>(ref this.tickCounter, "tickCounter");
		}
	}
}
