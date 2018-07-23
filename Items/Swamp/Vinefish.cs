using Terraria;
using Terraria.ModLoader;

namespace Havoc.Items.Swamp
{
	public class Vinefish : ModItem
	{
		public override void SetDefaults()
		{

			item.questItem = true;
			item.maxStack = 1;
			item.width = 26;
			item.height = 26;
			item.uniqueStack = true;
			item.rare = -11;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Vinefish");
      Tooltip.SetDefault("");
    }


		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
            return true;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "Hey! Today I was fishing in a swamp when I was almost dragged into the water by a fish that's made of vines. I want to see if it tastes like fish and seeweed, so bring it to me!";
			catchLocation = "\n(Caught anywhere whilst in a Swamp)";
		}
	}
}
