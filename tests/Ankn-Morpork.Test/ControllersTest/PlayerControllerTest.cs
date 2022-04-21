using Ankn_Morpork.Controllers;
using Ankn_Morpork.NPCs;
using NUnit.Framework;

namespace Ankn_Morpork.Test.ControllersTest
{
    [TestFixture]
    internal class PlayerControllerTest
    {
        private Player _player;
        private GuildNPC _guildNPC;
        private bool _playerAction;
        private PlayerController _playerController;

        [SetUp]
        public void SetUp()
        {
            _player = new Player();
            _playerController = new PlayerController();
            _playerAction = false;
        }

        [Test]
        public void PlayWithNPC_PlayerActionIsFalseNpcIsClown_PlayerStayAlive()
        {
            _guildNPC = new Clown();

            _playerController.PlayWithNPC(_player, _guildNPC, _playerAction);

            Assert.That(_player.isAlive == true);
        }

        [Test]
        public void PlayWithNPC_PlayerActionIsFalseNpcIsThiefWhoCanNotStealMoney_PlayerStayAlive()
        {
            _guildNPC = new Thief();
            //acceptableAmountOfThefts by default = 6
            Thief.currentAmountOfThief = 7;

            _playerController.PlayWithNPC(_player, _guildNPC, _playerAction);

            Assert.That(_player.isAlive == true);
        }

        [Test]
        public void PlayWithNPC_PlayerActionIsFalseNpcIsThiefWhoCanStealMoney_PlayerDie()
        {
            _guildNPC = new Thief();
            Thief.currentAmountOfThief = 0;

            _playerController.PlayWithNPC(_player, _guildNPC, _playerAction);

            Assert.That(_player.isAlive == false);
        }

        [Test]
        public void PlayWithNPC_PlayerActionIsFalseNpcIsBeggarWhoDoNotTakeMoney_PlayerStayAlive()
        {
            _guildNPC = new Beggar() { name = BeggarType.Drinker };

            _playerController.PlayWithNPC(_player, _guildNPC, _playerAction);

            Assert.That(_player.isAlive == true);
        }

        [Test]
        public void PlayWithNPC_PlayerActionIsFalseNpcIsBeggarWhoTakeMoney_PlayerDie()
        {
            //All beggars but Drinker can take money
            _guildNPC = new Beggar() { name = BeggarType.Jimmy };

            _playerController.PlayWithNPC(_player, _guildNPC, _playerAction);

            Assert.That(_player.isAlive == false);
        }

        [Test]
        public void PlayWithNPC_PlayerActionIsFalseNpcIsAssasin_PlayerDie()
        {
            _guildNPC = new Assasin();

            _playerController.PlayWithNPC(_player, _guildNPC, _playerAction);

            Assert.That(_player.isAlive == false);
        }
    }
}
