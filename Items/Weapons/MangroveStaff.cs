using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Havoc.Items.Weapons
{
	public class MangroveStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mangrove Staff");
		}
		
		public override void SetDefaults()
		{
			item.damage = 19;
			item.magic = true;
			item.mana = 7;
			item.width = 38;
			item.height = 40;
			item.useTime = 22;
			item.useAnimation = 10;
			Item.staff[item.type] = true;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 1;
			item.shoot = mod.ProjectileType("MangroveOrb");
	        	item.shootSpeed = 5f;
			item.UseSound = SoundID.Item1;		
			item.autoReuse = true;
		}

        	public override void AddRecipes()
        	{
            		ModRecipe recipe = new ModRecipe(mod);
            		recipe.AddIngredient(null, "BiomassBar", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
            		recipe.AddRecipe();
        	}
}}