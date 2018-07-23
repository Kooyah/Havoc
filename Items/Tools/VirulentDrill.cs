using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Items.Tools
{
	public class VirulentDrill : ModItem
	{
		public override void SetStaticDefaults()
		{
       			DisplayName.SetDefault("Virulent Drill");
		}

		public override void SetDefaults()
		{
			item.damage = 26;
			item.melee = true;
			item.width = 56;
			item.height = 22;
			item.useTime = 7;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.pick = 150;
			item.tileBoost++;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 3000;
			item.rare = 4;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("VirulentDrill");
			item.shootSpeed = 40f;
		}

        	public override void AddRecipes()
        	{
            		ModRecipe recipe = new ModRecipe(mod);
            		recipe.AddIngredient(null, "VirulentBar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
            		recipe.AddRecipe();
        	}
	}
}