using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Weapons
{
	public class Cosmillash : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmillash");
			Tooltip.SetDefault("Shoots homing quasar beams");
		}
		public override void SetDefaults()
		{
			item.damage = 97;
			item.noMelee = true;
			item.magic = true;
			item.mana = 12;
			item.width = 22;
			item.height = 22;
			item.useTime = 20;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.knockBack = 10;
			item.value = 10000;
			item.rare = 10;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 30;
		}
		public override bool Shoot (Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("QuasarOrb");
			float numberProjectiles = 3; // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(Main.rand.Next(33));
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 4);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentNebula, 12);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.Ectoplasm, 8);
			recipe.AddIngredient(ItemID.SoulofNight, 8);			recipe.AddTile(TileID.LunarCraftingStation);			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
