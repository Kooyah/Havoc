using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Projectiles.Swamp
{
	public class Landslide1 : ModProjectile
	{
        bool abovePlayer;
		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.timeLeft = 2000;
            projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Landslide");
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (abovePlayer == true)
            {
                return false;
            }
            return true;
        }

        public override void AI()
        {
            projectile.velocity.X *= 0.98f;
            projectile.velocity.Y *= 1.00025f;
            Player player = Main.player[projectile.owner];
            if (projectile.ai[0] == 0f)
            {
                if (player.position.Y > projectile.position.Y)
                {
                    abovePlayer = true;
                    projectile.tileCollide = false;
                }
                else if (player.position.Y < projectile.position.Y)
                {
                    abovePlayer = false;
                    projectile.tileCollide = true;
                }
            }
        }
	}
    public class Landslide2 : ModProjectile
    {
        bool abovePlayer;
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 2;
            projectile.timeLeft = 1000;
            projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Landslide");
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (abovePlayer == true)
            {
                return false;
            }
            return true;
        }

        public override void AI()
        {
            projectile.velocity.X *= 0.95f;
            projectile.velocity.Y *= 1.0005f;
            Player player = Main.player[projectile.owner];
            if (projectile.ai[0] == 0f)
            {
                if (player.position.Y > projectile.position.Y)
                {
                    abovePlayer = true;
                    projectile.tileCollide = false;
                }
                else if (player.position.Y < projectile.position.Y)
                {
                    abovePlayer = false;
                    projectile.tileCollide = true;
                }
            }
        }
    }
    public class Landslide3 : ModProjectile
    {
        bool abovePlayer;
        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 3;
            projectile.timeLeft = 1000;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Landslide");
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (abovePlayer == true)
            {
                return false;
            }
            return true;
        }

        public override void AI()
        {
            projectile.velocity.X *= 0.95f;
            projectile.velocity.Y *= 1.001f;
            Player player = Main.player[projectile.owner];
            if (projectile.ai[0] == 0f)
            {
                if (player.position.Y > projectile.position.Y)
                {
                    abovePlayer = true;
                    projectile.tileCollide = false;
                }
                else if (player.position.Y < projectile.position.Y)
                {
                    abovePlayer = false;
                    projectile.tileCollide = true;
                }
                /*if (projectile.velocity.Y > 5)
                {
                    projectile.velocity.Y = 5;
                }*/
                if (Main.tile[(int)projectile.position.X / 16, (int)projectile.position.Y / 16].active())
                {
                    projectile.alpha = 150;
                }
                else
                {
                    projectile.alpha = 0;
                }
            }
        }
    }
}