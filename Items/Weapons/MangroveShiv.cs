using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Weapons
{
	public class MangroveShiv : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mangrove Shiv");
		}
		
		public override void SetDefaults()
		{
			item.damage = 17;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 3;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 1;
	        	item.UseSound = SoundID.Item1;		
			item.autoReuse = true;
		}

        	public override void AddRecipes()
        	{
            		ModRecipe recipe = new ModRecipe(mod);
            		recipe.AddIngredient(null, "BiomassBar", 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
            		recipe.AddRecipe();
        	}
	}
}