using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Swamp
{
	public class SwampDoor : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 48;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("SwampDoorClosed");
        }     

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Swamp Door");
      Tooltip.SetDefault("");
    }

	}
}   
