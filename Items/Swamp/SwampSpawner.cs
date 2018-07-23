using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Havoc.Items;

namespace Havoc.Items.Swamp
{
	public class SwampSpawner : ModItem
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
      DisplayName.SetDefault("Debug Swamp Spawner");
      Tooltip.SetDefault("Right click to spawn a Swamp.");
    }


		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
            Main.NewText("Made Swamp.");
            HavocWorld havocWorld = (HavocWorld)mod.GetModWorld("HavocWorld");
            havocWorld.MakeSwamp();
		}
	}
}
