using NUnit.Framework;

namespace Ankn_Morpork.Tests
{
    [TestFixture]
    public class BeggarTest
    {
        private GuildNPC _beggarNPC;
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player();
            _beggarNPC = new Beggar();
        }

        [Test]
        public void PlayerMeetGuildNPC_PlayerDoNotHaveEnoughMoneyForBeggarReward_PlayerDiedPlayerMoneyEquelToZero()
        {
            _player.moneyQuantity = 0;

            _beggarNPC.PlayerMeetGuildNPC(_player, _beggarNPC, _beggarNPC.PlayerRewardForNPC);

            Assert.That(_player.isAlive == false && _player.moneyQuantity == 0);
        }

        [Test]
        public void PlayerMeetGuildNPC_PlayerHasEnoughMoneyForBeggarReward_PlayerIsAliveBeggarTakePlayerMoney()
        {
            var expectedPlayerMoneyQuantity = _player.moneyQuantity - _beggarNPC.PlayerRewardForNPC;

            _beggarNPC.PlayerMeetGuildNPC(_player, _beggarNPC, _beggarNPC.PlayerRewardForNPC);

            Assert.That(_player.isAlive == true && _player.moneyQuantity == expectedPlayerMoneyQuantity);
        }
    }
}
