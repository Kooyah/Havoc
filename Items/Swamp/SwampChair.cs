using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Swamp
{
	public class SwampChair : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("SwampChair");
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Swamp Chair");
      Tooltip.SetDefault("");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SwampWood", 6);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}   
