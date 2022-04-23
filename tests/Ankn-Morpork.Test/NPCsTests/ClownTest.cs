using Ankn_Morpork.NPCs;
using Ankn_Morpork.NPCsInterface;
using NUnit.Framework;

namespace Ankn_Morpork.Test.NPCsTests
{
    [TestFixture]
    public class ClownTest
    {
        private IGuildNPC _clownNPC;
        private Player _player;
        [SetUp]
        public void Setup()
        {
            _player = new Player();
            _clownNPC = new Clown();
        }

        [Test]
        public void PlayerMeetGuildNPC_WhenCalled_GiveMoneyForPlayer()
        {
            var playerMoneyQuantityBeforeCallingMethod = _player.moneyQuantity;

            _clownNPC.PlayerMeetGuildNPC(_player, _clownNPC, _clownNPC.PlayerRewardForNPC);

            Assert.That(_player.moneyQuantity, Is.EqualTo(playerMoneyQuantityBeforeCallingMethod + _clownNPC.PlayerRewardForNPC));
        }
    }
}
