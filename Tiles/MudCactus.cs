using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Havoc.Tiles
{ 
    public class MudCactus : ModCactus
    {
        private Mod mod
        {
            get
            {
                return ModLoader.GetMod("Havoc");
            }
        }

        public override Texture2D GetTexture()
        {
            return mod.GetTexture("Tiles/MudCactus");
        }
    }
}