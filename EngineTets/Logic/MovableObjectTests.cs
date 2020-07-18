using Engine.Engine.models;
using Engine.Logic;
using Engine.Resources;
using NUnit.Framework;
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
            Instance = new MovableObject(ActiveElements, null, null, null,playerStatus);

            Instance.IsDestroyed = false;
            Instance.IsVisible = true;

            var fluid = new Fluid(0, -1, BlockType.Water, null, new BlockIdProcessor());
            fluid.IsDestroyed = false;
            fluid.IsVisible = true;

            ActiveElements.ActiveFluids = new List<Fluid>(1);
            ActiveElements.ActiveFluids.Add(fluid);
            
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
        public List<Block> ActiveBlocks { get; set; }

        public List<Foliage> ActiveToppings { get; set; }

        public List<Fluid> ActiveFluids { get; set; }
    }
}
