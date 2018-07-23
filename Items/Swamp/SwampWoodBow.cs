using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Havoc.Items;

namespace Havoc.Items.Swamp
{
	public class SwampWoodBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 7;
			item.ranged = true;
			item.width = 18;
			item.height = 32;
			item.useTime = 25;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 3000;
			item.rare = 0;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 35f;
			item.useAmmo = AmmoID.Arrow;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Swamp Wood Bow");
      Tooltip.SetDefault("");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SwampWood", 10);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
