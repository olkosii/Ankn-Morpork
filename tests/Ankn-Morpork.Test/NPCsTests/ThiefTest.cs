using Ankn_Morpork.NPCs;
using Ankn_Morpork.NPCsInterface;
using NUnit.Framework;

namespace Ankn_Morpork.Test.NPCsTests
{
    [TestFixture]
    public class ThiefTest
    {
        private IGuildNPC _thiefNPC;
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player();
            _thiefNPC = new Thief();
            Thief.currentAmountOfThief = 0;
        }

        [Test]
        public void PlayerMeetGuildNPC_PlayerHasEnoughMoneyForThiefReward_PlayerIsAliveTakeMoneyFromPlayer()
        {
            var playerMoneyQuantityBeforeCallingMethod = _player.moneyQuantity;

            _thiefNPC.PlayerMeetGuildNPC(_player, _thiefNPC, _thiefNPC.PlayerRewardForNPC);

            Assert.That(_player.moneyQuantity, Is.EqualTo(playerMoneyQuantityBeforeCallingMethod - _thiefNPC.PlayerRewardForNPC));
            Assert.That(_player.isAlive == true);
        }

        [Test]
        public void PlayerMeetGuildNPC_PlayerDoNotHaveEnoughMoneyForThiefReward_PlayerDiedPlayerMoneyEquelToZero()
        {
            _player.moneyQuantity = 0;

            _thiefNPC.PlayerMeetGuildNPC(_player, _thiefNPC, _thiefNPC.PlayerRewardForNPC);

            Assert.That(_player.moneyQuantity == 0 && _player.isAlive == false);
        }

        [Test]
        public void CheckIfThiefCanStealPlayerMoney_CurrentAmountOfThiefLessThanAcceptableAmountOfThefts_ReturnTrue()
        {

            Thief thief = (Thief)_thiefNPC;

            var result = thief.CheckIfThiefCanStealPlayerMoney();

            Assert.That(result, Is.True);
        }

        [Test]
        public void CheckIfThiefCanStealPlayerMoney_CurrentAmountOfThiefMoreThanAcceptableAmountOfThefts_ReturnFalse()
        {
            Thief thief = (Thief)_thiefNPC;
            Thief.currentAmountOfThief = 7;

            var result = thief.CheckIfThiefCanStealPlayerMoney();

            Assert.That(result, Is.False);
        }
    }
}
