using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Weapons 
{ 
    public class ThermalPike : ModItem
    {		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thermal Pike");
		}
		
		public override void SetDefaults()
	    {
		    item.width = 36;  
		    item.damage = 54;  
		    item.melee = true; 
		    item.noMelee = true;
		    item.useTurn = true;
		    item.noUseGraphic = true;
		    item.useAnimation = 29;
		    item.useStyle = 5;
		    item.useTime = 26;
		    item.knockBack = 5.5f;  
		    item.UseSound = SoundID.Item1;
		    item.autoReuse = false; 
		    item.height = 44; 
		    item.maxStack = 1;
		    item.value = 10000; 
		    item.rare = 6;  
		    item.shoot = mod.ProjectileType("ThermalPikeProj");
		    item.shootSpeed = 9f;
	    }

	        public override void AddRecipes()
        	{
            		ModRecipe recipe = new ModRecipe(mod);
            		recipe.AddIngredient(null, "FieryShard", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
            		recipe.AddRecipe();
        	}
	}
}