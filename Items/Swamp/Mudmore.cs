using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Havoc.Items;

namespace Havoc.Items.Swamp
{
	public class Mudmore : ModItem
	{
        public override void SetDefaults()
		{
			base.SetDefaults();

            item.damage = 54;
            item.width = 50;
			item.height = 58;
            item.melee = true;
            item.useTurn = true;
            item.rare = 4;
            item.useStyle = 1;
            item.useAnimation = 26;
           	item.knockBack = 8;
            item.useTime = 36;
            item.consumable = false;
            item.UseSound = SoundID.Item1;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mudmore");
      Tooltip.SetDefault("Releases mud upon striking enemies");
    }


        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            Projectile.NewProjectile(target.Center.X, target.Center.Y, Main.rand.Next(-3, 4), Main.rand.Next(-3, 0), mod.ProjectileType("MudBlob"), item.damage - 20, 0f, Main.myPlayer, 0f, 0f);
        }
    }
}   
