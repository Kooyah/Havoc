using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Projectiles
{
    public class RedPhasebrandProj : ModProjectile
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Phasebrand");
		}
		
		public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Arkhalis);
            aiType = ProjectileID.Arkhalis;      
            projectile.width = 68;
            Main.projFrames[projectile.type] = 28;  
			projectile.height = 47;          
        }

    }
}