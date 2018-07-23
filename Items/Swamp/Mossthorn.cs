using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Swamp
{ 
    public class Mossthorn : ModItem
    {		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mossthorn");
		}
		
		public override void SetDefaults()
	    {
		    item.width = 40;
		    item.height = 48;  
		    item.damage = 11;  
		    item.melee = true; 
		    item.noMelee = true;
		    item.useTurn = false;
		    item.noUseGraphic = true;
		    item.useAnimation = 29;
		    item.useStyle = 5;
		    item.useTime = 26;
		    item.knockBack = 4.5f;  
		    item.UseSound = SoundID.Item1;
		    item.autoReuse = false;  
		    item.maxStack = 1;
		    item.value = 35000; 
		    item.rare = 1;  
		    item.shoot = mod.ProjectileType("MossthornProj");
		    item.shootSpeed = 9f;
	    }
	}
}