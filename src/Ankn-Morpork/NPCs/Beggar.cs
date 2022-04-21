using System;
using System.Collections.Generic;

namespace Ankn_Morpork.NPCs
{
    public class Beggar : GuildNPC
    {
        public BeggarType name;
        public override decimal PlayerRewardForNPC { get; set; }

        private static Dictionary<int, decimal> beggarsDictionary = SetBeggards();
        private static Dictionary<int, decimal> SetBeggards()
        {
            Dictionary<int, decimal> beggards = new Dictionary<int, decimal>(11);

            beggards.Add(1, 3);
            beggards.Add(2, 2);
            beggards.Add(3, 1);
            beggards.Add(4, 1);
            beggards.Add(5, 0.9m);
            beggards.Add(6, 0.8m);
            beggards.Add(7, 0.6m);
            beggards.Add(8, 0.5m);
            beggards.Add(9, 0.08m);
            beggards.Add(10, 0.02m);
            beggards.Add(11, 0);

            return beggards;
        }

        private BeggarType GetBeggarName()
        {
            Random rand = new Random();
            int beggarId = rand.Next(1, 12);

            BeggarType beggar = (BeggarType)beggarId;
            return beggar;
        }

        public Beggar()
        {
            name = GetBeggarName();
            PlayerRewardForNPC = beggarsDictionary[(int)name];
        }
        public override void PlayerMeetGuildNPC(Player player, GuildNPC npc, decimal reward)
        {
            Beggar beggar = (Beggar)npc;

            if (beggar.PlayerRewardForNPC < player.moneyQuantity)
                player.moneyQuantity -= reward;
            else
            {
                player.moneyQuantity = 0;
                player.isAlive = false;
            }

            if (player.moneyQuantity < 0)
                player.moneyQuantity = 0;
        }
    }
    public enum BeggarType
    {
        Twitcher = 1,
        Drooler,
        Dribbler,
        Mumbler,
        Mutterer,
        Shouter,
        Demander,
        Jimmy,
        HungryMan,
        TeaMan,
        Drinker
    }
}
