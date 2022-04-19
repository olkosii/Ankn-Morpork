using NUnit.Framework;

namespace Ankn_Morpork.Tests
{
    [TestFixture]
    internal class GuildNPCTest
    {
        [Test]
        public void GuildNPC_NpcNumberIsOne_ReturnNpcThief()
        {
            GuildNPC npc = new GuildNPC();

            var result = npc.CreateNpc(1);

            Assert.That(result.GetType(), Is.EqualTo(new Thief().GetType()));
        }

        [Test]
        public void GuildNPC_NpcNumberIsTwo_ReturnNpcClown()
        {
            GuildNPC npc = new GuildNPC();

            var result = npc.CreateNpc(2);

            Assert.That(result.GetType(), Is.EqualTo(new Clown().GetType()));
        }
        [Test]
        public void GuildNPC_NpcNumberIsThree_ReturnNpcAssasin()
        {
            GuildNPC npc = new GuildNPC();

            var result = npc.CreateNpc(3);

            Assert.That(result.GetType(), Is.EqualTo(new Assasin().GetType()));
        }
        [Test]
        public void GuildNPC_NpcNumberIsFour_ReturnNpcBeggar()
        {
            GuildNPC npc = new GuildNPC();

            var result = npc.CreateNpc(4);

            Assert.That(result.GetType(), Is.EqualTo(new Beggar().GetType()));
        }
        [Test]
        public void GuildNPC_NpcNumberIsFive_ReturnNull()
        {
            GuildNPC npc = new GuildNPC();

            var result = npc.CreateNpc(5);

            Assert.That(result, Is.EqualTo(null));
        }
    }
}
