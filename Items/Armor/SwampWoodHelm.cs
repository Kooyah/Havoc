using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class SwampWoodHelm : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swamp Wood Helmet");
            Tooltip.SetDefault("3% increased magic critical strike chance");
        }

        public override void SetDefaults()
		{
			item.width = 30;
			item.height = 20;
			item.value = 10000;
			item.rare = 0;
			item.defense = 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("SwampWoodChest") && legs.type == mod.ItemType("SwampLegs");
		}

		public override void UpdateEquip(Player player)
		{
            player.magicCrit += 3;
		}
		
		public override void UpdateArmorSet(Player player)
		{
			player.magicDamage *= 1.05f;
            player.setBonus = "5% increased magic damage.";
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SwampWood", 25);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}