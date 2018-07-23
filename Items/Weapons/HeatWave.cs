using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace Havoc.Items.Weapons
{
	public class HeatWave : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heat Wave");
		}
		
		public override void SetDefaults()
		{
			item.damage = 48;
			item.magic = true;
			item.mana = 35;
			item.width = 34;      
            item.height = 24;
			item.useTime = 14;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 6;
	        item.shootSpeed = 9f;
            item.noMelee = true; 
			item.shoot = mod.ProjectileType("HeatWave");
			item.UseSound = SoundID.Item1;		
			item.autoReuse = true;
		    item.useTurn = true;
		}
	}
}