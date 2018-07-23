using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Havoc.Walls
{
	public class Swamp_Wall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = false;
			//dustType = mod.DustType("Sparkle");
			//drop = mod.ItemType("N");
			AddMapEntry(new Color(10, 20, 10));
		}
	}
}