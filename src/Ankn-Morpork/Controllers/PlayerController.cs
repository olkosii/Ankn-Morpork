using Ankn_Morpork.NPCs;
using Ankn_Morpork.NPCsInterface;
using System;

namespace Ankn_Morpork.Controllers
{
    public class PlayerController
    {
        public bool PlayerAction()
        {
            Console.Write("\n\tEnter 1 - to continue\n\tEnter 2 - to skip\n\nYour choice : ");

            int inputNumber;
            bool input = int.TryParse(Console.ReadLine(), out inputNumber);

            while (inputNumber != 1 || inputNumber != 2)
            {
                if (inputNumber == 1 || inputNumber == 2)
                    break;

                Console.Write("\nPlease enter correct number...\n\tEnter 1 - to continue\n\tEnter 2 - to skip\n\nYour choice : ");
                input = int.TryParse(Console.ReadLine(), out inputNumber);
            }

            if (inputNumber == 1)
                return true;
            else
                return false;
        }

        private decimal CheckPlayerRewardForAssasin()
        {
            Console.Write("Write your reward for Assasin : ");

            decimal proposedReward;
            bool input = decimal.TryParse(Console.ReadLine(), out proposedReward);

            while (input == false)
            {
                Console.WriteLine("\nPlease write only numbers...");
                Console.Write("Write your reward for Assasin : ");
                input = decimal.TryParse(Console.ReadLine(), out proposedReward);
            }

            return proposedReward;
        }

        public void PlayWithNPC(IPlayer player, IGuildNPC npc, bool playerAction)
        {
            if (playerAction == true)
            {
                if (npc is Assasin)
                    npc.PlayerRewardForNPC = CheckPlayerRewardForAssasin();

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
