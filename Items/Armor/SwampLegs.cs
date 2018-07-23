using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Havoc.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class SwampLegs : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swamp Wood Leggings");
            Tooltip.SetDefault("3% increased magic critical strike chance");
        }

        public override void SetDefaults()
		{
			item.width = 18;
            item.height = 12;
			item.value = 10000;
			item.rare = 0;
			item.defense = 1;
		}

		public override void UpdateEquip(Player player)
		{
            player.magicCrit += 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SwampWood", 15);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}