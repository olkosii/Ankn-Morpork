using NUnit.Framework;

namespace Ankn_Morpork.Tests
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
            _assasinNPC.PlayerRewardForNPC = 10;

            _assasinNPC.PlayerMeetGuildNPC(_player,_assasinNPC,_assasinNPC.PlayerRewardForNPC);

            Assert.That(_player.isAlive == true && _player.moneyQuantity == 90);
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