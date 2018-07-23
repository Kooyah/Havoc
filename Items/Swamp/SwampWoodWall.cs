using Terraria.ModLoader;

namespace Havoc.Items.Swamp
{
	public class SwampWoodWall : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = 1;
			item.consumable = true;
			item.createWall = mod.WallType("SwampWood_Wall");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Swamp Wall");
      Tooltip.SetDefault("");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SwampWood");
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}
