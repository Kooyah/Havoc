using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Projectiles.Swamp
{
	public class MudBlob : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 26;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 3;
			projectile.damage = 34;
			projectile.timeLeft = 1000;
			projectile.light = 0.1f;
			aiType = -1;
            Main.projFrames[projectile.type] = 3;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mud Blob");
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return false;
		}
		
		public void AI()
		{
			if (projectile.localAI[1] == 0f)
			{
				projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
			}
		}
	}
}