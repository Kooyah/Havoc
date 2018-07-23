using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Weapons
{
	public class CelestialFlare : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Flare");
			Tooltip.SetDefault("Engulfs enemies in a devastating inferno");
		}
		
		public override void SetDefaults()
		{
			item.damage = 190;
			item.melee = true;
			item.width = 44;
			item.height = 52;
			item.useTime = 30;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 10000;
			item.rare = 10;
	        item.UseSound = SoundID.Item1;		
			item.autoReuse = true;
		    
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentSolar, 12);
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(ItemID.Ectoplasm, 8);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
            recipe.AddRecipe();
        }

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.Next(8) == 0)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("HotDust"));
		}
		Lighting.AddLight(player.position, 0.9f, 0.9f, 0f);
	}
	
	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		if(!(Main.rand.Next(5) == 0))
		{
			target.AddBuff(mod.BuffType("ThermalBlaze"), 600, false);
			target.AddBuff(BuffID.Daybreak, 600, true);
			target.AddBuff(BuffID.OnFire, 600, true);
		}
	}
    }
}