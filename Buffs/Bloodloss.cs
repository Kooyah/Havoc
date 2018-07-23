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
	public class Bloodloss : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Blood loss");
			Description.SetDefault("Rapidly losing life");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<HavocPlayer>(mod).bloodloss = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<HavocGlobalNPC>(mod).bloodloss = true;
		}
	}
}