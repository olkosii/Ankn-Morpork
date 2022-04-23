using Ankn_Morpork.Builder;
using Ankn_Morpork.GameMessages;
using Ankn_Morpork.NPCs;
using Ankn_Morpork.NPCsInterface;
using System;

namespace Ankn_Morpork.Controllers
{
    public class GameController
    {
        public bool playerAction;
        internal IGuildNPC _currentNPC;
        private PlayerController _playerController = new PlayerController();

        private int GetRandomNPCNumber()
        {
            Random random = new Random();
            int randomNpcNumber = random.Next(1, 5);

            return randomNpcNumber;
        }

        public void GameStart(IPlayer player)
        {
            while (player.isAlive == true && 0 < player.moneyQuantity && player.moneyQuantity < 200)
            {
                var npc = NPCBuilder.CreateNpc(GetRandomNPCNumber());
                MeetNPCMessages.NPCPhrase(npc);

                playerAction = _playerController.PlayerAction();

                _currentNPC = npc;
                _playerController.PlayWithNPC(player, npc, playerAction);
            }
        }

        public string GameEnd(IPlayer player, IGuildNPC npc, bool action)
        {
            string reason = "";
            if (player.moneyQuantity > 200)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                reason = EndGameReason.winMessage;

                return reason;
            }
            else if (action == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                if (npc is Beggar)
                    reason = EndGameReason.beggarKillMessage;
                else if (npc is Assasin)
                    reason = EndGameReason.assasinKillMessage;
                else if (npc is Thief)
                    reason = EndGameReason.thiefKillMessage;

                return reason;
            }
            else if (npc is Assasin assasin && action == true)
            {
                decimal currentPlayerRewardForAssasin = assasin.PlayerRewardForNPC;
                if (assasin.MinReward >= currentPlayerRewardForAssasin || currentPlayerRewardForAssasin >= assasin.MaxReward)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    reason = EndGameReason.notSuitablePlayerRewardMessage;

                    return reason;
                }
            }
            else if (player.moneyQuantity < npc.PlayerRewardForNPC)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (npc is Assasin)
                    reason = EndGameReason.playerDidNotHaveEnoughMoneyForAssasinMessage;
                else if (npc is Thief)
                    reason = EndGameReason.playerDidNotHaveEnoughMoneyForThiefMessage;
                else if (npc is Beggar)
                    reason = EndGameReason.playerDidNotHaveEnoughMoneyForBeggarMessage;

                return reason;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            return EndGameReason.diedMessage;
        }
    }
}
