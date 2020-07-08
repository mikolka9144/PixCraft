using Engine.Engine;
using Engine.Engine.models;
using Engine.Resources;
using NUnit.Framework;

namespace EngineTets.Engine
{
    internal class OreTableTests
    {
        private OreTable OreTable;

        [SetUp]
        public void Setup()
        {
            OreTable = new OreTable(new[] { new OreEntry(5, 10, 34, BlockType.None) });
        }

        [Test]
        public void GetOreData_Count()
        {
            var dataToCheck = OreTable.GetCount(BlockType.None);
            Assert.AreEqual(34, dataToCheck);
        }

        [Test]
        public void GetOreData_Chance()
        {
            var dataToCheck = OreTable.GetChance(BlockType.None);
            Assert.AreEqual(10, dataToCheck);
        }

        [Test]
        public void GetOreData_MinimumDepth()
        {
            var dataToCheck = OreTable.GetMinimumDepth(BlockType.None);
            Assert.AreEqual(5, dataToCheck);
        }
    }
}