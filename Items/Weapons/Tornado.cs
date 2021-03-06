using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Weapons
{
	public class Tornado : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tornado");
			Tooltip.SetDefault("Fires homing tornadoes as it's held out");
		}
        
		public override void SetDefaults()
        {
            Item refItem = new Item();
			refItem.SetDefaults(ItemID.TheEyeOfCthulhu);                                 
            item.damage = 125;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;
            item.channel = true;
            item.melee = true;
            item.knockBack = 2.5f;
            item.value = 10000;
            item.rare = 9;
            item.noUseGraphic = true;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.TornadoProj>();
        }
      
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0.0f, 0.0f);
		    return false;
	    }
    }
}