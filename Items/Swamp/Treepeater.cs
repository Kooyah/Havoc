using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Havoc.Items;
using Microsoft.Xna.Framework;

namespace Havoc.Items.Swamp
{
	public class Treepeater : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 58;
			item.ranged = true;
			item.width = 22;
			item.height = 56;
			item.useTime = 51;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 4;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 30f;
			item.useAmmo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treepeater");
            Tooltip.SetDefault("");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 5f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack);
            return false;
        }
    }
}
