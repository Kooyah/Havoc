using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Havoc.Waters
{
	public class SwampWaterStyle : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
		{
            return HavocPlayer.ZoneSwamp;//Main.bgStyle == mod.GetSurfaceBgStyleSlot("SwampSurfaceBgStyle");
		}

		public override int ChooseWaterfallStyle()
		{
			return mod.GetWaterfallStyleSlot("SwampWaterfallStyle");
		}

		public override int GetSplashDust()
		{
            return 1;// mod.DustType("SwampWaterSplash");
		}

		public override int GetDropletGore()
		{
			return mod.GetGoreSlot("Gores/SwampDroplet");
		}

		public override void LightColorMultiplier(ref float r, ref float g, ref float b)
		{
			r = 1f;
			g = 1f;
			b = 1f;
		}

		public override Color BiomeHairColor()
		{
			return Color.Brown;
		}
	}
}