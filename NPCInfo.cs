 using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc
{
    public class NPCInfoBase
    {
        public static bool corruptTower;

        public static void CapVelocityYModded(ModNPC mnpc, float? X, float? Y, bool? isCapNegativeX, bool? isCapNegativeY)
        {
            if (X != null)
            {
                if (isCapNegativeX != null && isCapNegativeX == false)
                {
                    if (mnpc.npc.velocity.X > X)
                    {
                        mnpc.npc.velocity.X = (float)X;
                    }
                }
                if (isCapNegativeX != null && isCapNegativeX == true)
                {
                    if (mnpc.npc.velocity.X < -X)
                    {
                        mnpc.npc.velocity.X = (float)-X;
                    }
                }
            }
            if (Y != null)
            {
                if (isCapNegativeY != null && isCapNegativeY == false)
                {
                    if (mnpc.npc.velocity.Y > Y)
                    {
                        mnpc.npc.velocity.Y = (float)Y;
                    }
                }
                if (isCapNegativeY != null && isCapNegativeY == true)
                {
                    if (mnpc.npc.velocity.Y < -Y)
                    {
                        mnpc.npc.velocity.Y = (float)-Y;
                    }
                }
            }
        }
    }
}