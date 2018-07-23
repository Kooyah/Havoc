using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Weapons
{
	public class Shadeflare : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadeflare");
			Tooltip.SetDefault("Unleashes torrents of shadowflame arrows");
		}

		public override void SetDefaults()
		{
			item.damage = 85;
			item.ranged = true;
			item.width = 32;
			item.height = 62;
			item.useTime = 18;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 11;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 50f;
			item.useAmmo = AmmoID.Arrow;
		}

        	public override void AddRecipes()
        	{
            		ModRecipe recipe = new ModRecipe(mod);
            		recipe.AddIngredient(ItemID.Phantasm);
            		recipe.AddIngredient(ItemID.LunarBar, 10);
            		recipe.AddIngredient(ItemID.Ectoplasm, 8);
            		recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
            		recipe.AddRecipe();
        	}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = 5;
				item.useTime = 18;
				item.useAnimation = 20;
				item.damage = 85;
				item.shoot = ProjectileID.WoodenArrowFriendly;
			}
			else
			{
				item.useStyle = 5;
				item.useTime = 18;
				item.useAnimation = 20;
				item.damage = 85;
				item.shoot = ProjectileID.WoodenArrowFriendly;
			}
return base.CanUseItem(player);
}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.ShadowFlameArrow;
			}

			float numberProjectiles = 4 + Main.rand.Next(1);
			float rotation = MathHelper.ToRadians(7);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 10f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}
