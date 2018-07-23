using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Projectiles
{
    public class MossYoyoProj : ModProjectile
    {
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quagmire");
		}
       
	    public override void SetDefaults()
        {
        	Projectile refProjectile = new Projectile();
			refProjectile.SetDefaults(ProjectileID.Amarok);
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
        }
    }
}