using Engine.Engine.models;
using Engine.Logic;
using Engine.Logic.models;
using Engine.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EngineTets.Logic
{
    class MovableObjectTests
    {
        private Elements ActiveElements;
        private PlayerStatus playerStatus;
        private MovableObject Instance;

        [SetUp]
        public void Setup()
        {
            ActiveElements = new Elements();
            playerStatus = new PlayerStatus(null);
            Instance = new MovableObject(ActiveElements, null, null,playerStatus,new TestSound());

            Instance.IsDestroyed = false;
            Instance.IsVisible = true;

            var fluid = new Fluid(0, -1, BlockType.Water, null, new BlockIdProcessor());
            fluid.IsDestroyed = false;
            fluid.IsVisible = true;

            ActiveElements.SetActiveFluids(new List<Fluid>(1));
            ActiveElements.GetActiveFluids(new Positon(0,0)).Add(fluid);
            
        }

        [Test]
        public void DrowningTest()
        {
            Assert.AreEqual(Parameters.MaxBreath, playerStatus.breath);
            for (int i = 0; i < 20; i++)
            {

                Instance.CheckIfUnderwater();
            }
            Assert.AreEqual(Parameters.MaxBreath-1, playerStatus.breath);
        }
    }
    class Elements : IActiveElements
    {
        public List<Block> VisiableBlocks => throw new System.NotImplementedException();

        public List<Block> GetActiveBlocks(Positon sprite)
        {
            throw new System.NotImplementedException();
        }

        public List<Fluid> GetActiveFluids(Positon sprite)
        {
            throw new System.NotImplementedException();
        }

        public List<Foliage> GetActiveToppings(Positon sprite)
        {
            throw new System.NotImplementedException();
        }

        internal void SetActiveFluids(List<Fluid> lists)
        {
            throw new NotImplementedException();
        }
    }
}
