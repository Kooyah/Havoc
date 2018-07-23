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
    public class SwampGrass : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = true;
            AddMapEntry(new Color(100, 200, 100));
            Main.tileMerge[Type][TileID.Mud] = true;
            Main.tileMerge[Type][mod.TileType("SwampGrass")] = true;
            Main.tileLighted[Type] = true;
            SetModTree(new SwampTree());
            SetModCactus(new MudCactus());
            drop = ItemID.MudBlock;
        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return mod.TileType("SwampSapling");
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!effectOnly)
            {
                fail = true;
                Main.tile[i, j].type = TileID.Mud;
                WorldGen.SquareTileFrame(i, j, true);
            }
        }

        public override void RandomUpdate(int i, int j)
        {
            if (!Main.tile[i, j - 1].active())
            {
                if (Main.rand.Next(6) == 1)
                {
                    WorldGen.PlaceObject(i, j - 1, mod.TileType("SwampGrassGrow"), true);
                }
                if (Main.rand.Next(6) == 1)
                {
                    WorldGen.PlaceObject(i, j - 1, mod.TileType("SwampGrassGrow2"), true);
                }
                if (Main.rand.Next(6) == 1)
                {
                    WorldGen.PlaceObject(i, j - 1, mod.TileType("SwampGrassGrow3"), true);
                }
            }

            for (int x = i - 1; x <= i + 1; x++)
            {
                for (int y = j - 1; y <= j + 1; y++)
                {
                    if ((x != i || j != y) && Main.tile[x, y].active() && Main.tile[x, y].type == TileID.Mud)
                    {
                        WorldGen.SpreadGrass(x, y, TileID.Mud, Type, false, Main.tile[i, j].color());
                        if ((int)Main.tile[x, y].type == Type)
                        {
                            WorldGen.SquareTileFrame(x, y, true);
                        }
                    }
                }
            }
        }
    }
}