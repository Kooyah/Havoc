using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc
{
	public class HavocGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}

		public bool thermalblaze = false;
		public bool bloodloss = false;
		
		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (thermalblaze)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 16;	
			}
			
			if (bloodloss)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 14;	
			}
		}
		
		public override void NPCLoot(NPC npc)
		{
			if (npc.type == NPCID.WyvernHead && NPC.downedGolemBoss && Main.rand.Next(200) <= 25)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Tornado"));
			}

			if (npc.type == NPCID.Golem && Main.rand.Next(200) <= 25)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Upheaval"));
			}

			if (npc.type == NPCID.RedDevil && Main.rand.Next(2) <= 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FieryShard"));
			}

			if (npc.type == NPCID.Lavabat && Main.rand.Next(4) <= 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FieryShard"));
			}
		}



		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (thermalblaze)
			{
				if (Main.rand.Next(5) < 4)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType<Dusts.HotDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
			
			if (bloodloss)
			{
				if (Main.rand.Next(5) < 4)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, DustID.Blood, npc.velocity.X * 0.8f, npc.velocity.Y * 0.8f, 100, default(Color), 1f);
					Main.dust[dust].velocity *= 1.8f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].scale *= 0.5f;
					}
				}
			}
		}
		
		public override void ResetEffects(NPC npc)
		{
			thermalblaze = false;
			bloodloss = false;
		}
	}
}