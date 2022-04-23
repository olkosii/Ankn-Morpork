using NUnit.Framework;
using Ankn_Morpork.Builder;
using Ankn_Morpork.NPCs;

namespace Ankn_Morpork.Test.BuilderTests
{
    [TestFixture]
    public class NPCBuilderTest
    {
        [Test]
        public void CreateNpc_NpcNumberIsOne_ReturnNpcThief()
        {
            var result = NPCBuilder.CreateNpc(1);

            Assert.That(result.GetType(), Is.EqualTo(new Thief().GetType()));
        }

        [Test]
        public void CreateNpc_NpcNumberIsTwo_ReturnNpcClown()
        {
            var result = NPCBuilder.CreateNpc(2);

            Assert.That(result.GetType(), Is.EqualTo(new Clown().GetType()));
        }
        [Test]
        public void CreateNpc_NpcNumberIsThree_ReturnNpcAssasin()
        {
            var result = NPCBuilder.CreateNpc(3);

            Assert.That(result.GetType(), Is.EqualTo(new Assasin().GetType()));
        }
        [Test]
        public void CreateNpc_NpcNumberIsFour_ReturnNpcBeggar()
        {
            var result = NPCBuilder.CreateNpc(4);

            Assert.That(result.GetType(), Is.EqualTo(new Beggar().GetType()));
        }
        [Test]
        public void CreateNpc_NpcNumberIsFive_ReturnNull()
        {
            var result = NPCBuilder.CreateNpc(5);

            Assert.That(result, Is.EqualTo(null));
        }
    }
}
