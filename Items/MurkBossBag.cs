using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items
{
	public class MurkBossBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("Murk");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Treasure Bag");
      Tooltip.SetDefault("Right click to open");
    }


		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
            int random = Main.rand.Next(3);
			if (random == 2)
            {
				player.QuickSpawnItem(mod.ItemType("MurkFlail"));
            }
            if (random == 1)
			{
				player.QuickSpawnItem(mod.ItemType("Mossthorn"));
            }
            if (random == 0)
            {
                player.QuickSpawnItem(mod.ItemType("Landslide"));
            }
            player.QuickSpawnItem(mod.ItemType("MudAbsorber"));
            player.QuickSpawnItem(mod.ItemType("MurkyGel"), 10);
		}
	}
}
