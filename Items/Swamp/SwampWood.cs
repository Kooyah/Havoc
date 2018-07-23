using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace Havoc.Items.Swamp
{
    public class SwampWood : ModItem
    {
        public override void SetDefaults()
        {
	    item.value = 100;
	    item.rare = 0;
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Swamp Wood");
      Tooltip.SetDefault("It smells odd...");
    }

    }
}
