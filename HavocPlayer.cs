using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace Havoc
{
	public class HavocPlayer : ModPlayer
	{
		public bool thermalblaze = false;
		public bool bloodinstinct = false;
		public bool bloodloss = false;
		public int swampFogAmount = 0;
		public static bool ZoneSwamp = false;
		
		public override void ResetEffects()
		{
			thermalblaze = false;
			bloodinstinct = false;
			bloodloss = false;
		}
		
		public override void UpdateDead()
		{
			thermalblaze = false;
			bloodloss = false;
		}
		
		public override void UpdateBiomes()
		{
			ZoneSwamp = (HavocWorld.swampGrass > 20);        
        }
		
		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
			if (junk)
			{
				return;
			}
            if (questFish == mod.ItemType("Vinefish") && Main.rand.Next(2) == 0 && HavocPlayer.ZoneSwamp)
            {
                caughtType = mod.ItemType("Vinefish");
            }
            if (Main.rand.Next(25) == 0 && HavocPlayer.ZoneSwamp)
            {
                caughtType = mod.ItemType("SwampCrate");
            }
        } 
		
		public override void UpdateBadLifeRegen()
		{
			if (thermalblaze)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegen -= 16;
			}
			
			if (bloodloss)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegen -= 14;
			}
		}
		
		public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
		{
			if (thermalblaze)
			{
				if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
				{
					int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType<Dusts.HotDust>(), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					Main.playerDrawDust.Add(dust);
				}
				r *= 0.1f;
				g *= 0.2f;
				b *= 0.7f;
				fullBright = true;
			}
			if(bloodloss)
			{
				if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
				{
					int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, DustID.Blood, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1f);
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					Main.playerDrawDust.Add(dust);
				}
				r *= 0.1f;
				g *= 0.2f;
				b *= 0.7f;
			}
		}
		
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)	
		{
			if(this.bloodinstinct)
			{
				if(Main.rand.Next(13) == 0)
				{
					target.AddBuff(mod.BuffType("Bloodloss"), 999, false);
				}
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(proj.type == mod.ProjectileType("ThermalPikeProj"))
			{
				if(!(Main.rand.Next(5) == 0))
				{
					target.AddBuff(mod.BuffType("ThermalBlaze"), 600, false);
				}
			}
			if(proj.type == mod.ProjectileType("SnappyTooth") || proj.type == mod.ProjectileType("SkyToothProj") || proj.type == mod.ProjectileType("JawsProj"))
			{
				if(Main.rand.Next(8) == 0)
				{
					target.AddBuff(mod.BuffType("Gouged"), 600, false);
				}
			}
			if(this.bloodinstinct)
			{
				if(Main.rand.Next(23) == 0)
				{
					target.AddBuff(mod.BuffType("Bloodloss"), 999, false);
				}
			}
		}
	}
}