using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Weapons
{
	public class MangroveBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mangrove Bow");
		}

		public override void SetDefaults()
		{
			item.damage = 14;
			item.ranged = true;
			item.width = 20;
			item.height = 32;
			item.useTime = 28;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 35f;
			item.useAmmo = AmmoID.Arrow;
		}

        	public override void AddRecipes()
        	{
            		ModRecipe recipe = new ModRecipe(mod);
            		recipe.AddIngredient(null, "BiomassBar", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
            		recipe.AddRecipe();
        	}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 2 + Main.rand.Next(1);
			float rotation = MathHelper.ToRadians(10);
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
