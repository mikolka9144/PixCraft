﻿using Engine.Logic;
using Engine.Resources;
using NUnit.Framework;
using System;

namespace EngineTets.Logic
{
    internal class PlayerStatusTest
    {
        private TestStatusDisplayer Displayer;
        private PlayerStatus Instance;

        [SetUp]
        public void Setup()
        {
            Displayer = new TestStatusDisplayer();
            Instance = new PlayerStatus(Displayer);
            Instance.OnDamageDeal += Instance_OnDamageDeal;
        }

        private void Instance_OnDamageDeal()
        {
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
        [Test]
        public void CheckDrowning()
        {
            Instance.breath = 1;
            Instance.DealBreathBuuble();
            Assert.AreEqual(Parameters.BaseHealth, Instance.health);
            Instance.DealBreathBuuble();
            Assert.AreEqual(Parameters.BaseHealth-1, Instance.health);
        }
    }

    internal class TestStatusDisplayer : IStatusDisplayer
    {
        public int SelectedIndex { get; set; }

        public void Present(int life, PlayerStatus currentItems)
        {
            throw new NotImplementedException();
        }
    }
}