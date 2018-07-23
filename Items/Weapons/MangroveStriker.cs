using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Weapons
{
	public class MangroveStriker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mangrove Striker");
		}
		
		public override void SetDefaults()
		{
			item.damage = 19;
			item.melee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 19;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 1;
	        	item.UseSound = SoundID.Item1;		
			item.autoReuse = true;
		}

        	public override void AddRecipes()
        	{
            		ModRecipe recipe = new ModRecipe(mod);
            		recipe.AddIngredient(null, "BiomassBar", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
            		recipe.AddRecipe();
        	}
}}