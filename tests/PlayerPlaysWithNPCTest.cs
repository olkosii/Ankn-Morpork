using NUnit.Framework;

namespace Ankn_Morpork.Tests
{
    [TestFixture]
    internal class PlayerPlaysWithNPCTest
    {
        private Player _player;
        private GuildNPC _guildNPC;
        private bool _playerAction;
        private PlayerPlaysWithNPC _playerPlaysWithNPC;

        [SetUp]
        public void SetUp()
        {
            _player = new Player();
            _playerPlaysWithNPC = new PlayerPlaysWithNPC();
            _playerAction = false;
        }

        [Test]
        public void PlayWithNPC_PlayerActionIsFalseNpcIsClown_PlayerStayAlive()
        {
            _guildNPC = new Clown();

            _playerPlaysWithNPC.PlayWithNPC(_player, _guildNPC, _playerAction);

            Assert.That(_player.isAlive == true);
        }

        [Test]
        public void PlayWithNPC_PlayerActionIsFalseNpcIsThiefWhoCanNotStealMoney_PlayerStayAlive()
        {
            _guildNPC = new Thief();
            //acceptableAmountOfThefts by default = 6
            Thief.currentAmountOfThief = 7;

            _playerPlaysWithNPC.PlayWithNPC(_player, _guildNPC, _playerAction);

            Assert.That(_player.isAlive == true);
        }

        [Test]
        public void PlayWithNPC_PlayerActionIsFalseNpcIsThiefWhoCanStealMoney_PlayerDie()
        {
            _guildNPC = new Thief();
            Thief.currentAmountOfThief = 0;

            _playerPlaysWithNPC.PlayWithNPC(_player, _guildNPC, _playerAction);

            Assert.That(_player.isAlive == false);
        }

        [Test]
        public void PlayWithNPC_PlayerActionIsFalseNpcIsBeggarWhoDoNotTakeMoney_PlayerStayAlive()
        {
            _guildNPC = new Beggar() { name = BeggarType.Drinker};

            _playerPlaysWithNPC.PlayWithNPC(_player, _guildNPC, _playerAction);

            Assert.That(_player.isAlive == true);
        }

        [Test]
        public void PlayWithNPC_PlayerActionIsFalseNpcIsBeggarWhoTakeMoney_PlayerDie()
        {
            //All beggars but Drinker can take money
            _guildNPC = new Beggar() { name = BeggarType.Jimmy };

            _playerPlaysWithNPC.PlayWithNPC(_player, _guildNPC, _playerAction);

            Assert.That(_player.isAlive == false);
        }

        [Test]
        public void PlayWithNPC_PlayerActionIsFalseNpcIsAssasin_PlayerDie()
        {
            _guildNPC = new Assasin();

            _playerPlaysWithNPC.PlayWithNPC(_player, _guildNPC, _playerAction);

            Assert.That(_player.isAlive == false);
        }
    }
}
