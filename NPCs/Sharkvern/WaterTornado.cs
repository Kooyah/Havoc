using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Havoc.NPCs.Sharkvern
{
    public class WaterTornado : ModProjectile
    {
    	public int spawnCount = 0;
    	
        public override void SetDefaults()
        {
            projectile.width = 44;
            projectile.height = 44;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 500;
			projectile.aiStyle = 36;
            Main.projFrames[projectile.type] = 6;
        }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Water Tornado");
		}
		
		public override void AI()
        {

           int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 2, projectile.height + 2, mod.DustType("TornadoDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 1f);
            Main.dust[DustID2].noGravity = true;
		
		}

	}
}