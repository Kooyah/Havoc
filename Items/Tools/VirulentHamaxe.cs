using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Tools
{
	public class VirulentHamaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
       			DisplayName.SetDefault("Virulent Hamaxe");
		}

		public override void SetDefaults()
		{
			item.damage = 42;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 30;
			item.useAnimation = 20;
			item.axe = 17;
			item.hammer = 85;
			item.useStyle = 1;
			item.knockBack = 6;
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