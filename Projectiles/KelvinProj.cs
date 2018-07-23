using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Projectiles
{
    public class KelvinProj : ModProjectile
    {
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kelvin");
		}
       
	public override void SetDefaults()
        {
        	Projectile refProjectile = new Projectile();
			refProjectile.SetDefaults(ProjectileID.TheEyeOfCthulhu);
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
        }
	
	public override void AI()
	{
		Lighting.AddLight(projectile.position, 0.6f, 0.5f, 0f);
	}
	
	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        	Player player = Main.player[projectile.owner];
		target.immune[projectile.owner] = 2;
		target.AddBuff(mod.BuffType("ThermalBlaze"), 80);
    	}
    }
}