using System;

namespace Ankn_Morpork
{
    public class Assasin : GuildNPC
    {
        internal int MinReward { get; }
        internal int MaxReward { get; }
        public override decimal PlayerRewardForNPC {get; set;}

        private bool IsBusy { get; } = true;

        public Assasin()
        {
            while (IsBusy == true)
            {
                IsBusy = GetBusy();
                MinReward = GetReward(5, 15);
                MaxReward = GetReward(16, 30);
            }
        }

        private int GetReward(int minValue, int maxValue)
        {
            Random rand = new Random();

            return rand.Next(minValue, maxValue);
        }

        private bool GetBusy()
        {
            Random rand = new Random();
            int busyResult = rand.Next(0, 2);
            if (busyResult == 1)
                return true;
            else
                return false;
        }

        internal decimal CheckPlayerReward()
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

        internal override void NPCPhrase()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You meet : Assasin guild, it means somebody in the city ordered your death\n" +
                "Can you pay more than your enemies?) (assasins don't tell their reward, you have to guess it)");
            Console.WriteLine("(If you pay more than your enemy you will stay alive,if you skip you will die)");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void PlayerMeetGuildNPC(Player player, GuildNPC npc, decimal proposedReward)
        {
            Assasin assasin = (Assasin)npc;

            if (assasin.MinReward <= proposedReward && proposedReward <= assasin.MaxReward)
            {
                player.moneyQuantity -= proposedReward;
                if(player.moneyQuantity < 0)
                    player.moneyQuantity = 0;
            }
            else
            {
                player.moneyQuantity = 0;
                player.isAlive = false;
            }
                
        }
    }
}
