using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Havoc.Items;

namespace Havoc.Items.Swamp
{
	public class ForagersBlade : ModItem
	{
        public override void SetDefaults()
		{
			base.SetDefaults();

            item.damage = 16;
            item.width = 32;
			item.height = 32;
            item.melee = true;
            item.useTurn = true;
            item.rare = 0;
            item.useStyle = 1;
            item.useAnimation = 22;
           	item.knockBack = 5;
            item.useTime = 18;
            item.consumable = false;
            item.UseSound = SoundID.Item1;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Machete");
    }

    }
}   
