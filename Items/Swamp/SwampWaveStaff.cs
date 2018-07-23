using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Swamp
{
	public class SwampWaveStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 28;
			item.magic = true;
			item.mana = 8;
			item.width = 50;
			item.height = 52;
			item.useTime = 21;
			item.useAnimation = 12;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 2;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
			item.shoot = mod.ProjectileType("SwampWave");
			item.shootSpeed = 10f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Swamp Wave Staff");
      Tooltip.SetDefault("");
    }

	}
}
