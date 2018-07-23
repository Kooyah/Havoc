using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class MangroveChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Mangrove Chestplate");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 3000;
			item.rare = 1;
			item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return head.type == mod.ItemType("MangroveHelmet") && legs.type == mod.ItemType("MangroveGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increased regeneration";
			player.lifeRegen = 2;
		}

        	public override void AddRecipes()
        	{
            		ModRecipe recipe = new ModRecipe(mod);
            		recipe.AddIngredient(null, "BiomassBar", 11);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
            		recipe.AddRecipe();
        	}
	}
}