using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.NPCs.Swamp
{
	public class MudBall : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 26;
			npc.height = 32;
			npc.damage = 21;
			npc.defense = 7;
			npc.lifeMax = 32;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 40f;
			npc.knockBackResist = 0.7f;
			npc.aiStyle = 2;
            animationType = NPCID.DemonEye;
            aiType = NPCID.DemonEye;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mudball");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int spawn = Main.rand.Next(1,3);
			return HavocPlayer.ZoneSwamp && spawn == 2 && Havoc.NoInvasion(spawnInfo) && !Main.dayTime ? 0.5f : 0f;
		}
	}
}
