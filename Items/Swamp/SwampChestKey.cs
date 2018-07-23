using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Havoc.Items;

namespace Havoc.Items.Swamp
{
	public class SwampChestKey : ModItem
	{
        public override void SetDefaults()
		{
			base.SetDefaults();


            item.width = 14;
			item.height = 18;
            item.melee = false;
            item.rare = 5;
            item.useStyle = 1;
            item.useAnimation = 0;
            item.maxStack = 1;
            item.useTime = 0;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Swampy Key");
      Tooltip.SetDefault("'Charged with the essence of the murky mires'");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight, 6);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddIngredient(null, "MurkyGel", 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
