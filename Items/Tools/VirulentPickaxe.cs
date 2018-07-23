using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Tools
{
	public class VirulentPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
       			DisplayName.SetDefault("Virulent Pickaxe");
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 25;
			item.useAnimation = 20;
			item.pick = 150;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 3000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

        	public override void AddRecipes()
        	{
            		ModRecipe recipe = new ModRecipe(mod);
            		recipe.AddIngredient(null, "VirulentBar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
            		recipe.AddRecipe();
        	}
	}
}