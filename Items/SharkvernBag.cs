using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items
{
	public class SharkvernBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 11;
			item.expert = true;
			bossBagNPC = mod.NPCType("SharkvernHead");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			player.TryGettingDevArmor();
			int lLoot = (Main.rand.Next(3));
            if (lLoot == 0)
            {
				player.QuickSpawnItem(mod.ItemType("SkytoothStormSpell"));
			}
			if (lLoot == 1)
			{
				player.QuickSpawnItem(mod.ItemType("Jaws"));
			}
			if (lLoot == 2)
			{
				player.QuickSpawnItem(mod.ItemType("SnappyShark"));
			}
		}
	}
}