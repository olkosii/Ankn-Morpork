using System;

namespace Ankn_Morpork
{
    public class GameController
    {
        internal GuildNPC _currentNPC;
        public bool playerAction;
        private int GetRandomNPCNumber()
        {
            Random random = new Random();
            int randomNpcNumber = random.Next(1, 5);

            return randomNpcNumber;
        }
        private PlayerPlaysWithNPC _playerPlaysWithNPC = new PlayerPlaysWithNPC();
        public void GameStart(Player player)
        {
            GuildNPC guildNPC = new GuildNPC();
            while (player.isAlive == true &&  0 < player.moneyQuantity && player.moneyQuantity < 200)
            {
                var npc = guildNPC.CreateNpc(GetRandomNPCNumber());
                npc.NPCPhrase();

                playerAction = player.Action(npc);

                _currentNPC = npc;
                _playerPlaysWithNPC.PlayWithNPC(player, npc, playerAction);
            }
        }
    }
}
