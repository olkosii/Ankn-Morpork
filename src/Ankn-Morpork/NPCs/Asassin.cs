using Ankn_Morpork.NPCsInterface;
using System;

namespace Ankn_Morpork.NPCs
{
    public class Assasin : IGuildNPC
    {
        internal int MinReward { get; }
        internal int MaxReward { get; }
        public decimal PlayerRewardForNPC { get; set; }

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

        public void PlayerMeetGuildNPC(IPlayer player, IGuildNPC npc, decimal proposedReward)
        {
            Assasin assasin = (Assasin)npc;

            if (assasin.MinReward <= proposedReward && proposedReward <= assasin.MaxReward)
            {
                player.moneyQuantity -= proposedReward;
                if (player.moneyQuantity < 0)
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
