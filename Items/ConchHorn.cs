using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items
{
	public class ConchHorn : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Conch Horn");
			Tooltip.SetDefault("'It's call pierces the depths of the ocean.' \nSummons Sharkvern");
		}
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 99;
			item.rare = 3;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("SharkvernHead"));
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("SharkvernHead"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Seashell, 10);
			recipe.AddIngredient(ItemID.SoulofNight,5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}