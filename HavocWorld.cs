using System.IO;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.ModLoader.IO;

namespace Havoc
{
    public class HavocWorld : ModWorld
    {
        #region vars
        private const int saveVersion = 0;
        public static bool downedMurk = false;
        public static bool downedEmpressFly = false;
        public static bool inSwamp = false;
        public static bool stopWorldEnter = false;
        public static int swampGrass;
        public static int lihahzrdBlocks;
        #endregion

        public override void Initialize()
        {
            downedMurk = false;
            downedEmpressFly = false;
            inSwamp = false;
            swampGrass = 0;
        }//if (buffType[b] == BuffID.Sharpened && inventory[selectedItem].melee) armorPenetration = 4;

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedMurk) downed.Add("Murk");
            if (downedEmpressFly) downed.Add("empressFly");

            return new TagCompound {
                {"downed", downed},
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedMurk = downed.Contains("Murk");
            downedEmpressFly = downed.Contains("empressFly");
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {

			int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
		
            tasks.Insert(genIndex + 1, new PassLegacy("Misc", delegate (GenerationProgress progress)
            {
                //Swamp
                progress.Message = "Adding Swamp";
                MakeSwamp();
            }));
        }

        [System.Obsolete("Doesn't look the way I want.", false)]

        public void SwampStalactites(int X, int Y, int repeates)
        {
            int rand = Main.rand.Next(0, 10);
            for (int i = Y; i < Y + repeates; i++)
            {
                if (repeates < 60)
                    WorldGen.TileRunner(X, i + rand, 6, 2, mod.TileType("Biomass"), true, 0f, 0f, true, false);
                else
                    WorldGen.TileRunner(X, i + rand, 10, 2, mod.TileType("Biomass"), true, 0f, 0f, true, false);
            }
            for (int i = Y + repeates; i < (Y + repeates) + 10; i++)
            {
                WorldGen.KillTile(X, i + rand);
                WorldGen.PlaceTile(X, i + rand, mod.TileType("Biomass"));
            }
        }

        public int BlockLining(double x, double y, int repeats, int tileType, bool random, int max, int min = 3)
        {
            for (double i = x; i < x + repeats; i++)
            {
                if (random)
                {
                    for (double k = y; k < y + Main.rand.Next(min, max); k++)
                    {
                        WorldGen.PlaceTile((int)i, (int)k, tileType);
                    }
                }
                else
                {
                    for (double k = y; k < y + max; k++)
                    {
                        WorldGen.PlaceTile((int)i, (int)k, tileType);
                    }
                }
            }
            return repeats;
        }

        public void SwampMound1(int X, int Y)
        {
            int rand = Main.rand.Next(0, 10);
            int mud = TileID.Mud;
            WorldGen.TileRunner(X, Y, 2, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 5, 4, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 10, 6, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 15, 8, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 20, 10, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 25, 12, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 30, 14, 4, mud, true, 0f, 0f, true, true);
        }

        public void SwampMound2(int X, int Y)
        {
            int rand = Main.rand.Next(0, 10);
            int mud = TileID.Mud;
            WorldGen.TileRunner(X, Y, 2, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 5, 4, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 10, 6, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 15, 8, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 20, 10, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 25, 12, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 30, 14, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 35, 17, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 40, 20, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 45, 23, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 50, 27, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 55, 31, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 60, 35, 4, mud, true, 0f, 0f, true, true);
        }

        public void SwampMound3(int X, int Y)
        {
            int rand = Main.rand.Next(10, 50);
            int mud = TileID.Mud;
            WorldGen.TileRunner(X, Y, 2, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 5, 4, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 10, 6, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 15, 8, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X, Y + 20, 10, 4, mud, true, 0f, 0f, true, true);

            WorldGen.TileRunner(X + rand, Y, 2, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X + rand, Y + 5, 4, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X + rand, Y + 10, 6, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X + rand, Y + 15, 8, 4, mud, true, 0f, 0f, true, true);
            WorldGen.TileRunner(X + rand, Y + 20, 10, 4, mud, true, 0f, 0f, true, true);

            for (int i = X - 20; i < X + 50 + (rand / 3); X++)
            {
                for (int j = Y - 20; j < Y + 50 + (rand / 3); j++)
                {
                    if (Main.tile[i, j] == null)
                    {
                        Main.tile[i, j].liquidType(0);
                        Main.tile[i, j].liquid = 255;
                        WorldGen.SquareTileFrame(i, j, true);
                    }
                }
            }
        }

        public int CheckWorldSize()
        {   //Yoraiz0r - Today at 6:43 PM
            //small world size is 4200x1200 , medium multiplies every axis by 1.5 , and large multiplies every axis by 2.0
            //just saying
            int worldSize = 0;
            if (Main.maxTilesX < 5000)
            {
                worldSize = 4000;
            }
            else if (Main.maxTilesX > 5000 && Main.maxTilesX < 17000)
            {
                worldSize = 15000;
            }
            else if (Main.maxTilesX > 17000)
            {
                worldSize = 20000;
            }
            return worldSize;
        }

        public double CheckWorldSizeByMultiplier()
        {   //Yoraiz0r - Today at 6:43 PM
            //small world size is 4200x1200 , medium multiplies every axis by 1.5 , and large multiplies every axis by 2.0
            //just saying
            double worldSize = 0;
            if (Main.maxTilesX < 5000)
            {
                worldSize = 1;
            }
            else if (Main.maxTilesX > 5000 && Main.maxTilesX < 17000)
            {
                worldSize = 1.5;
            }
            else if (Main.maxTilesX > 17000)
            {
                worldSize = 2;
            }
            return worldSize;
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            HavocPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<HavocPlayer>(mod);
            swampGrass = tileCounts[mod.TileType("SwampGrass")];
        }

        public override void ResetNearbyTileEffects()
        {
            swampGrass = 0;
        }

        public override void PostWorldGen()
        {
            for (int i = 1; i < Main.rand.Next(4, 6); i++)
            {
                int[] itemsToPlaceInOvergrownChestsSecond = new int[] { ItemID.MudBlock, ItemID.IronskinPotion, ItemID.WoodenArrow, mod.ItemType("DecayedMoss") };
                int itemsToPlaceInOvergrownChestsChoiceSecond = 0;
                for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
                {
                    Chest chest = Main.chest[chestIndex];
                    if (chest != null && Main.tile[chest.x, chest.y].type == mod.TileType("OvergrownChest"))
                    {
                        for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                        {
                            if (chest.item[inventoryIndex].type == 0)
                            {
                                itemsToPlaceInOvergrownChestsChoiceSecond = Main.rand.Next(itemsToPlaceInOvergrownChestsSecond.Length);
                                chest.item[inventoryIndex].SetDefaults(itemsToPlaceInOvergrownChestsSecond[itemsToPlaceInOvergrownChestsChoiceSecond]);
                                chest.item[inventoryIndex].stack = Main.rand.Next(3, 4);
                                break;
                            }
                        }
                    }
                }
            }
            int[] itemsToPlaceInOvergrownChests = new int[] { mod.ItemType("FiberglassRifle"), mod.ItemType("ForagersBlade") };
            int itemsToPlaceInOvergrownChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null && Main.tile[chest.x, chest.y].type == mod.TileType("OvergrownChest"))
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        itemsToPlaceInOvergrownChestsChoice = Main.rand.Next(itemsToPlaceInOvergrownChests.Length);
                        chest.item[0].SetDefaults(itemsToPlaceInOvergrownChests[itemsToPlaceInOvergrownChestsChoice]);
                        break;
                    }
                }
            }
        }

        [Obsolete]
        public void MakeSwampOld(int x, int y)
        {
            int firstX = x;
            int firstY = y;
            int rand1 = 0;
            int rand2 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (Main.tile[firstX - (i * 50), firstY].type != TileID.LihzahrdBrick || Main.tile[firstX - (i * 50), firstY].wall != WallID.LihzahrdBrickUnsafe)
                    WorldGen.digTunnel(firstX - (i * 50), firstY, 0, 0, 2, 100, false);
            }
            for (int i = firstX - 270 - WorldGen.genRand.Next(-6, 7); i < firstX + 95 + WorldGen.genRand.Next(-6, 7); i++)
            {
                for (int l = firstY - 100 - WorldGen.genRand.Next(-6, 7); l < firstY + 80 + WorldGen.genRand.Next(-6, 7); l++)
                {
                    WorldGen.KillWall(i, l, true);
                    WorldGen.PlaceWall(i, l, mod.WallType("Swamp_Wall"), true);
                }
            }
            for (int k = 0; k < 8; k++)
            {
                for (int i = firstX - 300; i < firstX + 130; i++)
                {
                    WorldGen.TileRunner(i, (firstY + 30 + k * 8) + Main.rand.Next(-20, 10), Main.rand.Next(6, 13), 3, TileID.Mud, true, 0f, 0f, true, false);
                }
            }

            for (int i = 0; i < Main.rand.Next(2, 3); i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    int yAdd = k * 10;
                    WorldGen.digTunnel(firstX + Main.rand.Next(-100, 50), firstY + k, 0, -10, 3, 10, false);
                }
            }

            for (int j = 0; j < 90; j++)
            {
                SwampStalactites(firstX + Main.rand.Next(-300, 70), firstY - 105, Main.rand.Next(10, 70));
            }

            for (int j = firstX - 250; j < firstX + 100; j++)
            {
                WorldGen.TileRunner(j, firstY - (90 + Main.rand.Next(-10, 20)), 16, 2, mod.TileType("Biomass"), true, 0f, 0f, true, false);
            }

            for (int j = 0; j < 40; j++)
            {
                WorldGen.TileRunner(firstX + Main.rand.Next(-300, 70), firstY - Main.rand.Next(-60, 60), Main.rand.Next(10, 12), 2, mod.TileType("Biomass"), false, 0f, 0f, true, true);
                WorldGen.TileRunner(firstX + Main.rand.Next(-300, 70), firstY - Main.rand.Next(-60, 130), Main.rand.Next(12, 15), 2, mod.TileType("MoistSand"), false, 0f, 0f, true, true);
            }

            for (int i = 0; i < 2; i++)
            {
                SwampMound1(firstX + Main.rand.Next(-300, 70), firstY - 10);
            }
            SwampMound2(firstX + Main.rand.Next(-200, 70), firstY - 50);

            for (int i = 0; i < 2000; i++)
            {//KillWall(int i, int j, bool fail = false)
                rand1 = Main.rand.Next(-300, 51);
                int num1 = (firstX + rand1);
                int num2 = firstY + Main.rand.Next(-100, 101);
                if (Main.tile[num1, num2 + 1] != null || Main.tile[num1, num2 + 1].type != 0)
                {
                    WorldGen.PlaceObject(num1, num2, mod.TileType("SwampSapling"), false, 0, 0, -1, 1);
                    WorldGen.GrowTree(num1, num2);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                Vector2 random = new Vector2(firstX + Main.rand.Next(-300, 70), firstY - Main.rand.Next(10, 20));
                House((int)random.X, (int)random.Y, mod.TileType("SwampWood_Placed"), 1, true, 2);
                if (WorldGen.genRand.Next(2) == 0)
                    WorldGen.PlaceChestDirect((int)random.X + 12, (int)random.Y + 8, (ushort)mod.TileType("OvergrownChest"), 0, 0);
            }

            for (int i = firstX - 300; i < firstX + 130; ++i)
            {
                for (int k = firstY - 200; k < firstY + 200; ++k)
                {
                    if (Main.tile[i, k].type == TileID.Mud)
                    {
                        if (!Main.tile[i, k - 1].active())
                        {
                            Main.tile[i, k].type = (ushort)mod.TileType("SwampGrass");
                        }
                    }
                }
            }
        }

        public void MakeSwamp()
        {
            int locationX = Main.dungeonX < Main.spawnTileX ? Main.spawnTileX + (Main.maxTilesX / 4) : Main.spawnTileX - (Main.maxTilesX / 4);
            int locationY = RaycastDown(locationX, 200) - 20;
            int size = WorldGen.genRand.Next((Main.maxTilesX / 6) - 40, (Main.maxTilesX / 6) + 60);
            int neg = locationX < Main.spawnTileX ? 1 : -1;
            int locationEdgeX = locationX + (size * neg);
            int locationEdgeY = locationY + Main.maxTilesY / 3;
            int biomeSize = locationEdgeX;
            int startX = locationX;
            int endX = locationEdgeX;
            if (neg == -1)
            {
                startX = locationEdgeX;
                endX = locationX;
            }
            for (int depth = locationY; depth < locationEdgeY; ++depth)
            {
                for (int i = startX; i < endX; ++i)
                {
                    Tile tile = Main.tile[i, depth];
                    if (tile != null)
                    {
                        if (tile.type == TileID.Dirt)
                            tile.type = TileID.Mud;
                        if (tile.type == TileID.Grass || tile.type == TileID.JungleGrass)
                            tile.type = (ushort)mod.TileType("SwampGrass");
                        if (tile.type == TileID.WoodBlock || tile.type == TileID.RichMahogany)
                            tile.type = (ushort)mod.TileType("SwampWood_Placed");
                        if (tile.type == TileID.Sand)
                            tile.type = (ushort)mod.TileType("MoistSand");
                        if (tile.wall != WallID.None)
                            tile.wall = (ushort)mod.WallType("Swamp_Wall");
                        ushort[] stoneTypes = new ushort[] { TileID.Stone, 179, 180, 181, 182, 183, 184 };
                        if (stoneTypes.Any(x => x == tile.type))
                        {
                            if (WorldGen.genRand.Next(30) <= 2)
                                tile.type = (ushort)mod.TileType("Biomass");
                            else
                                tile.type = TileID.Mud;
                        }
                    }
                }
                int rand = WorldGen.genRand.Next(3);
                if (depth < locationEdgeY - ((locationEdgeY - locationY) / 2))
                {
                    if (rand == 0)
                        biomeSize--;
                    if (rand == 1)
                        biomeSize++;
                }
                else
                {
                    if (rand == 0)
                        biomeSize--;
                    if (rand == 1)
                        biomeSize -= 2;
                }
            }
            for (int i = 0; i < 100; ++i)
            {
                Point spawnPos = new Point(0, 0);
                if (neg == 1)
                    spawnPos = new Point(WorldGen.genRand.Next(locationX, locationEdgeX), WorldGen.genRand.Next(locationY, locationEdgeY));
                if (neg == -1)
                    spawnPos = new Point(WorldGen.genRand.Next(locationEdgeX, locationX), WorldGen.genRand.Next(locationY, locationEdgeY));
                if (spawnPos != new Point(0, 0))
                    SpawnPools(spawnPos);
            }
            if (locationX < locationEdgeX)
            {
                for (int i = locationX; i < locationEdgeX; ++i)
                {
                    for (int k = locationY; k < locationEdgeY; ++k)
                    {
                        if (Main.tile[i, k].type == TileID.Mud)
                        {
                            if (!Main.tile[i, k - 1].active() || !Main.tile[i, k + 1].active() || !Main.tile[i + 1, k].active() || !Main.tile[i - 1, k].active())
                            {
                                Main.tile[i, k].type = (ushort)mod.TileType("SwampGrass");
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = locationEdgeX; i < locationX; ++i)
                {
                    for (int k = locationY; k < locationEdgeY; ++k)
                    {
                        if (Main.tile[i, k].type == TileID.Mud)
                        {
                            if (!Main.tile[i, k - 1].active() || !Main.tile[i, k + 1].active() || !Main.tile[i + 1, k].active() || !Main.tile[i - 1, k].active())
                            {
                                Main.tile[i, k].type = (ushort)mod.TileType("SwampGrass");
                            }
                        }
                    }
                }
            }
            int differenceX = locationEdgeX - locationX;
            int differenceY = locationEdgeY - locationY;
            Point middle = new Point(locationX + (differenceX / 2), locationY + (differenceY / 2));
            for (int i = -80; i < 80; ++i)
            {
                for (int k = -20; k < 10; ++k)
                {
                    WorldGen.KillTile(middle.X + i, middle.Y - k);
                    if (k < 1)
                        Main.tile[middle.X + i, middle.Y + k].liquid = 150;
                }
            }
            GenerateShip(middle);
        }

        public void GenerateShip(Point middle)
        {
            int startY = middle.Y - 10;
            int worldSize = CheckWorldSize();
            for (int i = -10 * worldSize; i < 10 * worldSize; ++i)
            {
                WorldGen.PlaceTile(middle.X + i, startY, (ushort)mod.TileType("SwampWood_Placed"));
                WorldGen.PlaceTile(middle.X + i, startY + 1, (ushort)mod.TileType("SwampWood_Placed"));
                for (int k = 0; k > -5; --k)
                    WorldGen.KillTile(middle.X + i, startY - 1 + k);
                if (i < 5 * worldSize)
                {
                    startY++;
                }
            }
        }

        public void SpawnPools(Point location)
        {
            int size = WorldGen.genRand.Next(38, 79);
            for (int i = 0; i < size; ++i)
            {
                for (int k = 0; k < size; k++)
                {
                    if (Vector2.Distance(new Vector2(i, k), location.ToVector2()) < size)
                    {
                        WorldGen.KillTile(i, k);
                        Main.tile[i, k].liquid = 150;
                        Main.tile[i, k].lava(false);
                    }
                }
            }
        }

        public void CheckReplaceTypes(int x, int y, int repeatY, int typeToReplace, int replaceType, int steps, int strength)
        {
            for (int k = 0; k < repeatY; ++k)
            {
                y++;
                for (int i = x - strength - Main.rand.Next(steps); i < x + strength; ++i)
                {
                    if (Main.tile[i, y].type == typeToReplace)
                    {
                        Main.tile[i, y].type = (ushort)replaceType;
                    }
                }
            }
        }

        public int RaycastDownType(int x, int y)
        {
            if (!Main.tile[x, y].active())
            {
                y++;
            }
            else
            {
                return Main.tile[x, y].type;
            }
            return Main.tile[x, y].type;
        }

        public int RaycastDown(int x, int y)
        {
            while (!Main.tile[x, y].active())
            {
                y++;
            }
            return y;
        }

        public void House(int X, int Y, int type = 30, int? paintings = 3, bool noRope = false, int randWall = 1, bool cobwebs = false)
        {
            int[] types;
            int wallID = 4;
            if (GetWoodSet(type, out types, out wallID))
            {
                //Clear area
                for (int i = X; i < X + 20; ++i)
                {
                    for (int j = Y - 1; j < Y + 10; ++j)
                    {
                        WorldGen.KillTile(i, j);
                    }
                }
                //Wall Placement
                for (int i = X + 1; i < X + 18; ++i)
                {
                    for (int j = Y + 1; j < Y + 9; ++j)
                    {
                        //5 = WallID
                        if (Main.rand.Next(randWall) == 0)
                        {
                            WorldGen.KillWall(i, j);
                            WorldGen.PlaceWall(i, j, wallID);
                        }
                    }
                }
                int chairType = 15;
                int tableType = 14;
                int workBenchType = 18;
                int doorType = 10;
                if (type == mod.TileType("SwampWood_Placed"))
                {
                    //chairType = mod.TileType("SwampChair");
                    tableType = mod.TileType("SwampTable");
                    doorType = mod.TileType("SwampDoorClosed");
                }
                //Side placements
                for (int i = Y; i < Y + 10; ++i)
                {
                    WorldGen.PlaceTile(X, i, type);
                    WorldGen.PlaceTile(X + 18, i, type);
                }
                //Roof-floor placements
                for (int i = X; i < X + 18; ++i)
                {
                    WorldGen.PlaceTile(i, Y, type);
                    WorldGen.PlaceTile(i, Y + 9, type);
                }
                //Chair placement
                WorldGen.PlaceObject(X + 8, Y + 8, chairType, true, types[3]);
                //Workbench-Table placement
                WorldGen.PlaceObject(X + 6, Y + 8, tableType, true, types[2]);
                WorldGen.PlaceObject(X + 12, Y + 8, workBenchType, true, types[5]);
                //Bottle placement
                WorldGen.PlaceObject(X + 12, Y + 7, 13, true, 0);
                //Torch placement
                WorldGen.PlaceObject(X + 1, Y + 3, 4, true, types[6]);
                WorldGen.PlaceObject(X + 17, Y + 3, 4, true, types[6]);
                //Door placements
                for (int i = Y + 8; i > Y + 5; --i)
                {
                    WorldGen.KillTile(X, i);
                }
                WorldGen.PlaceObject(X, Y + 8, doorType, true, types[0]);
                //Painting placements
                if (paintings != null)
                {
                    WorldGen.PlaceObject(X + 13, Y + 3, 246, true, (int)paintings);
                    WorldGen.PlaceObject(X + 5, Y + 3, 246, true, (int)paintings);
                }
                //Placing supports & rope
                int yChange = 10;
                while (!Main.tile[X, Y + yChange].active())
                {
                    WorldGen.PlaceTile(X, Y + yChange, 124);
                    yChange++;
                }
                yChange = 10;
                while (!Main.tile[X + 18, Y + yChange].active())
                {
                    WorldGen.PlaceTile(X + 18, Y + yChange, 124);
                    yChange++;
                }
                if (!noRope)
                {
                    yChange = 10;
                    while (!Main.tile[X - 1, Y + yChange].active())
                    {
                        WorldGen.PlaceTile(X - 1, Y + yChange, 213);
                        yChange++;
                    }
                }
                if (cobwebs)
                {
                    WorldGen.PlaceTile(X + 1, Y + 1, 51);
                    WorldGen.PlaceTile(X + 2, Y + 1, 51);
                    WorldGen.PlaceTile(X + 1, Y + 2, 51);
                }
            }
        }

        /// <summary>Returns int[] { DoorClosedStyle, DoorOpenStyle, TableStyle, ChairStyle, WorkbenchStyle, TorchStyle }; wallID is by WallID also.</summary>
        public bool GetWoodSet(int woodType, out int[] styles, out int wallID)
        {
            switch (woodType)
            {
                case TileID.WoodBlock:
                    styles = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    wallID = 4;
                    return true;
                case TileID.BorealWood:
                    styles = new int[] { 30, 31, 28, 30, 23, 23, 9};
                    wallID = 149;
                    return true;
                case TileID.PalmWood:
                    styles = new int[] { 29, 29, 26, 23, 23, 22, 0 };
                    wallID = 151;
                    return true;
                default:
                    if (woodType == mod.TileType("SwampWood_Placed"))
                    {
                        styles = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                        wallID = mod.WallType("SwampWood_Wall");
                        return true;
                    }
                    styles = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    wallID = 1;
                    return false;
            }
        }
    }
}