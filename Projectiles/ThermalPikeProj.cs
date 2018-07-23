using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Projectiles
{
	public class ThermalPikeProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thermal Pike");
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.ownerHitCheck = true;
			projectile.aiStyle = 19;
			projectile.melee = true;  
			projectile.timeLeft = 90;
			projectile.hide = true;
		}

		public override void AI()
		{
			Main.player[projectile.owner].direction = projectile.direction;
			Main.player[projectile.owner].heldProj = projectile.whoAmI;
			Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
			projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
			projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
			projectile.position += projectile.velocity * projectile.ai[0];
			if (Main.rand.Next(4) == 0)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType<Dusts.HotDust>(), 0f, 0f, 254, default(Color), 0.3f);
				Main.dust[dustIndex].velocity += projectile.velocity * 0.5f;
				Main.dust[dustIndex].velocity *= 0.5f;
				return;
			}
			if(projectile.ai[0] == 0f)
			{
				projectile.ai[0] = 3f;
				projectile.netUpdate = true;
			}
			if(Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
			{
				projectile.ai[0] -= 2.4f;
				if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
				{
					projectile.localAI[0] = 1f;
					Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X * projectile.ai[0], projectile.Center.Y + projectile.velocity.Y * projectile.ai[0], projectile.velocity.X * 2.4f, projectile.velocity.Y * 2.4f, mod.ProjectileType("HellionSpike"), (int)((double)projectile.damage * 0.8), projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
				}
			}
			else
			{
				projectile.ai[0] += 0.95f;
			}
			
			if(Main.player[projectile.owner].itemAnimation == 0)
			{
				projectile.Kill();
			}
			
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 2.355f;
			if(projectile.spriteDirection == -1)
			{
				projectile.rotation -= 1.57f;
			}
			Lighting.AddLight(projectile.position, 0.6f, 0.5f, 0f);
		}
	
	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        	Player player = Main.player[projectile.owner];
		target.immune[projectile.owner] = 2;
		target.AddBuff(mod.BuffType("ThermalBlaze"), 80);
    }
}}