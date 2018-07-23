using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.NPCs.Swamp
{
	public class SwampSlime : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 38;
			npc.height = 32;
			npc.damage = 14;
			npc.defense = 3;
			npc.lifeMax = 62;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
			npc.knockBackResist = 1.1f;
			npc.aiStyle = 1;
            npc.alpha = 0;
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
			aiType = NPCID.BlueSlime;
			animationType = NPCID.BlueSlime;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swamp Slime");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, Main.rand.Next(4));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MurkyGel"), Main.rand.Next(2));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return HavocPlayer.ZoneSwamp && Havoc.NoInvasion(spawnInfo) ? 0.5f : 0f;
		}
	}
}