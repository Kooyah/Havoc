using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Havoc.Items;

namespace Havoc.Items.Swamp
{
	public class SwampWoodHammer : ModItem
	{
        public override void SetDefaults()
		{
			base.SetDefaults();

            item.damage = 6;
            item.hammer = 40;
            item.width = 32;
			item.height = 32;
            item.melee = true;
            item.useTurn = false;
            item.rare = 0;
            item.useStyle = 1;
            item.useAnimation = 20;
           	item.knockBack = 7;
            item.useTime = 42;
            item.consumable = false;
            item.UseSound = SoundID.Item1;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Swamp Wood Hammer");
      Tooltip.SetDefault("");
    }

        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SwampWood", 8);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}   
