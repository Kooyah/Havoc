 using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc
{
    public class HavocGlobalTile : GlobalTile
    {
        public override void SetDefaults()
        {
            Main.tileMerge[TileID.Mud][mod.TileType("SwampGrass")] = true;
        }
    }
}