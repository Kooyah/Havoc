using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Accessory
{
	public class MudAbsorber : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mud Absorber");
            Tooltip.SetDefault("More damage and life regeneration when close to mud");
        }

        public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 3;
			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			bool nearMud = false; //                   8f
			int y_top_edge = (int)(player.position.Y - 16f) / 16;
			int y_bottom_edge = (int)(player.position.Y + (float)player.height + 16f) / 16;
			int x_left_edge = (int)(player.position.X - 16f) / 16;
			int x_right_edge = (int)(player.position.X + (float)player.width + 16f) / 16;

			for (int x = x_left_edge; x <= x_right_edge; x++)
			{
				for (int y = y_top_edge; y <= y_bottom_edge; y++)
				{
					if (Main.tile[x, y].type == TileID.Mud || Main.tile[x, y].type == TileID.JungleGrass || Main.tile[x, y].type == TileID.MushroomGrass || Main.tile[x, y].type == mod.TileType("SwampGrass"))
					{
						nearMud = true;
						break;
					}
				}
				if (nearMud) break;
			}
			
			if (nearMud)
			{
				item.lifeRegen = 10;
				player.meleeDamage *= 1.2f;
				player.thrownDamage *= 1.5f;
				player.rangedDamage *= 1.2f;
				player.magicDamage *= 1.3f;
				player.meleeSpeed *= 1.2f; 
				player.minionDamage *= 1.2f;
                player.thrownCrit += 1;
                player.magicCrit += 1;
                player.meleeCrit += 1;
                player.rangedCrit += 1;
            }
            else
            {
                item.lifeRegen = 0;
            }
		}
	}
}