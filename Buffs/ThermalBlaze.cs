using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Havoc.Buffs
{
	public class ThermalBlaze : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Thermal Blaze");
			Description.SetDefault("Incinerated by the burning air...");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<HavocPlayer>(mod).thermalblaze = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<HavocGlobalNPC>(mod).thermalblaze = true;
		}
	}
}