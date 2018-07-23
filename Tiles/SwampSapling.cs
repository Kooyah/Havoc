using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Havoc.Tiles
{
	public class SwampSapling : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 18 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.AnchorValidTiles = new int[]{ mod.TileType("SwampGrass") };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.DrawFlipHorizontal = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.RandomStyleRange = 3;
			TileObjectData.addTile(Type);
			sapling = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Sapling");
            AddMapEntry(new Color(200, 200, 200), name);
			adjTiles = new int[]{ TileID.Saplings };
		}

		public override void RandomUpdate(int i, int j)
		{
			if (WorldGen.genRand.Next(20) == 0)
			{
				bool isPlayerNear = WorldGen.PlayerLOS(i, j);
				bool success = WorldGen.GrowTree(i, j);
				if (success && isPlayerNear)
				{
					WorldGen.TreeGrowFXCheck(i, j);
				}
			}
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
		{
			if (i % 2 == 1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
		}
	}

    public class SwampTree : ModTree
    {
        private Mod mod
        {
            get
            {
                return ModLoader.GetMod("Havoc");
            }
        }

        /*public override int CreateDust()
        {
            return mod.DustType("Sparkle");
        }*/

        public override int GrowthFXGore()
        {
            return mod.GetGoreSlot("Gores/SwampLeaf");
        }

        public override int DropWood()
        {
            return mod.ItemType("SwampWood");
        }

        public override Texture2D GetTexture()
        {
            return mod.GetTexture("Tiles/SwampTree");
        }

        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        {
            return mod.GetTexture("Tiles/SwampTree_Tops");
        }

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
        {
            return mod.GetTexture("Tiles/SwampTree_Branches");
        }
    }
}