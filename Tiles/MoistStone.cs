using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace Havoc.Tiles
{
	public class MoistStone : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
            minPick = 50;
            soundType = 21;
            mineResist = 2f;
            TileID.Sets.CanBeClearedDuringGeneration[Type] = true;
            drop = mod.ItemType("MoistStone");
			AddMapEntry(new Color(100, 160, 100));
		}
    }
}