using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items
{
	public class BiomassBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Biomass Bar");
		}
		
	public override void SetDefaults()
        {
		item.width = 18;
		item.height = 14;
		item.maxStack = 99;
		item.value = 100;
		item.rare = 0;
		item.alpha = 0;
	}

	public override void AddRecipes()
	{
		ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "Biomass", 3);
                recipe.AddIngredient(null, "MurkyGel");
                recipe.AddTile(TileID.Furnaces);
		recipe.SetResult(this, 1);
		recipe.AddRecipe();
	}
    }
}