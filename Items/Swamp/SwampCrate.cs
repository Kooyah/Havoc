using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Havoc.Items;

namespace Havoc.Items.Swamp
{
    public class SwampCrate : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 26;

            item.rare = 2;
            item.maxStack = 99;
            item.melee = false;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Swamp Crate");
      Tooltip.SetDefault("Right click to open");
    }


        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int rand = Main.rand.Next(11);
            if (rand == 0)
                player.QuickSpawnItem(ItemID.IronBar, Main.rand.Next(4, 9));
            else if (rand == 1)
                player.QuickSpawnItem(ItemID.LeadBar, Main.rand.Next(4, 9));
            else if (rand == 2)
                player.QuickSpawnItem(ItemID.TinBar, Main.rand.Next(4, 9));
            else if (rand == 3)
                player.QuickSpawnItem(ItemID.CopperBar, Main.rand.Next(4, 9));
            else if (rand == 6)
                player.QuickSpawnItem(mod.ItemType("SwampWaveStaff"), 1);
            
        }
	}
}
