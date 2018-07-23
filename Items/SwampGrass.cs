using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items
{
	public class SwampGrass : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Debug Swamp Grass");
        }

        public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("SwampGrass");
        }     
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddIngredient(null, "SwampSeeds", 1);
            recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}   
	}
}   