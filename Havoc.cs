using System;

using System.IO;

using Terraria;

using Terraria.Graphics.Effects;

using Terraria.Graphics.Shaders;

using Terraria.ID;

using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Havoc.Skies;

using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.UI;

using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Havoc

{

	class Havoc : Mod


		{

			public Havoc()

			{	
				Properties = new ModProperties()

				{	
	
					Autoload = true,
					AutoloadGores = true,

					AutoloadSounds = true,

					AutoloadBackgrounds = true

				};
			}

		

			public override void UpdateMusic(ref int music)

			{
			if (Main.myPlayer != -1 && !Main.gameMenu)

				{
                for (int i = 0; i < 201; i++)

                			{
                    if (Main.player[Main.myPlayer].active && HavocPlayer.ZoneSwamp && !Main.npc[i].boss) //Main.player[Main.myPlayer].GetModPlayer<HavocPlayer>(this).ZoneSwamp) 
                    
						{
		
                        		music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Swamp");

                    				}

                			}

            			}

			}	

		

			public override void Load()

			{

				if (!Main.dedServ)

				{

					AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Swamp"), ItemType("SwampMusicBox"), TileType("SwampMusicBox"));

                			//GetSoundSlot(SoundType.Music, "Sounds/Music/DriveMusic"), ItemType("ExampleMusicBox"), TileType("ExampleMusicBox")
			                //GetSoundSlot(SoundType.Music, "Sounds/Music/Swamp"), ItemType("SwampMusicBox"), TileType("SwampMusicBox")
			
                Filters.Scene["Havoc:ZoneSwamp"] = new Filter(new SwampSkyShaderData("SwampSky").UseColor(0.5f, 0.5f, 0.5f).UseOpacity(0.7f), EffectPriority.VeryHigh);

                			SkyManager.Instance["Havoc:ZoneSwamp"] = new SwampSky();

            			}

			}

		
	
			public static bool NoInvasion(NPCSpawnInfo spawnInfo)

        		{
            
				return !spawnInfo.invasion && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime);

        	}

	}

}

