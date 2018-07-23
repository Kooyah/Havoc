using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Tools
{
	public class MangrovePickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
       			DisplayName.SetDefault("Mangrove Pickaxe");
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 18;
			item.useAnimation = 20;
			item.pick = 56;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 3000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

        	public override void AddRecipes()
        	{
            		ModRecipe recipe = new ModRecipe(mod);
            		recipe.AddIngredient(null, "BiomassBar", 8);
            		recipe.AddIngredient(null, "SwampWood", 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
            		recipe.AddRecipe();
        	}
	}
}