using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MangroveHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Mangrove Helmet");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 3000;
			item.rare = 1;
			item.defense = 5;
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