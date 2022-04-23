using System;

namespace Ankn_Morpork.NPCsInterface
{
    public interface IGuildNPC
    {
        decimal PlayerRewardForNPC { get; set; }
        void PlayerMeetGuildNPC(IPlayer player, IGuildNPC npc, decimal Reward);
    }
}
