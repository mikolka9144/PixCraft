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
        private Parameters parameters;
        private Elements ActiveElements;
        private PlayerStatus playerStatus;
        private MovableObject Instance;

        [SetUp]
        public void Setup()
        {
            parameters = new Parameters();
            ActiveElements = new Elements();
            playerStatus = new PlayerStatus(null,parameters);
            Instance = new MovableObject(ActiveElements, null, null,playerStatus,new TestSound(),parameters);

            Instance.IsVisible = true;

            var fluid = new Fluid(0, -1, BlockType.Water, null, new BlockIdProcessor());
            fluid.IsVisible = true;

            ActiveElements.SetActiveFluids(new List<Fluid>(1));
            ActiveElements.GetActiveFluids(new Vector2(0,0)).Add(fluid);
            
        }

        [Test]
        public void DrowningTest()
        {
            Assert.AreEqual(parameters.MaxBreath, playerStatus.breath);
            for (int i = 0; i < 20; i++)
            {

                Instance.CheckIfUnderwater();
            }
            Assert.AreEqual(parameters.MaxBreath-1, playerStatus.breath);
        }
    }
    class Elements : IActiveElements
    {
        public List<Block> VisiableBlocks { get; set; } = new List<Block>();
        public List<Fluid> Fluids { get; private set; }

        public List<Block> GetActiveBlocks(Vector2 sprite) => VisiableBlocks;

        public List<Fluid> GetActiveFluids(Vector2 sprite)
        {
            return Fluids;
        }

        public List<Block> GetActiveToppings(Vector2 sprite)
        {
            throw new System.NotImplementedException();
        }

        internal void SetActiveFluids(List<Fluid> lists)
        {
            Fluids = lists;
        }
    }
}
