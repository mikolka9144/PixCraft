using Engine;
using Engine.PixBlocks_Implementations;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace EngineTets.Sound
{
    public class SoundTests
    {
        private SoundTest SoundTable;
        private PixSound Instance;

        [SetUp]
        public void Setup()
        {
            SoundTable = new SoundTest();

            Instance = new PixSound(SoundTable);
        }

        [Test]
        public void test1()
        {
            Instance.PlaySound(SoundType.Break);
            Instance.PlaySound(SoundType.Break);
            Thread.Sleep(30);
            Instance.PlaySound(SoundType.Break);
            Thread.Sleep(30);
            Assert.AreEqual(2, SoundTable.playCount);
        }

        
    }

    internal class SoundTest : ISounds
    {
        public int playCount = 0;

        public Task GetSound(SoundType soundType)
        {
            return new Task(Play);
        }
        private void Play()
        {
            playCount++;
            Thread.Sleep(10);
        }
    }
}
