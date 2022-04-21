using Ankn_Morpork.NPCs;
using NUnit.Framework;

namespace Ankn_Morpork.Test
{
    public class AssasinTest
    {
        private GuildNPC _assasinNPC;
        private Player _player;
        [SetUp]
        public void Setup()
        {
            _player = new Player();
            _assasinNPC = new Assasin();
        }

        [Test]
        public void PlayerMeetGuildNPC_PlayerProposedRewardAreSuitableForAnAssassin_PlayerIsAliveAssasinTakeMoneyFromPlayer()
        {
            //Assasins always can get reward of 16$
            _assasinNPC.PlayerRewardForNPC = 16;
            decimal playerMoneyBeforeMeetingWithAssasin = _player.moneyQuantity;

            _assasinNPC.PlayerMeetGuildNPC(_player, _assasinNPC, _assasinNPC.PlayerRewardForNPC);

            Assert.That(_player.isAlive == true && _player.moneyQuantity == 
                playerMoneyBeforeMeetingWithAssasin - _assasinNPC.PlayerRewardForNPC);
        }

        [Test]
        public void PlayerMeetGuildNPC_PlayerProposedRewardAreNOTSuitableForAnAssassin_PlayerDiedPlayerMoneyEquelToZero()
        {
            _assasinNPC.PlayerRewardForNPC = 0;

            _assasinNPC.PlayerMeetGuildNPC(_player, _assasinNPC, _assasinNPC.PlayerRewardForNPC);

            Assert.That(_player.isAlive == false && _player.moneyQuantity == 0);
        }
    }
}