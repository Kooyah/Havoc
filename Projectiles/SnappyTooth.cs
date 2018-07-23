using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace Havoc.Projectiles
{
    public class SnappyTooth : ModProjectile
    {
        public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Snappy Tooth");
	}
		
	public override void SetDefaults()
        { 
	    projectile.CloneDefaults(ProjectileID.Bullet);
	    aiType = ProjectileID.Bullet;
            projectile.width = 9;      
            projectile.height = 12;
            projectile.friendly = true;     
            projectile.melee = true;        
            projectile.tileCollide = true;   
            projectile.penetrate = -1;     
            projectile.timeLeft = 2000; 
            projectile.ignoreWater = true;   
        }


	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)

	{

		target.AddBuff(mod.BuffType("Gouged"), 240);
	}			
    }
}