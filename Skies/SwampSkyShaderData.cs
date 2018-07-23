using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace Havoc.Skies
{
	public class SwampSkyShaderData : ScreenShaderData
	{
		public SwampSkyShaderData(string passName) : base(passName)
		{
		}

        public override void Apply()
		{
            if (HavocPlayer.ZoneSwamp)
            {
				UseTargetPosition(Main.player[Main.myPlayer].Center);
			}
			base.Apply();
		}
	}
}