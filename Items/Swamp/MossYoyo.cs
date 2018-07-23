using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Swamp
{
	public class MossYoyo : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quagmire");
		}
        
		public override void SetDefaults()
        {
            Item refItem = new Item();
			refItem.SetDefaults(ItemID.Amarok);                                 
            item.damage = 15;
            item.useTime = 24;
            item.useAnimation = 22;
            item.useStyle = 5;
            item.channel = true;
            item.melee = true;
			item.crit = 4;
            item.knockBack = 4.5f;
            item.value = 47000*5;
            item.rare = 1;
            item.noUseGraphic = true;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.MossYoyoProj>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodYoyo);
            recipe.AddIngredient(null, "MurkyGel", 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
            recipe.AddRecipe();
        }
      
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0.0f, 0.0f);
		    return false;
	    }
    }
}