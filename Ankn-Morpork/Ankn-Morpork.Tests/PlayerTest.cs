using NUnit.Framework;

namespace Ankn_Morpork.Tests
{
    [TestFixture]
    internal class PlayerTest
    {
        private Player _player;
        private GuildNPC _guildNPC;

        [SetUp]
        public void SetUp()
        {
            _player = new Player();
        }

        [Test]
        public void EndOfGameReasons_PlayerMoneyMoreThan200_ReturnWinLine()
        {
            _guildNPC = new GuildNPC();

            _player.moneyQuantity = 201;

            var result = Player.EndOfGameReasons(_player, _guildNPC, true);

            Assert.That(result, Is.EqualTo("\t\t\t\tCONGRATULATIONS!!!\n\t\t" +
                "You have earned enough money to leave Ankn Morpork"));
        }

        [Test]
        public void EndOfGameReasons_PlayerProposedRewardAreNOTSuitableForAnAssassin_ReturnDeathReasonLine()
        {
            _guildNPC = new Assasin();

            _guildNPC.PlayerRewardForNPC = 0;

            var result = Player.EndOfGameReasons(_player, _guildNPC, true);

            Assert.That(result, Is.EqualTo("YOU DIED...\nThis Assassin wouldn't accept reward of that amount"));
        }

        [Test]
        public void EndOfGameReasons_PlayerMoneyLessThanNpcReward_ReturnDeathReasonLine()
        {
            _guildNPC = new Thief();

            _player.moneyQuantity = 0;

            var result = Player.EndOfGameReasons(_player, _guildNPC, true);

            Assert.That(result, Is.EqualTo($"YOU DIED...\n" +
                $"You didn't have enough money in order to pay {_guildNPC.GetType().Name}"));
        }

        [Test]
        public void EndOfGameReasons_PlayerActionIsFalseNpcIsBeggar_ReturnDeathReasonLine()
        {
            _guildNPC = new Beggar();
            Beggar beggar = (Beggar)_guildNPC;

            var result = Player.EndOfGameReasons(_player, _guildNPC, false);

            Assert.That(result, Is.EqualTo($"YOU DIED...\n{beggar.name} chase you to death"));
        }

        [Test]
        public void EndOfGameReasons_PlayerActionIsFalseNpcIsAssasin_ReturnDeathReasonLine()
        {
            _guildNPC = new Assasin();

            var result = Player.EndOfGameReasons(_player, _guildNPC, false);

            Assert.That(result, Is.EqualTo("YOU DIED...\nAssasin killed you"));
        }

        [Test]
        public void EndOfGameReasons_PlayerActionIsFalseNpcIsThief_ReturnDeathReasonLine()
        {
            _guildNPC = new Thief();

            var result = Player.EndOfGameReasons(_player, _guildNPC, false);

            Assert.That(result, Is.EqualTo("YOU DIED...\nYou resisted and thief killed you"));
        }

    }
}
