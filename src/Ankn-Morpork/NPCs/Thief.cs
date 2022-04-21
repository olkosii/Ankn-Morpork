using System;

namespace Ankn_Morpork.NPCs
{
    public class Thief : GuildNPC
    {
        public static int currentAmountOfThief = 0;
        private int acceptableAmountOfThefts = 6;

        public override decimal PlayerRewardForNPC { get; set; }

        public Thief()
        {
            currentAmountOfThief++;
            PlayerRewardForNPC = 10;
        }

        internal override void NPCPhrase()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (acceptableAmountOfThefts < currentAmountOfThief)
            {
                Console.WriteLine("You meet : Thief guild, but thieves have exceeded the socially acceptable number of thefts : 6\n" +
                    "So if you skip, they won't take the money and you will stay alive");
                Console.ForegroundColor = ConsoleColor.White;

                return;
            }
            Console.WriteLine("You meet : Thief guild, be careful, If you resist, you might get hurt");
            Console.ForegroundColor = ConsoleColor.White;
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
