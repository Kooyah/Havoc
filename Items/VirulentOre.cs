using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items
{
	public class VirulentOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Virulent Ore");
		}
		
	public override void SetDefaults()
        {
		item.width = 16;
		item.height = 16;
		item.maxStack = 99;
		item.value = 100;
		item.rare = 0;
		item.alpha = 0;
	}
    }
}