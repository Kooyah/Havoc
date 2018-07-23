using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Projectiles
{
	public class QuasarOrb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quasar Orb");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}

		public override void SetDefaults()
		{
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;       
			projectile.width = 4;
			projectile.height = 4;
			aiType = ProjectileID.Bullet;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 9;
			projectile.light = 0.5f;
			projectile.alpha = 166;
			projectile.scale = 1.2f;
			projectile.timeLeft = 600;
			projectile.ranged = true;
		}
		
		public override void AI()
		{
			for(int i = 0; i < 200; i++)
			{
			   NPC target = Main.npc[i];
			   //If the npc is hostile
			   if(!target.friendly)
			   {
				   //Get the shoot trajectory from the projectile and target
				   float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
				   float shootToY = target.position.Y - projectile.Center.Y;
				   float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

				   //If the distance between the live targeted npc and the projectile is less than 480 pixels
				   if(distance < 333f && !target.friendly && target.active && target.CanBeChasedBy(projectile, false))
				   {
					   //Divide the factor, 3f, which is the desired velocity
					   distance = 3f / distance;
		   
					   //Multiply the distance by a multiplier if you wish the projectile to have go faster
					   shootToX *= distance * 3;
					   shootToY *= distance * 3;

					   //Set the velocities to the shoot values
					   projectile.velocity.X = shootToX;
					   projectile.velocity.Y = shootToY;
				   }
			   }
			}
			if(Main.rand.Next(6) == 0)
			{
				int num126 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 2f);
				Main.dust[num126].noGravity = true;
				Main.dust[num126].velocity = projectile.Center - Main.dust[num126].position;
				Main.dust[num126].velocity.Normalize();
				Dust dust3 = Main.dust[num126];
				dust3.velocity *= -5f;
				dust3 = Main.dust[num126];
				dust3.velocity += projectile.velocity / 2f;
			}
		}
		
		
		
	}
}