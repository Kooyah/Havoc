using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Havoc.Items;

namespace Havoc.Items.Swamp
{
	public class SwampWoodSword : ModItem
	{
        public override void SetDefaults()
		{
			base.SetDefaults();

            item.damage = 9;
            item.width = 32;
			item.height = 32;
            item.melee = true;
            item.useTurn = false;
            item.rare = 0;
            item.useStyle = 1;
            item.useAnimation = 20;
           	item.knockBack = 6;
            item.useTime = 20;
            item.consumable = false;
            item.UseSound = SoundID.Item1;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Swamp Wood Sword");
      Tooltip.SetDefault("");
    }

        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SwampWood", 7);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}   
