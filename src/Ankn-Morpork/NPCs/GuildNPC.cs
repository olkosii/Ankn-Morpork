using System;

namespace Ankn_Morpork.NPCs
{
    public class GuildNPC
    {
        public virtual decimal PlayerRewardForNPC { get; set; }

        public GuildNPC CreateNpc(int randomNpcNumber)
        {
            if (randomNpcNumber > 0 && randomNpcNumber < 5)
            {
                switch (randomNpcNumber)
                {
                    case 1:
                        return new Thief();
                    case 2:
                        return new Clown();
                    case 3:
                        return new Assasin();
                    case 4:
                        return new Beggar();
                }
            }

            return null;
        }

        public virtual void PlayerMeetGuildNPC(Player player, GuildNPC npc, decimal Reward) { }
    }
}
