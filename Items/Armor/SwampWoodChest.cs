using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class SwampWoodChest : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swamp Wood Chestplate");
            Tooltip.SetDefault("3% increased magic critical strike chance");
        }

        public override void SetDefaults()
		{
			item.width = 28;
			item.height = 22;
			item.value = 10000;
			item.rare = 0;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
        {
            player.magicCrit += 3;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SwampWood", 20);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}