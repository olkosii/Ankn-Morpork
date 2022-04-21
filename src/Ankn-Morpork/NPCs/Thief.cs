using System;

namespace Ankn_Morpork.NPCs
{
    public class Thief : GuildNPC
    {
        public static int currentAmountOfThief = 0;
        public int acceptableAmountOfThefts { get; } = 6;

        public override decimal PlayerRewardForNPC { get; set; }

        public Thief()
        {
            currentAmountOfThief++;
            PlayerRewardForNPC = 10;
        }

        public override void PlayerMeetGuildNPC(Player player, GuildNPC npc, decimal reward)
        {
            Thief thief = (Thief)npc;

            if (currentAmountOfThief <= acceptableAmountOfThefts)
                player.moneyQuantity -= reward;
            else if (thief.PlayerRewardForNPC > player.moneyQuantity)
            {
                player.moneyQuantity = 0;
                player.isAlive = false;
            }

            if (player.moneyQuantity < 0)
            {
                player.moneyQuantity = 0;
                player.isAlive = false;
            }
        }

        public bool CheckIfThiefCanStealPlayerMoney()
        {
            if (currentAmountOfThief <= acceptableAmountOfThefts)
                return true;
            else
                return false;
        }
    }
}
