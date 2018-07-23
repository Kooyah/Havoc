using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.NPCs.Murk
{
	public class Murk : ModNPC
	{
        int counter = 0;
        public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 2800;
			npc.damage = 45;
			npc.defense = 14;
            npc.knockBackResist = 0.0f;
            npc.dontTakeDamage = false;
			npc.value = Item.buyPrice(0, 3, 5, 0);
			npc.npcSlots = 50f;
            npc.width = 126;
            npc.height = 134;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = false;
			npc.noTileCollide = false;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.HitSound = SoundID.NPCHit1;
            npc.alpha = 0;
            aiType = NPCID.KingSlime;
            animationType = NPCID.KingSlime;			
			NPCID.Sets.MustAlwaysDraw[npc.type] = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Murk");
            bossBag = mod.ItemType("MurkBossBag");
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Murk");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.KingSlime];
        }

        public void CustomBehavior(ref float ai)
		{
			Player player = Main.player[npc.target];
        }
        
        public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
		if (Main.rand.Next(1) == 0)
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MurkyGel"), Main.rand.Next(8, 12));
		}
                int choice = Main.rand.Next(3);
                if (choice == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MurkFlail"));
                else if (choice == 1)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Mossthorn"));
                else if (choice == 2)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Landslide"));
		}}


        public override void AI()
        {
            float num644 = 1f;
            bool flag65 = false;
            bool flag66 = false;
            npc.aiAction = 0;
            if (npc.ai[3] == 0f && npc.life > 0)
            {
                npc.ai[3] = (float)npc.lifeMax;
            }
            if (npc.localAI[3] == 0f && Main.netMode != 1)
            {
                npc.ai[0] = -100f;
                npc.localAI[3] = 1f;
                npc.TargetClosest(true);
                npc.netUpdate = true;
            }
            if (Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
                if (Main.player[npc.target].dead)
                {
                    npc.timeLeft = 0;
                    if (Main.player[npc.target].Center.X < npc.Center.X)
                    {
                        npc.direction = 1;
                    }
                    else
                    {
                        npc.direction = -1;
                    }
                }
            }
            if (!Main.player[npc.target].dead && npc.ai[2] >= 300f && npc.ai[1] < 5f && npc.velocity.Y == 0f)
            {
                npc.ai[2] = 0f;
                npc.ai[0] = 0f;
                npc.ai[1] = 5f;
                if (Main.netMode != 1)
                {
                    npc.TargetClosest(false);
                    Point point5 = npc.Center.ToTileCoordinates();
                    Point point6 = Main.player[npc.target].Center.ToTileCoordinates();
                    Vector2 vector65 = Main.player[npc.target].Center - npc.Center;
                    int num645 = 10;
                    int num646 = 0;
                    int num647 = 7;
                    int num648 = 0;
                    bool flag67 = false;
                    if (vector65.Length() > 2000f)
                    {
                        flag67 = true;
                        num648 = 100;
                    }
                    while (!flag67 && num648 < 100)
                    {
                        num648++;
                        int num649 = Main.rand.Next(point6.X - num645, point6.X + num645 + 1);
                        int num650 = Main.rand.Next(point6.Y - num645, point6.Y + 1);
                        if ((num650 < point6.Y - num647 || num650 > point6.Y + num647 || num649 < point6.X - num647 || num649 > point6.X + num647) && (num650 < point5.Y - num646 || num650 > point5.Y + num646 || num649 < point5.X - num646 || num649 > point5.X + num646) && !Main.tile[num649, num650].nactive())
                        {
                            int num651 = num650;
                            int num652 = 0;
                            bool flag68 = Main.tile[num649, num651].nactive() && Main.tileSolid[(int)Main.tile[num649, num651].type] && !Main.tileSolidTop[(int)Main.tile[num649, num651].type];
                            if (flag68)
                            {
                                num652 = 1;
                            }
                            else
                            {
                                while (num652 < 150 && num651 + num652 < Main.maxTilesY)
                                {
                                    int num653 = num651 + num652;
                                    bool flag69 = Main.tile[num649, num653].nactive() && Main.tileSolid[(int)Main.tile[num649, num653].type] && !Main.tileSolidTop[(int)Main.tile[num649, num653].type];
                                    if (flag69)
                                    {
                                        num652--;
                                        break;
                                    }
                                    num652++;
                                }
                            }
                            num650 += num652;
                            bool flag70 = true;
                            if (flag70 && Main.tile[num649, num650].lava())
                            {
                                flag70 = false;
                            }
                            if (flag70 && !Collision.CanHitLine(npc.Center, 0, 0, Main.player[npc.target].Center, 0, 0))
                            {
                                flag70 = false;
                            }
                            if (flag70)
                            {
                                npc.localAI[1] = (float)(num649 * 16 + 8);
                                npc.localAI[2] = (float)(num650 * 16 + 16);
                                break;
                            }
                        }
                    }
                    if (num648 >= 100)
                    {
                        Vector2 bottom = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].Bottom;
                        npc.localAI[1] = bottom.X;
                        npc.localAI[2] = bottom.Y;
                    }
                }
            }
            if (!Collision.CanHitLine(npc.Center, 0, 0, Main.player[npc.target].Center, 0, 0))
            {
                npc.ai[2] += 1f;
            }
            if (Math.Abs(npc.Top.Y - Main.player[npc.target].Bottom.Y) > 320f)
            {
                npc.ai[2] += 1f;
            }

            if (Main.netMode != 1)
            {
                bool flag80 = false;
                int num70 = 0;
                num70 = num70 + 1;
                Vector2 vector65 = Main.player[npc.target].Center - npc.Center;
                int num665 = 0;
                int num666 = 10;
                bool flag71 = false;
                bool flag81 = true;
                if (Main.expertMode == true)
                {
                    npc.lifeMax = 5000;
                }

                if (npc.life <= 1500 && Main.expertMode == true)
                {
                    npc.damage = 123;
                    npc.defense = 54;
                    npc.knockBackResist = 0.0f;
                    if (npc.life <= 1000)
                    {
                        flag80 = true;
                        num665 = 10;
                    }
                }
                else if (npc.life < npc.lifeMax / 2 && Main.expertMode == false)
                {
                    npc.damage = 102;
                    npc.defense = 34;
                }

                if (npc.life <= 1500)
                {
                    if (flag81 == true)
                    {
                        flag71 = true;
                    }
                }

                if (flag71 == true)
                {
                    npc.defense = 10;
                    flag81 = false;
                    flag71 = false;
                    if (counter++ == 10)
                    {

                    }
                }

                if (Main.expertMode == true && npc.life <= 500)
                {
                    if (num70 >= 75)
                    {
                        npc.life += 5;
                        num70 = 0;
                    }
                }
            }

            if (npc.ai[1] == 5f)
            {
                flag65 = true;
                npc.aiAction = 1;
                npc.ai[0] += 1f;
                num644 = MathHelper.Clamp((60f - npc.ai[0]) / 60f, 0f, 1f);
                num644 = 0.5f + num644 * 0.5f;
                if (npc.ai[0] >= 60f)
                {
                    flag66 = true;
                }
                /* if (npc.ai[0] == 60f)
                {
                    Gore.NewGore(npc.Center + new Vector2(-40f, (float)(-(float)npc.height / 2)), npc.velocity, 734, 1f);
                } */
                if (npc.ai[0] >= 60f && Main.netMode != 1)
                {
                    npc.Bottom = new Vector2(npc.localAI[1], npc.localAI[2]);
                    npc.ai[1] = 6f;
                    npc.ai[0] = 0f;
                    npc.netUpdate = true;
                }
                if (Main.netMode == 1 && npc.ai[0] >= 120f)
                {
                    npc.ai[1] = 6f;
                    npc.ai[0] = 0f;
                }
                if (!flag66)
                {
                    for (int num654 = 0; num654 < 10; num654++)
                    {
                        int num655 = Dust.NewDust(npc.position + Vector2.UnitX * -20f, npc.width + 40, npc.height, 4, npc.velocity.X, npc.velocity.Y, 150, new Color(78, 136, 255, 80), 2f);
                        Main.dust[num655].noGravity = true;
                        Main.dust[num655].velocity *= 0.5f;
                    }
                }
            }
            else if (npc.ai[1] == 6f)
            {
                flag65 = true;
                npc.aiAction = 0;
                npc.ai[0] += 1f;
                num644 = MathHelper.Clamp(npc.ai[0] / 30f, 0f, 1f);
                num644 = 0.5f + num644 * 0.5f;
                if (npc.ai[0] >= 30f && Main.netMode != 1)
                {
                    npc.ai[1] = 0f;
                    npc.ai[0] = 0f;
                    npc.netUpdate = true;
                    npc.TargetClosest(true);
                }
                if (Main.netMode == 1 && npc.ai[0] >= 60f)
                {
                    npc.ai[1] = 0f;
                    npc.ai[0] = 0f;
                    npc.TargetClosest(true);
                }
                for (int num656 = 0; num656 < 10; num656++)
                {
                    int num657 = Dust.NewDust(npc.position + Vector2.UnitX * -20f, npc.width + 40, npc.height, 4, npc.velocity.X, npc.velocity.Y, 150, new Color(78, 136, 255, 80), 2f);
                    Main.dust[num657].noGravity = true;
                    Main.dust[num657].velocity *= 2f;
                }
            }
            npc.dontTakeDamage = (npc.hide = flag66);
            if (npc.velocity.Y == 0f)
            {
                npc.velocity.X = npc.velocity.X * 0.8f;
                if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
                {
                    npc.velocity.X = 0f;
                }
                if (!flag65)
                {
                    npc.ai[0] += 2f;
                    if ((double)npc.life < (double)npc.lifeMax * 0.8)
                    {
                        npc.ai[0] += 1f;
                    }
                    if ((double)npc.life < (double)npc.lifeMax * 0.6)
                    {
                        npc.ai[0] += 1f;
                    }
                    if ((double)npc.life < (double)npc.lifeMax * 0.4)
                    {
                        npc.ai[0] += 2f;
                    }
                    if ((double)npc.life < (double)npc.lifeMax * 0.2)
                    {
                        npc.ai[0] += 3f;
                    }
                    if ((double)npc.life < (double)npc.lifeMax * 0.1)
                    {
                        npc.ai[0] += 4f;
                    }
                    if (npc.ai[0] >= 0f)
                    {
                        npc.netUpdate = true;
                        npc.TargetClosest(true);
                        if (npc.ai[1] == 3f)
                        {
                            npc.velocity.Y = -13f;
                            npc.velocity.X = npc.velocity.X + 3.5f * (float)npc.direction;
                            npc.ai[0] = -200f;
                            npc.ai[1] = 0f;
                        }
                        else if (npc.ai[1] == 2f)
                        {
                            npc.velocity.Y = -6f;
                            npc.velocity.X = npc.velocity.X + 4.5f * (float)npc.direction;
                            npc.ai[0] = -120f;
                            npc.ai[1] += 1f;
                        }
                        else
                        {
                            npc.velocity.Y = -8f;
                            npc.velocity.X = npc.velocity.X + 4f * (float)npc.direction;
                            npc.ai[0] = -120f;
                            npc.ai[1] += 1f;
                        }
                    }
                    else if (npc.ai[0] >= -30f)
                    {
                        npc.aiAction = 1;
                    }
                }
            }
            else if (npc.target < 255 && ((npc.direction == 1 && npc.velocity.X < 3f) || (npc.direction == -1 && npc.velocity.X > -3f)))
            {
                if ((npc.direction == -1 && (double)npc.velocity.X < 0.1) || (npc.direction == 1 && (double)npc.velocity.X > -0.1))
                {
                    npc.velocity.X = npc.velocity.X + 0.2f * (float)npc.direction;
                }
                else
                {
                    npc.velocity.X = npc.velocity.X * 0.93f;
                }
            }
            int num658 = Dust.NewDust(npc.position, npc.width, npc.height, 4, npc.velocity.X, npc.velocity.Y, 255, new Color(0, 80, 255, 80), npc.scale * 1.2f);
            Main.dust[num658].noGravity = true;
            Main.dust[num658].velocity *= 0.5f;
            if (npc.life > 0)
            {
                float num659 = (float)npc.life / (float)npc.lifeMax;
                num659 = num659 * 0.5f + 0.75f;
                num659 *= num644;
                if (num659 != npc.scale)
                {
                    npc.position.X = npc.position.X + (float)(npc.width / 2);
                    npc.position.Y = npc.position.Y + (float)npc.height;
                    npc.scale = num659;
                    npc.width = (int)(98f * npc.scale);
                    npc.height = (int)(92f * npc.scale);
                    npc.position.X = npc.position.X - (float)(npc.width / 2);
                    npc.position.Y = npc.position.Y - (float)npc.height;
                }
                if (Main.netMode != 1)
                {
                    int num660 = (int)((double)npc.lifeMax * 0.07);
                    if ((float)(npc.life + num660) < npc.ai[3])
                    {
                        npc.ai[3] = (float)npc.life;
                        int num661 = Main.rand.Next(1, 4);
                        for (int num662 = 0; num662 < num661; num662++)
                        {
                            int x = (int)(npc.position.X + (float)Main.rand.Next(npc.width - 32));
                            int y = (int)(npc.position.Y + (float)Main.rand.Next(npc.height - 32));
                            int num663 = mod.NPCType("SwampSlime");

                            int num664 = NPC.NewNPC(x, y, num663, 0, 0f, 0f, 0f, 0f, 255);
                            Main.npc[num664].SetDefaults(num663, -1f);
                            Main.npc[num664].velocity.X = (float)Main.rand.Next(-15, 16) * 0.1f;
                            Main.npc[num664].velocity.Y = (float)Main.rand.Next(-30, 1) * 0.1f;
                            Main.npc[num664].ai[0] = (float)(-1000 * Main.rand.Next(3));
                            Main.npc[num664].ai[1] = 0f;
                            if (Main.netMode == 2 && num664 < 200)
                            {
                                NetMessage.SendData(23, -1, -1, null, num664, 0f, 0f, 0f, 0, 0, 0);
                            }
                        }
                        return;
                    }
                }
            }
        }

        public override bool CheckDead()
        {
            HavocWorld.downedMurk = true;
            return true;
        }

        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            int x = (int)(npc.position.X + (float)Main.rand.Next(npc.width - 32));
            int y = (int)(npc.position.Y + (float)Main.rand.Next(npc.height - 32));
            int num663 = mod.NPCType("Fly");

            int num664 = NPC.NewNPC(x, y, num663, 0, 0f, 0f, 0f, 0f, 255);
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            int x = (int)(npc.position.X + (float)Main.rand.Next(npc.width - 32));
            int y = (int)(npc.position.Y + (float)Main.rand.Next(npc.height - 32));
            int num663 = mod.NPCType("Fly");

            int num664 = NPC.NewNPC(x, y, num663, 0, 0f, 0f, 0f, 0f, 255);
        }
    }
}