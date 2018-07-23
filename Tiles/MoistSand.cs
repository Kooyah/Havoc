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
	public class MoistSand : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
            Main.tileSand[Type] = true;
            Main.tileLighted[Type] = true;
            minPick = 0;
            //soundType = 21;
            //mineResist = 4f;
            TileID.Sets.CanBeClearedDuringGeneration[Type] = true;
            drop = mod.ItemType("MoistSand");
			AddMapEntry(new Color(140, 160, 100));
            SetModCactus(new MudCactus());
        }
    }
}