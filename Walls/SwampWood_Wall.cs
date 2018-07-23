using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Havoc.Walls
{
	public class SwampWood_Wall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			//dustType = mod.DustType("Sparkle");
			drop = mod.ItemType("SwampWoodWall");
			AddMapEntry(new Color(10, 20, 10));
		}
	}
}