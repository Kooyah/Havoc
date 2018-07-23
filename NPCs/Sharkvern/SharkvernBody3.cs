using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.NPCs.Sharkvern
{    
    public class SharkvernBody3 : ModNPC
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sharkvern");
		}
		
		public override void SetDefaults()
        {
            npc.width = 52;             
            npc.height = 54;           
            npc.damage = 36;
            npc.defense = 45;
            npc.lifeMax = 27000;
            npc.knockBackResist = 0.0f;
            npc.behindTiles = true;
            npc.noTileCollide = true;
            npc.netAlways = true;
            npc.noGravity = true;
            npc.dontCountMe = true;
            npc.HitSound = SoundID.NPCHit1;
        }

         public override bool PreAI()
        {
            if (npc.ai[3] > 0)
                npc.realLife = (int)npc.ai[3];
            if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead)
                npc.TargetClosest(true);
            if (Main.player[npc.target].dead && npc.timeLeft > 300)
                npc.timeLeft = 300;

            if (Main.netMode != 1)
            {
                if (!Main.npc[(int)npc.ai[1]].active)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
            }

            if (npc.ai[1] < (double)Main.npc.Length)
            {
                // space
                Vector2 npcCenter = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                // space
                float dirX = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - npcCenter.X;
                float dirY = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - npcCenter.Y;
                //space
                npc.rotation = (float)Math.Atan2(dirY, dirX) + 1.57f;
                // space
                float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
                // space
                float dist = (length - (float)npc.width) / length;
                float posX = dirX * dist;
                float posY = dirY * dist;

                // space
                npc.velocity = Vector2.Zero;
                // space
                npc.position.X = npc.position.X + posX;
                npc.position.Y = npc.position.Y + posY;
            }
 		   return false;
        }

        public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life > 0 && Main.netMode != 1 && Main.rand.Next(50) == 0)
			{
				int randomSpawn = Main.rand.Next(2);
				if (randomSpawn == 0)
				{
					randomSpawn = mod.NPCType("AquaSurge");
				}
				int num660 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), randomSpawn, 0, 0f, 0f, 0f, 0f, 255);
			}
		}

	    public override bool PreDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            Main.spriteBatch.Draw(texture, npc.Center - Main.screenPosition, new Rectangle?(), drawColor, npc.rotation, origin, npc.scale, SpriteEffects.None, 0);
            return false;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {

            return false;     
        }
    }
}
