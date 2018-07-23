using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Havoc.Tiles
{
    public class PrismalTile : ModTile
    {
        public override void SetDefaults()
        {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
            minPick = 230;
			drop = mod.ItemType("PismalOre");
        }
      
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)  
        {
            r = 0.5f;
            g = 0.5f;
            b = 0.5f;
        }
    }
}