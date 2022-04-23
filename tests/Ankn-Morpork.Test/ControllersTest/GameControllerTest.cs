using Ankn_Morpork.Controllers;
using Ankn_Morpork.GameMessages;
using Ankn_Morpork.NPCs;
using Ankn_Morpork.NPCsInterface;
using NUnit.Framework;

namespace Ankn_Morpork.Test.ControllersTest
{
    [TestFixture]
    public class GameControllerTest
    {
        private GameController _contoller;
        private Player _player;
        private IGuildNPC _guildNPC;

        [SetUp]
        public void SetUp()
        {
            _player = new Player();
            _contoller = new GameController();
        }

        [Test]
        public void GameEnd_PlayerMoneyMoreThan200_ReturnWinLine()
        {
            _player.moneyQuantity = 201;

            var result = _contoller.GameEnd(_player, _guildNPC, true);

            Assert.That(result, Is.EqualTo(EndGameReason.winMessage));
        }

        [Test]
        public void GameEnd_PlayerProposedRewardAreNOTSuitableForAnAssassin_ReturnDeathReasonLine()
        {
            _guildNPC = new Assasin();

            _guildNPC.PlayerRewardForNPC = 0;

            var result = _contoller.GameEnd(_player, _guildNPC, true);

            Assert.That(result, Is.EqualTo(EndGameReason.notSuitablePlayerRewardMessage));
        }

        [Test]
        public void GameEnd_PlayerMoneyLessThanNpcReward_ReturnDeathReasonLine()
        {
            _guildNPC = new Thief();

            _player.moneyQuantity = 0;

            var result = _contoller.GameEnd(_player, _guildNPC, true);

            Assert.That(result, Is.EqualTo(EndGameReason.playerDidNotHaveEnoughMoneyForThiefMessage));
        }

        [Test]
        public void GameEnd_PlayerActionIsFalseNpcIsBeggar_ReturnDeathReasonLine()
        {
            _guildNPC = new Beggar();
            Beggar beggar = (Beggar)_guildNPC;

            var result = _contoller.GameEnd(_player, _guildNPC, false);

            Assert.That(result, Is.EqualTo(EndGameReason.beggarKillMessage));
        }

        [Test]
        public void GameEnd_PlayerActionIsFalseNpcIsAssasin_ReturnDeathReasonLine()
        {
            _guildNPC = new Assasin();

            var result = _contoller.GameEnd(_player, _guildNPC, false);

            Assert.That(result, Is.EqualTo(EndGameReason.assasinKillMessage));
        }

        [Test]
        public void GameEnd_PlayerActionIsFalseNpcIsThief_ReturnDeathReasonLine()
        {
            _guildNPC = new Thief();

            var result = _contoller.GameEnd(_player, _guildNPC, false);

            Assert.That(result, Is.EqualTo(EndGameReason.thiefKillMessage));
        }
    }
}
