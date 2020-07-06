using Engine;
using Engine.Logic;
using Engine.Saves;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineTets.Logic
{
    class CraftingTests
    {
        private PlayerStatus Inventory;
        private List<CraftingEntry> CraftingEntries;
        private CraftingModule Instance;

        [SetUp]
        public void Setup()
        {
            Inventory = new PlayerStatus(null);
            CraftingEntries = new List<CraftingEntry>();
            Instance = new CraftingModule(CraftingEntries);
        }

        [Test]
        public void tryCraftItem_neededItemIn1Slot()
        {
            CraftingEntries.Add(new CraftingEntry(new[] { new Item(3, BlockType.Dirt) }, new Item(1, BlockType.DiamondOre)));
            Inventory.Inventory.Add(new Item(3, BlockType.Dirt));

            var flag = Instance.Craft(Inventory,BlockType.DiamondOre);

            Assert.IsTrue(flag);
            Assert.IsTrue(Inventory.Inventory.Find(s=>s.type == BlockType.DiamondOre).Count == 1);
            Assert.IsNull(Inventory.Inventory.FirstOrDefault(s => s.type == BlockType.Dirt));
        }
        [Test]
        public void tryCraftItem_neededItemIn1Slot2()
        {
            CraftingEntries.Add(new CraftingEntry(new[] { new Item(3, BlockType.Dirt) }, new Item(1, BlockType.DiamondOre)));
            Inventory.Inventory.Add(new Item(4, BlockType.Dirt));

            var flag = Instance.Craft(Inventory, BlockType.DiamondOre);

            Assert.IsTrue(flag);
            Assert.IsTrue(Inventory.Inventory.Find(s => s.type == BlockType.DiamondOre).Count == 1);
            Assert.IsNotNull(Inventory.Inventory.First(s => s.type == BlockType.Dirt));
        }
        [Test]
        public void tryCraftItem_neededItemInManySlots()
        {
            CraftingEntries.Add(new CraftingEntry(new[] { new Item(3, BlockType.Dirt) }, new Item(1, BlockType.DiamondOre)));
            Inventory.Inventory.Add(new Item(2, BlockType.Dirt));
            Inventory.Inventory.Add(new Item(2, BlockType.Dirt));

            var flag = Instance.Craft(Inventory, BlockType.DiamondOre);

            Assert.IsTrue(flag);
            Assert.IsTrue(Inventory.Inventory.Find(s => s.type == BlockType.DiamondOre).Count == 1);
            Assert.IsTrue(Inventory.Inventory.Find(s => s.type == BlockType.Dirt).Count == 1);
        }
        [Test]
        public void tryCraftItem_WithNotNeededItems()
        {
            CraftingEntries.Add(new CraftingEntry(new[] { new Item(3, BlockType.Dirt) }, new Item(1, BlockType.DiamondOre)));
            Inventory.Inventory.Add(new Item(2, BlockType.Dirt));

            var flag = Instance.Craft(Inventory, BlockType.DiamondOre);

            Assert.IsFalse(flag);
            Assert.IsNull(Inventory.Inventory.Find(s => s.type == BlockType.DiamondOre));
            Assert.IsTrue(Inventory.Inventory.Find(s => s.type == BlockType.Dirt).Count == 2);

        }
        [Test]
        public void tryCraftItem_NonStackAbleItem()
        {
            var craftedItem = new Item(2, BlockType.CoalOre);
            craftedItem.CanStack = false;
            CraftingEntries.Add(new CraftingEntry(new[] { new Item(3, BlockType.Dirt) }, craftedItem));
            Inventory.Inventory.Add(new Item(3, BlockType.Dirt));

            var flag = Instance.Craft(Inventory, BlockType.CoalOre);

            Assert.IsTrue(flag);
            Assert.IsTrue(Inventory.Inventory.Count == 2);
        }
    }
}
