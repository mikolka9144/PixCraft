using Engine;
using Engine.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineTets.Logic
{
    class PlayerStatusTest
    {
        private TestStatusDisplayer Displayer;
        private PlayerStatus Instance;

        [SetUp]
        public void Setup()
        {
            Displayer = new TestStatusDisplayer();
            Instance = new PlayerStatus(Displayer);
        }

        [Test]
        public void CheckBlocks()
        {
            Instance.AddElement(new Item(3, BlockType.DiamondOre));
            Instance.AddElement(new Item(3, BlockType.stick));
            Instance.AddElement(new Item(3, BlockType.Grass));

            Displayer.SelectedIndex = 0;
            var first = Instance.GetBlockToPlace();
            Displayer.SelectedIndex = 1;
            var secound = Instance.GetBlockToPlace();
            Displayer.SelectedIndex = 2;
            var third = Instance.GetBlockToPlace();

            Assert.AreEqual(BlockType.DiamondOre, first);
            Assert.AreEqual(BlockType.None, secound);
            Assert.AreEqual(BlockType.Grass, third);
        }
    }

    internal class TestStatusDisplayer : IStatusDisplayer
    {
        public int SelectedIndex { get; set ; }

        public void Present(int life, List<Item> currentItems)
        {
        }
    }
}
