using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items
{
	public class RoilingSludge : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 14;
			item.height = 16;
			item.maxStack = 99;

			item.rare = 1;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Roiling Sludge");
      Tooltip.SetDefault("Summons The Murk");
    }


        public override bool UseItem(Player player)
		{
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Murk"));
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MudBlock, 25);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddIngredient(null, "MurkyGel", 3);
            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
