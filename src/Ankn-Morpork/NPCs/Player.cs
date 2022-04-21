using System;

namespace Ankn_Morpork.NPCs
{
    public class Player
    {
        public decimal moneyQuantity { get; set; }
        public bool isAlive = true;
        public Player()
        {
            moneyQuantity = 100;
        }

        public bool Action(GuildNPC npc)
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
        public static string EndOfGameReasons(Player player, GuildNPC npc, bool action)
        {
            if (player.moneyQuantity > 200)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string reason = "\t\t\t\tCONGRATULATIONS!!!\n\t\tYou have earned enough money to leave Ankn Morpork";

                return reason;
            }
            else if (action == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                string reason = "";
                if (npc is Beggar beggar)
                    reason = $"YOU DIED...\n{beggar.name} chase you to death";
                else if (npc is Assasin)
                    reason = "YOU DIED...\nAssasin killed you";
                else if (npc is Thief)
                    reason = "YOU DIED...\nYou resisted and thief killed you";

                return reason;
            }
            else if (npc is Assasin assasin && action == true)
            {
                decimal currentPlayerRewardForAssasin = assasin.PlayerRewardForNPC;
                if (assasin.MinReward >= currentPlayerRewardForAssasin || currentPlayerRewardForAssasin >= assasin.MaxReward)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    string reason = "YOU DIED...\nThis Assassin wouldn't accept reward of that amount";

                    return reason;
                }
            }
            else if (player.moneyQuantity < npc.PlayerRewardForNPC)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string reason = $"YOU DIED...\n" +
                    $"You didn't have enough money in order to pay {npc.GetType().Name}";

                return reason;
            }


            Console.ForegroundColor = ConsoleColor.Red;
            return "YOU DIED...";
        }
    }
}
