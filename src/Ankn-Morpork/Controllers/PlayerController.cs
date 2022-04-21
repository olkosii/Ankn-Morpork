using Ankn_Morpork.NPCs;
using System;

namespace Ankn_Morpork.Controllers
{
    public class PlayerController
    {
        public void PlayWithNPC(Player player, GuildNPC npc, bool playerAction)
        {
            if (playerAction == true)
            {
                if (npc is Assasin assasin)
                    npc.PlayerRewardForNPC = assasin.CheckPlayerReward();

                npc.PlayerMeetGuildNPC(player, npc, npc.PlayerRewardForNPC);

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"\t\tYour money : {player.moneyQuantity}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (npc is Clown ||
                   (npc is Beggar beggar && beggar.name == BeggarType.Drinker) ||
                   (npc is Thief thief && thief.CheckIfThiefCanStealPlayerMoney() == false))
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;

                    Console.WriteLine($"\t\tYour money : {player.moneyQuantity}\n");

                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                player.isAlive = false;
            }

        }
    }
}
